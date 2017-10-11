using XCWeiXin.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Globalization;

namespace XCWeiXin.DAL
{
    public class wxResponseBaseMgr
    {

        /// <summary>
        /// 将用户请求的数据和系统回复的数据保存到数据库，数据落地
        /// </summary>
        /// <param name="wid">微帐号主键Id，apiid</param>
        /// <param name="openid">请求的用户openid</param>
        /// <param name="requestType">用户请求的类型：文本消息：text 图片消息:image 地理位置消息:location 链接消息:link 事件:event</param>
        /// <param name="requestContent">用户请求的数据内容</param>
        /// <param name="responseType"> 系统回复的类型：文本消息：text ,图文消息:txtpic ,语音music, 地理位置消息:location 链接消息:link,未取到数据none</param>
        /// <param name="responseContent">系统回复的内容</param>
        /// <param name="ToUserName">由于取不到xml内容，我们将toUserName存入</param>
        /// <returns></returns>
        public static int Add(int wid, string openid, string requestType, string requestContent, string responseType, string responseContent, string ToUserName, string pickname, string image)
        {
            int ret = 0;
            try
            {
                XCWeiXin.Model.wx_response_BaseData model = new Model.wx_response_BaseData();
                model.wid = wid;
                model.wx_openid = openid;
                model.requestType = requestType;
                model.requestContent = requestContent;
                model.responseType = responseType;
                model.reponseContent = responseContent;
                model.wx_xmlContent = ToUserName;
                model.createDate = DateTime.Now;
                model.extStr = pickname;
                model.extStr2 = image;
                ret = Add(model);

            }
            catch (Exception ex)
            {
                ret = 0;
            }


            return ret;
        }

        public string ccc(string openid)
        {
            string ret = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select top 1 extStr3 from wx_response_BaseData  ");
            strSql.Append("  where wx_openid='" + openid + "'and requestContent like '小招%' ");

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString());

            while (sr.Read())
            {
                ret = sr["extStr3"].ToString();
            }
            sr.Close();

            return ret;
        }

        public static bool OpenidExists(string openid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_response_BaseData");
            strSql.Append(" where openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100)
			};
            parameters[0].Value = openid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

      /// <summary>
      /// 更新新消息（更好匹配新数据）
      /// </summary>
      /// <param name="extStr3"></param>
      /// <param name="openid"></param>
      /// <returns></returns>
 
        public static bool updata_1(string extStr3, string openid)
        {

            StringBuilder strsql = new StringBuilder();
            strsql.Append("update wx_response_BaseData set ");
            strsql.Append("extStr3=@extStr3 ");
            strsql.Append(" where wx_openid=@openid ");
            SqlParameter[] paemeter =
            {
                new SqlParameter("@extStr3",SqlDbType.VarChar,20000),
                new SqlParameter("@openid",SqlDbType.VarChar,1000) };
            paemeter[0].Value = extStr3;
            paemeter[1].Value = openid;
            int rows = DbHelperSQL.ExecuteSql(strsql.ToString(), paemeter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool updata(string extStr3, string openid)
        {
            DateTime dd = DateTime.Now.AddMinutes(5);
            DateTime dt = DateTime.Now;
            string sss = dd.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            string ss = dt.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update wx_response_BaseData set ");
            strsql.Append("extStr3=@extStr3 ");
            strsql.Append(" where wx_openid=@openid and (createDate>='" + ss + "') and (createDate<='" + sss + "' )");
            SqlParameter[] paemeter =
            {
                new SqlParameter("@extStr3",SqlDbType.VarChar,20000),
                new SqlParameter("@openid",SqlDbType.VarChar,1000) };
            paemeter[0].Value = extStr3;
            paemeter[1].Value = openid;
            int rows = DbHelperSQL.ExecuteSql(strsql.ToString(), paemeter);
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
        /// 增加一条数据
        /// </summary>
        public static int Add(XCWeiXin.Model.wx_response_BaseData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_response_BaseData(");
            strSql.Append("wid,wx_openid,requestType,requestContent,responseType,reponseContent,createTime,wx_xmlContent,createDate,flag,rType,remark,extInt,extStr,extStr2,extStr3)");
            strSql.Append(" values (");
            strSql.Append("@wid,@wx_openid,@requestType,@requestContent,@responseType,@reponseContent,@createTime,@wx_xmlContent,@createDate,@flag,@rType,@remark,@extInt,@extStr,@extStr2,@extStr3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wx_openid", SqlDbType.VarChar,100),
					new SqlParameter("@requestType", SqlDbType.VarChar,50),
					new SqlParameter("@requestContent", SqlDbType.VarChar,2000),
					new SqlParameter("@responseType", SqlDbType.VarChar,50),
					new SqlParameter("@reponseContent", SqlDbType.VarChar,2000),
					new SqlParameter("@createTime", SqlDbType.VarChar,40),
					new SqlParameter("@wx_xmlContent", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@rType", SqlDbType.VarChar,70),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,200),
					new SqlParameter("@extStr2", SqlDbType.VarChar,700),
					new SqlParameter("@extStr3", SqlDbType.VarChar,2000)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.wx_openid;
            parameters[2].Value = model.requestType;
            parameters[3].Value = model.requestContent;
            parameters[4].Value = model.responseType;
            parameters[5].Value = model.reponseContent;
            parameters[6].Value = model.createTime;
            parameters[7].Value = model.wx_xmlContent;
            parameters[8].Value = model.createDate;
            parameters[9].Value = model.flag;
            parameters[10].Value = model.rType;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.extInt;
            parameters[13].Value = model.extStr;
            parameters[14].Value = model.extStr2;
            parameters[15].Value = model.extStr3;

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


    }
}
