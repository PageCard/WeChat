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
    public partial class userinfo : ShopBasePage
    {
        override protected void OnInit(EventArgs e)
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


            serverPath = MyCommFun.GetRootPath() + "/shop/templates/" + templateFileName + "/userinfo.html";
            ShopTemplateMgr template = new ShopTemplateMgr("/shop/templates/" + templateFileName, serverPath, wid);
            template.tType = TemplateType.userinfo;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(wid);
        }
    }
}