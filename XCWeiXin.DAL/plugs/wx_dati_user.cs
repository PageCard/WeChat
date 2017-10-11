using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_dati_user
	/// </summary>
	public partial class wx_dati_user
	{
		public wx_dati_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dati_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dati_user");
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
		public int Add(XCWeiXin.Model.wx_dati_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dati_user(");
            strSql.Append("wid,openid,aid,atitle,usersum,score,addtime)");
			strSql.Append(" values (");
            strSql.Append("@wid,@openid,@aid,@atitle,@usersum,@score,@addtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@aid", SqlDbType.Int,4),
                    new SqlParameter("@atitle", SqlDbType.VarChar,200),
                    new SqlParameter("@usersum", SqlDbType.VarChar,15),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@addtime", SqlDbType.DateTime)};

            parameters[0].Value = model.wid;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.aid;
            parameters[3].Value = model.atitle;
            parameters[4].Value = model.usersum;
            parameters[5].Value = model.score;
            parameters[6].Value = model.addtime;
          

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
		public bool Update(XCWeiXin.Model.wx_dati_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dati_user set ");
            strSql.Append("wid=@wid,");
            strSql.Append("openid=@openid,");
            strSql.Append("aid=@aid,");
            strSql.Append("atitle=@atitle,");
            strSql.Append("usersum=@usersum,");
            strSql.Append("score=@score,");
            strSql.Append("addtime=@addtime");           
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@aid", SqlDbType.Int,4),
                    new SqlParameter("@atitle", SqlDbType.VarChar,200),
                    new SqlParameter("@usersum", SqlDbType.VarChar,15),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.aid;
            parameters[3].Value = model.atitle;
            parameters[4].Value = model.usersum;
            parameters[5].Value = model.score;
            parameters[6].Value = model.addtime;
            parameters[7].Value = model.id;

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
            strSql.Append("update wx_dati_user set ");
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
			strSql.Append("delete from wx_dati_user ");
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
			strSql.Append("delete from wx_dati_user ");
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
		public XCWeiXin.Model.wx_dati_user GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,wid,openid,aid,atitle,usersum,score,addtime  from wx_dati_user");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_dati_user model=new XCWeiXin.Model.wx_dati_user();
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
        public XCWeiXin.Model.wx_dati_user GetModel(string whereStr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,openid,aid,atitle,usersum,score,addtime  from wx_dati_user");
           
            if (whereStr.Trim() != "")
            {
                strSql.Append(" where " + whereStr);
            }

            XCWeiXin.Model.wx_dati_user model = new XCWeiXin.Model.wx_dati_user();
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
		public XCWeiXin.Model.wx_dati_user DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_dati_user model=new XCWeiXin.Model.wx_dati_user();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
                if (row["wid"] != null && row["wid"].ToString() != "")
				{
                    model.wid = int.Parse(row["wid"].ToString());
				}
                if (row["aid"] != null && row["aid"].ToString() != "")
				{
                    model.aid = int.Parse(row["aid"].ToString());
				}
                if (row["openid"] != null)
				{
                    model.openid = row["openid"].ToString();
				}
                if (row["score"] != null)
				{
                    model.score = int.Parse(row["score"].ToString());
				}

                if (row["atitle"] != null)
                {
                    model.atitle = row["atitle"].ToString();
                }

                if (row["usersum"] != null)
				{
                    model.usersum = row["usersum"].ToString();
				}
               
                if (row["addtime"] != null)
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
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
            strSql.Append("select id,wid,openid,aid,atitle,usersum,score,addtime");
			strSql.Append(" FROM wx_dati_user ");
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
            strSql.Append(" id,wid,openid,aid,atitle,usersum,score,addtime ");
			strSql.Append(" FROM wx_dati_user ");
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
			strSql.Append("select count(1) FROM wx_dati_user ");
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
			strSql.Append(")AS Row, T.*  from wx_dati_user T ");
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
            strSql.Append(" select  * from wx_dati_user ");
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
            strSql.Append("delete from wx_dati_user where id=@id;");
           
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

