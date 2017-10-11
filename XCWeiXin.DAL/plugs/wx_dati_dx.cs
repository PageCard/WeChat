using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_dati_dx
	/// </summary>
	public partial class wx_dati_dx
	{
		public wx_dati_dx()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dati_dx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dati_dx");
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
		public int Add(XCWeiXin.Model.wx_dati_dx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dati_dx(");
            strSql.Append("pid,title,score,isshow,answer,summary,xA,xB,xC,xD,xE,xF,sid)");
			strSql.Append(" values (");
            strSql.Append("@pid,@title,@score,@isshow,@answer,@summary,@xA,@xB,@xC,@xD,@xE,@xF,@sid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@score", SqlDbType.Int,4),
                    new SqlParameter("@isshow", SqlDbType.Bit),
                    new SqlParameter("@answer", SqlDbType.VarChar,15),
					new SqlParameter("@summary", SqlDbType.VarChar,500),
					new SqlParameter("@xA", SqlDbType.VarChar,100),
					new SqlParameter("@xB", SqlDbType.VarChar,100),
                    new SqlParameter("@xC", SqlDbType.VarChar,100),
                    new SqlParameter("@xD", SqlDbType.VarChar,100),
                    new SqlParameter("@xE", SqlDbType.VarChar,100),
                    new SqlParameter("@xF", SqlDbType.VarChar,100),
                    new SqlParameter("@sid", SqlDbType.Int,4)};

            parameters[0].Value = model.pid;
			parameters[1].Value = model.title;
            parameters[2].Value = model.score;
            parameters[3].Value = model.isshow;
            parameters[4].Value = model.answer;
            parameters[5].Value = model.summary;
            parameters[6].Value = model.xA;
            parameters[7].Value = model.xB;
            parameters[8].Value = model.xC;
            parameters[9].Value = model.xD;
            parameters[10].Value = model.xE;
            parameters[11].Value = model.xF; 
            parameters[12].Value = model.sid;

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
		public bool Update(XCWeiXin.Model.wx_dati_dx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dati_dx set ");
            strSql.Append("pid=@pid,");
			strSql.Append("title=@title,");
            strSql.Append("score=@score,");
            strSql.Append("isshow=@isshow,");
            strSql.Append("answer=@answer,");            
            strSql.Append("summary=@summary,");
            strSql.Append("xA=@xA,");
            strSql.Append("xB=@xB,");
            strSql.Append("xC=@xC,");
            strSql.Append("xD=@xD,");
            strSql.Append("xE=@xE,");
            strSql.Append("xF=@xF");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@score", SqlDbType.Int,4),
                    new SqlParameter("@isshow", SqlDbType.Bit),
                    new SqlParameter("@answer", SqlDbType.VarChar,15),
					new SqlParameter("@summary", SqlDbType.VarChar,500),
					new SqlParameter("@xA", SqlDbType.VarChar,100),
					new SqlParameter("@xB", SqlDbType.VarChar,100),
                    new SqlParameter("@xC", SqlDbType.VarChar,100),
                    new SqlParameter("@xD", SqlDbType.VarChar,100),
                    new SqlParameter("@xE", SqlDbType.VarChar,100),
                    new SqlParameter("@xF", SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.score;
            parameters[3].Value = model.isshow;
            parameters[4].Value = model.answer;
            parameters[5].Value = model.summary;
            parameters[6].Value = model.xA;
            parameters[7].Value = model.xB;
            parameters[8].Value = model.xC;
            parameters[9].Value = model.xD;
            parameters[10].Value = model.xE;
            parameters[11].Value = model.xF;
            parameters[12].Value = model.id;

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
        /// 更新mid
        /// </summary>
        public bool UpdateMid(int id,int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_dati_dx set ");
            strSql.Append("sid=@sid");          
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4),					
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = sid;          
            parameters[1].Value = id;

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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_dati_dx ");
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
			strSql.Append("delete from wx_dati_dx ");
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
		public XCWeiXin.Model.wx_dati_dx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,pid,title,score,isshow,answer,summary,xA,xB,xC,xD,xE,xF,sid  from wx_dati_dx");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_dati_dx model=new XCWeiXin.Model.wx_dati_dx();
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
		public XCWeiXin.Model.wx_dati_dx DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_dati_dx model=new XCWeiXin.Model.wx_dati_dx();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
                if (row["pid"] != null && row["pid"].ToString() != "")
				{
                    model.pid = int.Parse(row["pid"].ToString());
				}
                if (row["sid"] != null && row["sid"].ToString() != "")
				{
                    model.sid = int.Parse(row["sid"].ToString());
				}
                if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
                if (row["score"] != null)
				{
                    model.score = int.Parse(row["score"].ToString());
				}
                if (row["isshow"] != null && row["isshow"].ToString() != "")
                {
                    if ((row["isshow"].ToString() == "1") || (row["isshow"].ToString().ToLower() == "true"))
                    {
                        model.isshow = true;
                    }
                    else
                    {
                        model.isshow = false;
                    }
                }
                if (row["answer"] != null)
                {
                    model.answer = row["answer"].ToString();
                }

                if (row["summary"] != null)
				{
                    model.summary = row["summary"].ToString();
				}                
                if (row["xA"] != null)
                {
                    model.xA = row["xA"].ToString();
                }
                if (row["xB"] != null)
                {
                    model.xB = row["xB"].ToString();
                }
                if (row["xC"] != null)
                {
                    model.xC = row["xC"].ToString();
                }
                if (row["xD"] != null)
                {
                    model.xD = row["xD"].ToString();
                }
                if (row["xE"] != null)
                {
                    model.xE = row["xE"].ToString();
                }
                if (row["xF"] != null)
                {
                    model.xF = row["xF"].ToString();
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
            strSql.Append("select id,pid,title,score,isshow,answer,summary,xA,xB,xC,xD,xE,xF,sid");
			strSql.Append(" FROM wx_dati_dx ");
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
            strSql.Append(" id,pid,title,score,isshow,answer,summary,xA,xB,xC,xD,xE,xF,sid ");
			strSql.Append(" FROM wx_dati_dx ");
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
			strSql.Append("select count(1) FROM wx_dati_dx ");
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
			strSql.Append(")AS Row, T.*  from wx_dati_dx T ");
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
            strSql.Append(" select  * from wx_dati_dx ");
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
            strSql.Append("delete from wx_dati_dx where id=@id;");
           
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

