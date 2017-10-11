﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_shop_advertisement
	/// </summary>
	public partial class wx_diancai_shop_advertisement
	{
		public wx_diancai_shop_advertisement()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_shop_advertisement"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_shop_advertisement");
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
		public int Add(XCWeiXin.Model.wx_diancai_shop_advertisement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_shop_advertisement(");
			strSql.Append("setupid,advertisementName,sortid,picUrl,websetUrl,isdisplay,createDate)");
			strSql.Append(" values (");
			strSql.Append("@setupid,@advertisementName,@sortid,@picUrl,@websetUrl,@isdisplay,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@setupid", SqlDbType.Int,4),
					new SqlParameter("@advertisementName", SqlDbType.VarChar,300),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@picUrl", SqlDbType.VarChar,300),
					new SqlParameter("@websetUrl", SqlDbType.VarChar,300),
					new SqlParameter("@isdisplay", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.VarChar,4000)};
			parameters[0].Value = model.setupid;
			parameters[1].Value = model.advertisementName;
			parameters[2].Value = model.sortid;
			parameters[3].Value = model.picUrl;
			parameters[4].Value = model.websetUrl;
			parameters[5].Value = model.isdisplay;
			parameters[6].Value = model.createDate;

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
		public bool Update(XCWeiXin.Model.wx_diancai_shop_advertisement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_shop_advertisement set ");
			strSql.Append("setupid=@setupid,");
			strSql.Append("advertisementName=@advertisementName,");
			strSql.Append("sortid=@sortid,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("websetUrl=@websetUrl,");
			strSql.Append("isdisplay=@isdisplay,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@setupid", SqlDbType.Int,4),
					new SqlParameter("@advertisementName", SqlDbType.VarChar,300),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@picUrl", SqlDbType.VarChar,300),
					new SqlParameter("@websetUrl", SqlDbType.VarChar,300),
					new SqlParameter("@isdisplay", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.VarChar,4000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.setupid;
			parameters[1].Value = model.advertisementName;
			parameters[2].Value = model.sortid;
			parameters[3].Value = model.picUrl;
			parameters[4].Value = model.websetUrl;
			parameters[5].Value = model.isdisplay;
			parameters[6].Value = model.createDate;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_diancai_shop_advertisement ");
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
			strSql.Append("delete from wx_diancai_shop_advertisement ");
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
		public XCWeiXin.Model.wx_diancai_shop_advertisement GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,setupid,advertisementName,sortid,picUrl,websetUrl,isdisplay,createDate from wx_diancai_shop_advertisement ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_diancai_shop_advertisement model=new XCWeiXin.Model.wx_diancai_shop_advertisement();
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
		public XCWeiXin.Model.wx_diancai_shop_advertisement DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_diancai_shop_advertisement model=new XCWeiXin.Model.wx_diancai_shop_advertisement();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["setupid"]!=null && row["setupid"].ToString()!="")
				{
					model.setupid=int.Parse(row["setupid"].ToString());
				}
				if(row["advertisementName"]!=null)
				{
					model.advertisementName=row["advertisementName"].ToString();
				}
				if(row["sortid"]!=null)
				{
                    model.sortid = int.Parse(row["sortid"].ToString());
				}
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["websetUrl"]!=null)
				{
					model.websetUrl=row["websetUrl"].ToString();
				}
				if(row["isdisplay"]!=null && row["isdisplay"].ToString()!="")
				{
					if((row["isdisplay"].ToString()=="1")||(row["isdisplay"].ToString().ToLower()=="true"))
					{
						model.isdisplay=true;
					}
					else
					{
						model.isdisplay=false;
					}
				}
				if(row["createDate"]!=null)
				{
					model.createDate=row["createDate"].ToString();
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
			strSql.Append("select id,setupid,advertisementName,sortid,picUrl,websetUrl,isdisplay,createDate ");
			strSql.Append(" FROM wx_diancai_shop_advertisement ");
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
			strSql.Append(" id,setupid,advertisementName,sortid,picUrl,websetUrl,isdisplay,createDate ");
			strSql.Append(" FROM wx_diancai_shop_advertisement ");
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
			strSql.Append("select count(1) FROM wx_diancai_shop_advertisement ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_shop_advertisement T ");
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
			parameters[0].Value = "wx_diancai_shop_advertisement";
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

        public DataSet GetListByid(int  setupid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,setupid,advertisementName,sortid,picUrl,websetUrl,isdisplay,createDate ");
            strSql.Append(" FROM wx_diancai_shop_advertisement where  setupid='" + setupid + "' ");
	
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  ExtensionMethod
	}
}

