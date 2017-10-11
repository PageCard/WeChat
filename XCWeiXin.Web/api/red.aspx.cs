using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.api
{
    public partial class red : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mchbillno = DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(28);

            string nonceStr = TenPayV3Util.GetNoncestr();
            RequestHandler packageReqHandler = new RequestHandler(null);

            packageReqHandler.SetParameter("nonce_str", nonceStr);              //随机字符串
            packageReqHandler.SetParameter("wxappid", "wx172ece37e2ed2939");		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", "1403543902");		  //商户号
            packageReqHandler.SetParameter("mch_billno", mchbillno);                 //填入商家订单号
            packageReqHandler.SetParameter("send_name", "测试红包");                 //红包发送者名称
            packageReqHandler.SetParameter("re_openid", "接受收红包的用户的openId");                 //接受收红包的用户的openId
            packageReqHandler.SetParameter("total_amount", "300");                //付款金额，单位分
            packageReqHandler.SetParameter("total_num", "3");               //红包发放总人数  必须介于(包括)3到20之间
            packageReqHandler.SetParameter("wishing", "红包祝福语");               //红包祝福语
            packageReqHandler.SetParameter("amt_type", "ALL_RAND");               //红包金额设置方式ALL_RAND—全部随机,商户指定总金额和红包发放总人数，由微信支付随机计算出各红包金额
            //packageReqHandler.SetParameter("amt_list", "各红包具体金额");               //各红包具体金额，自定义金额时必须设置，单位分  示例值"200|100|100"
            packageReqHandler.SetParameter("act_name", "测试红包");   //活动名称
            packageReqHandler.SetParameter("remark", "备注信息");   //备注信息
            string sign = packageReqHandler.CreateMd5Sign("key", "70OvzuXGLFP7539B9zbvEMUBd1H1Tv8Q");
            packageReqHandler.SetParameter("sign", sign);	                    //签名
            //发红包需要post的数据
            string data = packageReqHandler.ParseXML();

            //发红包接口地址
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendgroupredpack";
            //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
            string cert = @"F:\apiclient_cert.p12";
            //私钥（在安装证书时设置）
            string password = "";
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


        }
        #region 裂变红包

        /// <summary>
        /// 目前支持向指定微信用户的openid发放指定金额红包
        /// 注意total_amount、min_value、max_value值相同
        /// total_num=1固定
        /// 单个红包金额介于[1.00元，200.00元]之间
        /// </summary>
        /// <returns></returns>




        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }
        #endregion 
    }
}