/*----------------------------------------------------------------
    Copyright (C) 2015 Senparc
    
    文件名：HomeController.cs
    文件功能描述：首页Controller
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace XCWeiXin.Web.App_Code.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            Response.Redirect("/admin/login.aspx");
            return View();
        }

        public ActionResult TestElmah()
        {
            try
            {
                throw new Exception("出错测试，使用Elmah保存错误结果(1)");
            }
            catch (Exception)
            {
                
            }

            throw new Exception("出错测试，使用Elmah保存错误结果(2)");
            return View();
        }
    }
}
