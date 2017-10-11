using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;

namespace XCWeiXin.Web.api.oauth.weixin_hugong
{
    public partial class oauth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int wid = 44;

            BLL.wx_userweixin wx = new BLL.wx_userweixin();
            Model.wx_userweixin wxModel = wx.GetModel(wid);

            int hc = this.GetHashCode();


            var returnUrl = MyCommFun.getWebSite() + "/api/oauth/weixin_hugong/info.aspx?wid=" + wid + "";
            var state = string.Format("{0}|{1}", "zql", hc);
            var url = OAuthApi.GetAuthorizeUrl(wxModel.AppId, returnUrl, state, OAuthScope.snsapi_userinfo);

            Response.Redirect(url);

        }
    }
}