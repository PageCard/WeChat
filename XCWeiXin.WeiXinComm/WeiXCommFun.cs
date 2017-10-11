using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using XCWeiXin.Common;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP;
using System.Diagnostics;
using XCWeiXin.BLL;
using XCWeiXin.DAL;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Text;
using System.Xml;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.CustomService;
using Senparc.Weixin.MP.AdvancedAPIs;
namespace XCWeiXin.WeiXinComm
{
    public partial class WeiXCommFun
    {
        #region 请求为“文字的”



        /// <summary>
        /// 推送纯文字————跳到客服
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt_kefu(RequestMessageText requestMessage, int Indexid, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageTransfer_Customer_Service>(requestMessage);
            string openid = requestMessage.FromUserName;

            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            //    requestMessage.Content = "欢迎咨询";
            string xml = " <xml><ToUserName><![CDATA[" + responseMessage.FromUserName + "]]></ToUserName> <FromUserName><![CDATA[" + responseMessage.ToUserName + "]]></FromUserName> <CreateTime>" + responseMessage.CreateTime + "</CreateTime> <MsgType><![CDATA[" + responseMessage.MsgType + "]]></MsgType> <TransInfo> <KfAccount><![CDATA[kf2001@anju0088]]></KfAccount></TransInfo></xml>";
            //     ResponseMessageBase.CreateFromResponseXml(xml);
            var result = UserApi.Info(stoce(), openid);
            string pickname = result.nickname;
            string image = result.headimgurl;

            // string xml = " <xml><ToUserName><![CDATA[" + responseMessage.FromUserName + "]]></ToUserName> <FromUserName><![CDATA[" + responseMessage.ToUserName + "]]></FromUserName> <CreateTime>" + responseMessage.CreateTime + "</CreateTime> <MsgType><![CDATA["+responseMessage.MsgType+"]]></MsgType> <TransInfo> <KfAccount><![CDATA[VIP_zql_99@anju0088]]></KfAccount></TransInfo></xml>";
            //ResponseMessageTransfer_Customer_Service.CreateFromResponseXml(xml);
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "Transfer_Customer_Service", responseMessage.MsgType.ToString(), requestMessage.ToUserName, pickname, image);
            //responseMessage.Content ="openid=" + requestMessage.FromUserName;
            CustomerServiceAccount ss = new CustomerServiceAccount();
            ss.KfAccount = "kf2001@anju0088";
            List<CustomerServiceAccount> listss = new List<CustomerServiceAccount>();
            listss.Add(ss);
            responseMessage.TransInfo = listss;
            return responseMessage;
        }

        public IResponseMessageBase GetResponseMessageTxt_kefu2(RequestMessageText requestMessage, int Indexid, int wid)
        {
            if (requestMessage.Content == "连接客服")
            {

                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageTransfer_Customer_Service>(requestMessage);
                string openid = requestMessage.FromUserName;

                string token = ConvertDateTimeInt(DateTime.Now).ToString();
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "Transfer_Customer_Service", responseMessage.MsgType.ToString(), requestMessage.ToUserName, pickname, image);

                CustomerServiceAccount ss = new CustomerServiceAccount();
                ss.KfAccount = "VIP_zql_99@anju0088";
                List<CustomerServiceAccount> listss = new List<CustomerServiceAccount>();
                listss.Add(ss);
                responseMessage.TransInfo = listss;

                return responseMessage;
            }
            else
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                string openid = requestMessage.FromUserName;
                string token = ConvertDateTimeInt(DateTime.Now).ToString();
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                //responseMessage.Content ="openid=" + requestMessage.FromUserName;
                return responseMessage;
            }


        }


        public AccessTokenResult normalReturn;
        public string stoce()
        {
            WeiXinCRMComm dd = new WeiXinCRMComm();
            string error = "";
            WeiXCommFun wxcomm = new WeiXCommFun();
            int wid = wxcomm.getApiid();
            string sctokn = dd.getAccessToken(wid, out error);
            return sctokn;

        }
        public int Account_count()
        {

            //string _appId = "wxd15c55f135a54cb7";
            //string _appSecret = "740baaae678494d07616f6848491dc94";
            //normalReturn = new AccessTokenResult();
            //normalReturn = CommonApi.GetToken(_appId, _appSecret);
            //string sctokn = normalReturn.access_token;

            // Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.AddCustom(actokn, account, nickpick, password);
            CustomInfoJson no = new CustomInfoJson();
            no = Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.GetCustomBasicInfo(stoce());
            string ssa = "";
            List<CustomInfoJson> ss = new List<CustomInfoJson>();
            for (int b = 0; b < no.kf_list.Count; b++)
            {
                for (int a = 0; a < b; a++)
                {
                    ss.Add(no);
                }
                ssa += no.kf_list[b].kf_account + no.kf_list[b].kf_nick;

            }
            //   Label1.Text += ssa;



            return ss.Count;

        }
        public string Account_count_1()
        {

            //string _appId = "wxd15c55f135a54cb7";
            //string _appSecret = "740baaae678494d07616f6848491dc94";
            //normalReturn = new AccessTokenResult();
            //normalReturn = CommonApi.GetToken(_appId, _appSecret);
            //string sctokn = normalReturn.access_token;

            // Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.AddCustom(actokn, account, nickpick, password);
            CustomInfoJson no = new CustomInfoJson();
            no = Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.GetCustomBasicInfo(stoce());
            string sbv = "";
            string ssc = "";
            List<CustomInfoJson> ss = new List<CustomInfoJson>();
            for (int b = 0; b < no.kf_list.Count; b++)
            {
                for (int a = 0; a < b; a++)
                {
                    ss.Add(no);
                }
                ssc = no.kf_list.Count.ToString();
                sbv += no.kf_list[b].kf_account + no.kf_list[b].kf_nick;

            }
            //   Label1.Text += ssa;



            return ssc;

        }
        public string Zaixian()
        {

            CustomOnlineJson yes = new CustomOnlineJson();
            yes = Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.GetCustomOnlineInfo(stoce());
            string str = "";
            List<CustomOnlineJson> lists = new List<CustomOnlineJson>();

            for (int b = 0; b < yes.kf_online_list.Count; b++)
            {
                //for (int a = 0; a < b; a++)
                //{
                //    lists.Add(yes);
                //}
                str += yes.kf_online_list[b].kf_account + "/";

            }

            return str;

        }
        /// <summary>
        /// 推送纯文字
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt_zhaohang(RequestMessageText requestMessage, int Indexid, int wid)
        {




            //   if(a<contt)

            string str = requestMessage.Content;


            if (str.Contains("客服"))
            {
                BLL.wx_userweixin wBll = new XCWeiXin.BLL.wx_userweixin();
                Model.wx_userweixin weixininfo = wBll.GetModel(wid);
                string weixincode = weixininfo.weixinCode;
                int contt = int.Parse(Account_count_1());

                string str_new = str.Replace("客服", "");

                if (int.Parse(str_new) > contt)
                {
                    var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                    string openid = requestMessage.FromUserName;
                    string token = ConvertDateTimeInt(DateTime.Now).ToString();
                    responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                    var result = UserApi.Info(stoce(), openid);
                    string pickname = result.nickname;
                    string image = result.headimgurl;
                    wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                    //responseMessage.Content ="openid=" + requestMessage.FromUserName;
                    responseMessage.Content = "不存在客服" + int.Parse(str_new) + "!";
                    return responseMessage;


                }
                else
                {
                    string kfcoont = "";
                    int number = 1;
                    BLL.wx_userweixin bll = new BLL.wx_userweixin();
                    Model.wx_userweixin model = bll.GetModel(wid);
                    number = int.Parse(model.extInt.ToString());
                    if (int.Parse(str_new) < 10)
                    {
                        kfcoont = "kf200" + (int.Parse(str_new) + number) + "@" + weixincode;
                    }
                    else
                    {
                        kfcoont = "kf20" + (int.Parse(str_new) + number) + "@" + weixincode;
                    }

                    if (Zaixian().Contains(kfcoont))
                    {
                        var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageTransfer_Customer_Service>(requestMessage);
                        string openid = requestMessage.FromUserName;

                        string token = ConvertDateTimeInt(DateTime.Now).ToString();
                        var result = UserApi.Info(stoce(), openid);
                        string pickname = result.nickname;
                        string image = result.headimgurl;
                        wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "Transfer_Customer_Service", responseMessage.MsgType.ToString(), requestMessage.ToUserName, pickname, image);

                        CustomerServiceAccount ss = new CustomerServiceAccount();
                        ss.KfAccount = kfcoont;
                        List<CustomerServiceAccount> listss = new List<CustomerServiceAccount>();
                        listss.Add(ss);
                        responseMessage.TransInfo = listss;


                        return responseMessage;
                    }
                    else
                    {
                        var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                        string openid = requestMessage.FromUserName;
                        string token = ConvertDateTimeInt(DateTime.Now).ToString();
                        responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                        var result = UserApi.Info(stoce(), openid);
                        string pickname = result.nickname;
                        string image = result.headimgurl;
                        wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                        responseMessage.Content = "客服" + str_new + "不在线,请稍后再试！";
                        return responseMessage;

                    }


                }
            }
            else if (str.Contains("小招"))
            {

                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                string openid = requestMessage.FromUserName;

                string token = ConvertDateTimeInt(DateTime.Now).ToString();
                //responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);

                wxResponseBaseMgr.updata_1(str, openid);
                responseMessage.Content = "消息已受到，请耐心等待！切勿输入其他文字";
                return responseMessage;

            }
            else
            {
                ///进入文字处理
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
                //<xml>
                //  <ToUserName><![CDATA[oFo2Hjq6_yMhyz6cQ2MZtmxODOVU]]></ToUserName>
                //  <FromUserName><![CDATA[gh_2cb6c9131eb6]]></FromUserName>
                //  <CreateTime>1472450395</CreateTime>
                //  <MsgType><![CDATA[text]]></MsgType>
                //  <Content><![CDATA[hello]]></Content>
                //</xml>
                string openid = requestMessage.ToUserName;
                string openids = requestMessage.FromUserName;

                //  string openid = requestMessage.ToUserName;
                string token = ConvertDateTimeInt(DateTime.Now).ToString();
                responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                var result = UserApi.Info(stoce(), openids);
                string pickname = result.nickname;
                string image = result.headimgurl;

                wxResponseBaseMgr dd = new wxResponseBaseMgr();
                string extstr3 = dd.ccc(openids);


                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                wxResponseBaseMgr.updata(extstr3, openids);


                //responseMessage.Content ="openid=" + requestMessage.FromUserName;
                return responseMessage;


            }



        }

        public void SendTextTest(string openId, string contents)
        {
            string accessToken = stoce();


            string URL_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
            var data = new
            {
                touser = openId,
                msgtype = "text",
                text = new
                {
                    content = contents
                }
            };
            CommonJsonSend.Send(accessToken, URL_FORMAT, data, timeOut: 1000);

        }


        /// <summary>
        /// 跳转客服
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        /// 

        public IResponseMessageBase GetResponseMessageTxt(RequestMessageText requestMessage, int Indexid, int wid)
        {

            BLL.wx_userweixin wBll = new XCWeiXin.BLL.wx_userweixin();
            Model.wx_userweixin weixininfo = wBll.GetModel(wid);
            string weixincode = weixininfo.weixinCode;
            int contt = Account_count();


            //   if(a<contt)

            string str = requestMessage.Content;
            if (str.Contains("客服"))
            {

                string str_new = str.Replace("客服", "");
                if (str_new == "1")
                {
                    str_new = "4";
                }
                if (str_new == "2")
                {
                    str_new = "5";
                }
                if (str_new == "3")
                {
                    str_new = "6";
                }

                string kfcoont = "kf200" + str_new + "@" + weixincode;
                if (Zaixian().Trim().ToString().Contains(kfcoont))
                {
                    var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageTransfer_Customer_Service>(requestMessage);
                    string openid = requestMessage.FromUserName;

                    string token = ConvertDateTimeInt(DateTime.Now).ToString();

                    var result = UserApi.Info(stoce(), openid);
                    string pickname = result.nickname;
                    string image = result.headimgurl;
                    wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "Transfer_Customer_Service", responseMessage.MsgType.ToString(), requestMessage.ToUserName, pickname, image);

                    CustomerServiceAccount ss = new CustomerServiceAccount();
                    ss.KfAccount = "kf200" + str_new + "@" + weixincode;
                    List<CustomerServiceAccount> listss = new List<CustomerServiceAccount>();
                    listss.Add(ss);
                    responseMessage.TransInfo = listss;
                    return responseMessage;
                }
                else
                {
                    var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                    string openid = requestMessage.FromUserName;
                    string token = ConvertDateTimeInt(DateTime.Now).ToString();
                    responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                    var result = UserApi.Info(stoce(), openid);
                    string pickname = result.nickname;
                    string image = result.headimgurl;
                    wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                    responseMessage.Content = "客服" + str_new + "不在线,请稍后再试！";
                    return responseMessage;

                }



            }
            else
            {
                ///进入文字处理
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                string openid = requestMessage.FromUserName;
                string token = ConvertDateTimeInt(DateTime.Now).ToString();
                responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                //responseMessage.Content ="openid=" + requestMessage.FromUserName;
                return responseMessage;


            }



        }
        //public IResponseMessageBase GetResponseMessageKefu_show(RequestMessageText requestMessage, int wid)
        //{

        //    var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageTransfer_Customer_Service>(requestMessage);
        //    string openid = requestMessage.FromUserName;
        //    string token = ConvertDateTimeInt(DateTime.Now).ToString();
        //  //  requestMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
        //    wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "Transfer_Customer_Service", requestMessage.Content, requestMessage.ToUserName);
        //    //responseMessage.Content ="openid=" + requestMessage.FromUserName;
        //    return responseMessage;
        //}




        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageText requestMessage, int Indexid, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            Model.wx_requestRuleContent model_wx = getDataMusicComm(wid, Indexid);
            if (model_wx == null)
            {
                string openid = requestMessage.FromUserName;
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "music", "-1", requestMessage.ToUserName, pickname, image);
            }
            else
            {
                responseMessage.Music.MusicUrl = model_wx.mediaUrl;
                responseMessage.Music.Title = model_wx.rContent;
                responseMessage.Music.Description = model_wx.rContent2;
                string openid = responseMessage.FromUserName;
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "music", "音乐链接：" + model_wx.mediaUrl + "|标题：" + model_wx.rContent + "|描述：" + model_wx.rContent2, requestMessage.ToUserName, pickname, image);

            }

            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// update note 1:
        ///    李朴 2013-8-20 添加会员卡的cardno参数
        ///    注意：如果该会员注册过，则字符串没有cardno参数；
        ///    只有在会员注册过，在数据库里查询到该会员的cadno，则在url里添加节点cardno。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageText requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            List<Article> picTxtList = getDataPicTxtComm(wid, Indexid, openid, token);
            if (picTxtList == null || picTxtList.Count <= 0)
            {
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "-1", requestMessage.ToUserName, pickname, image);
            }
            else
            {
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "这次发了" + picTxtList.Count + "条图文", requestMessage.ToUserName, pickname, image);
            }
            //requestMessage.Content = "openid=" + responseMessage.FromUserName;
            responseMessage.Articles.AddRange(picTxtList);

            return responseMessage;
        }



        /// <summary>
        /// 推送纯文字
        /// 2013-9-12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageText requestMessage, string content, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            string openid = requestMessage.FromUserName;
            var result = UserApi.Info(stoce(), openid);
            string pickname = result.nickname;
            string image = result.headimgurl;
            //    wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", "文字请求，推送纯粹文字，内weixfonnfun.cs11容为：" + content, requestMessage.ToUserName,pickname,image);
            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// 2013-9-12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageImage requestMessage, string content, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            string openid = requestMessage.FromUserName;
            var result = UserApi.Info(stoce(), openid);
            string pickname = result.nickname;
            string image = result.headimgurl;
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), "微信上墙", "text", "文字请求，推送纯粹文字，内容weixfonnfun.cs22为：" + content, requestMessage.ToUserName, pickname, image);
            return responseMessage;
        }


        #endregion

        #region 请求为“事件的”
        /// <summary>
        /// 推送纯文字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageEventBase requestMessage, int Indexid, int wid)
        {


            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);

            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.Event != null)
            {
                EventName += requestMessage.Event.ToString();
            }
            var result = UserApi.Info(stoce(), openid);
            string pickname = result.nickname;
            string image = result.headimgurl;
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);

            return responseMessage;
        }
        /// <summary>
        /// 2014-9-8新增抽奖功能
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageEventBase requestMessage, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = string.Format("感谢您参与本次活动，您的幸运号码为 WDS2014920{0} ,请凭本号码参与后续精彩活动！", getDataTxtComm(openid));

            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.Event != null)
            {
                EventName += requestMessage.Event.ToString();
            }
            var result = UserApi.Info(stoce(), openid);
            string pickname = result.nickname;
            string image = result.headimgurl;
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);

            return responseMessage;
        }
        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageEventBase requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.Event != null)
            {
                EventName += requestMessage.Event.ToString();
            }


            Model.wx_requestRuleContent model = getDataMusicComm(wid, Indexid);
            if (model == null)
            {
                string openid = requestMessage.FromUserName;
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "-1", requestMessage.ToUserName, pickname, image);
            }
            else
            {
                string openid = requestMessage.FromUserName;
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                responseMessage.Music.MusicUrl = model.mediaUrl;
                responseMessage.Music.Title = model.rContent;
                responseMessage.Music.Description = model.rContent2;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "音乐链接：" + model.mediaUrl + "|标题：" + model.rContent + "|描述：" + model.rContent2, requestMessage.ToUserName, pickname, image);

            }
            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// update note 1:
        ///    李朴 2013-8-20 添加会员卡的cardno参数
        ///    注意：如果该会员注册过，则字符串没有cardno参数；
        ///    只有在会员注册过，在数据库里查询到该会员的cadno，则在url里添加节点cardno。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <param name="wid">微帐号主键Id</param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageEventBase requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            List<Article> picTxtList = getDataPicTxtComm(wid, Indexid, openid, token);
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.Event != null)
            {
                EventName += requestMessage.Event.ToString();
            }

            if (picTxtList == null || picTxtList.Count <= 0)
            {

                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "-1", requestMessage.ToUserName, pickname, image);
            }
            else
            {

                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "这次发了" + picTxtList.Count + "条图文", requestMessage.ToUserName, pickname, image);
            }
            // requestMessage.ConvertToRequestMessageText();
            responseMessage.Articles.AddRange(picTxtList);
            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// 2013-9-12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageEventBase requestMessage, string content, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            string openid = requestMessage.FromUserName;
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.Event != null)
            {
                EventName += requestMessage.Event.ToString();
            }
            var result = UserApi.Info(stoce(), openid);
            string pickname = result.nickname;
            string image = result.headimgurl;
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", "事件：推送纯粹的文字，内容为:" + content, requestMessage.ToUserName, pickname, image);

            return responseMessage;
        }


        #endregion

        #region 模块功能的回复内容

        /// <summary>
        /// 模块功能回复【请求为‘文字’类型】
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="modelFunctionName"></param>
        /// <param name="modelFunctionId"></param>
        /// <param name="apiid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetModuleResponse(RequestMessageText requestMessage, string modelFunctionName, int modelFunctionId, int apiid)
        {
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();

            responselist = PanDuanMoudle(modelFunctionName, modelFunctionId, openid, apiid);
            if (responselist == null || responselist.Count <= 0)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
                responseMessage.Content = "【" + modelFunctionName + "】功能模块未获得到数据";
                return responseMessage;
            }
            Model.ReponseContentType responseType = responselist[0].rcType;
            if (responseType == Model.ReponseContentType.text)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                responseMessage.Content = responselist[0].rContent.ToString();
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName, pickname, image);
                return responseMessage;
            }
            else if (responseType == Model.ReponseContentType.txtpic)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
                IList<Article> rArticlelist = new List<Article>();
                Article article = new Article();
                foreach (Model.ResponseContentEntity response in responselist)
                {
                    article = new Article();
                    article.Title = response.rContent;
                    article.Description = response.rContent2;
                    article.Url = getWXApiUrl(response.detailUrl, token, openid) + getWxUrl_suffix();
                    if (response.picUrl == null || response.picUrl.ToString().Trim() == "")
                    {
                        article.PicUrl = "";
                    }
                    else
                    {
                        if (!response.picUrl.Contains("http://"))
                        {
                            article.PicUrl = MyCommFun.getWebSite() + response.picUrl;
                        }
                        else
                        {
                            article.PicUrl = response.picUrl;
                        }
                    }
                    rArticlelist.Add(article);

                }

                responseMessage.Articles.AddRange(rArticlelist);
                var result = UserApi.Info(stoce(), openid);
                string pickname = result.nickname;
                string image = result.headimgurl;
                wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "这次发了" + rArticlelist.Count + "条图文", requestMessage.ToUserName, pickname, image);

                return responseMessage;

            }
            else
            {
                return null;
            }


        }


        /// <summary>
        /// 模块功能回复【请求为‘事件’类型】
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="modelFunctionName"></param>
        /// <param name="modelFunctionId"></param>
        /// <param name="apiid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetModuleResponse(RequestMessageEventBase requestMessage, string modelFunctionName, int modelFunctionId, int apiid)
        {
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();

            responselist = PanDuanMoudle(modelFunctionName, modelFunctionId, openid, apiid);
            if (responselist == null || responselist.Count <= 0)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
                responseMessage.Content = "【" + modelFunctionName + "】功能模块未获得到数据";
                return responseMessage;
            }

            Model.ReponseContentType responseType = responselist[0].rcType;

            if (responseType == Model.ReponseContentType.text)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                responseMessage.Content = responselist[0].rContent.ToString();
                return responseMessage;
            }
            else if (responseType == Model.ReponseContentType.txtpic)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
                IList<Article> rArticlelist = new List<Article>();
                Article article = new Article();
                foreach (Model.ResponseContentEntity response in responselist)
                {
                    article = new Article();
                    article.Title = response.rContent;
                    article.Description = response.rContent2;
                    article.Url = getWXApiUrl(response.detailUrl, token, openid) + getWxUrl_suffix();
                    if (response.picUrl == null || response.picUrl.ToString().Trim() == "")
                    {
                        article.PicUrl = "";
                    }
                    else
                    {
                        if (!response.picUrl.Contains("http://"))
                        {
                            article.PicUrl = MyCommFun.getWebSite() + response.picUrl;
                        }
                        else
                        {
                            article.PicUrl = response.picUrl;
                        }
                    }
                    rArticlelist.Add(article);

                }
                responseMessage.Articles.AddRange(rArticlelist);
                return responseMessage;
            }
            else
            {
                return null;
            }


        }





        #endregion


        #region 从数据库里读取数据

        BLL.wx_requestRuleContent rcBll = new BLL.wx_requestRuleContent();

        /// <summary>
        /// 从数据库里取文本类型的值
        /// </summary>
        /// <param name="Indexid"></param>
        /// <returns></returns>
        public string getDataTxtComm(int wid, int Indexid, string openid, string token)
        {
            //随机数

            string content = rcBll.GetTxtContent(Indexid);
            if (content.Contains("{openid}"))
            {
                content = content.Replace("{openid}", openid);
            }
            content = ProcTitle(content, openid);
            return content;

        }
        /// <summary>
        /// 2014-9-18 新增抽奖功能
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="openid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string getDataTxtComm(string openid)
        {
            string content = rcBll.GetTxtContent(openid);

            return content;

        }
        /// <summary>
        /// 从数据库里取语音类型的值
        /// </summary>
        /// <param name="wid">微帐号主键Id</param>
        /// <param name="Indexid"></param>
        /// <returns></returns>
        public Model.wx_requestRuleContent getDataMusicComm(int wid, int Indexid)
        {

            Model.wx_requestRuleContent model = rcBll.GetMusicContent(Indexid);
            return model;

        }

        /// <summary>
        /// 从数据库里取图文类型的值
        /// </summary>
        /// <param name="wid">微帐号主键id</param>
        /// <param name="Indexid"></param>
        /// <param name="openid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<Article> getDataPicTxtComm(int wid, int Indexid, string openid, string token)
        {
            List<Article> retlist = new List<Article>();
            string website = MyCommFun.getWebSite();



            IList<Model.wx_requestRuleContent> twList = rcBll.GetTuWenContent(Indexid);


            Article article = new Article();
            for (int i = 0; i < twList.Count(); i++)
            {
                article = new Article();
                article.Title = ProcTitle(twList[i].rContent, openid);
                article.Description = twList[i].rContent2;
                article.Url = getWXApiUrl(twList[i].detailUrl, token, openid) + rcBll.cardnoStr(wid, openid) + getWxUrl_suffix();
                if (twList[i].picUrl == null || twList[i].picUrl.ToString().Trim() == "")
                {
                    article.PicUrl = "";
                }
                else
                {
                    if (twList[i].picUrl.Contains("http://"))
                    {
                        article.PicUrl = twList[i].picUrl;

                    }
                    else
                    {
                        article.PicUrl = website + twList[i].picUrl;
                    }
                }
                retlist.Add(article);
            }

            return retlist;

        }

        /// <summary>
        /// 判断该微帐号与原始Id号是否一致，如果不一致，则返回false，如果一致则返回true
        /// </summary>
        /// <param name="apiid"></param>
        /// <param name="wxid">原始Id号</param>
        /// <returns></returns>
        public bool ExistApiidAndWxId(int apiid, string wxid)
        {
            bool exists = true;
            DAL.wx_userweixin weixinDal = new DAL.wx_userweixin();
            if (weixinDal.ExistsWidAndWxId(apiid, wxid))
            {
                exists = true;
            }
            else
            {
                exists = false;
            }

            return exists;
        }
        /// <summary>
        /// 如果content包含了sn码，则将sn码动态替换成一个值
        /// [jintian]==当天的日期
        /// [zuotian]==昨天的日期
        /// [mingtian]==明天的日期
        /// </summary>
        /// <param name="title"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        private string ProcTitle(string content, string openid)
        {
            //if (content.Contains("[sn]"))
            //{
            //    MxWeiXin.BLL.wx_sn_info snBll = new MxWeiXin.BLL.wx_sn_info();
            //    content = content.Replace("[sn]", snBll.getNewRadmInfo(openid));
            //}
            content = content.Replace("[jintian]", DateTime.Now.ToString("yyyy年MM月dd日"));
            content = content.Replace("[zuotian]", DateTime.Now.AddDays(-1).ToString("yyyy年MM月dd日"));
            content = content.Replace("[mingtian]", DateTime.Now.AddDays(1).ToString("yyyy年MM月dd日"));
            return content;
        }

        #endregion

        #region 常用的一些小方法
        public int getApiid()
        {
            if (HttpContext.Current.Request["apiid"] == null || HttpContext.Current.Request["apiid"].ToString().Length < 1)
            {
                return 0;
            }
            int tmpInt = 0;
            if (!int.TryParse(HttpContext.Current.Request["apiid"].ToString(), out tmpInt))
            {
                return 0;
            }
            int apiid = int.Parse(HttpContext.Current.Request["apiid"].ToString());
            return apiid;

        }

        public string getWXApiUrl(string url, string token, string openid)
        {

            string ret = "";
            if (url.Contains("?"))
            {
                ret = url + "&token=" + token + "&openid=" + openid;
            }
            else
            {
                ret = url + "?token=" + token + "&openid=" + openid;
            }

            return ret;
        }

        /// <summary>
        /// 设置微信url地址的后缀
        /// </summary>
        /// <returns></returns>
        public string getWxUrl_suffix()
        {
            string nati_suffix = Utils.GetAppSettingValue("nati_suffix");
            if (nati_suffix == "")
            {
                return "#mp.weixin.qq.com";
            }
            else
            {
                return "&" + nati_suffix;
            }

        }


        public long ConvertDateTimeInt(System.DateTime time)
        {
            long intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (long)(time - startTime).TotalSeconds;
            return intResult;
        }
        #endregion


    }
}
