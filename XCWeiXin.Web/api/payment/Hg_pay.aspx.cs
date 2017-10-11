using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Xml.Linq;
using XCWeiXin.Common;
using ZXing.Common;
using ZXing;
using System.IO;
using System.Drawing.Imaging;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.api.payment
{
    public partial class Hg_pay : System.Web.UI.Page
    {
      
        public string payaddid = "";
        public string paytimeStamp = "";
        public string paynonceStr = "";
        public string paypaySign = "";
        public string paypackageValue = "";
        public int getwid = 0, getorderId = 0;
        public string litout_trade_no, litDate;
        public double litMoney;
        public string order_dd = "";
        public string oreder_name = "";
        public int hg_number = 0;
        public string order_type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            order_type = Request.QueryString["order_type"];
            order_dd = Request.QueryString["Order_dd"];
            BLL.HG.Hg_list order_T = new BLL.HG.Hg_list();
            if (order_type == "new")
            {
                Model.HG.A_HG_new_order model = order_T.getorder(order_dd);
                string timeStamp = "";
            string nonceStr = "";
            string paySign = "";
            //创建支付应答对象
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler packageReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            //初始化
            packageReqHandler.Init();
            litMoney = double.Parse(model.total);
            timeStamp = TenPayV3Util.GetTimestamp();
            nonceStr = TenPayV3Util.GetNoncestr();

            //设置package订单参数
            packageReqHandler.SetParameter("appid", "wx172ece37e2ed2939");		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", "1403543902");		  //商户号
            packageReqHandler.SetParameter("nonce_str", nonceStr);                    //随机字符串
            packageReqHandler.SetParameter("body", model.Name_+"服务");    //商品信息
            packageReqHandler.SetParameter("out_trade_no", order_dd);		//商家订单号
            packageReqHandler.SetParameter("total_fee", ((double.Parse(model.total))*100).ToString());			        //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
            packageReqHandler.SetParameter("notify_url", MyCommFun.getWebSite() + "/api/wxpay/notify_url.aspx?wid=" + 44 + "|" +order_dd);		    //接收财付通通知的URL
            packageReqHandler.SetParameter("trade_type", TenPayV3Type.JSAPI.ToString());	                    //交易类型
            packageReqHandler.SetParameter("openid", model.Openid_);	                    //用户的openId

            string sign = packageReqHandler.CreateMd5Sign("key", "70OvzuXGLFP7539B9zbvEMUBd1H1Tv8Q");
            packageReqHandler.SetParameter("sign", sign);	                    //签名
            string data = packageReqHandler.ParseXML();

        
            var result = TenPayV3.Unifiedorder(data);
            var res = XDocument.Parse(result);
            string prepayId = res.Element("xml").Element("prepay_id").Value;

            //设置支付参数
            RequestHandler paySignReqHandler = new RequestHandler(null);
            paySignReqHandler.SetParameter("appId", "wx172ece37e2ed2939");
            paySignReqHandler.SetParameter("timeStamp", timeStamp);
            paySignReqHandler.SetParameter("nonceStr", nonceStr);
            paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
            paySignReqHandler.SetParameter("signType", "MD5");
            paySign = paySignReqHandler.CreateMd5Sign("key", "70OvzuXGLFP7539B9zbvEMUBd1H1Tv8Q");
            payaddid = "";
            paytimeStamp = timeStamp;
            paynonceStr = nonceStr;
            paypackageValue = string.Format("prepay_id={0}", prepayId);
            paypaySign = paySign;
            litDate = DateTime.Now.ToString();
            oreder_name = model.Name_ + "服务预约";
            }

            
            else {
                hg_number = int.Parse(Request.QueryString["kkl"]); 
            Model.HG.HG_order model = order_T.Getorder(order_dd);
           
            string timeStamp = "";
            string nonceStr = "";
            string paySign = "";
            //创建支付应答对象
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler packageReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            //初始化
            packageReqHandler.Init();
            litMoney = model.Total;
            timeStamp = TenPayV3Util.GetTimestamp();
            nonceStr = TenPayV3Util.GetNoncestr();

            //设置package订单参数
            packageReqHandler.SetParameter("appid", "wx172ece37e2ed2939");		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", "1403543902");		  //商户号
            packageReqHandler.SetParameter("nonce_str", nonceStr);                    //随机字符串
            packageReqHandler.SetParameter("body", model.By_name+"护理");    //商品信息
            packageReqHandler.SetParameter("out_trade_no", order_dd);		//商家订单号
            packageReqHandler.SetParameter("total_fee", ((model.Total)*100).ToString());			        //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
            packageReqHandler.SetParameter("notify_url", MyCommFun.getWebSite() + "/api/wxpay/notify_url.aspx?wid=" + 44 + "|" +order_dd);		    //接收财付通通知的URL
            packageReqHandler.SetParameter("trade_type", TenPayV3Type.JSAPI.ToString());	                    //交易类型
            packageReqHandler.SetParameter("openid", model.Openid);	                    //用户的openId

            string sign = packageReqHandler.CreateMd5Sign("key", "70OvzuXGLFP7539B9zbvEMUBd1H1Tv8Q");
            packageReqHandler.SetParameter("sign", sign);	                    //签名
            string data = packageReqHandler.ParseXML();

        
            var result = TenPayV3.Unifiedorder(data);
            var res = XDocument.Parse(result);
            string prepayId = res.Element("xml").Element("prepay_id").Value;

            //设置支付参数
            RequestHandler paySignReqHandler = new RequestHandler(null);
            paySignReqHandler.SetParameter("appId", "wx172ece37e2ed2939");
            paySignReqHandler.SetParameter("timeStamp", timeStamp);
            paySignReqHandler.SetParameter("nonceStr", nonceStr);
            paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
            paySignReqHandler.SetParameter("signType", "MD5");
            paySign = paySignReqHandler.CreateMd5Sign("key", "70OvzuXGLFP7539B9zbvEMUBd1H1Tv8Q");
            payaddid = "";
            paytimeStamp = timeStamp;
            paynonceStr = nonceStr;
            paypackageValue = string.Format("prepay_id={0}", prepayId);
            paypaySign = paySign;
            litDate = DateTime.Now.ToString();
            oreder_name = model.By_name + "护理预约";
            }

        }

        /// <summary>
        /// 微信发送模板消息
        /// </summary>
        public void SendTemplateMessageTest_hg()
        {
            //            您好，已为您成功预约上门服务。
            //项目：高级美甲
            //时间：2015年10月1日14:00~16:00
            //技师：志玲
            //费用：98元
            //地址：西安市雁塔区曲江金地湖城大境
            //2015年9月28日 16:36
            //            {{first.DATA}}
            //客户姓名：{{keyword1.DATA}}
            //联系电话：{{keyword2.DATA}}
            //上门时间：{{keyword3.DATA}}
            //支付信息：{{keyword4.DATA}}
            //服务地址：{{keyword5.DATA}}
            //{{remark.DATA}}
            //            你好，你收到一个新订单
            //客户姓名：张三丰
            //联系电话：13515812621
            //上门时间：2015年5月26日 12:00
            //支付信息：微信支付  ￥200.00
            //服务地址：上海市浦东新区环林西路
            //请联系你的客户，并及时提供服务  int number = int.Parse(Request.QueryString["kk"]);
            BLL.HG.Hg_list order_T = new BLL.HG.Hg_list();
            int Hg_number = int.Parse(Request.QueryString["kk"]);
            Model.HG.HGlist model_hg = order_T.Getmodel(Hg_number);
            Model.HG.HG_order model = order_T.Getorder(Request.QueryString["order"]);

            var openId = model_hg.open_id_hg;//换成已经关注用户的openId
            var templateId = "6oFH4updt21Zfwbks6O7erhZRlOI6jS3Yju8l9qFsw4";//换成已经在微信后台添加的模板Id
            var accessToken = Token();
            var testData = new //TestTemplateData()
            {
                first = new TemplateDataItem("您好，新订单通知"),
                keyword1 = new TemplateDataItem(model.Nursing_name),
                keyword2 = new TemplateDataItem(model.Nursing_tel),
                keyword3 = new TemplateDataItem(model.Service_time),
                keyword4 = new TemplateDataItem("微信支付：" + (model.Total).ToString() + "元"),
                keyword5 = new TemplateDataItem(model.By_adress),
                remark = new TemplateDataItem("请联系你的客户，并及时提供服务")
            };
            var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId, "#FF0000", "http://www.hugongll.com/templates/Doc/Hugo_list/Login.aspx", testData);


        }
        public string Token()
        {

            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(44, out error);
            return accessToken;


        }
        //扫码支付
        //public void ff()
        //{
        //    RequestHandler packageReqHandler = new RequestHandler(null);

        //    var sp_billno = DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(28);
        //    var nonceStr = TenPayV3Util.GetNoncestr();

        //    //商品Id，用户自行定义
        //    string productId = DateTime.Now.ToString("yyyyMMddHHmmss");

        //    //创建请求统一订单接口参数
        //    packageReqHandler.SetParameter("appid", TenPayV3Info.AppId);
        //    packageReqHandler.SetParameter("mch_id", TenPayV3Info.MchId);
        //    packageReqHandler.SetParameter("nonce_str", nonceStr);
        //    packageReqHandler.SetParameter("body", "test");
        //    packageReqHandler.SetParameter("out_trade_no", sp_billno);
        //    packageReqHandler.SetParameter("total_fee", "1");
        //    packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress);
        //    packageReqHandler.SetParameter("notify_url", TenPayV3Info.TenPayV3Notify);
        //    packageReqHandler.SetParameter("trade_type", TenPayV3Type.NATIVE.ToString());
        //    packageReqHandler.SetParameter("product_id", productId);

        //    string sign = packageReqHandler.CreateMd5Sign("key", TenPayV3Info.Key);
        //    packageReqHandler.SetParameter("sign", sign);

        //    string data = packageReqHandler.ParseXML();

        //    //调用统一订单接口
        //    var result = TenPayV3.Unifiedorder(data);
        //    var unifiedorderRes = XDocument.Parse(result);
        //    string codeUrl = unifiedorderRes.Element("xml").Element("code_url").Value;

        //    BitMatrix bitMatrix;
        //    bitMatrix = new MultiFormatWriter().encode(codeUrl, BarcodeFormat.QR_CODE, 600, 600);
        //    BarcodeWriter bw = new BarcodeWriter();

        //    var ms = new MemoryStream();
        //    var bitmap = bw.Write(bitMatrix);
        //    bitmap.Save(ms, ImageFormat.Png);
        //    //return File(ms, "image/png");
        //    ms.WriteTo(Response.OutputStream);
        //    Response.ContentType = "image/png";
          
        //}
    }
}