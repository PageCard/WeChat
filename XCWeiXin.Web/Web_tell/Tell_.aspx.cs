using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;

namespace XCWeiXin.Web.Web_tell
{
    public partial class Tell_ : System.Web.UI.Page
    {
        public string str;
        DateTime dt = DateTime.Now;
        DateTime dd = DateTime.Now.AddDays(-1);
        public string ss;
        public string sss;
        public string openid = MyCommFun.RequestParam("create");
        //Request.Params["type"];

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Now.AddHours(1.1);
            DateTime dt = DateTime.Now.AddDays(-1);
            string sss = dd.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            string ss = dt.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            str = "id in(select max(id) from wx_response_BaseData group by wx_openid) and wid=36 and requestType='Text'and (createDate>='" + ss + "') and (createDate<='" + sss + "' )";
            ss = dt.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            sss = dd.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
        }
    }
}