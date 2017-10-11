﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;

namespace XCWeiXin.Web.admin.templates
{
    public partial class template_list : Web.UI.ManagePage
    {
       
        wx_templates tBll = new wx_templates();
        wx_wsite_modulebase mBll = new wx_wsite_modulebase();
        wx_templates_wcode twBll = new wx_templates_wcode();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                RptBind(weixin.id);
            }
        }

         

        #region 数据绑定=================================
        /// <summary>
        /// 绑定模版,颜色
        /// </summary>
        /// <param name="wid"></param>
        private void RptBind(int wid)
        {
          
            // 首页模版数据绑定
            this.rptList01.DataSource = tBll.GetModelList("typeId=1");
            this.rptList01.DataBind();

            //二级页面模版
            rptList02.DataSource = tBll.GetModelList("typeId=4");
            rptList02.DataBind();
            //列表页
            this.rptList03.DataSource = tBll.GetModelList("typeId=2");
            this.rptList03.DataBind();
            //详细页
            this.rptList04.DataSource = tBll.GetModelList("typeId=3");
            this.rptList04.DataBind();

            //---------- 绑定颜色  start-----------
            IList<Model.wx_wsite_modulebase> mlist = mBll.GetModelList("1=1");
            Model.wx_wsite_modulebase mbase = new Model.wx_wsite_modulebase();
            for (int i = 0; i < mlist.Count; i++)
            {
                mbase = mlist[i];
                if (mbase.mCode.IndexOf("no") >= 0)
                {
                }
                else
                {
                    mbase.mName = "<img src=\"" + mbase.mName + "\">";
                }
            }

            //颜色选择
            this.rptColor.DataSource = mlist;
            this.rptColor.DataBind();
            //---------- 绑定颜色 end-----------

            //绑定当前微帐号选择的模版Id和颜色
            IList<Model.wx_templates_wcode> twlist = twBll.GetModelList("wid=" + wid);
             if (twlist != null && twlist.Count()>0 )
             {
                 hidWTId.Value = twlist[0].id.ToString();
                 aLookIndex.NavigateUrl = "/index.aspx?wid=" + wid;
                 aLookIndex.Target = "_blank";
                 int selectColorId = 0;
                 if (twlist[0].topcolorTypeId == null || twlist[0].topcolorTypeId < 0)
                 {
                     selectColorId = 3; //红色的1
                 }
                 else
                 {
                     selectColorId = twlist[0].topcolorTypeId.Value;
                 }
                 MessageBox.ResponseScript(this, "$(\"#rad_list01" + twlist[0].tid + "\").attr(\"checked\",\"checked\"); $(\"#rad_list02" + twlist[0].channelTid + "\").attr(\"checked\",\"checked\");$(\"#rad_list03" + twlist[0].listTid + "\").attr(\"checked\",\"checked\");$(\"#rad_list04" + twlist[0].detailTid + "\").attr(\"checked\",\"checked\");$(\"#radcolor" + selectColorId + "\").attr(\"checked\",\"checked\");");
             }

        }

        #endregion

        
        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
          
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
         
        }


        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int tId = MyCommFun.Str2Int(txtSelectTemplateId.Text);//首页
            int erjiTId = MyCommFun.Str2Int(txtSelectErJiTemplateId.Text);//二级页面模版
            int list03Id = MyCommFun.Str2Int(txtSelectList03TemplateId.Text);//列表页面模版
            int list04Id = MyCommFun.Str2Int(txtSelectList04TemplateId.Text);//详细页面模版
            int colorId = MyCommFun.Str2Int(txtSelectColorId.Text);//颜色
            if (tId != 0)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();

                Model.wx_templates_wcode tw = new Model.wx_templates_wcode();
                bool isAdd = true;
                bool Succ = false;
                if (hidWTId.Value != "0")
                {
                    int wtId = MyCommFun.Str2Int(hidWTId.Value);
                    tw = twBll.GetModel(wtId);
                    if (tw != null)
                    {
                        isAdd = false;
                    }
                }
                tw.wid = weixin.id;
                tw.tid = tId;
                tw.channelTid = erjiTId;
                tw.listTid = list03Id;
                tw.detailTid = list04Id;
                tw.createDate = DateTime.Now;

                //颜色
                string colorContent = mBll.getValuestr(colorId);
                tw.topcolorTypeId = colorId;
              
                tw.topcolorHtml = colorContent;

                if (isAdd)
                {
                  int id=  twBll.Add(tw);
                  if (id > 0)
                  { Succ = true; }
                  hidWTId.Value = id.ToString();
                }
                else
                {
                  Succ= twBll.Update(tw);
                }
                if (Succ)
                {
                    JscriptMsg("模版设置成功！", "template_list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("模版设置失败！", "", "Error");
                }
            }
           
            
        }
 
       
        
    }
}