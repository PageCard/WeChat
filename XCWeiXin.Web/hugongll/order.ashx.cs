using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using XCWeiXin.Common;
using XCWeiXin.DBUtility;

namespace XCWeiXin.Web.hugongll
{
    /// <summary>
    /// order1 的摘要说明
    /// </summary>
    public class order1 : IHttpHandler
    {
       

        public void ProcessRequest(HttpContext context)
        {
            string where=context.Request.QueryString["where"];
            string openid=context.Request.QueryString["openid"];
            string action=context.Request.QueryString["action"];
            string order_id=context.Request.QueryString["order_dd"];
            if (action =="order")
            {
                context.Response.ContentType = "text/json";
                context.Response.Write(MyCommFun.GetJsonByDataset(order_new(openid, where)));
 
            }
            else if(action=="delete_order")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                jsonDict = new Dictionary<string, string>();


                Update_delete("已删除",order_id);
                jsonDict.Add("errCode", "false");
                jsonDict.Add("recontent", "更新成功!");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
            }
            else if (action == "list")
            {
                context.Response.ContentType = "text/json";
                context.Response.Write(MyCommFun.GetJsonByDataset(list()));
 
            }
           
        }
        /// <summary>
        /// 更新删除字段数据库订单
        /// </summary>
        /// <param name="list"></param>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public bool Update_delete(string list, string orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update A_HG_new_order ");
            str.Append(" set Delet_='" + list + "' where order_dd='" + orderid + "' ");
            int row = DbHelperSQL.ExecuteSql(str.ToString());
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除选中订单
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from A_HG_new_order ");
            strSql.Append(" where order_dd='" + idlist + "'   ");
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
        public DataSet list()
        {
            string str = "select * from A_HG_HG";
            return DbHelperSQL.Query(str.ToString());
        }
        public DataSet order_new(string openid, string where)
        {
            string str = "select * from A_HG_new_order where (openid_='" + openid + "') and " + where + " order by order_ DESC";
            return DbHelperSQL.Query(str.ToString());
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