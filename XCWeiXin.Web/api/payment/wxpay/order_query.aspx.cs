using System;
using XCWeiXin.Common;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Xml.Linq;

namespace XCWeiXin.Web.api.payment.wxpay
{
    public partial class order_query : System.Web.UI.Page
    {
        public string context = "";
        public string openid = "";
        public string litout_trade_no = "";
        public string openids = "";
        public string bank_type = ""; //支付方式
        public string total_fee = "";//总金额
        public string time_end = ""; ///付款时间
        public string out_trade_no = "";///商家订单号
        public string transaction_id = ""; /// 微信生成的支付订单号    
        public string result_code = "";  //交易状态
        protected void Page_Load(object sender, EventArgs e)
        {

            OrderQuery();
            string context = OrderQuery().ToString();

        }

        public string OrderQuery()
        {

            int orderId = MyCommFun.RequestInt("orderid");
            int wid = MyCommFun.RequestInt("wid");
            string code = MyCommFun.RequestParam("code");
            string state = MyCommFun.RequestParam("state");
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);
            BLL.wx_userweixin wx = new BLL.wx_userweixin();
            Model.wx_userweixin wxModel = wx.GetModel(wid);
            BLL.orders otBll = new BLL.orders();
            Model.orders orderEntity = otBll.GetModel(orderId, wid);
            litout_trade_no = orderEntity.order_no;
            string nonceStr = TenPayV3Util.GetNoncestr();
            RequestHandler packageReqHandler = new RequestHandler(null);

            //设置package订单参数
            packageReqHandler.SetParameter("appid", paymentInfo.appId);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", paymentInfo.partnerId);		  //商户号
            packageReqHandler.SetParameter("transaction_id", "");       //填入微信订单号 
            packageReqHandler.SetParameter("out_trade_no", litout_trade_no);         //填入商家订单号
            packageReqHandler.SetParameter("nonce_str", nonceStr);             //随机字符串
            string sign = packageReqHandler.CreateMd5Sign("key", paymentInfo.paySignKey);
            packageReqHandler.SetParameter("sign", sign);	                    //签名

            string data = packageReqHandler.ParseXML();

            var result = TenPayV3.OrderQuery(data);
            var res = XDocument.Parse(result);
            openid = res.Element("xml").Element("sign").Value;
            string transaction_id = res.Element("xml").Element("sign").Value;
            openids = res.Element("xml").Element("openid").Value;
            bank_type = res.Element("xml").Element("bank_type").Value;
            if (bank_type == "CNY")
            {
                bank_type = "钱包零钱";
            }
            if (bank_type == "CFT")
            {
                bank_type = "银行卡";
            }
            total_fee = res.Element("xml").Element("total_fee").Value;
            time_end = res.Element("xml").Element("time_end").Value;
            out_trade_no = res.Element("xml").Element("out_trade_no").Value;
            transaction_id = res.Element("xml").Element("transaction_id").Value;
            result_code = res.Element("xml").Element("result_code").Value;

            return openid;

        }



    }
}
    