using Senparc.Weixin;
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
    public partial class info : System.Web.UI.Page
    {
        public string openid = "";
        public string name = "";
        public string sex = "";


        string code = MyCommFun.RequestParam("code");
        string state = MyCommFun.RequestParam("state");
        public string image = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int wid = MyCommFun.RequestInt("wid");
            BLL.wx_userweixin wx = new BLL.wx_userweixin();
            Model.wx_userweixin wxModel = wx.GetModel(wid);

            if (string.IsNullOrEmpty(code))
            {
                Response.Write("您拒绝了授权！");
                return;
            }

            if (!state.Contains("|"))
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                Response.Write("验证失败！请从正规途径进入！1001");
                return;
            }
            var openIdResult = OAuthApi.GetAccessToken(wxModel.AppId, wxModel.AppSecret, code);
            if (openIdResult.errcode != ReturnCode.请求成功)
            {
                Response.Write("错误：" + openIdResult.errmsg);
                return;
            }
            else
            {

                var result = OAuthApi.GetUserInfo(openIdResult.access_token, openIdResult.openid);
                name = result.nickname;
                image = result.headimgurl;
                Session["name"] = name;
                Session["imageheader"] = image;
                HttpCookie cookie = new HttpCookie("open_id1");
                cookie.Value = result.openid;
                cookie.Expires = DateTime.Now.AddDays(3650);
                HttpContext.Current.Response.Cookies.Add(cookie);
               
                Response.Redirect("/hugongll/index.aspx?open_ids=" + result.openid + "");

            }

        }
    }
}