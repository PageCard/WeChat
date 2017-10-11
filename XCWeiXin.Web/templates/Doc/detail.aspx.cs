using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.BLL;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class detail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                Start();
                TextBox2.Text = Request.QueryString["Hg_name"].ToString();
                mony.Text = Request.QueryString["Mony"].ToString() + "/天";

                if (IsCookie("phone"))
                {
                    telnum.Text = HttpContext.Current.Request.Cookies["phone"].Value;


                }

                else
                {
                    telnum.Text = null;

                }


            }


        }

        public static bool IsCookie(string cook)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[cook] != null)
                return true;
            else
                return false;
        }
        public void Start()
        {



            if (Request.QueryString["type"].ToString() == "1")
            {
                huli_type.Text = "医院护理";

            }
            else if (Request.QueryString["type"].ToString() == "2")
            {
                huli_type.Text = "居家护理";

            }
            else if (Request.QueryString["type"].ToString() == "3")
            {
                huli_type.Text = "b";

            }
            else
            {

                huli_type.Text = Request.QueryString["Type"].ToString();

            }

        }




        public void Cookie1()
        {



            System.Web.HttpCookie showtime = new HttpCookie("nameboy");
            showtime.Value = name.Text;
            showtime.Expires = DateTime.Now.AddDays(3650);
            Response.AppendCookie(showtime);



        }
        public void cookie2()
        {
            System.Web.HttpCookie newcookie123 = new HttpCookie("phone");
            newcookie123.Value = telnum.Text;
            newcookie123.Expires = DateTime.Now.AddDays(3650);
            Response.AppendCookie(newcookie123);
        }

        protected void suc_Click(object sender, EventArgs e)
        {  BLL.HG.Hg_list list = new BLL.HG.Hg_list();
            int number=int.Parse(Request.QueryString["number"].ToString());
              Model.HG.HGlist Hg = list.Getmodel(number);
         
            Cookie1();
            cookie2();
            if ((name.Text == null) || (name.Text == "") )
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('联系人不能为空');</script>");
            }
            else if((text_time.Text==null)||(text_time.Text=="")||(pickdate.Text==null) ||(pickdate.Text=="") ||(picktime.Text==null)||(picktime.Text==""))
            {
                 Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('预约时间不能为空 ');</script>");
            }
            else if ((telnum.Text == null) || (telnum.Text == ""))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('联系电话不能为空 ');</script>");
 
            }
            else if ((by_name.Text == null) || (by_name.Text == "") || (by_age.Text == null) || (by_age.Text == "") || (by_adress.Text == "") || (by_adress.Text==null))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('被护理人信息不能为空 ');</script>");
               
            }

            else
            {
                if (Hg.Hg_st2 == "空闲")
                {
                    string open_id = "";
                    if (System.Web.HttpContext.Current.Request.Cookies["open_id"] != null)
                    {
                        open_id = HttpContext.Current.Request.Cookies["open_id"].Value;
                    }
                    Model.HG.HG_order Str = new Model.HG.HG_order();

                    BLL.HG.Hg_list add = new BLL.HG.Hg_list();
                    Str.Openid = open_id;
                    Str.Nursing_name = name.Text.Trim().ToString();
                    Str.Nursing_sex = Select1.Items[Select1.SelectedIndex].Value;
                    Str.Nursing_tel = telnum.Text.Trim().ToString();
                    Str.By_name = by_name.Text.Trim().ToString();
                    Str.By_sex = Sel_Test.Items[Sel_Test.SelectedIndex].Value;
                    Str.By_care = By_care.Items[By_care.SelectedIndex].Value;
                    Str.By_age = by_age.Text.Trim().ToString();
                    Str.By_adress = by_adress.Text.Trim().ToString();
                    Str.HUli_type = huli_type.Text.Trim();
                    Str.Hg_name = TextBox2.Text;
                    Str.Hg_number = Request.QueryString["number"].ToString();
                    Str.Service_time = pickdate.Text + "/" + picktime.Text;
                    Str.Service_day = Request.Form["inp"].ToString();
                    Str.Status_order = "未完成";
                    Str.Start_time = DateTime.Now.ToString();
                    Str.Order_dd = DateTime.Now.Minute + GuidTo16String();
                    string total = hid.Value;
                    //string bb = "";
                    //Regex reg = new Regex(@"[0-9][0-9,.]*");
                    //MatchCollection mc = reg.Matches(total);
                    //foreach (Match m in mc)
                    //{
                    //    bb += m.Value;
                    //}
                    Str.Total = (double.Parse(total.ToString()));
                    Str.Pay_type = "微信支付";
                    Str.Wid = 44;
                    Str.Str_sm = TextBox1.Text;
                    add.Add_order(Str);

                    //   int aa = add.Add_order(Str);
                    //ClientScript.RegisterStartupScript(typeof(string), "操作提示", "<script>alert('" + by_name.Text + bb + text_time .Text+ "')</script>");
                    //   Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('立即支付!');{location.href=''}</script>");
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>if(confirm('保存成功！是否？')){location.href='ProductonAdd.aspx'}else{location.href='ProductonList.aspx'}</script>");
                    Response.Redirect("/api/payment/Hg_pay.aspx?order_dd=" + Str.Order_dd + "&kkl=" + Request.QueryString["number"].ToString() + "");
                }
                else {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('手速一慢被人捷足先登了！');{location.href='card_sing.aspx'}</script>");
                }
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

        protected void time_day_Click(object sender, EventArgs e)
        {
            Cookie1();
            cookie2();
            Response.Redirect("time.aspx?type=" + huli_type.Text + "&name=" + name.Text + "");
        }
    }
}