using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.WeiXinComm;
using XCWeiXin.DBUtility;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class ider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fankui_Click(object sender, EventArgs e)
        {
            string pick_name = "";
            string openid = HttpContext.Current.Request.Cookies["open_id1"].Value;
            string neirong = TextBox1.Text;
            var result = UserApi.Info(stoce(), openid);
            pick_name = result.nickname;
            string str="INSERT INTO A_HG_FK (neirong,open_id,name) VALUES ('"+neirong +"','"+openid+"','"+pick_name+"')";
         int aa= DbHelperSQL.ExecuteSql(str);
         if (aa > 0)
         {
             Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('感谢你的反馈！ ');</script>");
         }
         else
         {
             Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('异常反馈！ ');</script>");
         }          

        }
        public string stoce()
        {
            WeiXinCRMComm dd = new WeiXinCRMComm();
            string error = "";
            WeiXCommFun wxcomm = new WeiXCommFun();
            int wid = 44;
            string sctokn = dd.getAccessToken(wid, out error);
            return sctokn;

        }
    }
}