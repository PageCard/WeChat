/************************************************************************ 
 * 项目名称 :  XCWeiXin.DAL.attr_shop   
 * 项目描述 :      
 * 类 名 称 :  sub_attrid 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 11:02:14 
 * 更新时间 :  2017/8/31 11:02:14 
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

namespace XCWeiXin.DAL.attr_shop
{
    public partial class sub_attrid
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int sub_Add(Model.attrshop.sub_attrid model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sub_attrid(");
            strSql.Append("sub_attrname,sub_attrcontext,sub_a,sub_b,sub_c,min_attrid)");
            strSql.Append(" values (");
            strSql.Append("@sub_attrname,@sub_attrcontext,@sub_a,@sub_b,@sub_c,@min_attrid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sub_attrname", SqlDbType.NVarChar,150),
					new SqlParameter("@sub_attrcontext", SqlDbType.NVarChar,350),
					new SqlParameter("@sub_a", SqlDbType.NVarChar,350),
					new SqlParameter("@sub_b", SqlDbType.NVarChar,350),
					new SqlParameter("@sub_c", SqlDbType.NVarChar,350),
					new SqlParameter("@min_attrid", SqlDbType.Int,4)};
            parameters[0].Value = model.sub_attrname;
            parameters[1].Value = model.sub_attrcontext;
            parameters[2].Value = model.sub_a;
            parameters[3].Value = model.sub_b;
            parameters[4].Value = model.sub_c;
            parameters[5].Value = model.min_attrid;

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
    }
}
