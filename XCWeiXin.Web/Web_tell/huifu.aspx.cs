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
    public partial class huifu : System.Web.UI.Page
    {
        public string openid = MyCommFun.RequestParam("openid");
        public string request = MyCommFun.RequestParam("request");
        public string createdata = MyCommFun.RequestParam("createdata");
        public int id = MyCommFun.RequestInt("id");
        public string openid_number;
        public string image;
        public string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Now.AddHours(0.1);
            DateTime dt = DateTime.Now.AddDays(-1);
            string sss = dd.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            string ss = dt.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            str = " wx_openid='" + openid + "' and (createDate>='" + ss + "') and(createDate<='" + sss + "' )and (requestType='Text') and wid=36 order by id desc ";
            var result = UserApi.Info(Token(), openid);
            openid_number = result.nickname;
            image = result.headimgurl;
            Image1.ImageUrl = image;

        }
        public string Token()
        {

            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(36, out error);
            return accessToken;


        }


    }
}