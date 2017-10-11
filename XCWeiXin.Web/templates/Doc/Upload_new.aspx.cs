using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class Upload_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        
        }
         #region 文件上传
  /// <summary>
  /// 文件上传
  /// </summary>
  protected void Button1_Click(object sender, EventArgs e)
  {
   if (FileUpload1.FileName == "")
   {
    this.Label1.Text = "上传文件不能为空";
    return;
   }
 
   bool fileIsValid = false;
   //如果确认了上传文件，则判断文件类型是否符合要求 
   if (this.FileUpload1.HasFile)
   {
    //获取上传文件的后缀 
    String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
    String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
    //判断文件类型是否符合要求 
    for (int i = 0; i < restrictExtension.Length; i++)
    {
     if (fileExtension == restrictExtension[i])
     {
      fileIsValid = true;
     }
     //如果文件类型符合要求,调用SaveAs方法实现上传,并显示相关信息 
     if (fileIsValid == true)
     {
      //上传文件是否大于10M
      if (FileUpload1.PostedFile.ContentLength > (10 * 1024 * 1024))
      {
       this.Label1.Text = "上传文件过大";
       return;
      }
      try
      {
       //this.Image1.ImageUrl = "upimage/" + FileUpload1.FileName;
       this.FileUpload1.SaveAs(Server.MapPath("upimage\\") + FileUpload1.FileName);
       this.Label1.Text = "文件上传成功!";
       Label2.Text = "客户端路径：" + FileUpload1.PostedFile.FileName + "<br>" +
"文件名：" + System.IO.Path.GetFileName(FileUpload1.FileName) + "<br>" +
"文件扩展名：" + System.IO.Path.GetExtension(FileUpload1.FileName) + "<br>" +
"文件大小：" + FileUpload1.PostedFile.ContentLength + " KB<br>" +
"文件MIME类型：" + FileUpload1.PostedFile.ContentType + "<br>" +
"保存路径：" + Server.MapPath("upload") + "\\" + FileUpload1.FileName;
      }
      catch
      {
       this.Label1.Text = "文件上传失败！";
      }
      finally
      {
 
      }
     }
     else
     {
      this.Label1.Text = "只能够上传后缀为.gif,.jpg,.bmp,.png的文件";
     }
    }
   }
  }
  #endregion
 }
}
   