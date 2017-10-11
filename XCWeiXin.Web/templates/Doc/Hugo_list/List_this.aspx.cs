using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc.Hugo_list
{
    public partial class List_this : System.Web.UI.Page
    {
        public string name="";
        public int HG_number;
        protected void Page_Load(object sender, EventArgs e)
        {
            string phone = Request.QueryString["name"];
            BLL.HG.Hg_list list=new BLL.HG.Hg_list();
            Model.HG.HGlist model = list.Get_xinxi(phone);
            name = model.Hg_name;
            HG_number = model.Hg_number;
          

        }
    }
}