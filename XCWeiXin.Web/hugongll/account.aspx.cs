using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.hugongll
{
    public partial class account : System.Web.UI.Page
    {
        public string open_id = "";
        public string headimg = "";
        public string pick_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["open_id1"] != null)
            {
                open_id = HttpContext.Current.Request.Cookies["open_id1"].Value;
            }
            else
            {
                Response.Redirect("/api/oauth/weixin_hugong/oauth.aspx");

               
            }
            var result = UserApi.Info(Token(), open_id);
            pick_name = result.nickname;



            headimg = result.headimgurl;
        }
        public string Token()
        {

            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(44, out error);
            return accessToken;


        }
    }
}