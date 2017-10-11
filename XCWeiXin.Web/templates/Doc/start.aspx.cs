using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class start : System.Web.UI.Page
    {
        //注释time:2017.03.21

        //注释人:张强林

        //2017.03.21此功能完善
        public string name = "";//联系人
        public string tel = "";//联系电话
        public string nur_sex = "";//联系人性别
        public string by_name = "";//被护理人
        public string by_sex = "";//被护理人性别
        public string by_age = "";//别护理人年龄
        public string by_care = "";//是否能自理
        public string by_adress = "";//被护理地址
        public string HUli_type = "";//护理类型
        public string total = "";//护理价格
        public string Status_order = "";//订单状态
        public string Str_sm = "";//备注
        public string server_time = "";//服务时间
        public string server_day = "";//服务天数
        public string order_number = "";//订单编号
        public string hg_number;//护工编号
        public string hg_name_s;//护工名字
        public string hg_name;//护工名字
        protected void Page_Load(object sender, EventArgs e)
        {
            order_number = Request.QueryString["order_dd"];
            BLL.HG.Hg_list order = new BLL.HG.Hg_list();
            Model.HG.HG_order model = order.Getorder(order_number);
            name = model.Nursing_name;
            tel = model.Nursing_tel;
            nur_sex = model.Nursing_sex;
            total = model.Total.ToString();
            Status_order = model.Status_order;
            Str_sm = model.str_sm;
            server_time = model.Service_time;
            server_day = model.Service_day;

            hg_name = model.Hg_name;


            by_age = model.By_age;
            by_name = model.By_name;
            by_sex = model.By_sex;
            by_care = model.By_care;
            by_adress = model.By_adress;

            HUli_type = model.HUli_type;
            hg_number = model.Hg_number;
            BLL.HG.Hg_list bb = new BLL.HG.Hg_list();
            Model.HG.HGlist get = bb.Getmodel(int.Parse(hg_number));
            hg_name_s = get.Phone;

        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            if ((Request.Form["lb1"].Length != 0) && (t1.Text.Length != 0))
            {
                BLL.HG.Hg_list bb = new BLL.HG.Hg_list();
                Model.HG.HG_order nn = new Model.HG.HG_order();
                string str = Request.Form["lb1"];
                string star=Regex.Replace(str, @"[^\d.\d]", "");
                nn.Rated_status =int.Parse( star);
                nn.Rated_hg = t1.Text;
                nn.Order_dd = Request.QueryString["order_dd"];
                if (bb.update_star(nn) == true)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('感谢评价，祝您生活愉快！');{location.href='index.aspx'}</script>");
                }
            }
            else {
                string script = "<script> alert('请为本次服务做出点评！！') </script>";
                Page.RegisterStartupScript("", script);
            }
        }
    }
}