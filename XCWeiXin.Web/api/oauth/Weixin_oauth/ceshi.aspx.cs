using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.api.oauth.Weixin_oauth
{
    public partial class ceshi : System.Web.UI.Page
    {
        public string openid="";
        protected void Page_Load(object sender, EventArgs e)
        {
            openid = Session["openidzzz"].ToString();

        }
    }
}