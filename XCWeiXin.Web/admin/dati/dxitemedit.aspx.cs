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
    public partial class dxitemedit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        wx_dati_dx datiBll = new wx_dati_dx();
        private int pid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            pid = MXRequest.GetQueryInt("pid");
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
            BLL.wx_dati_base dtBll = new BLL.wx_dati_base();
            Model.wx_dati_base getdt= dtBll.GetModel(pid);
            txtscore.Text =getdt.dxscore.ToString();
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
            Model.wx_dati_dx dati = datiBll.GetModel(id);
            hidid.Value = dati.id.ToString();
           //绑定控件的值
            txttitle.Text = dati.title.Trim().ToString();   
         
            txtscore.Text = dati.score.ToString();

            rblisshow.SelectedValue = dati.isshow == true ? "1" : "0";           
            txtsummary.InnerText = dati.summary.Trim();
            string getanswer = dati.answer;
            if (getanswer == rbxA.Text.ToString()) rbxA.Checked = true;
            if (getanswer == rbxB.Text.ToString()) rbxB.Checked = true;
            if (getanswer == rbxC.Text.ToString()) rbxC.Checked = true;
            if (getanswer == rbxD.Text.ToString()) rbxD.Checked = true;
            if (getanswer == rbxE.Text.ToString()) rbxE.Checked = true;
            if (getanswer == rbxF.Text.ToString()) rbxF.Checked = true;

            txtxA.Text = dati.xA.Trim().ToString();
            txtxB.Text = dati.xB.Trim().ToString();
            txtxC.Text = dati.xC.Trim().ToString();
            txtxD.Text = dati.xD.Trim().ToString();
            txtxE.Text = dati.xE.Trim().ToString();
            txtxF.Text = dati.xF.Trim().ToString();            

        }


        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string answer = null;
            if (rbxA.Checked) answer = rbxA.Text.Trim();
            if (rbxB.Checked) answer = rbxB.Text.Trim();
            if (rbxC.Checked) answer = rbxC.Text.Trim();
            if (rbxD.Checked) answer = rbxD.Text.Trim();
            if (rbxE.Checked) answer = rbxE.Text.Trim();
            if (rbxF.Checked) answer = rbxF.Text.Trim();

            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "题目名称不能为空！ ";
            }
            if (answer == null)
            {
                strErr += "答案不能为空！ ";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_dati_dx dati = new Model.wx_dati_dx();

            if (id > 0)
            {
                dati = datiBll.GetModel(id);
            }


            dati.title = txttitle.Text.Trim();
            dati.score = int.Parse(txtscore.Text.Trim());
            dati.isshow = rblisshow.SelectedValue == "0" ? false : true;
            dati.answer = answer;
            dati.summary = txtsummary.Value.Trim();
            dati.xA = txtxA.Text.Trim();
            dati.xB = txtxB.Text.Trim();
            dati.xC = txtxC.Text.Trim();
            dati.xD = txtxD.Text.Trim();
            dati.xE = txtxE.Text.Trim();
            dati.xF = txtxF.Text.Trim();


            #endregion

            

            if (id <= 0)
            {  //新增
                dati.pid = pid;
                int c = datiBll.GetRecordCount(" pid=" + pid) + 1;
                dati.sid = c;
                //1新增主表
                id = datiBll.Add(dati);
                //更新mid号
                DataSet dt = datiBll.GetList(" pid=" + pid);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    datiBll.UpdateMid(int.Parse(dt.Tables[0].Rows[i]["id"].ToString()), i + 1);
                }
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加题库信息，主键为" + id); //记录日志
                JscriptMsg("添加题目信息成功！", "dxitemlist.aspx?pid="+pid, "Success");
            }
            else
            {   //修改
                datiBll.Update(dati);
 
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改题库信息，主键为" + id); //记录日志
                JscriptMsg("修改题目信息成功！", "dxitemlist.aspx?pid="+pid, "Success");

            }

        }

     

      

    }
}