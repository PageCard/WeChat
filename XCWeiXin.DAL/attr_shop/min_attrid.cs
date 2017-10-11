/************************************************************************ 
 * 项目名称 :  XCWeiXin.DAL.attr_shop   
 * 项目描述 :      
 * 类 名 称 :  min_attrid 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 11:02:03 
 * 更新时间 :  2017/8/31 11:02:03 
************************************************************************ 
 * Copyright @ 张强林 2017. All rights reserved. 
************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWeiXin.DBUtility;
using XCWeiXin.Model;
namespace XCWeiXin.DAL.attr_shop
{
  public  class min_attrid
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.attrshop.min_attrid model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into min_attrid(");
            strSql.Append("attrid,sub_attrid,min_attridname,min_attridcontext,min_a,min_b,min_c)");
            strSql.Append(" values (");
            strSql.Append("@attrid,@sub_attrid,@min_attridname,@min_attridcontext,@min_a,@min_b,@min_c)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@attrid", SqlDbType.Int,4),
					new SqlParameter("@sub_attrid", SqlDbType.Int,4),
					new SqlParameter("@min_attridname", SqlDbType.NVarChar,250),
					new SqlParameter("@min_attridcontext", SqlDbType.NVarChar,250),
					new SqlParameter("@min_a", SqlDbType.NVarChar,250),
					new SqlParameter("@min_b", SqlDbType.NVarChar,250),
					new SqlParameter("@min_c", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.attrid;
            parameters[1].Value = model.sub_attrid;
            parameters[2].Value = model.min_attridname;
            parameters[3].Value = model.min_attridcontext;
            parameters[4].Value = model.min_a;
            parameters[5].Value = model.min_b;
            parameters[6].Value = model.min_c;

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
        public bool Update(Model.attrshop.min_attrid model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update min_attrid set ");
            strSql.Append("attrid=@attrid,");
            strSql.Append("sub_attrid=@sub_attrid,");
            strSql.Append("min_attridname=@min_attridname,");
            strSql.Append("min_attridcontext=@min_attridcontext,");
            strSql.Append("min_a=@min_a,");
            strSql.Append("min_b=@min_b,");
            strSql.Append("min_c=@min_c");
            strSql.Append(" where min_attrid=@min_attrid");
            SqlParameter[] parameters = {
					new SqlParameter("@attrid", SqlDbType.Int,4),
					new SqlParameter("@sub_attrid", SqlDbType.Int,4),
					new SqlParameter("@min_attridname", SqlDbType.NVarChar,250),
					new SqlParameter("@min_attridcontext", SqlDbType.NVarChar,250),
					new SqlParameter("@min_a", SqlDbType.NVarChar,250),
					new SqlParameter("@min_b", SqlDbType.NVarChar,250),
					new SqlParameter("@min_c", SqlDbType.NVarChar,250),
					new SqlParameter("@min_attrid", SqlDbType.Int,4)};
            parameters[0].Value = model.attrid;
            parameters[1].Value = model.sub_attrid;
            parameters[2].Value = model.min_attridname;
            parameters[3].Value = model.min_attridcontext;
            parameters[4].Value = model.min_a;
            parameters[5].Value = model.min_b;
            parameters[6].Value = model.min_c;
            parameters[7].Value = model.minattrid;

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
        public bool Delete(int min_attrid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from min_attrid ");
            strSql.Append(" where min_attrid=@min_attrid");
            SqlParameter[] parameters = {
					new SqlParameter("@min_attrid", SqlDbType.Int,4)
			};
            parameters[0].Value = min_attrid;

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
