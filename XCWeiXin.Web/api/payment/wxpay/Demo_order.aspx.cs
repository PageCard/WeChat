using System;
using XCWeiXin.Common;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Xml.Linq;


namespace XCWeiXin.Web.api.payment.wxpay
{
    public partial class Demo_order : System.Web.UI.Page
    {
        public string context = "";
        public string openid = "";
        public string litout_trade_no = "";
        public string openids = "";

      
     
        protected void Page_Load(object sender, EventArgs e)
        {

            OrderQuery();
            string context = OrderQuery().ToString();

        }
       
        public string OrderQuery()
        {
            //int orderId = MyCommFun.RequestInt("orderid");
            //int wid = MyCommFun.RequestInt("wid");
            //string code = MyCommFun.RequestParam("code");
            //string state = MyCommFun.RequestParam("state");
            //BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            //Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);
            //BLL.wx_userweixin wx = new BLL.wx_userweixin();
            //Model.wx_userweixin wxModel = wx.GetModel(wid);
            //BLL.orders otBll = new BLL.orders();
            //Model.orders orderEntity = otBll.GetModel(orderId, wid);
            //litout_trade_no = orderEntity.order_no;
            string nonceStr = TenPayV3Util.GetNoncestr();
            RequestHandler packageReqHandler = new RequestHandler(null);

            //设置package订单参数
            packageReqHandler.SetParameter("appid", "wx57d365e74490cf2f");		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", "1261485801");		  //商户号
            packageReqHandler.SetParameter("transaction_id", "");       //填入微信订单号 
            packageReqHandler.SetParameter("out_trade_no", "0908322087037927");         //填入商家订单号
            packageReqHandler.SetParameter("nonce_str", nonceStr);             //随机字符串
            string sign = packageReqHandler.CreateMd5Sign("key", "Hk80BEC2ChK727L4W6845133519F3lD6");
            packageReqHandler.SetParameter("sign", sign);	                    //签名

            string data = packageReqHandler.ParseXML();

            var result = TenPayV3.OrderQuery(data);
            var res = XDocument.Parse(result);
            openid = res.Element("xml").Element("sign").Value;
            string transaction_id = res.Element("xml").Element("sign").Value;
            openids = res.Element("xml").Element("openid").Value;
            return openid;

        }
    }
}