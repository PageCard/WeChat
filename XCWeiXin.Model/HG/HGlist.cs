using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWeiXin.Model.HG
{
    ///CopyRight @ 20161118 张强林
     public   class HGlist
    {
        private int hg_number;
        private string hg_name = string.Empty;
        private string hg_sex = string.Empty;
        private string hg_Degree = string.Empty;
        private string hg_Profile = string.Empty;
        private string hg_IDcard;
        private int hg_age;
        private string hg_st1 = string.Empty;
        private string hg_st2 = string.Empty;
        private string hg_st3 = string.Empty;
        private int hg_sum;
        private int Wid;
         private string Dengji;
         private int techer;
         


        public int Hg_number
        {
            get { return hg_number; }
            set { hg_number = value; }
        }

        public string Hg_name
        {
            get { return hg_name; }
            set { hg_name = value; }
        }

        public string Hg_sex
        {
            get { return hg_sex; }
            set { hg_sex = value; }
        }

        public string Hg_Degree
        {
            get { return hg_Degree; }
            set { hg_Degree = value; }
        }

        public string Hg_Profile
        {
            get { return hg_Profile; }
            set { hg_Profile = value; }
        }

        public string Hg_IDcard
        {
            get { return hg_IDcard; }
            set { hg_IDcard = value; }
        }

        public int Hg_age
        {
            get { return hg_age; }
            set { hg_age = value; }
        }

        public string Hg_st1
        {
            get { return hg_st1; }
            set { hg_st1 = value; }
        }

        public string Hg_st2
        {
            get { return hg_st2; }
            set { hg_st2 = value; }
        }

        public string Hg_st3
        {
            get { return hg_st3; }
            set { hg_st3 = value; }
        }

        public int Hg_sum
        {
            get { return hg_sum; }
            set { hg_sum = value; }
        }

        public int wid
        {
            get { return Wid; }
            set { Wid = value; }
        }
        public string dengji
        {
            get { return Dengji; }
            set { Dengji = value; }
        }
        public int Techer
        {
            get { return techer; }
            set { techer = value; }
        }
        public string nation
        { get; set; }
        public string marry
        { get; set; }
        public string Mony
        { get; set; }
        public string Phone
        { get; set; }
        public string Headurl
        {
            get;
            set;
        }
        public string open_id_hg
        {
            get;
            set;
        }

    }
}
