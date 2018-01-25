using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.DBUtility;
using XCWeiXin.Model;
using XCWeiXin.BLL;

namespace XCWeiXin.Web.attr_shop
{
    public partial class attr_size : System.Web.UI.Page
    {
        BLL.attr_shop.sub_attrid bll = new BLL.attr_shop.sub_attrid();
        Model.attrshop.sub_attrid model = new Model.attrshop.sub_attrid();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
            DataTable ww = new DataTable();
            DataSet aa = DbHelperSQL.Query("select attrid,attrname from attr_shop");
            ww=aa.Tables[0];
            drop.DataSource = ww;
            drop.DataValueField = ww.Columns[0].ColumnName;
            drop.DataTextField = ww.Columns[1].ColumnName;
            drop.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sizeid = drop1.SelectedItem.Value ;
            model.min_attrid =int.Parse( sizeid);
            model.sub_attrname = size.Text.Trim().ToString();
            bll.sub_attr(model);
            JscriptMsg("商品添加成功", "attrlist.aspx", "Success");
            
        }
        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }

        protected void drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string b = drop.SelectedItem.Value;
          
                DataTable vv = new DataTable();
                DataSet bb = DbHelperSQL.Query("select min_attrid,min_attridname from min_attrid where attrid=" + drop.SelectedItem.Value + "");

                vv = bb.Tables[0];
                drop1.DataSource = vv;
                drop1.DataValueField = vv.Columns[0].ColumnName;
                drop1.DataTextField = vv.Columns[1].ColumnName;
                
                drop1.DataBind();

            

        }
       
       
    }
}