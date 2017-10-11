﻿using XCWeiXin.Templates;
using System;
using System.Collections.Generic;
using XCWeiXin.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.shop
{
    public partial class order_success : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.OnInit(e);
            if (errInitTemplates != "")
            {
                Response.Write(errInitTemplates);
                return;
            }

            //1获得模版基本信息
            BLL.wx_module_templates tBll = new BLL.wx_module_templates();
            templateFileName = tBll.GetTemplatesFileNameByWid("shop", wid);
            if (templateFileName == null || templateFileName.Trim() == "")
            {
                errInitTemplates = "不存在该帐号或者该帐号尚未设置模版！";
                Response.Write(errInitTemplates);
                Response.End();
                return;
            }

            serverPath = MyCommFun.GetRootPath() + "/shop/templates/" + templateFileName + "/order_success.html";
            ShopTemplateMgr template = new ShopTemplateMgr("/shop/templates/" + templateFileName, serverPath, wid);
            template.tType = TemplateType.orderSuccess;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(wid);
        }
    }
}