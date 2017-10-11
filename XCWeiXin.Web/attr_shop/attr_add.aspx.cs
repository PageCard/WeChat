using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Model;
using XCWeiXin.DAL;

namespace XCWeiXin.Web.attr_shop
{
    public partial class attr_add : System.Web.UI.Page
    {
        Model.attrshop.attr_shop model = new Model.attrshop.attr_shop();
        DAL.attr_shop.attr_shop dal = new DAL.attr_shop.attr_shop();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            model.attrname = attr.Text.Trim().ToString();
            model.attrcontext = text.Text.Trim().ToString();
            dal.attr_Add(model);
            JscriptMsg("添加属性成功", "attrlist.aspx", "Success");
           
        }
        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
    }
}