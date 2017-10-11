using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCWeiXin.Common;
using System.Data;
using XCWeiXin.DBUtility;
using System.Text;
namespace XCWeiXin.Web.templates.Doc.Hugo_list
{
    /// <summary>
    /// list_l 的摘要说明
    /// </summary>
    public class list_l : IHttpHandler
    {
      
      // string pass = MyCommFun.RequestParam("pass_1");

        public void ProcessRequest(HttpContext context)
        {
            string action = MyCommFun.RequestParam("action");
            int user = MyCommFun.RequestInt("Hg_number");
            string order = MyCommFun.RequestParam("order_number");
            string text = MyCommFun.RequestParam("text");
            if(action=="Suc_pay")
            {
            context.Response.ContentType = "text/json";
            context.Response.Write(MyCommFun.GetJsonByDataset(Get_pay(user)));
            }
            else if (action == "all_suc")
            {
                context.Response.ContentType = "text/json";
                context.Response.Write(MyCommFun.GetJsonByDataset(Get_all(user)));
 
            }
            else if (action == "upload_start")
            {
                if (Update_start(text, order) == true)
                {
                    context.Response.ContentType = "text/json";
                    Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                    jsonDict = new Dictionary<string, string>();
                    jsonDict.Add("errCode", "false");
                    jsonDict.Add("recontent", "更新成功!");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }
                else
                {
                    context.Response.ContentType = "text/json";
                    Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                    jsonDict = new Dictionary<string, string>();
                    jsonDict.Add("errCode", "false");
                    jsonDict.Add("recontent", "fail!");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
 
                }
            }
        }
        public DataSet Get_pay(int user)
        {
            string str = "select  * from A_HG_oreder where HG_number=" + user + " and ((Status_order='已支付') or (Status_order='进行中'))";
            return DbHelperSQL.Query(str);

        }
        public DataSet Get_all(int user)
        {
            string str = "select  * from A_HG_oreder where (HG_number=" + user + ") and (Status_order='已完成') or (Status_order='待评价')";
            return DbHelperSQL.Query(str);

        }
      
        public bool Update_start(string idlist,string orderid)
        {
            
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update  A_HG_oreder ");
          strSql.Append(" set Status_order='" + idlist + "' where Order_dd='" + orderid + "' ");
          int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
          if (rows > 0)
          {
              return true;
          }
          else
          {
              return false;
          }
      
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}