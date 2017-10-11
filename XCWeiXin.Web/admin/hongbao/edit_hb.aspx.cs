using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;
using System.Text;
using System.Net;

namespace XCWeiXin.Web.admin.hunqing
{
    public partial class edit_hb : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_hb_base sstBll = new wx_hb_base();

        wx_requestRule rBll = new wx_requestRule();

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
                if (!sstBll.Exists(id))
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
                else
                {
                    txtStartTime.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            
           
           
        }


        

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
              Model.wx_userweixin weixin = GetWeiXinCode();
              litwUrl.Text = MyCommFun.getWebSite() + "/weixin/hongbao/index.aspx?wid=" + weixin.id + "&xid=" + id;
            hidid.Value = id.ToString();
            Model.wx_hb_base hb = sstBll.GetModel(id);

            Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='红包' and modelFunctionId=" + id)[0];

            txtDepict.Value = hb.depict;
            txtEndTime.Text = hb.endTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtPayname.Text = hb.payname;
            txtPaynum.Text = hb.paynum;
            txtPaypass.Text = hb.paypass;
            if (hb.payreIP.Length>1)
            txtPayreIP.Text = hb.payreIP;
            else
            txtPayreIP.Text = GetAddressIP();

            if (hb.payZSadd.Length>1)
            txtPayZSadd.Text = hb.payZSadd;
            else
            txtPayZSadd.Text = "/weixin/hongbao/"+id+"/cert/apiclient_cert.p12";

            txtPricemax.Text = hb.pricemax.ToString();
            txtPricemin.Text = hb.pricemin.ToString();
            txtSignname.Text = hb.signname;
            txtStartTime.Text=hb.startTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtTitle.Text = hb.title;
            txtZftxt.Text = hb.zftxt;

        
            
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！";
            }
            if (this.txtDepict.Value.Trim().Length == 0)
            {
                strErr += "描述不能为空！";
            }
            if (this.txtPayname.Text.Trim().Length == 0 )
            {
                strErr += "商户名称不能为空！";
            }
            if (this.txtPaynum.Text.Trim().Length == 0 )
            {
                strErr += "商户ID不能为空！";
            }
            if (this.txtPaypass.Text.Trim().Length == 0)
            {
                strErr += "密钥不能为空！";
            }
            

            if (this.txtPricemax.Text.Trim().Length == 0)
            {
                strErr += "最大金额不能为空！";
            }

            if (this.txtPricemin.Text.Trim().Length == 0)
            {
                strErr += "最小金额不能为空！";
            }

            if (this.txtStartTime.Text.Trim().Length == 0)
            {
                strErr += "活动开始时间不能为空！";
            }
            if (this.txtEndTime.Text.Trim().Length == 0)
            {
                strErr += "活动结束时间不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            #endregion

            #region 赋值
            Model.wx_hb_base hb = new Model.wx_hb_base();
            Model.wx_requestRule rule = new Model.wx_requestRule();        
            if (id > 0)
            {
                hb = sstBll.GetModel(id);
            }
         
            hb.payname=txtPayname.Text.Trim();
            hb.paynum=txtPaynum.Text.Trim();
            hb.paypass=txtPaypass.Text.Trim();
            hb.payreIP=txtPayreIP.Text.Trim();
            hb.payZSadd=txtPayZSadd.Text.Trim();
            hb.pricemax=int.Parse(txtPricemax.Text.Trim());
            hb.pricemin=int.Parse(txtPricemin.Text.Trim());
           
            hb.startTime=MyCommFun.Obj2DateTime(txtStartTime.Text);
            hb.title=txtTitle.Text.Trim();
            hb.zftxt=txtZftxt.Text.Trim();
            hb.endTime=MyCommFun.Obj2DateTime(txtEndTime.Text);
            hb.depict = txtDepict.Value;
            hb.appID = weixin.AppId;
       //     XCWeiXin.API.WxPayAPI.RequestHandler packageReqHandler =new API.WxPayAPI.RequestHandler();
       //     string paySign = packageReqHandler.CreateMd5Sign("key", txtPaypass.Text.Trim());
        //    hb.signname = paySign;
            #endregion

            if (id <= 0)
            {  //新增
                hb.wid = weixin.id;
               
                hb.addtime = DateTime.Now;
                //1新增主表
                id = sstBll.Add(hb);


                //2 新增回复规则表
                rBll.AddModeltxtPicRule(weixin.id, "红包", id, txtTitle.Text.Trim());
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加红包，主键为" + id); //记录日志
                JscriptMsg("添加红包成功！", "index_hb.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                sstBll.Update(hb);

                //2 修改回复规则表
                IList<Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '红包' and modelFunctionId=" + id);

                if (rlist != null && rlist.Count > 0)
                {
                    rule = rlist[0];
                    rule.reqKeywords = txtTitle.Text.Trim();
                    rBll.Update(rule);
                }
                else
                {
                    rBll.AddModeltxtPicRule(weixin.id, "红包", id, txtTitle.Text.Trim());
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改红包，主键为" + id); //记录日志
                JscriptMsg("修改成功！", "index_hb.aspx", "Success");
            }


        }


        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
 
    }
}