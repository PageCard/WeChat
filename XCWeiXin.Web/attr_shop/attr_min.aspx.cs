using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.Model;
using XCWeiXin.BLL;

namespace XCWeiXin.Web.attr_shop
{
    public partial class attr_min : System.Web.UI.Page
    {
        public int id;
        Model.attrshop.min_attrid model = new Model.attrshop.min_attrid();
        BLL.attr_shop.min_attrid bll = new BLL.attr_shop.min_attrid();     
        protected void Page_Load(object sender, EventArgs e)
        {
          
         
             id = MXRequest.GetQueryInt("id");
        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
              model.attrid = id;
              model.min_attridname = attr.Text.Trim().ToString();
              model.min_attridcontext = text.Text.Trim().ToString();
              bll.add_min(model);
              JscriptMsg("商品大属性添加成功", "attrlist.aspx", "Success");


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