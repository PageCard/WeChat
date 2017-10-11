using System;
using XCWeiXin.Common;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using XCWeiXin.BLL;
using XCWeiXin.Common;
using System.Collections.Generic;
using System.Data;

namespace XCWeiXin.Web.api.payment.wxpay
{
    public partial class apply_for_refund : System.Web.UI.Page
    {
        private static TenPayV3Info _tenPayV3Info;

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }
        public string amount = "";///订单总金额
        public string litout_trade_no = ""; ///订单号
        protected void Page_Load(object sender, EventArgs e)
        {
            Apply_refund();
        }
        public string Apply_refund()
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
            amount = orderEntity.order_amount.ToString();
            string nonceStr = TenPayV3Util.GetNoncestr();
            RequestHandler packageReqHandler = new RequestHandler(null);

            //设置package订单参数
            packageReqHandler.SetParameter("appid", paymentInfo.appId);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", paymentInfo.partnerId);		  //商户号
            packageReqHandler.SetParameter("out_trade_no", orderEntity.order_no);                 //填入商家订单号
            packageReqHandler.SetParameter("out_refund_no", orderEntity.order_no);                //填入退款订单号
            packageReqHandler.SetParameter("total_fee", amount);               //填入总金额
            packageReqHandler.SetParameter("refund_fee", amount);               //填入退款金额
            packageReqHandler.SetParameter("op_user_id", paymentInfo.partnerId);   //操作员Id，默认就是商户号
            packageReqHandler.SetParameter("nonce_str", nonceStr);              //随机字符串
            string sign = packageReqHandler.CreateMd5Sign("key", paymentInfo.paySignKey);
            packageReqHandler.SetParameter("sign", sign);	                    //签名
            //退款需要post的数据
            string data = packageReqHandler.ParseXML();
         
           
            //退款接口地址
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
            string cert = MyCommFun.GetRootPath() + paymentInfo.CertInfoPath; 
           
            //私钥（在安装证书时设置）
            string password = paymentInfo.partnerPwd;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //调用证书
            X509Certificate2 cer = new X509Certificate2(cert, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);

            #region 发起post请求
            HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webrequest.ClientCertificates.Add(cer);
            webrequest.Method = "post";

            byte[] postdatabyte = Encoding.UTF8.GetBytes(data);
            webrequest.ContentLength = postdatabyte.Length;
            Stream stream;
            stream = webrequest.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length);
            stream.Close();

            HttpWebResponse httpWebResponse = (HttpWebResponse)webrequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();
            #endregion

            var res = XDocument.Parse(responseContent);
            string openid = res.Element("xml").Element("out_refund_no").Value;

            return openid;
        }
    }
}