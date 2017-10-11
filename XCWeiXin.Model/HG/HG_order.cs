using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWeiXin.Model.HG
{
    ///CopyRight @ 20161118 张强林
   public class HG_order
    {
        private int oreder_id;
        private string openid = string.Empty;
        private string nursing_name = string.Empty;
        private string nursing_sex = string.Empty;
        private string nursing_tel = string.Empty;
        private string nursing_adress = string.Empty;
        private string by_name = string.Empty;
        private string by_sex = string.Empty;
        private string by_care = string.Empty;
        private string by_age = string.Empty;
        private string by_adress = string.Empty;
        private string start_time = string.Empty;
        private string end_time = string.Empty;
        private string hg_number = string.Empty;
        private string status_order = string.Empty;
        private string rated_hg = string.Empty;
        private int rated_status;
        private string pay_type = string.Empty;
        private double total;
        private int wid;
        private string service_time = string.Empty;
        private string service_day = string.Empty;
        public string Str_sm = "";


        public int Oreder_id
        {
            get { return oreder_id; }
            set { oreder_id = value; }
        }

        public string Openid
        {
            get { return openid; }
            set { openid = value; }
        }

        public string Nursing_name
        {
            get { return nursing_name; }
            set { nursing_name = value; }
        }

        public string Nursing_sex
        {
            get { return nursing_sex; }
            set { nursing_sex = value; }
        }

        public string Nursing_tel
        {
            get { return nursing_tel; }
            set { nursing_tel = value; }
        }

        public string Nursing_adress
        {
            get { return nursing_adress; }
            set { nursing_adress = value; }
        }

        public string By_name
        {
            get { return by_name; }
            set { by_name = value; }
        }

        public string By_sex
        {
            get { return by_sex; }
            set { by_sex = value; }
        }

        public string By_care
        {
            get { return by_care; }
            set { by_care = value; }
        }

        public string By_age
        {
            get { return by_age; }
            set { by_age = value; }
        }

        public string By_adress
        {
            get { return by_adress; }
            set { by_adress = value; }
        }

        public string Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }

        public string End_time
        {
            get { return end_time; }
            set { end_time = value; }
        }

        public string Hg_number
        {
            get { return hg_number; }
            set { hg_number = value; }
        }

        public string Status_order
        {
            get { return status_order; }
            set { status_order = value; }
        }

        public string Rated_hg
        {
            get { return rated_hg; }
            set { rated_hg = value; }
        }

        public int Rated_status
        {
            get { return rated_status; }
            set { rated_status = value; }
        }

        public string Pay_type
        {
            get { return pay_type; }
            set { pay_type = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public int Wid
        {
            get { return wid; }
            set { wid = value; }
        }
        public string Service_time
        {
            get { return service_time; }
            set { service_time = value; }
        }
        public string Service_day
        {
            get { return service_day; }
            set { service_day = value; }
        }
        public string str_sm
        {
            get { return Str_sm; }
            set{Str_sm=value ;}
        }
        public string HUli_type
        {
            get;
            set;
        }
        public string Hg_name
        { get; set; }
        public string Order_dd
        { get; set; }

    }
}
