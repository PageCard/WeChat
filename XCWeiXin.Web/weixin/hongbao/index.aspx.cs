using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;

namespace XCWeiXin.Web.weixin.hongbao
{
    public partial class index : WeiXinPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int wid = MyCommFun.RequestInt("wid");
            int aid = MyCommFun.RequestInt("aid");
            string openid = MyCommFun.RequestOpenid();
            if (openid == "" && openid == null)
            {
                Response.Write("错误错误：100004");
                return;
            }
            if (aid == 0)
            {
                Response.Write("错误错误：100005");
                return;
            }
            if (wid == 0)
            {
                Response.Write("错误错误：100003");
                return;
            }
        }
    }
}