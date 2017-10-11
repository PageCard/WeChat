using LitJson;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using XCWeiXin.Common;
using XCWeiXin.DBUtility;


namespace XCWeiXin.Web.api.payment
{
    /// <summary>
    /// zql 的摘要说明
    /// </summary>
    public class zql : IHttpHandler
    {

     
        public string payaddid = "";
        public string paytimeStamp = "";
        public string paynonceStr = "";
        public string paypaySign = "";
        public string paypackageValue = "";
        public int getwid = 0, getorderId = 0;
        public string litout_trade_no, litDate;
        public string litMoney;
        public string order_dd = "";
        public string oreder_name = "";
        public int hg_number = 0;
        public string order_type = "";

        public void ProcessRequest(HttpContext context)
        {
            Model.HG.A_HG_new_order Str = new Model.HG.A_HG_new_order();

            BLL.HG.Hg_list add = new BLL.HG.Hg_list();
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            jsonDict = new Dictionary<string, string>();
            string case_ = context.Request.QueryString["case_"];
            if (case_ == "save")
            {
                //  string openid=context.Request.QueryString["openid"];
                string name = context.Request.QueryString["name"];
                string phone = context.Request.QueryString["phone"];
                string sex = context.Request.QueryString["sex"];
                string money = context.Request.QueryString["money"];
                string type_ = context.Request.QueryString["type_"];
                string time = context.Request.QueryString["time"];
                string day = context.Request.QueryString["day"];
                string adress = context.Request.QueryString["adress"];
                string weixiname=context.Request.QueryString["weixinname"];
                string openid=context.Request.QueryString["openid"];
                //   string total=context.Request.QueryString["total"];
                //   Str.Openid_ = openid;
                Str.Name_ = name;
                Str.Tel_ = phone;
                Str.Sex_ = sex;
                Str.Pick_many = money;
                Str.Type_ = type_;
                Str.Time_ = time;
                Str.start_time = DateTime.Now.ToString();//开始时间
                Str.Pick_day = day;
                Str.Weixin_name = weixiname;
                Str.Openid_ = openid;
                int day_ = int.Parse(day);
                int money_ = int.Parse(money);
                int total_ = day_ * money_;
                Str.total = total_.ToString();
                string bb=DateTime.Now.Day.ToString() + GuidTo16String();//生成的订单号
                Str.Order_dd = bb;
                Str.Order_from = "小程序";
                Str.Fw_zt = "未支付";
                Str.Delet_ = "未删除";
                Str.Adress = adress;
                int fal = add.Add_order_new(Str);
                //   Str.total = total;
                if (fal== 0)
                {


                    jsonDict.Add("order_dd",bb);
                    jsonDict.Add("errCode", "false");
                    jsonDict.Add("recontent", fal.ToString());
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }
                else
                {
                    jsonDict.Add("order_dd", bb);
                    jsonDict.Add("errCode", "true");
                    jsonDict.Add("recontent", fal.ToString());
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                }

            }
            else if (case_ == "jujia")
            {
                {
                    //  string openid=context.Request.QueryString["openid"];
                    string name = context.Request.QueryString["name"];
                    string phone = context.Request.QueryString["phone"];
                    string sex = context.Request.QueryString["sex"];
                    string money = context.Request.QueryString["money"];
                    string type_ = context.Request.QueryString["type_"];
                    string time = context.Request.QueryString["time"];
                    string day = context.Request.QueryString["day"];
                    string adress = context.Request.QueryString["adress"];
                    string weixiname = context.Request.QueryString["weixinname"];
                    string openid = context.Request.QueryString["openid"];
                    //   string total=context.Request.QueryString["total"];
                    //   Str.Openid_ = openid;
                    Str.Name_ = name;
                    Str.Tel_ = phone;
                    Str.Sex_ = sex;
                    Str.Pick_many = money;
                    Str.Type_ = type_;
                    Str.Time_ = time;
                    Str.start_time = DateTime.Now.ToString();//开始时间
                    Str.Pick_day = day;
                    Str.Weixin_name = weixiname;
                    Str.Openid_ = openid;

                    Str.total = money;
                    string bb = DateTime.Now.Day.ToString() + GuidTo16String();//生成的订单号
                    Str.Order_dd = bb;
                    Str.Order_from = "小程序";
                    Str.Fw_zt = "未支付";
                    Str.Delet_ = "未删除";
                    Str.Adress = adress;
                    int fal = add.Add_order_new(Str);
                    //   Str.total = total;
                    if (fal== 0)
                    {


                        jsonDict.Add("order_dd", bb);
                        jsonDict.Add("errCode", "false");
                        jsonDict.Add("recontent", fal.ToString());
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    }
                    else
                    {
                        jsonDict.Add("order_dd", bb);
                        jsonDict.Add("errCode", "true");
                        jsonDict.Add("recontent", fal.ToString());
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                    }

                }
            }
            else if (case_ == "order")
            {
                string openid = context.Request.QueryString["openid"];
                context.Response.ContentType = "text/json";
                context.Response.Write(MyCommFun.GetJsonByDataset(order_new(openid)));
 
            }
            else
            {
                order_dd = MyCommFun.QueryString("order");
                BLL.HG.Hg_list order_T = new BLL.HG.Hg_list();
                Model.HG.A_HG_new_order model = order_T.getorder(order_dd);
                string timeStamp = "";
                string nonceStr = "";
                string paySign = "";
                //创建支付应答对象
                Senparc.Weixin.MP.TenPayLibV3.RequestHandler packageReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
                //初始化
                packageReqHandler.Init();

                timeStamp = TenPayV3Util.GetTimestamp();
                nonceStr = TenPayV3Util.GetNoncestr();

                //设置package订单参数
                packageReqHandler.SetParameter("appid", "wx16650bedd9b0916a");		  //公众账号ID
                packageReqHandler.SetParameter("mch_id", "1403543902");		  //商户号
                packageReqHandler.SetParameter("nonce_str", nonceStr);                    //随机字符串
                packageReqHandler.SetParameter("body", model.Name_ + "服务");    //商品信息
                packageReqHandler.SetParameter("out_trade_no", order_dd);		//商家订单号
                packageReqHandler.SetParameter("total_fee", ((double.Parse(model.total)) * 100).ToString());			        //商品金额,以分为单位(money * 100).ToString()
                packageReqHandler.SetParameter("spbill_create_ip", context.Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
                packageReqHandler.SetParameter("notify_url", MyCommFun.getWebSite() + "/api/wxpay/notify_url.aspx?wid=" + 44 + "|" + order_dd);		    //接收财付通通知的URL
                packageReqHandler.SetParameter("trade_type", TenPayV3Type.JSAPI.ToString());	                    //交易类型
                packageReqHandler.SetParameter("openid", model.Openid_);	                    //用户的openId

                string sign = packageReqHandler.CreateMd5Sign("key", "70OvzuXGLFP7539B9zbvEMUBd1H1Tv8Q");
                packageReqHandler.SetParameter("sign", sign);	                    //签名
                string data = packageReqHandler.ParseXML();


                var result = TenPayV3.Unifiedorder(data);
                DateTime bb111 = new DateTime();
                WriteTextLog(bb111, result);
                var res = XDocument.Parse(result);
                string prepayId = res.Element("xml").Element("prepay_id").Value;

                //设置支付参数
                RequestHandler paySignReqHandler = new RequestHandler(null);
                paySignReqHandler.SetParameter("appId", "wx16650bedd9b0916a");
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
                context.Response.ContentType = "text/json";
                pay_ bb = new pay_
                {
                    timeStamp = timeStamp,
                    nonceStr = nonceStr,
                    paySign = paySign,
                    signType = "MD5",
                    package = prepayId





                };
                string json_bill = JsonMapper.ToJson(bb);
                context.Response.Write(json_bill);
            }
        }
        public DataSet order_new(string openid)
        {
            string str = "select * from A_HG_new_order where openid_='" + openid + "' order by order_ DESC";
            return DbHelperSQL.Query(str.ToString());
        }
        public static void WriteTextLog(DateTime time,string str1)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"合同\Log\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileFullPath = path + MyCommFun.RequestParam("pickname") + "护理合同" + time.ToString("yyyy-MM-dd") + ".txt";



            string str = str1;

            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
      
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        }

       
    
}