using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (UpLoadPic())
            {
                Response.Write(FileUpload1.PostedFile.FileName.ToString());
            }
        }
        private string[] AcceptedFileTypes = new string[] { "jpg", "jpeg", "jpe", "png", "p2p" };
        public bool UpLoadPic()//上传  
        {
            bool ifSucess = false;
            if (FileUpload1.PostedFile.ContentLength > 0)
            {
                if (IsValidFileType(FileUpload1.PostedFile.FileName))
                {

                    if (FileUpload1.PostedFile.ContentLength < 1024 * 2000)
                    {

                        string fullName = FileUpload1.PostedFile.FileName;
                        string newName = System.DateTime.Now.ToString("yyyyMMddhhmmss") + fullName.Substring(fullName.LastIndexOf("."));
                        string path = Server.MapPath("~/admin/images/new/");
                        FileUpload1.SaveAs(path + "/" + newName);
                        Label2.Text = newName;
                        Image1.ImageUrl = "~/admin/images/new/" + newName;
                        Image1.Visible = true;
                        ifSucess = true;
                    }
                    else
                    {
                        Response.Write("<script>alert(’出错了！上传文件太大！’)</script>");
                    }
                }
                else
                {
                    ifSucess = false;
                    Response.Write("<script>alert(’出错了！上传文件格式不对！’)</script>");
                }
            }
            else
            {
                Response.Write("<script>alert(’出错了！上传文件不能为空！’)</script>");
            }
            return ifSucess;
        }
        private bool IsValidFileType(string FileName)//图片格式检验  
        {
            string ext = FileName.Substring(FileName.LastIndexOf(".") + 1, FileName.Length - FileName.LastIndexOf(".") - 1);
            for (int i = 0; i < AcceptedFileTypes.Length; i++)
            {
                if (ext.ToLower() == AcceptedFileTypes[i])
                {
                    return true;
                }
            }
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strname = FileUpload1.PostedFile.FileName;//使用文件名

            if (strname != "")
            {
                bool fileOK = false;
                int i = strname.LastIndexOf(".");
                string kzm = strname.Substring(i);
                string Newname = Guid.NewGuid().ToString();
                // string xingdui = @"~\images\";
                string juedui = Server.MapPath("~\\admin\\images\\new\\");
                string newFilename = juedui + Newname;
                if (FileUpload1.HasFile)
                {
                    String[] allowedExtensions = { ".gif", ".png",".jpeg", ".bmp", ".jpg", ".txt" };
                    for (int j = 0; j < allowedExtensions.Length; j++)
                    {
                        if (kzm == allowedExtensions[j])
                        {
                            fileOK = true;
                        }
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        newFilename = newFilename + kzm;
                        // 判定该路径是否存在
                        if (!Directory.Exists(juedui))
                            Directory.CreateDirectory(juedui);
                        //为了能看清楚我们提取出来的图片地址，在这使用label
                        Label2.Text = "<b>原文件路径：</b>" + FileUpload1.PostedFile.FileName + "<br />" +
                                       "<b>文件大小：</b>" + FileUpload1.PostedFile.ContentLength + "字节<br />" +
                                       "<b>文件类型：</b>" + FileUpload1.PostedFile.ContentType;
                        //   Label3.Text = xiangdui + newName + kzm;

                        Label4.Text = "文件上传成功.";


                        FileUpload1.PostedFile.SaveAs(newFilename);//将图片存储到服务器上
                    }
                    catch (Exception)
                    {
                        Label4.Text = "文件上传失败.";
                    }
                }
                else
                {
                    Label4.Text = "只能够上传图片文件.";
                }

            }
            //protected void upfile_Click(object sender, EventArgs e)
            //{
            //    string strname = FileUpload1.PostedFile.FileName;//使用文件名
            //    newPreview.ImageUrl = strname;
            //    if (strname != "")
            //    {
            //        bool fileOK = false;
            //        int i = strname.LastIndexOf(".");
            //        string kzm = strname.Substring(i);
            //        string Newname = Guid.NewGuid().ToString();
            //       // string xingdui = @"~\images\";
            //        string juedui = Server.MapPath("~\\admin\\images\\new\\");
            //        string newFilename = juedui + Newname;
            //        if (FileUpload1.HasFile)
            //        {
            //            String[] allowedExtensions = { ".gif", ".png", ".bmp", ".jpg", ".txt" };
            //            for (int j = 0; j < allowedExtensions.Length; j++)
            //            {
            //                if (kzm == allowedExtensions[j])
            //                {
            //                    fileOK = true;
            //                }
            //            }
            //        }
            //        if (fileOK)
            //        {
            //            try
            //            {
            //                newFilename = newFilename + kzm;
            //                // 判定该路径是否存在
            //                if (!Directory.Exists(juedui))
            //                    Directory.CreateDirectory(juedui);
            //                newPreview.ImageUrl = newFilename;     //为了能看清楚我们提取出来的图片地址，在这使用label
            //                Label2.Text = "<b>原文件路径：</b>" + FileUpload1.PostedFile.FileName + "<br />" +
            //                               "<b>文件大小：</b>" + FileUpload1.PostedFile.ContentLength + "字节<br />" +
            //                               "<b>文件类型：</b>" + FileUpload1.PostedFile.ContentType + "@@@" + MyCommFun.GetRootPath() + "admin" + "\\" + "images" + "\\new" + "\\" + Newname + kzm+ "<br />";
            //             //   Label3.Text = xiangdui + newName + kzm;
            //                string ss = MyCommFun.GetRootPath().ToString();
            //                Label4.Text = "文件上传成功.";

            //                newPreview.ImageUrl = MyCommFun.GetRootPath() + "admin" + "\\" + "images" + "\\new"+"\\"+Newname+kzm;
            //                FileUpload1.PostedFile.SaveAs(newFilename);//将图片存储到服务器上
            //            }
            //            catch (Exception)
            //            {
            //                Label4.Text = "文件上传失败.";
            //            }
            //        }
            //        else
            //        {
            //            Label4.Text = "只能够上传图片文件.";
            //        }    
            //    }



        }
    }
}