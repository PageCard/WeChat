using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;
using XCWeiXin.WeiXinComm;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;


namespace XCWeiXin.Web.admin.weixin
{
    public partial class wxMenu : Web.UI.ManagePage
    {

        WeiXinCRMComm cpp = new WeiXinCRMComm();
        MenuMgr mMrg = new MenuMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                GetMenu();

            }
        }

        #region 获取最新的菜单=================================
        private void GetMenu()
        {

            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
               
                string error = "";
                string accessToken = cpp.getAccessToken(weixin.id, out error);

                if (error != "")
                {
                    JscriptMsg(error, "", "Error");
                    return;
                }
                GetMenuResult result = mMrg.GetMenu(accessToken);
             
                if (result == null)
                {
                    //JscriptMsg("未获得到菜单，请参考【使用规则】，自行排查问题！", "", "Error");
                    return;
                    //强制刷新
                    //accessToken = cpp.FlushAccessToken(weixin.id, out  error);
                    //result = CommonApi.GetMenu(accessToken);

                }
              
                var topButtonList = result.menu.button;               
                int topNum = topButtonList.Count;
                TextBox txtName = new TextBox();
                TextBox txtKey = new TextBox();
                TextBox txtUrl = new TextBox();
                TextBox txtType = new TextBox();
                for (int i = 0; i < topNum; i++)
                {
                    var topButton = topButtonList[i];
                    
                    if (topButton != null)
                    {
                        txtName = this.FindControl("txtTop" + (i + 1)) as TextBox;
                        txtKey = this.FindControl("txtTop" + (i + 1) + "Key") as TextBox;
                        txtUrl = this.FindControl("txtTop" + (i + 1) + "Url") as TextBox;
                        txtType = this.FindControl("txtTop" + (i + 1) + "Type") as TextBox;
                        txtName.Text = topButton.name;
                       // txtType.Text = ((SingleViewButton)topButton).type;

                        if (topButton.GetType() != typeof(SubButton))
                        {//下面无子菜单
                            if (topButton.GetType() == typeof(SingleViewButton))
                            {  //view 页面跳转
                                txtUrl.Text = ((SingleViewButton)topButton).url;
                                txtType.Text = ((SingleViewButton)topButton).type;
                            }
                            else
                            {
                                txtKey.Text = ((SingleClickButton)topButton).key;
                                txtType.Text = ((SingleViewButton)topButton).type;
                            }

                        }
                        else
                        {   //下面有子菜单
                            IList<SingleButton> subButtonList = ((SubButton)topButton).sub_button;

                            if (subButtonList != null && subButtonList.Count > 0)
                            {

                                TextBox txtSubName = new TextBox();
                                TextBox txtSubKey = new TextBox();
                                TextBox txtSubUrl = new TextBox();
                                TextBox txtSubType = new TextBox();
                                for (int j = 0; j < subButtonList.Count; j++)
                                {
                                    txtSubName = this.FindControl("txtMenu" + (i + 1) + (j + 1)) as TextBox;
                                    txtSubKey = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Key") as TextBox;
                                    txtSubUrl = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Url") as TextBox;
                                    txtSubType = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Type") as TextBox;
                                  
                                    if (subButtonList[j].GetType() == typeof(SingleViewButton))
                                    {
                                        SingleViewButton sub = (SingleViewButton)subButtonList[j];                                       
                                        txtSubName.Text = sub.name;
                                        txtSubUrl.Text = sub.url;
                                      
                                        txtSubType.Text = sub.type;
                                    }
                                    else 
                                    {
                                        SingleClickButton sub = (SingleClickButton)subButtonList[j];
                                        txtSubName.Text = sub.name;
                                        txtSubKey.Text = sub.key;
                                        txtSubType.Text = sub.type;
                                    }
                                   


                                }
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                string aa = ex.Message;
                string bb = "";
            }
        }


        #endregion

        #region 备份菜单提取=================================
        private void GetMenuBack()
        {

            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                GetMenuResult result = mMrg.GetMenuBack(weixin.AppId);
                if (result == null)
                {
                    //JscriptMsg("未获得到菜单，请参考【使用规则】，自行排查问题！", "", "Error");
                    return;
                    //强制刷新
                    //accessToken = cpp.FlushAccessToken(weixin.id, out  error);
                    //result = CommonApi.GetMenu(accessToken);

                }

                var topButtonList = result.menu.button;
                int topNum = topButtonList.Count;
                TextBox txtName = new TextBox();
                TextBox txtKey = new TextBox();
                TextBox txtUrl = new TextBox();
                TextBox txtType = new TextBox();
                for (int i = 0; i < topNum; i++)
                {
                    var topButton = topButtonList[i];

                    if (topButton != null)
                    {
                        txtName = this.FindControl("txtTop" + (i + 1)) as TextBox;
                        txtKey = this.FindControl("txtTop" + (i + 1) + "Key") as TextBox;
                        txtUrl = this.FindControl("txtTop" + (i + 1) + "Url") as TextBox;
                        txtType = this.FindControl("txtTop" + (i + 1) + "Type") as TextBox;
                        txtName.Text = topButton.name;
                        // txtType.Text = ((SingleViewButton)topButton).type;

                        if (topButton.GetType() != typeof(SubButton))
                        {//下面无子菜单
                            if (topButton.GetType() == typeof(SingleViewButton))
                            {  //view 页面跳转
                                txtUrl.Text = ((SingleViewButton)topButton).url;
                                txtType.Text = ((SingleViewButton)topButton).type;
                            }
                            else
                            {
                                txtKey.Text = ((SingleClickButton)topButton).key;
                                txtType.Text = ((SingleViewButton)topButton).type;
                            }

                        }
                        else
                        {   //下面有子菜单
                            IList<SingleButton> subButtonList = ((SubButton)topButton).sub_button;

                            if (subButtonList != null && subButtonList.Count > 0)
                            {

                                TextBox txtSubName = new TextBox();
                                TextBox txtSubKey = new TextBox();
                                TextBox txtSubUrl = new TextBox();
                                TextBox txtSubType = new TextBox();
                                for (int j = 0; j < subButtonList.Count; j++)
                                {
                                    txtSubName = this.FindControl("txtMenu" + (i + 1) + (j + 1)) as TextBox;
                                    txtSubKey = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Key") as TextBox;
                                    txtSubUrl = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Url") as TextBox;
                                    txtSubType = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Type") as TextBox;
                                    if (subButtonList[j].GetType() == typeof(SingleViewButton))
                                    {
                                        SingleViewButton sub = (SingleViewButton)subButtonList[j];

                                        txtSubName.Text = sub.name;
                                        txtSubUrl.Text = sub.url;

                                        txtSubType.Text = sub.type;
                                    }
                                    else
                                    {
                                        SingleClickButton sub = (SingleClickButton)subButtonList[j];
                                        txtSubName.Text = sub.name;
                                        txtSubKey.Text = sub.key;
                                        txtSubType.Text = sub.type;
                                    }


                                }
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        /// <summary>
        /// 更新菜单
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();

                string error = "";
                string accessToken = cpp.getAccessToken(weixin.id, out error);

                if (error != "")
                {
                    JscriptMsg(error, "", "Error");
                    return;
                }


                //重新整理按钮信息
                ButtonGroup bg = new ButtonGroup();
                TextBox txtName = new TextBox();
                TextBox txtKey = new TextBox();
                TextBox txtUrl = new TextBox();
                TextBox txtType = new TextBox();
                IList<BaseButton> topList = new List<BaseButton>();
                IList<SingleButton> subList = new List<SingleButton>();
                #region 菜单设置
                for (int i = 0; i < 3; i++)
                {
                    txtName = this.FindControl("txtTop" + (i + 1)) as TextBox;
                    txtKey = this.FindControl("txtTop" + (i + 1) + "Key") as TextBox;
                    txtUrl = this.FindControl("txtTop" + (i + 1) + "Url") as TextBox;
                    txtType = this.FindControl("txtTop" + (i + 1) + "Type") as TextBox;
                    if (txtName.Text.Trim() == "")
                    {
                        // 如果名称为空，则忽略该菜单，以及下面的子菜单
                        continue;
                    }


                    subList = new List<SingleButton>();
                    TextBox txtSubName = new TextBox();
                    TextBox txtSubKey = new TextBox();
                    TextBox txtSubUrl = new TextBox();
                    TextBox txtSubType = new TextBox();
                    for (int j = 0; j < 5; j++)
                    {
                        #region 子菜单的设置
                        txtSubName = this.FindControl("txtMenu" + (i + 1) + (j + 1)) as TextBox;
                        txtSubKey = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Key") as TextBox;
                        txtSubUrl = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Url") as TextBox;
                        txtSubType = this.FindControl("txtMenu" + (i + 1) + (j + 1) + "Type") as TextBox;
                        if (txtSubName.Text.Trim() == "")
                        {
                            continue;
                        }

                        if (txtSubUrl.Text.Trim() != "")
                        {
                            SingleViewButton sub = new SingleViewButton();
                            sub.name = txtSubName.Text.Trim();
                            sub.url = txtSubUrl.Text.Trim();
                        //    sub.type = txtSubType.Text.Trim();
                            subList.Add(sub);

                        }
                        else if (txtSubKey.Text.Trim() != "")
                        {
                            SingleClickButton sub = new SingleClickButton();
                            sub.name = txtSubName.Text.Trim();
                            sub.key = txtSubKey.Text.Trim();
                            sub.type = txtSubType.Text.Trim();
                            subList.Add(sub);
                        }
                        else
                        {
                            //报错 :子菜单必须有key和name
                            JscriptMsg("二级菜单的名称和key或者url必填！", "", "Error");
                            return;
                        }
                        #endregion

                    } //子菜单循环结束


                    if (subList != null && subList.Count > 0)
                    {
                        //有子菜单, 该一级菜单是SubButton
                        if (subList.Count < 1)
                        {
                            JscriptMsg("子菜单个数为2~5个！", "", "Error");
                            return;
                        }
                        SubButton topButton = new SubButton(Utils.CutString(txtName.Text.Trim(), 16));
                        topButton.sub_button.AddRange(subList);
                        topList.Add(topButton);
                    }
                    else
                    {
                        // 无子菜单
                        if (txtKey.Text.Trim() == "" && txtUrl.Text.Trim() == "")
                        {
                            JscriptMsg("若无子菜单，必须填写key或者url值！", "", "Error");
                            return;
                        }

                        if (txtUrl.Text.Trim() != "")
                        {  //view 页面跳转
                            SingleViewButton topSingleButton = new SingleViewButton();
                            topSingleButton.name = txtName.Text.Trim();
                            topSingleButton.url = txtUrl.Text.Trim();
                           // topSingleButton.type = txtType.Text.Trim();
                            topList.Add(topSingleButton);
                        }
                        else if (txtKey.Text.Trim() != "")
                        {
                            SingleClickButton topSingleButton = new SingleClickButton();
                            topSingleButton.name = txtName.Text.Trim();
                            topSingleButton.key = txtKey.Text.Trim();
                            topSingleButton.type = txtType.Text.Trim();
                            topList.Add(topSingleButton);
                        }
                    }
                }


                #endregion

                bg.button.AddRange(topList);
                var result = mMrg.CreateMenu(accessToken, bg);
                JscriptMsg("菜单提交成功！", "wxMenu.aspx", "Success");
            }
            catch (Exception ex)
            {
                JscriptMsg("报错：" + ex.Message, "", "Error");
            }

        }

        /// <summary>
        /// 提取备份菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBackMenu_Click(object sender, EventArgs e)
        {
           
            GetMenuBack();

        }
        /// <summary>
        /// 备份菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddMenu_Click(object sender, EventArgs e)
        {

            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();

                string error = "";
                string accessToken = cpp.getAccessToken(weixin.id, out error);

                if (error != "")
                {
                    JscriptMsg(error, "", "Error");
                    return;
                }

                JscriptMsg(mMrg.GetMenuAdd(weixin.AppId, accessToken), "", "Success");
            }
            catch (Exception ex)
            {
                JscriptMsg("报错：" + ex.Message, "", "Error");
            }

        }


        /// <summary>
        /// 删当前菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelMenu_Click(object sender, EventArgs e)
        {
            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();

                string error = "";
                string token = cpp.getAccessToken(weixin.id, out error);
                if (error != "")
                {
                    JscriptMsg(error, "", "Error");
                    return;
                }
                var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.DeleteMenu(token);
                //重新获得最新的菜单
                GetMenu();

            }
            catch (Exception ex)
            {
                JscriptMsg("执行过程出现错误：" + ex.Message, "back", "Error");
                return;
            }

        }


        protected void FlushAT_Click(object sender, EventArgs e)
        {
            try
            {

                Model.wx_userweixin weixin = GetWeiXinCode();

                string error = "";
                cpp.FlushAccessToken(weixin.id, out error);
                if (error != "")
                {
                    JscriptMsg(error, "", "Error");
                    return;
                }

                JscriptMsg("Access_Token更新成功！", "wxMenu.aspx", "Success");
            }
            catch (Exception ex)
            {
                JscriptMsg("执行过程出现错误：" + ex.Message, "back", "Error");
                return;
            }


        }

    }
}