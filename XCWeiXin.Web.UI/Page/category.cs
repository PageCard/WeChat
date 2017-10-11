using System;
using System.Collections.Generic;
using System.Text;
using XCWeiXin.Common;

namespace XCWeiXin.Web.UI.Page
{
    public partial class category : Web.UI.BasePage
    {
        protected int category_id;  //类别ID
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            category_id = MXRequest.GetQueryInt("category_id");
        }
    }
}
