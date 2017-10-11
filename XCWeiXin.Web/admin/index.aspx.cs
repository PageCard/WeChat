using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;

namespace XCWeiXin.Web.admin
{
    public partial class index : Web.UI.ManagePage
    {
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo();
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[MXKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "XCWeiXin", -14400);
            Utils.WriteCookie("AdminPwd", "XCWeiXin", -14400);

            Session["yubomId"] = null;
            Utils.WriteCookie("yubomId", "XCWeiXin", -14400);

            Response.Redirect("login.aspx");
        }

    }
}