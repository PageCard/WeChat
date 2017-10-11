using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string open_id = "";
            string open_ids = Request.QueryString["open_ids"];

            if (System.Web.HttpContext.Current.Request.Cookies["open_id"] != null)
            {
                open_id = HttpContext.Current.Request.Cookies["open_id"].Value;
            }
            else
            {
                Response.Redirect("/api/oauth/Weixin_oauth/oauth.aspx");
            }

        }
    }
}