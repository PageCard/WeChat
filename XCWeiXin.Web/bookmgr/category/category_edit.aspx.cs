using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;

namespace XCWeiXin.Web.bookmgr.category
{
    public partial class category_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
           
            this.id = MXRequest.GetQueryInt("id");

           
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_book_category().Exists(this.id))
                {
                    JscriptMsg("预订类别不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
              //  ChkAdminLevel("channel_" + this.channel_name + "_category", MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.wx_book_category bll = new BLL.wx_book_category();

            Model.wx_userweixin weixin = GetWeiXinCode();

            DataTable dt = bll.GetWCodeList(weixin.id, 0);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级菜单", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.wx_book_category bll = new BLL.wx_book_category();
            Model.wx_book_category model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.parent_id.ToString();
           
            txtTitle.Text = model.title;
            txtSortId.Text = model.sort_id.ToString();
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
            txtLinkUrl.Text = model.link_url;
            txtImgUrl.Text = model.img_url;
            if (model.img_url != null && model.img_url.Trim() != "")
            {
                imgUrl.ImageUrl = model.img_url;
            }
            txtContent.Text = model.class_content;
            txtImgICO.Text = model.ico_url;
            if (model.ico_url != null && model.ico_url.Trim() != "")
            {
                if (model.ico_url.Contains("/"))
                {
                    imgIco.ImageUrl = model.ico_url;
                }
                else
                {
                    imgIco.Style.Add("display", "none");
                    litImgIco.Text = "<span class=\"" + model.ico_url + "\"></span>";
                }
            }

            model.albums = new wx_book_albums().GetModelList("classId=" + model.id);
            rptAlbumList.DataSource = model.albums;
            rptAlbumList.DataBind();


        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.wx_book_category model = new Model.wx_book_category();
                BLL.wx_book_category bll = new BLL.wx_book_category();
            
             
                model.title = txtTitle.Text.Trim();
                model.parent_id = int.Parse(ddlParentId.SelectedValue);
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                model.seo_title = txtSeoTitle.Text;
                model.seo_keywords = txtSeoKeywords.Text;
                model.seo_description = txtSeoDescription.Text;
                model.link_url = txtLinkUrl.Text.Trim();
                model.img_url = txtImgUrl.Text.Trim();
                model.class_content = txtContent.Text.Trim();
                model.ico_url = Request.Form["txtImgICO"].Trim();// txtImgICO.Text;
                Model.wx_userweixin weixin = GetWeiXinCode();
                model.wid = weixin.id;



                #region 保存相册====================
                //检查是否有自定义图片
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
                if (albumArr != null && albumArr.Length > 0)
                {
                    List<Model.wx_book_albums> ls = new List<Model.wx_book_albums>();
                    for (int i = 0; i < albumArr.Length; i++)
                    {
                        string[] imgArr = albumArr[i].Split('|');
                        if (imgArr.Length == 3)
                        {
                            if (!string.IsNullOrEmpty(remarkArr[i]))
                            {
                                ls.Add(new Model.wx_book_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                            }
                            else
                            {
                                ls.Add(new Model.wx_book_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                            }
                        }
                    }
                    model.albums = ls;
                }
                #endregion
                if (bll.Add(model) > 0)
                {
                    AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加预订分类:" + model.title); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.wx_book_category bll = new BLL.wx_book_category();
                Model.wx_book_category model = bll.GetModel(_id);

                int parentId = int.Parse(ddlParentId.SelectedValue);

                model.title = txtTitle.Text.Trim();
                //如果选择的父ID不是自己,则更改
                if (parentId != model.id)
                {
                    model.parent_id = parentId;
                }
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                model.seo_title = txtSeoTitle.Text;
                model.seo_keywords = txtSeoKeywords.Text;
                model.seo_description = txtSeoDescription.Text;
                model.link_url = txtLinkUrl.Text.Trim();
                model.img_url = txtImgUrl.Text.Trim();
                model.class_content = txtContent.Text.Trim();
                model.ico_url = Request.Form["txtImgICO"].Trim();// txtImgICO.Text;


                #region 保存相册====================
                //检查是否有自定义图片
                if (model.albums != null)
                {
                    model.albums.Clear();
                }
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
                if (albumArr != null)
                {
                    List<Model.wx_book_albums> ls = new List<Model.wx_book_albums>();
                    for (int i = 0; i < albumArr.Length; i++)
                    {
                        string[] imgArr = albumArr[i].Split('|');
                        int img_id = Utils.StrToInt(imgArr[0], 0);
                        if (imgArr.Length == 3)
                        {
                            if (!string.IsNullOrEmpty(remarkArr[i]))
                            {
                                ls.Add(new Model.wx_book_albums { id = img_id, productId = id, original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                            }
                            else
                            {
                                ls.Add(new Model.wx_book_albums { id = img_id, productId = id, original_path = imgArr[1], thumb_path = imgArr[2] });
                            }
                        }
                    }
                    model.albums = ls;
                }

                #endregion
                if (bll.Update(model))
                {
                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改预订目分类:" + model.title); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存类别
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
               // ChkAdminLevel("channel_" + this.channel_name + "_category", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {

                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改预订类别成功！", "category_list.aspx", "Success");
            }
            else //添加
            {
               // ChkAdminLevel("channel_" + this.channel_name + "_category", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加预订类别成功！", "category_list.aspx", "Success");
            }
        }
    }
}