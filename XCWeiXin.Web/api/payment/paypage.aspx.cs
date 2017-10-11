using XCWeiXin.API.Payment.wxpay;
using XCWeiXin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.TenPayLib;
using Senparc.Weixin.MP.TenPayLibV3;
using Senparc.Weixin;
using System.Xml.Linq;

namespace XCWeiXin.Web.api.payment
{
    public partial class paypage : System.Web.UI.Page
    {

        public String packageValue = "";
        protected int wid = 0;
        protected string openid = "";
        /// <summary>
        /// 订单付款的有效持续时间（单位为分）
        /// </summary>
        protected int expireMinute = 0;
        public string payaddid = "";
        public string paytimeStamp = "";
        public string paynonceStr = "";
        public string paypaySign = "";
        public string paypackageValue = "";

        private static TenPayInfo _tenPayInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            openid = MyCommFun.RequestOpenid();
            int otid = MyCommFun.RequestInt("orderid");
            wid = MyCommFun.RequestInt("wid");
            expireMinute = MyCommFun.RequestInt("expireminute");
            if (expireMinute == 0)
            {
                expireMinute = 30;
            }
            else if(expireMinute==-1)
            {  //如果为-1，则有限期间为1年
                expireMinute = 60 * 12 * 365;
            }
            if (openid == "" || otid == 0 || wid==0)
            {
                return;
            }
            BLL.orders otBll = new BLL.orders();
            Model.orders orderEntity = otBll.GetModel(otid,wid);
            litout_trade_no.Text = orderEntity.order_no;
            litMoney.Text = orderEntity.order_amount.ToString();
            litDate.Text = orderEntity.add_time.ToString();
            WxPayData(orderEntity.order_amount, orderEntity.id.ToString(), orderEntity.order_no);
        }
        //public static TenPayInfo TenPayInfo
        //{
        //    get
        //    {
        //        if (_tenPayInfo == null)
        //        {
        //            _tenPayInfo =
        //                TenPayInfoCollection.Data[System.Configuration.ConfigurationManager.AppSettings["WeixinPay_PartnerId"]];
        //        }
        //        return _tenPayInfo;
        //    }
        //}
        /// <summary>
        /// 微信支付：生成请求数据
        /// </summary>
        /// <param name="openid">微信用户id</openid>
        /// <param name="ttFee">商品总价格</param>
        /// <param name="busiBody"></param>
        /// <returns></returns>
        protected void WxPayData(decimal ttFee, string busiBody, string out_trade_no)
        {
            WxPayHelper wxPayHelper = new WxPayHelper();
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

            // //先设置基本信息
            // string partnerId = paymentInfo.partnerId;// "1218574001";//  
            // string appId = paymentInfo.appId;// "wxa9b8e33e48ac5e0f";// 
            // string partnerKey = paymentInfo.partnerKey;// "huyuxianghuyuxianghuyuxiang12345";//  
            // //paysignkey(非appkey) 
            // string appKey = paymentInfo.paySignKey; //"nwRmqgvSG08pe3vU5qzBLb7Bvih0WOABGzUPvqgFqE0iSkJlJ8wh7JlLYy2cXFgFA3v1bM8eTDm1y1UcyeW9IGq2py2qei7J5xDoVR9lfO3cS6fMjFbMQeeqBRit0bKp";// 

            // wxPayHelper.SetAppId(appId);
            // wxPayHelper.SetAppKey(appKey);
            // wxPayHelper.SetPartnerKey(partnerKey);
            // wxPayHelper.SetSignType("SHA1");
            // //设置请求package信息
            // wxPayHelper.SetParameter("bank_type", "WX");
            // wxPayHelper.SetParameter("body", busiBody);
            // wxPayHelper.SetParameter("attach",wid+"|"+busiBody);
            // wxPayHelper.SetParameter("partner", partnerId);
            // wxPayHelper.SetParameter("out_trade_no", out_trade_no);
            // wxPayHelper.SetParameter("total_fee", ((int)(ttFee * 100)).ToString());
            // wxPayHelper.SetParameter("fee_type", "1");
            //// wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx?wid="+wid);

            // wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx");//不能带参数
            // wxPayHelper.SetParameter("spbill_create_ip", MXRequest.GetIP());
            // wxPayHelper.SetParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            // //---------有效期截至日期------

            // wxPayHelper.SetParameter("time_expire", DateTime.Now.AddMinutes(expireMinute).ToString("yyyyMMddHHmmss"));

            // wxPayHelper.SetParameter("input_charset", "UTF-8");
            // packageValue = wxPayHelper.CreateBizPackage();

            ///////////////////////////////////////////////////////////////////////////


            //通过，用code换取access_token
            //var openIdResult = OAuthApi.GetAccessToken(paymentInfo.appId, "a891edd957f2aede546f9256096bf95a", code);
            //if (openIdResult.errcode != ReturnCode.请求成功)
            //{
            //    return Content("错误：" + openIdResult.errmsg);
            //}

            string timeStamp = "";
            string nonceStr = "";
            string paySign = "";

            string sp_billno = Request["order_no"];
            //当前时间 yyyyMMdd
            string date = DateTime.Now.ToString("yyyyMMdd");

            if (null == sp_billno)
            {
                //生成订单10位序列号，此处用时间和随机数生成，商户根据自己调整，保证唯一
                sp_billno = DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(28);
            }
            else
            {
                sp_billno = Request["order_no"].ToString();
            }

            //创建支付应答对象
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler packageReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            //初始化
            packageReqHandler.Init();

            timeStamp = TenPayV3Util.GetTimestamp();
            nonceStr = TenPayV3Util.GetNoncestr();

            //设置package订单参数
            packageReqHandler.SetParameter("appid", paymentInfo.appId);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", paymentInfo.partnerId);		  //商户号
            packageReqHandler.SetParameter("nonce_str", nonceStr);                    //随机字符串
            packageReqHandler.SetParameter("body", "aaa");    //商品信息
            packageReqHandler.SetParameter("out_trade_no", sp_billno);		//商家订单号
            packageReqHandler.SetParameter("total_fee", "100");			        //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
            packageReqHandler.SetParameter("notify_url", "http://ddd.com");		    //接收财付通通知的URL
            packageReqHandler.SetParameter("trade_type", Senparc.Weixin.MP.TenPayV3Type.JSAPI.ToString());	                    //交易类型
            packageReqHandler.SetParameter("openid", "oFo2Hjq6_yMhyz6cQ2MZtmxODOVU");	                    //用户的openId

            string sign = packageReqHandler.CreateMd5Sign("key", paymentInfo.partnerKey);
            packageReqHandler.SetParameter("sign", sign);	                    //签名

            string data = packageReqHandler.ParseXML();

            var result = TenPayV3.Unifiedorder(data);
            var res = XDocument.Parse(result);
            string prepayId = res.Element("xml").Element("prepay_id").Value;

            //设置支付参数
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler paySignReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            paySignReqHandler.SetParameter("appId", paymentInfo.appId);
            paySignReqHandler.SetParameter("timeStamp", timeStamp);
            paySignReqHandler.SetParameter("nonceStr", nonceStr);
            paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
            paySignReqHandler.SetParameter("signType", "MD5");
            paySign = paySignReqHandler.CreateMd5Sign("key", paymentInfo.partnerKey);

            payaddid = paymentInfo.appId;
            paytimeStamp = timeStamp;
            paynonceStr = nonceStr;
            paypackageValue = packageValue;
            paypaySign = paySign;



        }

    }
}