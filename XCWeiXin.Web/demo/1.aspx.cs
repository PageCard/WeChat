using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.demo
{
    public partial class _1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                Response.Redirect("select1.aspx?wid=" + RadioButton1.Text + "");
            }
            else if(RadioButton2.Checked)
            
            {
                Response.Redirect("select1.aspx?wid=" + RadioButton2.Text + "");


            }
            else if (RadioButton3.Checked)
            {
                Response.Redirect("select1.aspx?wid=" + RadioButton3.Text + "");
            }
            else if (RadioButton4.Checked)
            {
                Response.Redirect("select1.aspx?wid=" + RadioButton4.Text + "");
            }

        }
    }
}