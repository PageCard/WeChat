using XCWeiXin.Templates;
using System;
using System.Collections.Generic;
using XCWeiXin.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.book
{
    public partial class confirmOrder : bookBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.OnInit(e);
            if (errInitTemplates != "")
            {
                Response.Write(errInitTemplates);
                return;
            }
            string openid = MyCommFun.RequestOpenid();
            BLL.wx_book_user_addr uAddrBll = new BLL.wx_book_user_addr();
            IList<Model.wx_book_user_addr> uaddrList = uAddrBll.GetOpenidAddr(openid, wid);
            if (uaddrList == null || uaddrList.Count <= 0 || uaddrList[0].id <= 0)
            {
                //该微信用户没有添加地址
                Response.Redirect("/book/editaddr.aspx?wid=" + wid + "&openid=" + openid + "&frompage=confirmOrder.aspx");
               // MessageBox.ResponseScript(this, "window.location.href =/book/editaddr.aspx?wid=" + wid + "&openid=" + openid + "&frompage=confirmOrder.aspx");
                return;
            }


            //1获得模版基本信息
            BLL.wx_book_templates tBll = new BLL.wx_book_templates();
            templateFileName = tBll.GetTemplatesFileNameByWid("book", wid);
            if (templateFileName == null || templateFileName.Trim() == "")
            {
                errInitTemplates = "不存在该帐号或者该帐号尚未设置模版！";
                Response.Write(errInitTemplates);
                Response.End();
                return;
            }


            serverPath = MyCommFun.GetRootPath() + "/book/templates/" + templateFileName + "/confirmOrder.html";
            bookTemplateMgr template = new bookTemplateMgr("/book/templates/" + templateFileName, serverPath, wid);
            template.tType = TemplateType.confirmOrder;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(wid);
        }

        override protected void OnInit(EventArgs e)
        {
            
        }
    }
}