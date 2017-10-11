using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;
using XCWeiXin.Web.weixin;


namespace XCWeiXin.Web
{
    public partial class err : WeiXinPage
    {
        protected int rev;       
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            rev = MyCommFun.RequestInt("rev", 0);


        }

    }
}