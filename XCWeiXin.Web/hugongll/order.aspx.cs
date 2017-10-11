using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.DBUtility;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.hugongll
{

    public partial class order : System.Web.UI.Page
    {
        public string openid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            boo();
            }
            string fail=Request.QueryString["Fail"];
            string order_dd=Request.QueryString["order"];
            if (fail == "suc")
            {
               
                Update("已支付",order_dd);
                SendTemplateMessageTest_hg();

            }
            else
            {
                Update("未支付", order_dd);

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
            BLL.HG.Hg_list bb=new BLL.HG.Hg_list();
            Model.HG.A_HG_new_order modle = bb.getorder_(Request.QueryString["order"]);

           


            var openId = modle.Openid_;//换成已经关注用户的openId
            var templateId = "6oFH4updt21Zfwbks6O7erhZRlOI6jS3Yju8l9qFsw4";//换成已经在微信后台添加的模板Id
            var accessToken = Token();
            var testData = new //TestTemplateData()
            {
                first = new TemplateDataItem("护理服务支付成功"),
                keyword1 = new TemplateDataItem(modle.Name_),
                keyword2 = new TemplateDataItem(modle.Tel_),
                keyword3 = new TemplateDataItem(modle.Time_),
                keyword4 = new TemplateDataItem("微信支付：" + (modle.total).ToString() + "元"),
                keyword5 = new TemplateDataItem(modle.Adress),
                remark = new TemplateDataItem("请保持电话通畅，服务人员会和您取得联系，提供快捷舒心的服务！")
            };

            var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId, "#FF0000", "http://www.hugongll.com/hugongll/order.aspx", testData);
           
            var openIds = "oZg9IwiZ4xGUBDtjT3lvrB4JV9Vo";//换成已经关注用户的openId
            templateId = "6oFH4updt21Zfwbks6O7erhZRlOI6jS3Yju8l9qFsw4";//换成已经在微信后台添加的模板Id
           accessToken = Token();
            testData = new //TestTemplateData()
            {
                first = new TemplateDataItem("新订单提醒（管理通知）"),
                keyword1 = new TemplateDataItem(modle.Name_),
                keyword2 = new TemplateDataItem(modle.Tel_),
                keyword3 = new TemplateDataItem(modle.Time_),
                keyword4 = new TemplateDataItem("微信支付：" + (modle.total).ToString() + "元"),
                keyword5 = new TemplateDataItem(modle.Adress),
                remark = new TemplateDataItem("请与以上用户联系，并回访")
            };
            result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openIds, templateId, "#FF0000", "http://www.hugongll.com/hugongll/order.aspx", testData);



        }
        public string Token()
        {

            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(44, out error);
            return accessToken;


        }
        public bool Update(string idlist, string orderid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  A_HG_new_order ");
            strSql.Append(" set Fw_zt='" + idlist + "' where order_dd='" + orderid + "' ");
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
       public void boo()
    {
        if (HttpContext.Current.Request.Cookies["open_id1"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('授权失败，请重新从菜单进入！');</script>");
            }
            else
            {

                openid = HttpContext.Current.Request.Cookies["open_id1"].Value;

            }
    }
    }
}