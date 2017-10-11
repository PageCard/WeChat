/************************************************************************ 
 * 项目名称 :  XCWeiXin.DAL.attr_shop   
 * 项目描述 :      
 * 类 名 称 :  attr_shop 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 11:01:49 
 * 更新时间 :  2017/8/31 11:01:49 
************************************************************************ 
 * Copyright @ 张强林 2017. All rights reserved. 
************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWeiXin.Model;
using XCWeiXin.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace XCWeiXin.DAL.attr_shop
{
   public class attr_shop
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int attr_Add(Model.attrshop.attr_shop model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into attr_shop(");
            strSql.Append("attrname,attrcontext,attr_a,attr_b,attr_c)");
            strSql.Append(" values (");
            strSql.Append("@attrname,@attrcontext,@attr_a,@attr_b,@attr_c)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@attrname", SqlDbType.NVarChar,50),
					new SqlParameter("@attrcontext", SqlDbType.NVarChar,250),
					new SqlParameter("@attr_a", SqlDbType.NVarChar,250),
					new SqlParameter("@attr_b", SqlDbType.NVarChar,250),
					new SqlParameter("@attr_c", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.attrname;
            parameters[1].Value = model.attrcontext;
            parameters[2].Value = model.attr_a;
            parameters[3].Value = model.attr_b;
            parameters[4].Value = model.attr_c;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.attrshop.attr_shop model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update attr_shop set ");
            strSql.Append("attrname=@attrname,");
            strSql.Append("attrcontext=@attrcontext,");
            strSql.Append("attr_a=@attr_a,");
            strSql.Append("attr_b=@attr_b,");
            strSql.Append("attr_c=@attr_c");
            strSql.Append(" where attrid=@attrid");
            SqlParameter[] parameters = {
					new SqlParameter("@attrname", SqlDbType.NVarChar,50),
					new SqlParameter("@attrcontext", SqlDbType.NVarChar,250),
					new SqlParameter("@attr_a", SqlDbType.NVarChar,250),
					new SqlParameter("@attr_b", SqlDbType.NVarChar,250),
					new SqlParameter("@attr_c", SqlDbType.NVarChar,250),
					new SqlParameter("@attrid", SqlDbType.Int,4)};
            parameters[0].Value = model.attrname;
            parameters[1].Value = model.attrcontext;
            parameters[2].Value = model.attr_a;
            parameters[3].Value = model.attr_b;
            parameters[4].Value = model.attr_c;
            parameters[5].Value = model.attrid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int attrid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from attr_shop ");
            strSql.Append(" where attrid=@attrid");
            SqlParameter[] parameters = {
					new SqlParameter("@attrid", SqlDbType.Int,4)
			};
            parameters[0].Value = attrid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
