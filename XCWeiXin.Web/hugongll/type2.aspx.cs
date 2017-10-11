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
    public partial class type2 : System.Web.UI.Page
    {
        public string pick_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string openid = HttpContext.Current.Request.Cookies["open_id1"].Value;
            // string neirong = TextBox1.Text;
            var result = UserApi.Info(stoce(), openid);
            pick_name = result.nickname;
        }
        public string stoce()
        {
            WeiXinCRMComm dd = new WeiXinCRMComm();
            string error = "";
            WeiXCommFun wxcomm = new WeiXCommFun();
            int wid = 44;
            string sctokn = dd.getAccessToken(wid, out error);
            return sctokn;

        }
    }
}