using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWeiXin.Model.HG
{
   public  class A_HG_new_order
    {
         private int order_;
        private string openid_ = string.Empty;
        private string name_ = string.Empty;
        private string tel_ = string.Empty;
        private string sex_ = string.Empty;
        private string weixin_name = string.Empty;
        private string pick_many = string.Empty;
        private string type_ = string.Empty;
        private string time_ = string.Empty;
        private string pick_day = string.Empty;
        private string adress = string.Empty;
        private string order_dd = string.Empty;
        private string fw_name = string.Empty;
        private string fw_zt = string.Empty;
        private string order_from = string.Empty;
        private string str_1 = string.Empty;
        private string str_2 = string.Empty;
        private string str_3 = string.Empty;
        private string total_;
        private string strat_time_;
        private string Delet;
        private string end_time_;


        public int Order_
        {
            get { return order_; }
            set { order_ = value; }
        }
        public string end_time
        {
            get { return end_time_; }
            set { end_time_ = value; }
        }
        public string Delet_
        {
            get { return Delet; }
            set { Delet = value; }
        }
        public string total
        {
            get { return total_; }
            set{ total_=value;}
        }
        public string start_time
        {
            get { return strat_time_; }
            set { strat_time_ = value; }
        }
        public string Openid_
        {
            get { return openid_; }
            set { openid_ = value; }
        }

        public string Name_
        {
            get { return name_; }
            set { name_ = value; }
        }

        public string Tel_
        {
            get { return tel_; }
            set { tel_ = value; }
        }

        public string Sex_
        {
            get { return sex_; }
            set { sex_ = value; }
        }

        public string Weixin_name
        {
            get { return weixin_name; }
            set { weixin_name = value; }
        }

        public string Pick_many
        {
            get { return pick_many; }
            set { pick_many = value; }
        }

        public string Type_
        {
            get { return type_; }
            set { type_ = value; }
        }

        public string Time_
        {
            get { return time_; }
            set { time_ = value; }
        }

        public string Pick_day
        {
            get { return pick_day; }
            set { pick_day = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string Order_dd
        {
            get { return order_dd; }
            set { order_dd = value; }
        }

        public string Fw_name
        {
            get { return fw_name; }
            set { fw_name = value; }
        }

        public string Fw_zt
        {
            get { return fw_zt; }
            set { fw_zt = value; }
        }

        public string Order_from
        {
            get { return order_from; }
            set { order_from = value; }
        }

        public string Str_1
        {
            get { return str_1; }
            set { str_1 = value; }
        }

        public string Str_2
        {
            get { return str_2; }
            set { str_2 = value; }
        }

        public string Str_3
        {
            get { return str_3; }
            set { str_3 = value; }
        }

    }
    
}
