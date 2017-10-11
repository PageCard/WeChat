using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;
using System.Linq;

namespace XCWeiXin.Web.admin.dati
{
    public partial class editDati : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_dati_base datiBll = new wx_dati_base();   

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!datiBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_dati_base dati = datiBll.GetModel(id);
            hidid.Value = dati.id.ToString();
           //绑定控件的值
            txttitle.Text = dati.title.Trim().ToString();
            //封面图片
            if (dati.headimg != null && dati.headimg.Trim() != "" && dati.headimg.Trim() != "/images/noneimg.jpg")
            {
                txtHeadimg.Text = dati.headimg.Trim();
                imgbjurl.ImageUrl = dati.headimg.Trim();
            }
            txtsummary.InnerText = dati.summary.Trim();
            txtdttime.Text = dati.dttime.ToString().Trim();
            rblisshowend.SelectedValue = dati.isshowend == true ? "1" : "0";
            txtdxtitle.Text = dati.dxtitle.Trim().ToString();
            txtdxgetnum.Text=dati.dxgetnum.ToString();
            txtdxscore.Text=dati.dxscore.ToString();
            txtbjcolor.Text = dati.bjcolor.Trim();
            txtstarttime.Text = dati.starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendtime.Text = dati.endtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtjfval.Text = dati.jfval.ToString();
            ddlJFtype.SelectedIndex = (dati.jftype);

            litwUrl.Text = MyCommFun.getWebSite() + "/weixin/dati/index.aspx?wid=" + dati.wid + "&id=" + id;

        }


        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "题库名称不能为空！ ";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_dati_base dati = new Model.wx_dati_base();

            if (id > 0)
            {
                dati = datiBll.GetModel(id);
            }

            string facePicc = "";
            if (txtHeadimg.Text.Trim() != "")
            {
                facePicc = txtHeadimg.Text.Trim();
            }
            dati.title = txttitle.Text.Trim();
            dati.headimg = facePicc;
            dati.bjcolor = txtbjcolor.Text.Trim();
            dati.summary = txtsummary.Value.Trim();
            dati.dttime = int.Parse(txtdttime.Text);          
            dati.isshowend = rblisshowend.SelectedValue == "0" ? false : true;
            //单选
            dati.dxtitle = txtdxtitle.Text.Trim();
            dati.dxgetnum = int.Parse(txtdxgetnum.Text);
            dati.dxscore = int.Parse(txtdxscore.Text);
            DateTime start = DateTime.Parse(txtstarttime.Text.Trim());
            DateTime end = DateTime.Parse(txtendtime.Text.Trim());
            dati.starttime = start;
            dati.endtime = end;
            dati.jfval = int.Parse(txtjfval.Text.ToString());
            dati.jftype = MyCommFun.Str2Int(ddlJFtype.SelectedItem.Value);
            #endregion

            

            if (id <= 0)
            {  //新增
                dati.wid = weixin.id;
                dati.addtime = DateTime.Now;
                
                //1新增主表
                id = datiBll.Add(dati);               
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加题库信息，主键为" + id); //记录日志
                JscriptMsg("添加题库信息成功！", "index.aspx", "Success");
            }
            else
            {   //修改
                datiBll.Update(dati);             
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改题库信息，主键为" + id); //记录日志
                JscriptMsg("修改题库信息成功！", "index.aspx", "Success");
            }

        }

     

      

    }
}