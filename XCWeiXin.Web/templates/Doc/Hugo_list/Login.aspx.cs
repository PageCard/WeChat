using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc.Hugo_list
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string bb = Request.Form["user"];
            string cc = Request.Form["pass"];
            BLL.HG.Hg_list order = new BLL.HG.Hg_list();
            bool or = order.Login_Hg(bb,cc);
            if (or == true)
            {
                ClientScript.RegisterStartupScript(typeof(string), "温馨提醒", "<script>alert('登陆成功');window.location.href ='List_this.aspx?name="+bb+"'</script>"); 

            }
            else {
                ClientScript.RegisterStartupScript(typeof(string), "温馨提醒", "<script>alert('检查用户名户密码')</script>");

            }
           
            
        }
    }
}