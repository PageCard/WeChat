using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;
using System.Text;

namespace XCWeiXin.Web.templates.list
{
    /// <summary>
    /// List 的摘要说明
    /// </summary>
    public class List : IHttpHandler
    {


        int currPage = 1;

        int category_id = MyCommFun.RequestInt("cid");
        int wid = MyCommFun.RequestInt("wid");


        int openid = MyCommFun.RequestInt("openid");
        string databaseprefix = "dt_";
        public void ProcessRequest(HttpContext context)
        {


            string channel_name = MyCommFun.RequestParam("channel_name");
            int pagesize = MyCommFun.RequestInt("page");
            string orderby1 = "id asc";
            int pageindex = MyCommFun.RequestInt("index");

            int recordCount = 0;

            context.Response.ContentType = "text/json";

            context.Response.Write(MyCommFun.GetJsonByDataset(GetList(channel_name, category_id, pagesize, pageindex, "wid=" + wid, orderby1, out recordCount)));
        }
        /// <summary>
        /// 根据视图获得查询分页数据
        /// </summary>
        public DataSet GetList(string channel_name, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM view_channel_" + channel_name);
            strSql.Append(" where datediff(d,add_time,getdate())>=0");
            if (category_id > 0)
            {
                strSql.Append(" and category_id in(select id from " + databaseprefix + "article_category where class_list like '%," + category_id + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
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