using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;

namespace XCWeiXin.Web.hugongll
{
    public partial class index : System.Web.UI.Page
    {
        public string open_id;
        public string cook;
        public string appid;
        public string timestamp;
        public string nonceStr;
        public string signature;
        public string js;

        protected void Page_Load(object sender, EventArgs e)
        {

           if(!IsPostBack)
           {
               string url = "http://www.hugongll.com";
               if (Request.Url.PathAndQuery.Contains("index.aspx"))
               {
                   url = "http://www.hugongll.com" + Request.Url.PathAndQuery;
               }
                   else{
                     url="http://www.hugongll.com/hugongll/index.aspx";

                   }

        var jssdk= GetJsSdkUiPackage("wx172ece37e2ed2939", "915da87498123dfd4a47ace800495fe7", url);
        
            appid = jssdk.AppId;
          timestamp = jssdk.Timestamp;
          nonceStr = jssdk.NonceStr;
          signature = jssdk.Signature;
           }
              cook = Request.QueryString["open_ids"];
            
              if (System.Web.HttpContext.Current.Request.Cookies["open_id1"] != null)
              {
                  cook = HttpContext.Current.Request.Cookies["open_id1"].Value;
              }
              else
              {
                  Response.Redirect("/api/oauth/weixin_hugong/oauth.aspx");
              }
          
         

        }
        public  JsSdkUiPackage GetJsSdkUiPackage(string appId, string appSecret, string url)
        {
            //获取时间戳
            var timestamp =JSSDKHelper. GetTimestamp();
            //获取随机码
            string nonceStr =JSSDKHelper.GetNoncestr();
            string ticket = JsApiTicketContainer.TryGetJsApiTicket(appId, appSecret);
            //获取签名
            string signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, url);
            //返回信息包
            return new JsSdkUiPackage(appId, timestamp, nonceStr, signature);
        }
    }
}