﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using System.Text;
using System.Data;

namespace XCWeiXin.Web.admin.shangqiang
{
    public partial class photo_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int aid;

        protected string keywords = string.Empty;
        BLL.wx_sq_piclist bll = new BLL.wx_sq_piclist();

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.View.ToString()); //检查权限
            this.aid = MXRequest.GetQueryInt("id");
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                RptBind(this.aid, "id>0" + CombSqlTxt(this.keywords), "createDate asc ");
            }
        }

         

        #region 数据绑定=================================
        private void RptBind(int aid, string _strWhere, string _orderby)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            this.page = MXRequest.GetQueryInt("page", 1);
            _strWhere = "aid="+aid+" and " + _strWhere;

            this.txtKeywords.Text = this.keywords;
            //列表显示
         
            DataSet artDs = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);

            ////链接处理，待做
            //if (artDs != null)
            //{
            //    DataRow dr;
            //    for (int i = 0; i < artDs.Tables[0].Rows.Count; i++)
            //    {
            //        dr = artDs.Tables[0].Rows[i];
            //        dr["url"] = " <a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/weixin/product/detail.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&id=" + dr["id"] + "</a>";
            //    }
            //}

            this.rptList.DataSource = artDs;
            this.rptList.DataBind();


            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}", aid.ToString(), this.keywords);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  openid like '%" + _keywords + "%'");
            }


            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("sq_photo_list_page_size"), out _pagesize))
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
            string keyw = txtKeywords.Text;
            Response.Redirect(Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}",
              aid.ToString(), keyw));
        }

        //筛选类别
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}",
               aid.ToString(), this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("sq_photo_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}",
              aid.ToString(), this.keywords));
        }

        /// <summary>
        /// 拉黑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLaHei_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Edit.ToString()); //检查权限
           
            Repeater rptList = new Repeater();
            rptList = this.rptList;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string  openid  =((HiddenField)rptList.Items[i].FindControl("hidOpenid")).Value;
                 CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                 if (cb.Checked)
                 {
                     bll.LaHei(openid, aid);
                 }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "微信上墙拉黑"); //记录日志
            Response.Redirect(Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}",
               aid.ToString(), this.keywords));
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnShenghe_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            
            Repeater rptList = new Repeater();
            rptList = this.rptList;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "hasShenghe=1");
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "微信上墙通过审核的图片"); //记录日志
            Response.Redirect(Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}",
               aid.ToString(), this.keywords));
        }


        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
          
            Repeater rptList = new Repeater();
            rptList = this.rptList;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除微信上墙图片成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            Response.Redirect(Utils.CombUrlTxt("photo_list.aspx", "id={0}&keywords={1}",
              aid.ToString(), this.keywords));
        }
    }
}