using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace XCWeiXin.Web.templates.Doc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void bt1_Click(object sender, EventArgs e)
        {
           
                HttpPostedFile f = Request.Files["file0"];
                int i = f.FileName.LastIndexOf(".");///长度
                string jpg = f.FileName.Substring(i);///获取后缀（ex:.png）
                if ((jpg.ToLower() == ".jpg") || (jpg.ToLower() == ".png") || (jpg.ToLower() == ".jpeg") || (jpg.ToLower() == ".gif") || (jpg.ToLower() == ".swf"))
                {
                    Stream m = f.InputStream;
                    string a = m.Length.ToString();
                    string n = m.ToString();
                    string bb = f.FileName;
                    int aa = f.ContentLength;
                    f.SaveAs(Server.MapPath("upimage\\") + f.FileName);
                    string ddd = Server.MapPath("upimage\\") + f.FileName;
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "操作提示", "<script>alert('文件格式不支持')</script>"); 
                }
                 //string kk= GetBase64FromImage(ddd);
      //GetImageFromBase64(kk);
            }
     

       

        
        /// <summary>
        /// data64转化image
        /// </summary>
        /// <param name="base64string"></param>
        /// <returns></returns>
        public Bitmap GetImageFromBase64(string base64string)
        {
            byte[] b = Convert.FromBase64String(base64string);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);
            bitmap.Save((Server.MapPath("upimage\\") + "去你妈的" + ".jpg"));
            return bitmap;
        }

        /// <summary>
        /// image转化data64
        /// </summary>
        /// <param name="imagefile"></param>
        /// <returns></returns>
        public string GetBase64FromImage(string imagefile)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(imagefile);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }
    }
}