using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using XCWeiXin.API.Payment.wxpay;
using XCWeiXin.BLL;
using System.Net;
using System.IO;
using XCWeiXin.Common;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;

namespace XCWeiXin.Web.api.payment.wxpay
{
    /// <summary>
    ///  维权接口页面
    /// </summary>
    public partial class getopenid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           int productId= MyCommFun.RequestInt("orderid");
            int hc = this.GetHashCode();
           int wid = MyCommFun.RequestInt("wid");
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

            var returnUrl = string.Format(MyCommFun.getWebSite() + "/api/payment/wxpay/JsApi.aspx?wid=" + wid + "&orderid=" + productId + "");
            var state = string.Format("{0}|{1}", productId, hc);
            var url = OAuthApi.GetAuthorizeUrl(PayV3Config.Mch_appId, returnUrl, state, OAuthScope.snsapi_userinfo);
            Response.Redirect(url);
            
        }

    }
}