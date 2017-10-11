using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCWeiXin.Web
{
    public partial class wether : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
            string url = "https://api.seniverse.com/v3/weather/daily.json";
            string postdata = "key=gj0bzc3lhudxttxn&location=36.069938:103.88660215&language=zh-Hans&unit=c&start=0&days=3";
            var weather = HttpGet(url, postdata);
        
            JavaScriptSerializer js = new JavaScriptSerializer();
            Model.weather.Root team =
            team = js.Deserialize<Model.weather.Root>(weather);


            Response.Write(team.results[0].daily[0].low);
          
          
        }
     
            
        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}