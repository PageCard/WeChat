using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc.Hugo_list
{
    public partial class HG_order_ok : System.Web.UI.Page
    {
        public string name = "";
        public string tel = "";
        public string nur_sex = "";
        public string by_name = "";
        public string by_sex = "";
        public string by_age = "";
        public string by_care = "";
        public string by_adress = "";
        public string HUli_type = "";
        public string total = "";
        public string Status_order = "";
        public string Str_sm = "";
        public string server_time = "";
        public string server_day = "";
        public string order_number = "";
        public string hg_number;
        public string hg_name_s;
        protected void Page_Load(object sender, EventArgs e)
        {
            order_number = Request.QueryString["orderdd"];
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
            HiddenField1.Value = hg_number;
            HiddenField2.Value = hg_name_s;
        }
    }
}