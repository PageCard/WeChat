using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.WeiXinComm;
using XCWeiXin.Common;
using Senparc.Weixin.MP.CommonAPIs;

namespace XCWeiXin.Web.Web_tell
{
    public partial class toke : System.Web.UI.Page
    {
        public string id;
        public string quest;
        public string create;
        public string load;
        public string openid;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = MyCommFun.RequestParam("id");
            quest = MyCommFun.RequestParam("quest");
            create = MyCommFun.RequestParam("creadate");
            load = MyCommFun.RequestParam("load");
            openid = MyCommFun.RequestParam("openid");

        }
        public string Token()
        {

            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(36, out error);
            return accessToken;


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.wx_response_BaseData bll = new BLL.wx_response_BaseData();
            Model.wx_response_BaseData model = new Model.wx_response_BaseData();

            string error = "";
            XCWeiXin.WeiXinComm.WeiXinCRMComm cpp = new XCWeiXin.WeiXinComm.WeiXinCRMComm();
            string accessToken = Token();
            string openId = openid;
            string contents = TextBox1.Text;
            string URL_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
            var data = new
            {
                touser = openId,
                msgtype = "text",
                text = new
                {
                    content = contents
                }
            };
            CommonJsonSend.Send(accessToken, URL_FORMAT, data, timeOut: 1000);

            model.id = int.Parse(id);
            model.reponseContent = TextBox1.Text;
            bll.updata(model);
            TextBox1.Text = "";
            Response.Redirect("huifu.aspx?openid=" + openid + "");
        }
    }
}