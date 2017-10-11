using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using XCWeiXin.Common;
using XCWeiXin.DBUtility;

namespace XCWeiXin.Web.Web_tell
{
    /// <summary>
    /// GetData 的摘要说明
    /// </summary>
    public class GetData : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            string type = MyCommFun.RequestParam("type");
            if (type == "list")
            {
                int pagesize = MyCommFun.RequestInt("pagesize");
                int pageindex = MyCommFun.RequestInt("pageindex");
                string str = MyCommFun.RequestParam("str");
                if (pageindex == 1)
                {
                    context.Response.ContentType = "text/json";
                    context.Response.Write(GetJsonByDataset(GetList(str)));

                }
                else
                {
                    context.Response.ContentType = "text/json";
                    context.Response.Write(null);

                }
            }
            else if (type == "tell")
            {
                string strwhere = MyCommFun.RequestParam("strwh");
                context.Response.ContentType = "text/json";
                context.Response.Write(GetJsonByDataset(Get_tell(strwhere)));
            }
            else if (type == "back")
            {
                string stt = MyCommFun.RequestParam("stt");
                context.Response.ContentType = "text/json";
                context.Response.Write(GetJsonByDataset(GetList(stt)));

            }
        }
        /// <summary>
        /// 查询会话聊天记录（包含请求）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Get_tell(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select * from wx_response_BaseData  ");
            if (strWhere.Trim() != "")
            {
                str.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(str.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wx_response_BaseData a  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 把dataset数据转换成json的格式
        /// </summary>
        /// <param name="ds">dataset数据集</param>
        /// <returns>json格式的字符串</returns>
        public static string GetJsonByDataset(DataSet ds)
        {
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                //如果查询到的数据为空则返回标记ok:false
                return "{\"ok\":false}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"ok\":true,\"count\":" + ds.Tables[0].Rows.Count + ",");
            foreach (DataTable dt in ds.Tables)
            {
                sb.Append(string.Format("\"{0}\":[", dt.TableName));

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{");
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        sb.AppendFormat("\"{0}\":\"{1}\",", dr.Table.Columns[i].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'"), ObjToStr(dr[i]).Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                    sb.Remove(sb.ToString().LastIndexOf(','), 1);
                    sb.Append("},");
                }

                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("],");
            }
            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 将object转换成为string
        /// </summary>
        /// <param name="ob">obj对象</param>
        /// <returns></returns>
        public static string ObjToStr(object ob)
        {
            if (ob == null)
            {
                return string.Empty;
            }
            else
                return ob.ToString();
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