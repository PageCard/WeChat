﻿using XCWeiXin.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.admin.grouppurchase
{
    public partial class manageSN : Web.UI.ManagePage
    {
        protected int id = 0;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        BLL.wx_purchase_customer gbll = new BLL.wx_purchase_customer();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            id = MyCommFun.RequestInt("id");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                 RptBind(CombSqlTxt(keywords), " id desc", id);
            }
        }


         private void RptBind(string _strWhere, string _orderby,int id)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();

            string  typeid = MyCommFun.QueryString("typeid");
            if (typeid == "all" || typeid=="")
            {
                _strWhere = "baseid=" + id + " " + _strWhere;
            }
            else
            {
                ddlProperty.SelectedValue = typeid;
                string status = typeid == "w" ? "0" : "2";
                _strWhere = "baseid=" + id + " and  [STATUS]=" + status + " " + _strWhere;

            }
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = gbll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("manageSN.aspx", "keywords={0}&id={1}&typeid={2}&page={3}", this.keywords,id.ToString(),typeid, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

            txtKeywords.Text = keywords;

        }
      

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and ( customerName like  '%" + _keywords + "%' or sn like  '%" + _keywords + "%') ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manageSN_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("manageSN.aspx", "keywords={0}&id={1}&typeid={2}", txtKeywords.Text, id.ToString(), ddlProperty.SelectedItem.Value));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manageSN_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("manageSN.aspx", "keywords={0}&id={1}&typeid={2}", txtKeywords.Text, id.ToString(), ddlProperty.SelectedItem.Value));
        }

        /// <summary>
        /// 选择类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("manageSN.aspx", "typeid={0}&keywords={1}&id={2}", ddlProperty.SelectedItem.Value, this.keywords,id.ToString(),id.ToString()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (gbll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除sn码" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("group_list.aspx", "keywords={0}&id={1}", this.keywords,this.id.ToString()), "Success");
        }


        /// <summary>
        ///  
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }

        


    }
}