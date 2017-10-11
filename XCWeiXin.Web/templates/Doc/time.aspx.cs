using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class time : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"].ToString();
            string day = pickdate.Text;
            string time = picktime.Text;
            string name = Request.QueryString["name"].ToString();
            
            Response.Redirect("detail.aspx?Type="+type+"&day="+day+"&time="+time+"&Name="+name+"");
        }
    }
}