using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.BLL;
using XCWeiXin.DBUtility;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class order : System.Web.UI.Page
    {
       public string open_id = "";
       public string order_dd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsFail()==true)
            {
                if (Request.QueryString["Fail"].ToString() == "suc")
                {
                    BLL.HG.Hg_list bb = new BLL.HG.Hg_list();
                    int number = int.Parse(Request.QueryString["kk"]);
                     order_dd = Request.QueryString["order"];
                    bb.update_list(number);
                    bb.update("已支付", order_dd);
                  //  Update_Hg("预约", number);
                      
                    SendTemplateMessageTest();
                    SendTemplateMessageTest_hg();

                }
                else { 

                }
 
            }
            if (System.Web.HttpContext.Current.Request.Cookies["open_id"] != null)
            {
                open_id = HttpContext.Current.Request.Cookies["open_id"].Value;
            }

        }
        public bool Update_Hg(string idlist, int Hg_number)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  A_HG_HG ");
            strSql.Append(" set Hg_st2='" + idlist + "' where Hg_number=" + Hg_number + "");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
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
                keyword4 = new TemplateDataItem("微信支付："+(model.Total).ToString()+"元"),
                keyword5=new TemplateDataItem(model.By_adress),
                remark = new TemplateDataItem("请联系你的客户，并及时提供服务")
            };
            var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId,  "http://www.hugongll.com/templates/Doc/Hugo_list/Login.aspx", testData);


        }
        /// <summary>
        /// 微信发送模板消息
        /// </summary>
        public void SendTemplateMessageTest()
        {
//            您好，已为您成功预约上门服务。
//项目：高级美甲
//时间：2015年10月1日14:00~16:00
//技师：志玲
//费用：98元
//地址：西安市雁塔区曲江金地湖城大境
//2015年9月28日 16:36
            BLL.HG.Hg_list order_T = new BLL.HG.Hg_list();
            Model.HG.HG_order model = order_T.Getorder(Request.QueryString["order"]);
            var openId = HttpContext.Current.Request.Cookies["open_id"].Value;//换成已经关注用户的openId
            var templateId = "D_WYLHdtug59Q-e1DhPQHrQGB8MurmOhABo44y6qahQ";//换成已经在微信后台添加的模板Id
            var accessToken = Token();
            var testData = new //TestTemplateData()
            {
                first = new TemplateDataItem("您好，预约通知","#F70D12"),
                keyword1 = new TemplateDataItem("医院护理"),
                keyword2 = new TemplateDataItem(model.Service_time),
                keyword3 = new TemplateDataItem(model.Hg_name, "#0AD690"),
                keyword4 = new TemplateDataItem((model.Total).ToString()+"元"),
                keyword5=new TemplateDataItem(model.By_adress),
                remark = new TemplateDataItem(DateTime.Now.ToString())
            };
            var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId,  "http://www.hugongll.com/templates/Doc/order.aspx", testData);


        }
        public string Token()
        {

            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(44, out error);
            return accessToken;


        }
        public bool IsFail()
        {
            if (Request.QueryString["Fail"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}