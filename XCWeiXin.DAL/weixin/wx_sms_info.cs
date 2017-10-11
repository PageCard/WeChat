﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;//Please add references
namespace XCWeiXin.DAL
{
	/// <summary>
	/// 数据访问类:wx_sms_info
	/// </summary>
	public partial class wx_sms_info
	{
		public wx_sms_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_sms_info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_sms_info");
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
		public int Add(XCWeiXin.Model.wx_sms_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_sms_info(");
			strSql.Append("wid,tel,smsContent,sStatusNum,sStatus,moduleName,actionId,actionName,createDate,remark)");
			strSql.Append(" values (");
			strSql.Append("@wid,@tel,@smsContent,@sStatusNum,@sStatus,@moduleName,@actionId,@actionName,@createDate,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,500),
					new SqlParameter("@smsContent", SqlDbType.VarChar,1000),
					new SqlParameter("@sStatusNum", SqlDbType.VarChar,100),
					new SqlParameter("@sStatus", SqlDbType.VarChar,100),
					new SqlParameter("@moduleName", SqlDbType.VarChar,100),
					new SqlParameter("@actionId", SqlDbType.Int,4),
					new SqlParameter("@actionName", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.tel;
			parameters[2].Value = model.smsContent;
			parameters[3].Value = model.sStatusNum;
			parameters[4].Value = model.sStatus;
			parameters[5].Value = model.moduleName;
			parameters[6].Value = model.actionId;
			parameters[7].Value = model.actionName;
			parameters[8].Value = model.createDate;
			parameters[9].Value = model.remark;

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
		public bool Update(XCWeiXin.Model.wx_sms_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_sms_info set ");
			strSql.Append("wid=@wid,");
			strSql.Append("tel=@tel,");
			strSql.Append("smsContent=@smsContent,");
			strSql.Append("sStatusNum=@sStatusNum,");
			strSql.Append("sStatus=@sStatus,");
			strSql.Append("moduleName=@moduleName,");
			strSql.Append("actionId=@actionId,");
			strSql.Append("actionName=@actionName,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,500),
					new SqlParameter("@smsContent", SqlDbType.VarChar,1000),
					new SqlParameter("@sStatusNum", SqlDbType.VarChar,100),
					new SqlParameter("@sStatus", SqlDbType.VarChar,100),
					new SqlParameter("@moduleName", SqlDbType.VarChar,100),
					new SqlParameter("@actionId", SqlDbType.Int,4),
					new SqlParameter("@actionName", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.tel;
			parameters[2].Value = model.smsContent;
			parameters[3].Value = model.sStatusNum;
			parameters[4].Value = model.sStatus;
			parameters[5].Value = model.moduleName;
			parameters[6].Value = model.actionId;
			parameters[7].Value = model.actionName;
			parameters[8].Value = model.createDate;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from wx_sms_info ");
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
			strSql.Append("delete from wx_sms_info ");
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
		public XCWeiXin.Model.wx_sms_info GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,tel,smsContent,sStatusNum,sStatus,moduleName,actionId,actionName,createDate,remark from wx_sms_info ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			XCWeiXin.Model.wx_sms_info model=new XCWeiXin.Model.wx_sms_info();
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
		public XCWeiXin.Model.wx_sms_info DataRowToModel(DataRow row)
		{
			XCWeiXin.Model.wx_sms_info model=new XCWeiXin.Model.wx_sms_info();
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
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["smsContent"]!=null)
				{
					model.smsContent=row["smsContent"].ToString();
				}
				if(row["sStatusNum"]!=null)
				{
					model.sStatusNum=row["sStatusNum"].ToString();
				}
				if(row["sStatus"]!=null)
				{
					model.sStatus=row["sStatus"].ToString();
				}
				if(row["moduleName"]!=null)
				{
					model.moduleName=row["moduleName"].ToString();
				}
				if(row["actionId"]!=null && row["actionId"].ToString()!="")
				{
					model.actionId=int.Parse(row["actionId"].ToString());
				}
				if(row["actionName"]!=null)
				{
					model.actionName=row["actionName"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,wid,tel,smsContent,sStatusNum,sStatus,moduleName,actionId,actionName,createDate,remark ");
			strSql.Append(" FROM wx_sms_info ");
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
			strSql.Append(" id,wid,tel,smsContent,sStatusNum,sStatus,moduleName,actionId,actionName,createDate,remark ");
			strSql.Append(" FROM wx_sms_info ");
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
			strSql.Append("select count(1) FROM wx_sms_info ");
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
			strSql.Append(")AS Row, T.*  from wx_sms_info T ");
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
			parameters[0].Value = "wx_sms_info";
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
            strSql.Append("select *  from wx_sms_info  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  ExtensionMethod
	}
}

