using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace XCWeiXin.API.Payment.wxpay
{

    public class Example
    {
        public static void Main(String[] args)
        {
            try
            {
                WxPayHelper wxPayHelper = new WxPayHelper();
                //�����û�����Ϣ
                wxPayHelper.SetAppId("wxf8b4f85f3a794e77");
                wxPayHelper.SetAppKey("2Wozy2aksie1puXUBpWD8oZxiD1DfQuEaiC7KcRATv1Ino3mdopKaPGQQ7TtkNySuAmCaDCrw4xhPY5qKTBl7Fzm0RgR3c0WaVYIXZARsxzHV2x7iwPPzOz94dnwPWSn");
                wxPayHelper.SetPartnerKey("8934e7d15453e97507ef794cf7b0519d");
                wxPayHelper.SetSignType("sha1");
                //��������package��Ϣ
                wxPayHelper.SetParameter("bank_type", "WX");
                wxPayHelper.SetParameter("body", "test");
                wxPayHelper.SetParameter("partner", "1900000109");
                wxPayHelper.SetParameter("out_trade_no", CommonUtil.CreateNoncestr());
                wxPayHelper.SetParameter("total_fee", "1");
                wxPayHelper.SetParameter("fee_type", "1");
                wxPayHelper.SetParameter("notify_url", "htttp://www.baidu.com");
                wxPayHelper.SetParameter("spbill_create_ip", "127.0.0.1");
                wxPayHelper.SetParameter("input_charset", "GBK");

                System.Console.Out.WriteLine("����app֧��package:");
                System.Console.Out.WriteLine(wxPayHelper.CreateAppPackage("test"));
                System.Console.Out.WriteLine("����jsapi֧��package:");
                System.Console.Out.WriteLine(wxPayHelper.CreateBizPackage());
                System.Console.Out.WriteLine("����ԭ��֧��url:");
                System.Console.Out.WriteLine(wxPayHelper.CreateNativeUrl("abc"));
                System.Console.Out.WriteLine("����ԭ��֧��package:");
                System.Console.Out.WriteLine(wxPayHelper.CreateNativePackage("0", "ok"));


            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine(e.Message);
            }

        }

    }
}
