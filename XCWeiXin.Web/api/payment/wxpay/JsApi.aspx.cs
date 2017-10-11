using System;
using XCWeiXin.Common;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Xml.Linq;

namespace XCWeiXin.Web.api.payment.wxpay
{
    /// <summary>
    ///  维权接口页面
    /// </summary>
    public partial class JsApi : System.Web.UI.Page
    {
        public string payaddid = "";
        public string paytimeStamp = "";
        public string paynonceStr = "";
        public string paypaySign = "";
        public string paypackageValue = "";
        public int getwid = 0, getorderId=0;
        public string litout_trade_no, litDate;
        public int litMoney;
        protected void Page_Load(object sender, EventArgs e)
        {
           int orderId= MyCommFun.RequestInt("orderid");           
           int wid = MyCommFun.RequestInt("wid");
           getwid = wid;
           getorderId = orderId;
            string code = MyCommFun.RequestParam("code");
            string state = MyCommFun.RequestParam("state");
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);
            BLL.wx_userweixin wx = new BLL.wx_userweixin();
            Model.wx_userweixin wxModel = wx.GetModel(wid);
            BLL.orders otBll = new BLL.orders();

            Model.orders orderEntity = otBll.GetModel(orderId, wid);
            
            litout_trade_no = orderEntity.order_no;
            litMoney = Decimal.ToInt32(orderEntity.order_amount);
            litDate = orderEntity.add_time.ToString();

            

            if (string.IsNullOrEmpty(code))
            {
                Response.Write("您拒绝了授权！");
                return;
            }

            if (!state.Contains("|"))
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                Response.Write("验证失败！请从正规途径进入！1001");
                return;
            }

            ////获取产品信息
            //var stateData = state.Split('|');
            //int productId = 0;
         
            //if (int.TryParse(stateData[0], out productId))
            //{
            //    int hc = 0;
            //    if (int.TryParse(stateData[1], out hc))
            //    {
            //        var products = ProductModel.GetFakeProductList();
            //        product = products.FirstOrDefault(z => z.Id == productId);
            //        if (product == null || product.GetHashCode() != hc)
            //        {
            //            return Content("商品信息不存在，或非法进入！1002");
            //        }
            //        ViewData["product"] = product;
            //    }
            //}

            //通过，用code换取access_token
            var openIdResult = OAuthApi.GetAccessToken(PayV3Config.Mch_appId, PayV3Config.Mch_Secret, code);
            if (openIdResult.errcode != ReturnCode.请求成功)
            {
                Response.Write("错误：" + openIdResult.errmsg);
                return;
            }

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
          //  packageReqHandler.SetParameter("appid", paymentInfo.appId);		  //公众账号ID
        ///    packageReqHandler.SetParameter("mch_id", paymentInfo.partnerId);		  //商户号

            packageReqHandler.SetParameter("appid",PayV3Config.Mch_appId);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", PayV3Config.Mch_mchid);		  //商户号
            ////
            packageReqHandler.SetParameter("sub_appid", paymentInfo.appId);		  //子商户公众账号ID
            packageReqHandler.SetParameter("sub_mch_id", paymentInfo.partnerId);		  //子商户号mch_id
            ///


            packageReqHandler.SetParameter("nonce_str", nonceStr);                    //随机字符串
            packageReqHandler.SetParameter("body", orderId.ToString());    //商品信息
            packageReqHandler.SetParameter("out_trade_no", litout_trade_no);		//商家订单号
            packageReqHandler.SetParameter("total_fee", (litMoney*100).ToString());			        //product == null ? "100" : (product.Price * 100).ToString()商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
            packageReqHandler.SetParameter("notify_url", MyCommFun.getWebSite() + "/api/wxpay/notify_url.aspx?wid="+ wid + "|"+ orderId);		    //接收财付通通知的URL
            packageReqHandler.SetParameter("trade_type", TenPayV3Type.JSAPI.ToString());	                    //交易类型
            packageReqHandler.SetParameter("openid", openIdResult.openid);	                    //用户的openId
       
         //   string sign = packageReqHandler.CreateMd5Sign("key", paymentInfo.paySignKey);
            string sign = packageReqHandler.CreateMd5Sign("key", PayV3Config.Mch_Key);
            packageReqHandler.SetParameter("sign", sign);	                    //签名

            string data = packageReqHandler.ParseXML();
           
            var result = TenPayV3.Unifiedorder(data);
         
            var res = XDocument.Parse(result);
            string prepayId = res.Element("xml").Element("prepay_id").Value;
            //设置支付参数
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler paySignReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            paySignReqHandler.SetParameter("appId", PayV3Config.Mch_appId);
            paySignReqHandler.SetParameter("timeStamp", timeStamp);
            paySignReqHandler.SetParameter("nonceStr", nonceStr);
            paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
            paySignReqHandler.SetParameter("signType", "MD5");
            paySign = paySignReqHandler.CreateMd5Sign("key", PayV3Config.Mch_Key);



            payaddid = PayV3Config.Mch_appId;
            paytimeStamp = timeStamp;
            paynonceStr = nonceStr;
            paypackageValue = string.Format("prepay_id={0}", prepayId); 
            paypaySign = paySign;

        }

    }
}