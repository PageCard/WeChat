﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_caipin_category
	/// </summary>
	public partial class wx_diancai_caipin_category
	{
		public wx_diancai_caipin_category()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_caipin_category"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_caipin_category");
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
		public int Add(XCWeiXin.Model.wx_diancai_caipin_category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_caipin_category(");
			strSql.Append("shopid,sortid,categoryName,miaoshu,isStart,createDate)");
			strSql.Append(" values (");
			strSql.Append("@shopid,@sortid,@categoryName,@miaoshu,@isStart,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@categoryName", SqlDbType.VarChar,100),
					new SqlParameter("@miaoshu", SqlDbType.VarChar,100),
					new SqlParameter("@isStart", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.sortid;
			parameters[2].Value = model.categoryName;
			parameters[3].Value = model.miaoshu;
			parameters[4].Value = model.isStart;
			parameters[5].Value = model.createDate;

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
		public bool Update(XCWeiXin.Model.wx_diancai_caipin_category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_caipin_category set ");
			strSql.Append("shopid=@shopid,");
			strSql.Append("sortid=@sortid,");
			strSql.Append("categoryName=@categoryName,");
			strSql.Append("miaoshu=@miaoshu,");
			strSql.Append("isStart=@isStart,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@categoryName", SqlDbType.VarChar,100),
					new SqlParameter("@miaoshu", SqlDbType.VarChar,100),
					new SqlParameter("@isStart", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.sortid;
			parameters[2].Value = model.categoryName;
			parameters[3].Value = model.miaoshu;
			parameters[4].Value = model.isStart;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from wx_diancai_caipin_category ");
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
			strSql.Append("delete from wx_diancai_caipin_category ");
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
		public XCWeiXin.Model.wx_diancai_caipin_category GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,shopid,sortid,categoryName,miaoshu,isStart,createDate from wx_diancai_caipin_category ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_diancai_caipin_category model=new XCWeiXin.Model.wx_diancai_caipin_category();
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
		public XCWeiXin.Model.wx_diancai_caipin_category DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_diancai_caipin_category model=new XCWeiXin.Model.wx_diancai_caipin_category();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["shopid"]!=null && row["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(row["shopid"].ToString());
				}
				if(row["sortid"]!=null)
				{
                    model.sortid = int.Parse(row["sortid"].ToString());
				}
				if(row["categoryName"]!=null)
				{
					model.categoryName=row["categoryName"].ToString();
				}
				if(row["miaoshu"]!=null)
				{
					model.miaoshu=row["miaoshu"].ToString();
				}
				if(row["isStart"]!=null && row["isStart"].ToString()!="")
				{
					if((row["isStart"].ToString()=="1")||(row["isStart"].ToString().ToLower()=="true"))
					{
						model.isStart=true;
					}
					else
					{
						model.isStart=false;
					}
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,shopid,sortid,categoryName,miaoshu,isStart,createDate ");
			strSql.Append(" FROM wx_diancai_caipin_category ");
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
			strSql.Append(" id,shopid,sortid,categoryName,miaoshu,isStart,createDate ");
			strSql.Append(" FROM wx_diancai_caipin_category ");
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
			strSql.Append("select count(1) FROM wx_diancai_caipin_category ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_caipin_category T ");
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
			parameters[0].Value = "wx_diancai_caipin_category";
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,shopid,sortid,categoryName,miaoshu,isStart,createDate ");
            strSql.Append(" FROM wx_diancai_caipin_category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetList(int  shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,shopid,sortid,categoryName,miaoshu,isStart,createDate ");
            strSql.Append(" FROM wx_diancai_caipin_category ");
            if (shopid != 0)
            {
                strSql.Append(" where shopid=" + shopid + " and  isStart=1 order by sortid asc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

