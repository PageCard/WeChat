﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_payment_alipay
	/// </summary>
	public partial class wx_bookpayment_alipay
	{
        public wx_bookpayment_alipay()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_payment_alipay"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_payment_alipay");
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
		public int Add(XCWeiXin.Model.wx_payment_alipay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_payment_alipay(");
			strSql.Append("wid,ownerName,partner,e_key,private_key,public_key,sign_type,createDate,extInt,extStr,extStr2)");
			strSql.Append(" values (");
			strSql.Append("@wid,@ownerName,@partner,@e_key,@private_key,@public_key,@sign_type,@createDate,@extInt,@extStr,@extStr2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@ownerName", SqlDbType.VarChar,100),
					new SqlParameter("@partner", SqlDbType.VarChar,32),
					new SqlParameter("@e_key", SqlDbType.VarChar,64),
					new SqlParameter("@private_key", SqlDbType.VarChar,2000),
					new SqlParameter("@public_key", SqlDbType.VarChar,2000),
					new SqlParameter("@sign_type", SqlDbType.VarChar,4000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.ownerName;
			parameters[2].Value = model.partner;
			parameters[3].Value = model.e_key;
			parameters[4].Value = model.private_key;
			parameters[5].Value = model.public_key;
			parameters[6].Value = model.sign_type;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.extInt;
			parameters[9].Value = model.extStr;
			parameters[10].Value = model.extStr2;

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
		public bool Update(XCWeiXin.Model.wx_payment_alipay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_payment_alipay set ");
			strSql.Append("wid=@wid,");
			strSql.Append("ownerName=@ownerName,");
			strSql.Append("partner=@partner,");
			strSql.Append("e_key=@e_key,");
			strSql.Append("private_key=@private_key,");
			strSql.Append("public_key=@public_key,");
			strSql.Append("sign_type=@sign_type,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@ownerName", SqlDbType.VarChar,100),
					new SqlParameter("@partner", SqlDbType.VarChar,32),
					new SqlParameter("@e_key", SqlDbType.VarChar,64),
					new SqlParameter("@private_key", SqlDbType.VarChar,2000),
					new SqlParameter("@public_key", SqlDbType.VarChar,2000),
					new SqlParameter("@sign_type", SqlDbType.VarChar,4000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.ownerName;
			parameters[2].Value = model.partner;
			parameters[3].Value = model.e_key;
			parameters[4].Value = model.private_key;
			parameters[5].Value = model.public_key;
			parameters[6].Value = model.sign_type;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.extInt;
			parameters[9].Value = model.extStr;
			parameters[10].Value = model.extStr2;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from wx_payment_alipay ");
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
			strSql.Append("delete from wx_payment_alipay ");
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
		public XCWeiXin.Model.wx_payment_alipay GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,ownerName,partner,e_key,private_key,public_key,sign_type,createDate,extInt,extStr,extStr2 from wx_payment_alipay ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_payment_alipay model=new XCWeiXin.Model.wx_payment_alipay();
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
		public XCWeiXin.Model.wx_payment_alipay DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_payment_alipay model=new XCWeiXin.Model.wx_payment_alipay();
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
				if(row["ownerName"]!=null)
				{
					model.ownerName=row["ownerName"].ToString();
				}
				if(row["partner"]!=null)
				{
					model.partner=row["partner"].ToString();
				}
				if(row["e_key"]!=null)
				{
					model.e_key=row["e_key"].ToString();
				}
				if(row["private_key"]!=null)
				{
					model.private_key=row["private_key"].ToString();
				}
				if(row["public_key"]!=null)
				{
					model.public_key=row["public_key"].ToString();
				}
				if(row["sign_type"]!=null)
				{
					model.sign_type=row["sign_type"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
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
			strSql.Append("select id,wid,ownerName,partner,e_key,private_key,public_key,sign_type,createDate,extInt,extStr,extStr2 ");
			strSql.Append(" FROM wx_payment_alipay ");
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
			strSql.Append(" id,wid,ownerName,partner,e_key,private_key,public_key,sign_type,createDate,extInt,extStr,extStr2 ");
			strSql.Append(" FROM wx_payment_alipay ");
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
			strSql.Append("select count(1) FROM wx_payment_alipay ");
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
			strSql.Append(")AS Row, T.*  from wx_payment_alipay T ");
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
			parameters[0].Value = "wx_payment_alipay";
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

		#endregion  ExtensionMethod
	}
}

