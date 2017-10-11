using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;

namespace XCWeiXin.DAL
{
    /// <summary>
    /// ���ݷ�����:����Ա
    /// </summary>
    public partial class manager
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public manager(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        #region ��������
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "manager");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ѯ�û����Ƿ����
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "manager");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ��ѯ�û����Ƿ����
        /// </summary>
        public bool Exists(string user_name,string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "manager");
            strSql.Append(" where user_name=@user_name and email=@email ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@email", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �����û���ȡ��Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 salt from " + databaseprefix + "manager");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "manager(");
            strSql.Append("role_id,role_type,user_name,password,salt,real_name,telephone,email,is_lock,add_time,wxNum,agentId,reg_ip,qq,province,city,county,remark,sort_id)");
            strSql.Append(" values (");
            strSql.Append("@role_id,@role_type,@user_name,@password,@salt,@real_name,@telephone,@email,@is_lock,@add_time,@wxNum,@agentId,@reg_ip,@qq,@province,@city,@county,@remark,@sort_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@role_type", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@salt", SqlDbType.NVarChar,20),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@email", SqlDbType.NVarChar,30),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@wxNum", SqlDbType.Int,4),
                    new SqlParameter("@agentId", SqlDbType.Int,4),
                    new SqlParameter("@reg_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@qq", SqlDbType.NVarChar,30),
					new SqlParameter("@province", SqlDbType.NVarChar,200),
					new SqlParameter("@city", SqlDbType.NVarChar,200),
					new SqlParameter("@county", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,1500),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
            parameters[0].Value = model.role_id;
            parameters[1].Value = model.role_type;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.password;
            parameters[4].Value = model.salt;
            parameters[5].Value = model.real_name;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.email;
            parameters[8].Value = model.is_lock;
            parameters[9].Value = model.add_time;

            parameters[10].Value = model.wxNum;
            parameters[11].Value = model.agentId;
            parameters[12].Value = model.reg_ip;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.province;
            parameters[15].Value = model.city;
            parameters[16].Value = model.county;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.sort_id;


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
        /// ����һ������
        /// </summary>
        public bool Update(Model.manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "manager set ");
            strSql.Append("role_id=@role_id,");
            strSql.Append("role_type=@role_type,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("password=@password,");
            strSql.Append("real_name=@real_name,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("email=@email,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("wxNum=@wxNum,");
            strSql.Append("agentId=@agentId,");
            strSql.Append("reg_ip=@reg_ip,");
            strSql.Append("qq=@qq,");
            strSql.Append("province=@province,");
            strSql.Append("city=@city,");
            strSql.Append("county=@county,");
            strSql.Append("remark=@remark,");
            strSql.Append("sort_id=@sort_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@role_type", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@email", SqlDbType.NVarChar,30),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@wxNum", SqlDbType.Int,4),
                    new SqlParameter("@agentId", SqlDbType.Int,4),
                    new SqlParameter("@reg_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@qq", SqlDbType.NVarChar,30),
					new SqlParameter("@province", SqlDbType.NVarChar,200),
					new SqlParameter("@city", SqlDbType.NVarChar,200),
					new SqlParameter("@county", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,1500),
					new SqlParameter("@sort_id", SqlDbType.Int,4)  };
            parameters[0].Value = model.id;
            parameters[1].Value = model.role_id;
            parameters[2].Value = model.role_type;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.password;
            parameters[5].Value = model.real_name;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.email;
            parameters[8].Value = model.is_lock;
            parameters[9].Value = model.add_time;

            parameters[10].Value = model.wxNum;
            parameters[11].Value = model.agentId;
            parameters[12].Value = model.reg_ip;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.province;
            parameters[15].Value = model.city;
            parameters[16].Value = model.county;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.sort_id;
             


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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "manager ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.manager GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,role_id,role_type,user_name,password,salt,real_name,telephone,email,is_lock,add_time,wxNum,agentId,reg_ip,qq,province,city,county,remark,sort_id from " + databaseprefix + "manager ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.manager model = new Model.manager();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["role_id"].ToString() != "")
                {
                    model.role_id = int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["role_type"].ToString() != "")
                {
                    model.role_type = int.Parse(ds.Tables[0].Rows[0]["role_type"].ToString());
                }
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.salt = ds.Tables[0].Rows[0]["salt"].ToString();
                model.real_name = ds.Tables[0].Rows[0]["real_name"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();

                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                model.wxNum = MyCommFun.Obj2Int(ds.Tables[0].Rows[0]["wxNum"]);
                model.agentId =MyCommFun.Obj2Int(ds.Tables[0].Rows[0]["agentId"]);

                if (ds.Tables[0].Rows[0]["reg_ip"] != null)
                {
                    model.reg_ip = ds.Tables[0].Rows[0]["reg_ip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["qq"] != null)
                {
                    model.qq = ds.Tables[0].Rows[0]["qq"].ToString();
                }
                if (ds.Tables[0].Rows[0]["province"] != null)
                {
                    model.province = ds.Tables[0].Rows[0]["province"].ToString();
                }
                if (ds.Tables[0].Rows[0]["city"] != null)
                {
                    model.city = ds.Tables[0].Rows[0]["city"].ToString();
                }
                if (ds.Tables[0].Rows[0]["county"] != null)
                {
                    model.county = ds.Tables[0].Rows[0]["county"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
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
        /// �����û������뷵��һ��ʵ��
        /// </summary>
        public Model.manager GetModel(string user_name, string password)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select id from " + databaseprefix + "manager");
            strSql.Append(" where user_name=@user_name and password=@password and is_lock=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@password", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(" id,role_id,role_type,user_name,password,salt,real_name,telephone,email,is_lock,add_time,wxNum,agentId,reg_ip,qq,province,city,county,remark,sort_id ");
            strSql.Append(" FROM " + databaseprefix + "manager ");
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
            strSql.Append("select   hasnum=(select  count(1) as hn from wx_userweixin where isDelete=0 and    uid=m.id), m.*  FROM " + databaseprefix + "manager m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where id!=1 and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}