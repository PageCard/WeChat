using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;

namespace XCWeiXin.Web.weixin.dati
{
    /// <summary>
    /// 错误处理
    /// </summary>
    public partial class err : WeiXinPage
    {
        /// <summary>
        /// 1、系统错误
        /// 2.未到开始时间
        /// 3.活动已结束
        /// </summary>    
        protected int rev;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            rev = MyCommFun.RequestInt("rev", 0);
        
         
        }

       


        
    }
}