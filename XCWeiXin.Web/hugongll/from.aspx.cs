using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.WeiXinComm;

namespace XCWeiXin.Web.hugongll
{
    public partial class from : System.Web.UI.Page
    {
        public string type;
        public string type_;
        public string pick_name;
        public string openid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["open_id1"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('授权失败，请重新从菜单进入！');</script>");
            }
            else
            {

                openid = HttpContext.Current.Request.Cookies["open_id1"].Value;
                // string neirong = TextBox1.Text;
                var result = UserApi.Info(stoce(), openid);
                pick_name = result.nickname;
                type = Request.QueryString["type"];
                if (type == "doc")
                {
                    type_ = "医院护理";

                }
                else if (type == "home")
                {
                    type_ = "居家护理";
                }
                else if (type == "yuesao")
                {
                    type_ = "月嫂服务";
                }
                else
                {

                }
            }


        }
        protected void pay_Click(object sender, EventArgs e)
        {
            if (Request.Form["name"] == null || Request.Form["name"] == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('雇主姓名不能为空');</script>");
            }
            else if (Request.Form["tel"] == null || Request.Form["tel"] == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('雇主电话不能为空');</script>");

            }
            else if (Request.Form["pick_many"] == null || Request.Form["pick_many"] == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('请选择服务价格');</script>");
            }
            else if (Request.Form["pick_day"] == null || Request.Form["pick_day"] == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('请选择服务天数');</script>");
            }
            else if (Request.Form["time_"] == null || Request.Form["time_"] == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('请选择服务时间');</script>");
            }
            else if (Request.Form["adress"] == null || Request.Form["adress"] == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('请选择服务地址');</script>");
            }

            else
            {
                Model.HG.A_HG_new_order add = new Model.HG.A_HG_new_order();
                DAL.HG.HG_order Add = new DAL.HG.HG_order();
                add.Openid_ = HttpContext.Current.Request.Cookies["open_id1"].Value;
                add.Weixin_name = pick_name;
                add.Name_ = Request.Form["name"];//雇主姓名
                add.Tel_ = Request.Form["tel"];//雇主电话
                add.Sex_ = sex_.Items[sex_.SelectedIndex].Text;//雇主性别
                add.Pick_many = Request.Form["pick_many"];//服务标准
                add.Pick_day = Request.Form["pick_day"];//服务天数
                add.Time_ = Request.Form["time_"]; ;//服务时间
                add.Type_ = type_;                 //服务类型
                add.Adress = Request.Form["adress"];//服务地址
                add.start_time = DateTime.Now.ToString();//开始时间
                add.Order_from = "微信公众号";
                add.Order_dd = DateTime.Now.Day.ToString() + GuidTo16String();//生成的订单号
                string nn = hid.Value;
                add.Fw_zt = "未支付";
                add.Delet_ = "未删除";
                add.total = nn;
                Add.add_order_new(add);
                Response.Redirect("/api/payment/Hg_pay.aspx?Order_dd=" + add.Order_dd + "&order_type=new");
            }
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
        public string stoce()
        {
            WeiXinCRMComm dd = new WeiXinCRMComm();
            string error = "";
            WeiXCommFun wxcomm = new WeiXCommFun();
            int wid = 44;
            string sctokn = dd.getAccessToken(wid, out error);
            return sctokn;

        }

    }
}