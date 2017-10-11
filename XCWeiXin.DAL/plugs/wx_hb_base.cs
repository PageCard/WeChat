using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;//Please add references
namespace XCWeiXin.DAL
{
    /// <summary>
    /// 企业红包
    /// 数据访问类:wx_hb_base
    /// </summary>
    public partial class wx_hb_base
    {
        public wx_hb_base()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_hb_base");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_hb_base");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(XCWeiXin.Model.wx_hb_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_hb_base(");
            strSql.Append("wid,appID,title,depict,zftxt,pricemin,pricemax,payname,paynum,paypass,payZSadd,payreIP,signname,startTime,endTime,addtime)");
            strSql.Append(" values (");
            strSql.Append("@wid,@appID,@title,@depict,@zftxt,@pricemin,@pricemax,@payname,@paynum,@paypass,@payZSadd,@payreIP,@signname,@startTime,@endTime,@addtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@appID", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@depict", SqlDbType.VarChar,100),
					new SqlParameter("@zftxt", SqlDbType.VarChar,100),
					new SqlParameter("@pricemin", SqlDbType.Int,5),
					new SqlParameter("@pricemax", SqlDbType.Int,5),
					new SqlParameter("@payname", SqlDbType.VarChar,100),
					new SqlParameter("@paynum", SqlDbType.VarChar,100),
					new SqlParameter("@paypass", SqlDbType.VarChar,50),
					new SqlParameter("@payZSadd", SqlDbType.VarChar,200),
					new SqlParameter("@payreIP", SqlDbType.VarChar,50),
					new SqlParameter("@signname", SqlDbType.VarChar,100),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@addtime", SqlDbType.DateTime)
                                        };
					
            parameters[0].Value = model.wid;
            parameters[1].Value = model.appID;
            parameters[2].Value = model.title;
            parameters[3].Value = model.depict;
            parameters[4].Value = model.zftxt;
            parameters[5].Value = model.pricemin;
            parameters[6].Value = model.pricemax;
            parameters[7].Value = model.payname;
            parameters[8].Value = model.paynum;
            parameters[9].Value = model.paypass;
            parameters[10].Value = model.payZSadd;
            parameters[11].Value = model.payreIP;
            parameters[12].Value = model.signname;
            parameters[13].Value = model.startTime;
            parameters[14].Value = model.endTime;
            parameters[15].Value = model.addtime;
         
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
        public bool Update(XCWeiXin.Model.wx_hb_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_hb_base set ");
            strSql.Append("wid=@wid,");
            strSql.Append("appID=@appID,");
            strSql.Append("title=@title,");
            strSql.Append("depict=@depict,");
            strSql.Append("zftxt=@zftxt,");
            strSql.Append("pricemin=@pricemin,");
            strSql.Append("pricemax=@pricemax,");           
            strSql.Append("payname=@payname,");
            strSql.Append("paynum=@paynum,");
            strSql.Append("paypass=@paypass,");
            strSql.Append("payZSadd=@payZSadd,");
            strSql.Append("payreIP=@payreIP,");
            strSql.Append("signname=@signname,");
            strSql.Append("startTime=@startTime,");
            strSql.Append("endTime=@endTime");
        //    strSql.Append("addtime=@addtime");
       
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@appID", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@depict", SqlDbType.VarChar,100),
					new SqlParameter("@zftxt", SqlDbType.VarChar,100),
					new SqlParameter("@pricemin", SqlDbType.Int,5),
					new SqlParameter("@pricemax", SqlDbType.Int,5),
					new SqlParameter("@payname", SqlDbType.VarChar,100),
					new SqlParameter("@paynum", SqlDbType.VarChar,100),
					new SqlParameter("@paypass", SqlDbType.VarChar,50),
					new SqlParameter("@payZSadd", SqlDbType.VarChar,200),
					new SqlParameter("@payreIP", SqlDbType.VarChar,50),
					new SqlParameter("@signname", SqlDbType.VarChar,100),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
				//	new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.appID;
            parameters[2].Value = model.title;
            parameters[3].Value = model.depict;
            parameters[4].Value = model.zftxt;
            parameters[5].Value = model.pricemin;
            parameters[6].Value = model.pricemax;
            parameters[7].Value = model.payname;
            parameters[8].Value = model.paynum;
            parameters[9].Value = model.paypass;
            parameters[10].Value = model.payZSadd;
            parameters[11].Value = model.payreIP;
            parameters[12].Value = model.signname;
            parameters[13].Value = model.startTime;
            parameters[14].Value = model.endTime;
         //   parameters[15].Value = model.addtime;
            parameters[15].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_hb_base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_hb_base ");
            strSql.Append(" where id in (" + idlist + ")  ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCWeiXin.Model.wx_hb_base GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from wx_hb_base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            XCWeiXin.Model.wx_hb_base model = new XCWeiXin.Model.wx_hb_base();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCWeiXin.Model.wx_hb_base DataRowToModel(DataRow row)
        {
            XCWeiXin.Model.wx_hb_base model = new XCWeiXin.Model.wx_hb_base();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["appID"] != null)
                {
                    model.appID = row["appID"].ToString();
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["depict"] != null)
                {
                    model.depict = row["depict"].ToString();
                }
                if (row["zftxt"] != null)
                {
                    model.zftxt = row["zftxt"].ToString();
                }
                if (row["pricemin"] != null)
                {
                    model.pricemin =int.Parse(row["pricemin"].ToString());
                }
                if (row["pricemax"] != null)
                {
                    model.pricemax =int.Parse(row["pricemax"].ToString());
                }
                if (row["payname"] != null)
                {
                    model.payname = row["payname"].ToString();
                }
                if (row["paynum"] != null)
                {
                    model.paynum = row["paynum"].ToString();
                }
                if (row["paypass"] != null )
                {
                    model.paypass = row["paypass"].ToString();
                }
                if (row["payZSadd"] != null)
                {
                    model.payZSadd = row["payZSadd"].ToString();
                }
                if (row["payreIP"] != null )
                {
                    model.payreIP = row["payreIP"].ToString();
                }
                if (row["signname"] != null)
                {
                    model.signname = row["signname"].ToString();
                }
                if (row["startTime"] != null )
                {
                    model.startTime = DateTime.Parse(row["startTime"].ToString());
                }
                if (row["endTime"] != null )
                {
                    model.endTime = DateTime.Parse(row["endTime"].ToString());
                }
                if (row["addtime"] != null)
                {
                    model.startTime = DateTime.Parse(row["startTime"].ToString());
                }
              
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM wx_hb_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM wx_hb_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_hb_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_hb_base T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "wx_hb_base";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from wx_hb_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        ///  删除一条喜帖信息，连带删除关联的其他信息【微信回复表的数据，喜帖相册，喜帖报名人信息，喜帖祝福信息】
        /// </summary>
        /// <param name="id">喜帖基本表的主键</param>
        /// <returns></returns>
        public bool DeleteHongbao(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_hb_base  where id=@id ; ");      
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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


        #endregion  ExtensionMethod
    }
}

