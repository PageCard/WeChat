﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.Sample.CommonService.OpenTicket;
using XCWeiXin.Common;

namespace XCWeiXin.Web.App_Code.Controllers
{

    public class OpenOAuthController : Controller
    {
      
     
        private static string ComponentAccessToken = null;//需要授权获取，腾讯服务器会主动推送
        private string component_AppId = Config.Component_Appid;
        private string component_Secret = Config.Component_Secret;
        private string component_Token = Config.Component_Token;
        private string component_EncodingAESKey = Config.Component_EncodingAESKey;



        #region 微信用户授权相关

        public ActionResult Index(string appId)
        {
            //此页面引导用户点击授权
            ViewData["UrlUserInfo"] = Senparc.Weixin.Open.OAuth.OAuthApi.GetAuthorizeUrl(appId, component_AppId, MyCommFun.getWebSite() + "/OpenOAuth/UserInfoCallback", "JeffreySu", new[] { Senparc.Weixin.Open.OAuthScope.snsapi_userinfo, Senparc.Weixin.Open.OAuthScope.snsapi_base });
            ViewData["UrlBase"] = Senparc.Weixin.Open.OAuth.OAuthApi.GetAuthorizeUrl(appId, component_AppId, MyCommFun.getWebSite() + "/OpenOAuth/BaseCallback", "JeffreySu", new[] { Senparc.Weixin.Open.OAuthScope.snsapi_userinfo, Senparc.Weixin.Open.OAuthScope.snsapi_base });
            return View();
        }

        /// <summary>
        /// OAuthScope.snsapi_userinfo方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public ActionResult UserInfoCallback(string code, string state, string appId)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != "JeffreySu")
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            Senparc.Weixin.Open.OAuth.OAuthAccessTokenResult result = null;

            //通过，用code换取access_token
            try
            {
                result = Senparc.Weixin.Open.OAuth.OAuthApi.GetAccessToken(appId, component_AppId, ComponentAccessToken, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != Senparc.Weixin.ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }
            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            Session["OAuthAccessToken"] = result;

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
            try
            {
                Senparc.Weixin.Open.OAuth.OAuthUserInfo userInfo = Senparc.Weixin.Open.OAuth.OAuthApi.GetUserInfo(result.access_token, result.openid);
                return View(userInfo);
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// OAuthScope.snsapi_base方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult BaseCallback(string code, string state, string appId)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != "JeffreySu")
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            //通过，用code换取access_token
            var result = Senparc.Weixin.Open.OAuth.OAuthApi.GetAccessToken(appId, component_AppId, ComponentAccessToken, code);
            if (result.errcode != Senparc.Weixin.ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            Session["OAuthAccessToken"] = result;

            //因为这里还不确定用户是否关注本微信，所以只能试探性地获取一下
            Senparc.Weixin.Open.OAuth.OAuthUserInfo userInfo = null;
            try
            {
                //已关注，可以得到详细信息
                userInfo = Senparc.Weixin.Open.OAuth.OAuthApi.GetUserInfo(result.access_token, result.openid);
                ViewData["ByBase"] = true;
                return View("UserInfoCallback", userInfo);
            }
            catch (ErrorJsonResultException ex)
            {
                //未关注，只能授权，无法得到详细信息
                //这里的 ex.JsonResult 可能为："{\"errcode\":40003,\"errmsg\":\"invalid openid\"}"
                return Content("用户已授权，授权Token：" + result);
            }
        }

        #endregion

        /// <summary>
        /// OAuthScope.snsapi_userinfo方式回调
        /// </summary>
        /// <param name="auth_code"></param>
        /// <param name="expires_in"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public ActionResult OpenOAuthCallback(string auth_code, int expires_in, string appId)
        {
            try
            {
                string openTicket =OpenController.GetOpenTicket(component_AppId);

                var component_access_token = Senparc.Weixin.Open.CommonAPIs.CommonApi.GetComponentAccessToken(component_AppId, component_Secret, openTicket).component_access_token;
                ComponentAccessToken = component_access_token;
                var oauthResult = Senparc.Weixin.Open.ComponentAPIs.ComponentApi.QueryAuth(component_access_token, component_AppId, auth_code);

                //TODO:储存oauthResult.authorization_info
                var authInfoResult = Senparc.Weixin.Open.ComponentAPIs.ComponentApi.GetAuthorizerInfo(component_access_token, component_AppId,
                     oauthResult.authorization_info.authorizer_appid);

                ViewData["QueryAuthInfo"] = oauthResult.authorization_info;
                ViewData["AuthorizerInfoResult"] = authInfoResult;


                return View();
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
        }


        /// <summary>
        /// 公众号授权页入口
        /// </summary>
        /// <returns></returns>
        public ActionResult JumpToMpOAuth()
        {
            return View();
        }

    }
}

