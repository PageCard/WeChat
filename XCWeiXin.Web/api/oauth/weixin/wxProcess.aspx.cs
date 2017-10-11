using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using XCWeiXin.API.OAuth;

namespace XCWeiXin.Web.api.oauth.weixin
{
    public partial class wxProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int wid =40;
                BLL.wx_userweixin wx = new BLL.wx_userweixin();
               Model.wx_userweixin wxModel = wx.GetModel(wid);       

                string url = Common.MyCommFun.getWebSite();
                string redirect_uri = url + "/api/oauth/weixin/index.aspx";
                string reurl = XCWeiXin.Common.MyCommFun.RequestParam("reurl");

                string appid = wxModel.AppId;




                WebClient client = new WebClient();
             //   client.Encoding = Encoding.UTF8;
            //    var address = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appid + "&redirect_uri=" + redirect_uri + "?reurl=" + reurl + "&response_type=code&scope=snsapi_base&state=1#wechat_redirect";
             //   string content = client.DownloadString(address);

           //     string aa="";
                //弹出授权页面(如在不弹出授权页面基础下未获得openid，弹出授权页面，提示用户授权)
                if (Request.QueryString["auth"] != null && Request.QueryString["auth"] != "" && Request.QueryString["auth"] == "1")
                {
                    Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appid + "&redirect_uri=" + redirect_uri + "?reurl=" + reurl + "&response_type=code&scope=snsapi_userinfo&state="+wid+"#wechat_redirect");
             
                
                }
                else
                {
                    //不弹出授权页面
                    Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appid + "&redirect_uri=" + redirect_uri + "?reurl=" + reurl + "&response_type=code&scope=snsapi_base&state="+wid+"#wechat_redirect");
                 
                }
            }

        }
    }
}