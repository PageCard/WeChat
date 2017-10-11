﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;


namespace XCWeiXin.Web.admin.wxRule
{
    public partial class editYuYin : Web.UI.ManagePage
    {

        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        wx_requestRule rBll = new wx_requestRule();
        wx_requestRuleContent rcBll = new wx_requestRuleContent();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!rBll.Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                //  ChkAdminLevel("manager_list", MXEnums.ActionEnum.View.ToString()); //检查权限

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            DataSet ds = rBll.GetRuleContent("id=" + id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                txtreqKeywords.Text =MyCommFun.ObjToStr(dr["reqKeywords"]);
                if (MyCommFun.ObjToStr(dr["isLikeSearch"]) != "")
                {
                    if (dr["isLikeSearch"].ToString().ToLower() == "false")
                    {
                        rblisLikeSearch.SelectedValue = "0";

                    }
                    else
                    { rblisLikeSearch.SelectedValue = "1"; }

                }
                txtTitle.Text =MyCommFun.ObjToStr(dr["rContent"]);
                txtMediaUrl.Text =MyCommFun.ObjToStr(dr["mediaUrl"]);
                txtrContent.Text =MyCommFun.ObjToStr(dr["rContent2"]);
            }

        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            string strErr = "";
            if (this.txtreqKeywords.Text.Trim().Length == 0)
            {
                strErr += "关键词不能为空！";
            }
            if (this.txtMediaUrl.Text.Trim().Length == 0)
            {
                strErr += "语音链接不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return false;
            }

            Model.manager manager = GetAdminInfo();
            Model.wx_userweixin weixin = GetWeiXinCode();

            Model.wx_requestRule rule = new Model.wx_requestRule();
            rule.uId = manager.id;
            rule.wId = weixin.id;
            rule.ruleName = "语音回复";
            rule.reqKeywords = txtreqKeywords.Text.Trim();
            rule.reqestType = 1;
            rule.responseType = 3;
            string radoValue = rblisLikeSearch.SelectedItem.Value;
            if (radoValue == "0")
            {
                rule.isLikeSearch = false;
            }
            else
            {
                rule.isLikeSearch = true;
            }
            rule.createDate = DateTime.Now;
            int rId = rBll.Add(rule);
            Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
            rc.uId = manager.id;
            rc.rId = rId;
            rc.rContent = txtTitle.Text.Trim();
            rc.rContent2 = txtrContent.Text.Trim();
            rc.mediaUrl = txtMediaUrl.Text.Trim();
            rc.createDate = DateTime.Now;
            int rcId = rcBll.Add(rc);


            if (rcId > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加语音回复，主键为:" + rId + ",关键词为：" + txtreqKeywords.Text.Trim()); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            string strErr = "";
            if (this.txtreqKeywords.Text.Trim().Length == 0)
            {
                strErr += "关键词不能为空！";
            }
            if (this.txtrContent.Text.Trim().Length == 0)
            {
                strErr += "内容或简介不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return false;
            }


            Model.wx_requestRule rule = rBll.GetModel(id);
            rule.reqKeywords = txtreqKeywords.Text.Trim();
            string radoValue = rblisLikeSearch.SelectedItem.Value;
            if (radoValue == "0")
            {
                rule.isLikeSearch = false;
            }
            else
            {
                rule.isLikeSearch = true;
            }
            bool ret = rBll.Update(rule);
            IList<Model.wx_requestRuleContent> ruleContentList = rcBll.GetModelList("rId=" + id);
            if (ruleContentList != null && ruleContentList.Count > 0)
            {
                Model.wx_requestRuleContent ruleContent = ruleContentList[0];

                ruleContent.rContent = txtTitle.Text.Trim();
                ruleContent.rContent2 = txtrContent.Text.Trim();
                ruleContent.mediaUrl = txtMediaUrl.Text.Trim();
                ret = rcBll.Update(ruleContent);
            }
            if (ret)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改语音回复，主键为:" + rule.id); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改语音回复信息成功！", "yuYinList.aspx", "Success");
            }
            else //添加
            {
                // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }

                JscriptMsg("添加语音回复信息成功！", "yuYinList.aspx", "Success");
            }
        }
    }
}