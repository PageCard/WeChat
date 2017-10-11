using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.hugongll
{
    public partial class Hugong_sing : System.Web.UI.Page
    {
        public string name = "";
        public string sex = "";
        public string Hg_Degree = "";
        public string Hg_Profile = "";
        public string Hg_IDcard = "";
        public int Hg_age = 0;
        public string nation = "";
        public string marry = "";
        public string dengji = "";
        public string Hg_st1 = "";
        public string Hg_st2 = "";
        public int teacher = 1;
        public string mony = "";
        public string head = "";
        BLL.HG.Hg_list list = new BLL.HG.Hg_list();
        protected void Page_Load(object sender, EventArgs e)
        {
            int number = int.Parse(Request.QueryString["number"]);
            hid.Value = number.ToString();
            int techer = int.Parse(Request.QueryString["techer"]);
            if (!IsPostBack)
            {
                Sing(number);
            }


        }
        public void Sing(int number)
        {
            Model.HG.HGlist Hg = list.Getmodel(number);
            name = Hg.Hg_name;
            sex = Hg.Hg_sex;
            Hg_Degree = Hg.Hg_Degree;
            Hg_Profile = Hg.Hg_Profile;
            Hg_IDcard = Hg.Hg_IDcard;
            Hg_age = Hg.Hg_age;
            nation = Hg.nation;
            marry = Hg.marry;
            Hg_st1 = Hg.Hg_st1;
            dengji = Hg.dengji;
            mony = Hg.Mony;
            hid4.Value = Hg.Hg_st2;

            string bb = "";
            string[] aa = new string[Hg_IDcard.Length];
            for (int a = 0; a < Hg_IDcard.Length; a++)
            {

                aa[a] = Hg_IDcard[a].ToString();
                aa[10] = "*";
                aa[11] = "*";
                aa[12] = "*";
                aa[13] = "*";
                aa[14] = "*";
                aa[15] = "*";
                bb += aa[a];
            }
            Hg_IDcard = bb;

            head = Hg.Headurl;

            teacher = Hg.Techer;

            hid2.Value = name;
            hid3.Value = Hg.Mony;


        }
    }
}