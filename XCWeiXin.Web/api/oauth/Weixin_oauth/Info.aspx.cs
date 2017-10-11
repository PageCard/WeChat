using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.api.oauth.Weixin_oauth
{
    public partial class Info : System.Web.UI.Page
    {
        public string openid = "";
        public string name = "";
        public string sex = "";


        string code = MyCommFun.RequestParam("code");
        string state = MyCommFun.RequestParam("state");
        public string image = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int wid = MyCommFun.RequestInt("wid");
            BLL.wx_userweixin wx = new BLL.wx_userweixin();
            Model.wx_userweixin wxModel = wx.GetModel(wid);

            if (string.IsNullOrEmpty(code))
            {
                Response.Write("您拒绝了授权！");
                return;
            }

            if (!state.Contains("|"))
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                Response.Write("验证失败！请从正规途径进入！1001");
                return;
            }
            var openIdResult = OAuthApi.GetAccessToken(wxModel.AppId, wxModel.AppSecret, code);
            if (openIdResult.errcode != ReturnCode.请求成功)
            {
                Response.Write("错误：" + openIdResult.errmsg);
                return;
            }
            else
            {

                var result = OAuthApi.GetUserInfo(openIdResult.access_token, openIdResult.openid);
                name = result.nickname;
                image = result.headimgurl;
                Session["name"] = name;
                Session["imageheader"] = image;
                openid = result.openid;
                SendTemplateMessageTest();
             

            }}
             //<summary>
         //微信发送模板消息
         //</summary>
              public void SendTemplateMessageTest()
              {

                  var openId = openid;//换成已经关注用户的openId
                  var templateId = "eu4TmBIP5QeDjZogvL4BsWc8MoildR7lGrAG9YDwvK0";//换成已经在微信后台添加的模板Id
                  var accessToken = Token();
                  var testData = new //TestTemplateData()
                  {
                      first = new TemplateDataItem("您好，授权通知"),
                      keyword1 = new TemplateDataItem("八月，该读书"),
                      keyword2 = new TemplateDataItem(DateTime.Now.ToString()),
                      keyword3 = new TemplateDataItem("信息通知"),
                      remark = new TemplateDataItem("你刚授权给了+"+ MyCommFun.getWebSite()+"")
                  };
                  var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId, "http://www.hugongll.com/hugongll/index.aspx", testData);

                
              }
              public string Token()
              {

                  WeiXinCRMComm cpp = new WeiXinCRMComm();
                  string error = "";
                  string accessToken = cpp.getAccessToken(43, out error);
                  return accessToken;


              }
        }
    }
