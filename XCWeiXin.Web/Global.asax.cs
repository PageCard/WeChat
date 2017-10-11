using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace XCWeiXin.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //避免对 Web 资源文件（例如 WebResource.axd 或 ScriptResource.axd）的请求传递给控制器  
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");

            routes.MapRoute(
               "Open",
               "Open/Callback/{appId}",
              new { controller = "Open", action = "Callback", appId = UrlParameter.Optional } ,
              new string[] { "XCWeiXin.Web.App_Code.Controllers" }
          );

           
         

            routes.MapRoute(
                "admin/login", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
                , new string[] { "XCWeiXin.Web.App_Code.Controllers" }
            );
        }
    }
}