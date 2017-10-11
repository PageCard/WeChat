using System;
using System.Diagnostics;
using System.Web;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP;
using System.IO;

namespace XCWeiXin.WeiXinComm
{
    /// <summary>
    /// 事件处理程序，此代码的简化MessageHandler方法已由/CustomerMessageHandler/CustomerMessageHandler_Event.cs完成，
    /// 此文件不再更新。
    /// </summary>
    public class Service
    {
        public static class Server
        {
            private static string _appDomainAppPath;
            public static string AppDomainAppPath
            {
                get
                {
                    if (_appDomainAppPath == null)
                    {
                        _appDomainAppPath = HttpRuntime.AppDomainAppPath;
                    }
                    return _appDomainAppPath;
                }
                set
                {
                    _appDomainAppPath = value;
                }
            }

            public static string GetMapPath(string virtualPath)
            {
                if (virtualPath == null)
                {
                    return "";
                }
                else if (virtualPath.StartsWith("~/"))
                {
                    return virtualPath.Replace("~/", AppDomainAppPath).Replace("/", "\\");
                }
                else
                {
                    return Path.Combine(AppDomainAppPath, virtualPath.Replace("/", "\\"));
                }
            }

            public static HttpContext HttpContext
            {
                get
                {
                    HttpContext context = HttpContext.Current;
                    if (context == null)
                    {
                        HttpRequest request = new HttpRequest("Default.aspx", "http://sdk.weixin.senparc.com/default.aspx", null);
                        StringWriter sw = new StringWriter();
                        HttpResponse response = new HttpResponse(sw);
                        context = new HttpContext(request, response);
                    }
                    return context;
                }
            }
        }
    }
}