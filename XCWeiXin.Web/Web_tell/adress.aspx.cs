using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.Web_tell
{
    public partial class adress : System.Web.UI.Page
    {
        public string openid;
        string create = MyCommFun.RequestParam("create");
        string id = MyCommFun.RequestParam("id");
        string like = MyCommFun.RequestParam("like");
        public string str;

        public string toke;
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime dd = DateTime.Now.AddHours(1.1);
            DateTime dt = DateTime.Now.AddDays(-1);
            string sss = dd.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            string ss = dt.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);

            str = "id in(select max(id) from wx_response_BaseData group by wx_openid) and wid=36 and requestType='Text'and (createDate>='" + ss + "') and (createDate<='" + sss + "' ) and extStr3=" + like + "";

            //   Response.Write(create);

        }
        public string name(string openiddd)
        {
            var result = UserApi.Info(Token(), openiddd);
            openid = result.nickname;
            return openid;
        }
        public string Token()
        {
            //Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(36, out error);
            return accessToken;


        }
        public void gg()
        {
            // SendTextTest("oFo2Hjq6_yMhyz6cQ2MZtmxODOVU");
            string error = "";
            XCWeiXin.WeiXinComm.WeiXinCRMComm cpp = new XCWeiXin.WeiXinComm.WeiXinCRMComm();
            string accessToken = Token();
            string openId = create;
            string contents = "Form:requestMessage.Content.ToString";
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
    }
}