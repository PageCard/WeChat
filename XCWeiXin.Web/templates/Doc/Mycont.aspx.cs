using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class Mycont : System.Web.UI.Page
    {
        public string open_id = "";
        public string headimg = "";
        public string pick_name = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["open_id"] != null)
            {
                open_id = HttpContext.Current.Request.Cookies["open_id"].Value;
            }
            else
            {
                
                open_id = Request.QueryString["open_ids"].ToString();
            }
            var result = UserApi.Info(stoce(), open_id);
           pick_name = result.nickname;
           headimg  = result.headimgurl;

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