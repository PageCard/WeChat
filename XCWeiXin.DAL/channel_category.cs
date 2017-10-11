using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;

namespace XCWeiXin.DAL
{
    /// <summary>
    /// ���ݷ�����:dt_channel_category
    /// </summary>
    public partial class channel_category
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public channel_category(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region ��������=========================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel_category");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ѯ����Ŀ¼���Ƿ����
        /// </summary>
        public bool Exists(string build_path)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel_category");
            strSql.Append(" where build_path=@build_path ");
            SqlParameter[] parameters = {
					new SqlParameter("@build_path", SqlDbType.NVarChar,100)};
            parameters[0].Value = build_path;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �����������
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "channel_category");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// ����Ƶ�����������Ŀ¼��
        /// </summary>
        public string GetBuildPath(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 build_path from " + databaseprefix + "channel_category");
            strSql.Append(" where id=" + id);
            string build_path = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(build_path))
            {
                return "";
            }
            return build_path;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.channel_category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "channel_category(");
            strSql.Append("title,build_path,templet_path,domain,is_default,sort_id)");
            strSql.Append(" values (");
            strSql.Append("@title,@build_path,@templet_path,@domain,@is_default,@sort_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@build_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@templet_path", SqlDbType.NVarChar,100),
					new SqlParameter("@domain", SqlDbType.NVarChar,255),
					new SqlParameter("@is_default", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.build_path;
            parameters[2].Value = model.templet_path;
            parameters[3].Value = model.domain;
            parameters[4].Value = model.is_default;
            parameters[5].Value = model.sort_id;

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
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel_category set " + strValue);
            strSql.Append(" where id=" + id);
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
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(string build_path, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel_category set " + strValue);
            strSql.Append(" where build_path=@build_path");
            SqlParameter[] parameters = {
                    new SqlParameter("@build_path", SqlDbType.NVarChar,100)};
            parameters[0].Value = build_path;
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
        /// ����һ������
        /// </summary>
        public bool Update(Model.channel_category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel_category set ");
            strSql.Append("title=@title,");
            strSql.Append("build_path=@build_path,");
            strSql.Append("templet_path=@templet_path,");
            strSql.Append("domain=@domain,");
            strSql.Append("is_default=@is_default,");
            strSql.Append("sort_id=@sort_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@build_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@templet_path", SqlDbType.NVarChar,100),
					new SqlParameter("@domain", SqlDbType.NVarChar,255),
					new SqlParameter("@is_default", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.build_path;
            parameters[3].Value = model.templet_path;
            parameters[4].Value = model.domain;
            parameters[5].Value = model.is_default;
            parameters[6].Value = model.sort_id;

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
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            //ȡ��Ҫɾ��Ƶ����¼
            Model.channel_category model = GetModel(id);
            if (model == null)
            {
                return false;
            }
            //ȡ�õ�����ID
            int nav_id = new navigation(databaseprefix).GetNavId("channel_" + model.build_path);

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //ɾ����������
                        if (nav_id > 0)
                        {
                            DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "navigation  where class_list like '%," + nav_id + ",%'");
                        }
                        //ɾ��Ƶ�������
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from " + databaseprefix + "channel_category ");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.channel_category GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,build_path,templet_path,domain,is_default,sort_id from " + databaseprefix + "channel_category ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.channel_category model = new Model.channel_category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.build_path = ds.Tables[0].Rows[0]["build_path"].ToString();
                model.templet_path = ds.Tables[0].Rows[0]["templet_path"].ToString();
                model.domain = ds.Tables[0].Rows[0]["domain"].ToString();
                if (ds.Tables[0].Rows[0]["is_default"].ToString() != "")
                {
                    model.is_default = int.Parse(ds.Tables[0].Rows[0]["is_default"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

  /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.channel_category GetModel(string build_path)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,build_path,templet_path,domain,is_default,sort_id from " + databaseprefix + "channel_category ");
            strSql.Append(" where build_path=@build_path");
            SqlParameter[] parameters = {
					new SqlParameter("@build_path", SqlDbType.NVarChar,50)};
            parameters[0].Value = build_path;

            Model.channel_category model = new Model.channel_category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.build_path = ds.Tables[0].Rows[0]["build_path"].ToString();
                model.templet_path = ds.Tables[0].Rows[0]["templet_path"].ToString();
                model.domain = ds.Tables[0].Rows[0]["domain"].ToString();
                if (ds.Tables[0].Rows[0]["is_default"].ToString() != "")
                {
                    model.is_default = int.Parse(ds.Tables[0].Rows[0]["is_default"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,build_path,templet_path,domain,is_default,sort_id ");
            strSql.Append(" FROM " + databaseprefix + "channel_category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "channel_category");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion
    }
}