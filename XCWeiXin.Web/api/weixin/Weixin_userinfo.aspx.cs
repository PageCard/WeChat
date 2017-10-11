using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.api.weixin
{
    public partial class Weixin_userinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["sex"] == "1")
            {
                Label3.Text = "性别：" + "男";
            }
            if (Request.Params["sex"] == "2")
            {
                Label3.Text = "性别：" + "女";
            }
            if (Request.Params["sex"] == "0")
            {
                Label3.Text = "性别：" + "未知";
            }

            Label1.Text ="用户Openid:"+ Request.Params["openid"];
            Label2.Text ="用户昵称"+ Request.Params["name"];
            Label4.Text = Request.Params["name"];
            //Label3.Text = Request.Params["sex"];

        }
    }
}