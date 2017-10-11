using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_dati_base
	/// </summary>
	public partial class wx_dati_base
	{
		public wx_dati_base()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dati_base"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dati_base");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XCWeiXin.Model.wx_dati_base model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dati_base(");
            strSql.Append("wid,title,bjcolor,summary,dttime,isshowend,addtime,dxtitle,dxgetnum,dxscore,headimg,starttime,endtime,jftype,jfval)");
			strSql.Append(" values (");
            strSql.Append("@wid,@title,@bjcolor,@summary,@dttime,@isshowend,@addtime,@dxtitle,@dxgetnum,@dxscore,@headimg,@starttime,@endtime,@jftype,@jfval)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@bjcolor", SqlDbType.VarChar,200),
					new SqlParameter("@summary", SqlDbType.VarChar,500),
					new SqlParameter("@dttime", SqlDbType.Int,4),
					new SqlParameter("@isshowend", SqlDbType.Bit),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@dxtitle", SqlDbType.VarChar,50),
					new SqlParameter("@dxgetnum", SqlDbType.Int,4),
					new SqlParameter("@dxscore", SqlDbType.Int,4),
                    new SqlParameter("@headimg", SqlDbType.VarChar,200),
                    new SqlParameter("@starttime", SqlDbType.DateTime),
                    new SqlParameter("@endtime", SqlDbType.DateTime),
                    new SqlParameter("@jftype", SqlDbType.Int,4),
                    new SqlParameter("@jfval", SqlDbType.Int,4),
                                        };
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.bjcolor;
			parameters[3].Value = model.summary;
			parameters[4].Value = model.dttime;
			parameters[5].Value = model.isshowend;
			parameters[6].Value = model.addtime;
			parameters[7].Value = model.dxtitle;
			parameters[8].Value = model.dxgetnum;
			parameters[9].Value = model.dxscore;
            parameters[10].Value = model.headimg;
            parameters[11].Value = model.starttime;
            parameters[12].Value = model.endtime;
            parameters[13].Value = model.jftype;
            parameters[14].Value = model.jfval;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(XCWeiXin.Model.wx_dati_base model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dati_base set ");
			strSql.Append("wid=@wid,");
			strSql.Append("title=@title,");
            strSql.Append("bjcolor=@bjcolor,");
            strSql.Append("summary=@summary,");
            strSql.Append("dttime=@dttime,");
            strSql.Append("isshowend=@isshowend,");
            strSql.Append("addtime=@addtime,");
            strSql.Append("dxtitle=@dxtitle,");
            strSql.Append("dxgetnum=@dxgetnum,");
            strSql.Append("dxscore=@dxscore,");
            strSql.Append("headimg=@headimg,");
            strSql.Append("starttime=@starttime,");
            strSql.Append("endtime=@endtime,");
            strSql.Append("jftype=@jftype,");
            strSql.Append("jfval=@jfval");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@bjcolor", SqlDbType.VarChar,200),
					new SqlParameter("@summary", SqlDbType.VarChar,500),
					new SqlParameter("@dttime", SqlDbType.Int,4),
					new SqlParameter("@isshowend", SqlDbType.Bit),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@dxtitle", SqlDbType.VarChar,50),
					new SqlParameter("@dxgetnum", SqlDbType.Int,4),
					new SqlParameter("@dxscore", SqlDbType.Int,4),
                     new SqlParameter("@headimg", SqlDbType.VarChar,200),
                    new SqlParameter("@starttime", SqlDbType.DateTime),
                    new SqlParameter("@endtime", SqlDbType.DateTime),
                    new SqlParameter("@jftype", SqlDbType.Int,4),
                    new SqlParameter("@jfval", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.bjcolor;
            parameters[3].Value = model.summary;
            parameters[4].Value = model.dttime;
            parameters[5].Value = model.isshowend;
            parameters[6].Value = model.addtime;
            parameters[7].Value = model.dxtitle;
            parameters[8].Value = model.dxgetnum;
            parameters[9].Value = model.dxscore;
            parameters[10].Value = model.headimg;
            parameters[11].Value = model.starttime;
            parameters[12].Value = model.endtime;
            parameters[13].Value = model.jftype;
            parameters[14].Value = model.jfval;
            parameters[15].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_dati_base ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_dati_base ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public XCWeiXin.Model.wx_dati_base GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 * from wx_dati_base ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_dati_base model=new XCWeiXin.Model.wx_dati_base();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public XCWeiXin.Model.wx_dati_base GetModel(string whereStr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from wx_dati_base ");
          
            if (whereStr.Trim() != "")
            {
                strSql.Append(" where " + whereStr);
            }

            XCWeiXin.Model.wx_dati_base model = new XCWeiXin.Model.wx_dati_base();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
		public XCWeiXin.Model.wx_dati_base DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_dati_base model=new XCWeiXin.Model.wx_dati_base();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
                if (row["bjcolor"] != null)
				{
                    model.bjcolor = row["bjcolor"].ToString();
				}
                if (row["summary"] != null)
				{
                    model.summary = row["summary"].ToString();
				}

                if (row["isshowend"] != null && row["isshowend"].ToString() != "")
                {
                    if ((row["isshowend"].ToString() == "1") || (row["isshowend"].ToString().ToLower() == "true"))
                    {
                        model.isshowend = true;
                    }
                    else
                    {
                        model.isshowend = false;
                    }
                }
                if (row["dttime"] != null)
                {
                    model.dttime = int.Parse(row["dttime"].ToString());
                }

                if (row["addtime"] != null)
				{
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
				}
                if (row["dxtitle"] != null)
				{
                    model.dxtitle = row["dxtitle"].ToString();
				}
                if (row["dxgetnum"] != null && row["dxgetnum"].ToString() != "")
				{
                    model.dxgetnum = int.Parse(row["dxgetnum"].ToString());
				}

                if (row["dxscore"] != null)
				{
                    model.dxscore = int.Parse(row["dxscore"].ToString());
				}

                if (row["starttime"] != null)
                {
                    model.starttime = DateTime.Parse(row["starttime"].ToString());
                }
                if (row["endtime"] != null)
                {
                    model.endtime = DateTime.Parse(row["endtime"].ToString());
                }

                if (row["headimg"] != null)
                {
                    model.headimg = row["headimg"].ToString();
                }
                if (row["jftype"] != null)
                {
                    model.jftype = int.Parse(row["jftype"].ToString());
                }
                if (row["jfval"] != null)
                {
                    model.jfval = int.Parse(row["jfval"].ToString());
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select * ");
			strSql.Append(" FROM wx_dati_base ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" * ");
			strSql.Append(" FROM wx_dati_base ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wx_dati_base ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_dati_base T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		 
		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from wx_dati_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 删除一条预约数据【主表，字段表，用户提交的结果表】
        /// </summary>
        public bool DeleteYuYue(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_dati_base where id=@id;");
            strSql.Append("delete from wx_dati_dx where pid=@id;");
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

