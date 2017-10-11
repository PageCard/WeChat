using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using XCWeiXin.DBUtility;

namespace XCWeiXin.DAL.Card_wx
{
    public partial class Card_Base
    {
        /// <summary>
        /// 插入卡券信息
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int Add(XCWeiXin.Model.Card_wx.Card_BaseInfo card)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Card_BaseInfo( ");
            strSql.Append("wid,Card_type,logo_url,brand_name,title,sub_title,color,notice,service_phone,source,description,use_limit,get_limit,use_custom_code,bind_openid,can_share,type,begin_timestamp,end_timestamp_day,quantity,can_give_friend,url_name_type,custom_url,custom_url_name,custom_url_sub_title,promotion_url,promotion_url_name,least_cost,reduce_cost,default_detail,Deal_detail,discount,Wx_Card_id,Paycell,hexiao)");
            strSql.Append(" values ( ");
            strSql.Append("@wid,@Card_type,@logo_url,@brand_name,@title,@sub_title,@color,@notice,@service_phone,@source,@description,@use_limit,@get_limit,@use_custom_code,@bind_openid,@can_share,@type,@begin_timestamp,@end_timestamp_day,@quantity,@can_give_friend,@url_name_type,@custom_url,@custom_url_name,@custom_url_sub_title,@promotion_url,@promotion_url_name,@least_cost,@reduce_cost,@default_detail,@Deal_detail,@discount,@Wx_Card_id,@Paycell,@hexiao) ");
          
            SqlParameter [] parameters={
                              new SqlParameter("@wid",SqlDbType.Int,4),
                              new SqlParameter("@Card_type",SqlDbType.VarChar,200),
                              new SqlParameter("@logo_url",SqlDbType.VarChar,400),
                              new SqlParameter("@brand_name",SqlDbType.VarChar,100),
                              new SqlParameter("@title",SqlDbType.VarChar,100),
                              new SqlParameter("@sub_title",SqlDbType.VarChar,100),
                              new SqlParameter("@color",SqlDbType.VarChar,100),
                              new SqlParameter("@notice",SqlDbType.VarChar,100),
                              new SqlParameter("@service_phone",SqlDbType.VarChar,100),
                              new SqlParameter("@source",SqlDbType.VarChar,100),
                              new SqlParameter("@description",SqlDbType.VarChar,500),
                              new SqlParameter("@use_limit",SqlDbType.VarChar,100),
                              new SqlParameter("@get_limit",SqlDbType.VarChar,100),
                              new SqlParameter("@use_custom_code",SqlDbType.Bit),
                              new SqlParameter("@bind_openid",SqlDbType.Bit),
                              new SqlParameter("@can_share",SqlDbType.Bit),
                              new SqlParameter("@type",SqlDbType.VarChar,100),
                              new SqlParameter("@begin_timestamp",SqlDbType.VarChar,100),
                              new SqlParameter("@end_timestamp_day",SqlDbType.VarChar,100),
                              new SqlParameter("@quantity",SqlDbType.VarChar,100),
                              new SqlParameter("@can_give_friend",SqlDbType.Bit),
                              new SqlParameter("@url_name_type",SqlDbType.VarChar,100),
                              new SqlParameter("@custom_url",SqlDbType.VarChar,100),
                              new SqlParameter("@custom_url_name",SqlDbType.VarChar,100),
                              new SqlParameter("@custom_url_sub_title",SqlDbType.VarChar,100),
                              new SqlParameter("@promotion_url",SqlDbType.VarChar,100),
                              new SqlParameter("@promotion_url_name",SqlDbType.VarChar,100),
                              new SqlParameter("@least_cost",SqlDbType.VarChar,200),
                              new SqlParameter("@reduce_cost",SqlDbType.VarChar,200),
                              new SqlParameter("@default_detail",SqlDbType.VarChar,100),
                              new SqlParameter("@Deal_detail",SqlDbType.VarChar,100),
                              new SqlParameter("@discount",SqlDbType.Money),
                              new SqlParameter("@Wx_Card_id",SqlDbType.VarChar,100),
                              new SqlParameter("@Paycell",SqlDbType.Bit),
                              new SqlParameter("@hexiao",SqlDbType.Bit)};
            parameters[0].Value=card.wid;
            parameters[1].Value=card.Card_type;
            parameters[2].Value=card.logo_url;
            parameters[3].Value=card.brand_name;
            parameters[4].Value=card.title;
            parameters[5].Value=card.sub_title;
            parameters[6].Value=card.color;
            parameters[7].Value=card.notice;
            parameters[8].Value=card.service_phone;
            parameters[9].Value=card.source;
            parameters[10].Value=card.description;
            parameters[11].Value=card.use_limit;
            parameters[12].Value=card.get_limit;
            parameters[13].Value=card.use_custom_code;
            parameters[14].Value=card.bind_openid;
            parameters[15].Value=card.can_share;
            parameters[16].Value=card.type;
            parameters[17].Value=card.begin_timestamp;
            parameters[18].Value=card.end_timestamp;
            parameters[19].Value=card.quantity;
            parameters[20].Value=card.can_give_friend;
            parameters[21].Value=card.url_name_type;
            parameters[22].Value=card.custom_url;
            parameters[23].Value=card.custom_url_name;
            parameters[24].Value=card.custom_url_sub_title;
            parameters[25].Value=card.promotion_url;
            parameters[26].Value=card.promotion_url_name;
            parameters[27].Value=card.least_cost;
            parameters[28].Value=card.reduce_cost;
            parameters[29].Value=card.default_detail;
            parameters[30].Value=card.deal_detail;
            parameters[31].Value=card.discount;
            parameters[32].Value = card.Wx_Card_id;
            parameters[33].Value = card.Paycell;
            parameters[34].Value = card.hexiao;
            object obj=DbHelperSQL.GetSingle(strSql.ToString(),parameters);
            if(obj==null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);

             }
        }
       
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select BaseInfoID,wid,Card_type,logo_url,brand_name,title,sub_title,color,notice,service_phone,source,description,use_limit,get_limit,use_custom_code,bind_openid,can_share,type,begin_timestamp,end_timestamp_day,quantity,can_give_friend,url_name_type,custom_url,custom_url_name,custom_url_sub_title,promotion_url,promotion_url_name,least_cost,reduce_cost,default_detail,Deal_detail,discount,Wx_Card_id,Paycell");
            strSql.Append(" FROM Card_BaseInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCWeiXin.Model.Card_wx.Card_BaseInfo GetModel(string Wx_Card_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BaseInfoID,wid,Card_type,logo_url,brand_name,title,sub_title,color,notice,service_phone,source,description,use_limit,get_limit,use_custom_code,bind_openid,can_share,type,begin_timestamp,end_timestamp_day,quantity,can_give_friend,url_name_type,custom_url,custom_url_name,custom_url_sub_title,promotion_url,promotion_url_name,least_cost,reduce_cost,default_detail,Deal_detail,discount,Wx_Card_id,Paycell,hexiao FROM Card_BaseInfo ");
            strSql.Append(" where Wx_Card_id=@Wx_Card_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Wx_Card_id", SqlDbType.VarChar,100)
			};
            parameters[0].Value =Wx_Card_id;

            XCWeiXin.Model.Card_wx.Card_BaseInfo model = new Model.Card_wx.Card_BaseInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.Card_wx.Card_BaseInfo DataRowToModel(DataRow row)
        {
            Model.Card_wx.Card_BaseInfo model = new Model.Card_wx.Card_BaseInfo();
            if (row != null)
            { 
                model.BaseInfoID = int.Parse(row["BaseInfoID"].ToString());
                model.wid = int.Parse(row["wid"].ToString());
                model.Card_type = row["Card_type"].ToString();
                model.logo_url = row["logo_url"].ToString();
                model.brand_name = row["brand_name"].ToString();
                model.title = row["title"].ToString();
                model.sub_title = row["sub_title"].ToString();
                model.color = row["color"].ToString();
                model.notice = row["notice"].ToString();
                model.service_phone = row["service_phone"].ToString();
                model.source = row["source"].ToString();
                model.description = row["description"].ToString();
                model.use_limit = int.Parse(row["use_limit"].ToString());
                model.get_limit = int.Parse(row["get_limit"].ToString());
                
                model.custom_url_name=row["custom_url_name"].ToString();
                model.custom_url = row["custom_url"].ToString();
                model.custom_url_sub_title = row["custom_url_sub_title"].ToString();

                model.promotion_url = row["promotion_url"].ToString();
                model.promotion_url_name = row["promotion_url_name"].ToString();
                model.least_cost = row["least_cost"].ToString();
                model.reduce_cost = row["reduce_cost"].ToString();
                model.default_detail = row["default_detail"].ToString();
                model.begin_timestamp = row["begin_timestamp"].ToString();
                model.end_timestamp = row["end_timestamp_day"].ToString();
                model.quantity=int.Parse(row["quantity"].ToString());
                model.can_give_friend = bool.Parse(row["can_give_friend"].ToString());
                model.can_share = bool.Parse(row["can_share"].ToString());
                model.default_detail = row["default_detail"].ToString();
                model.deal_detail = row["Deal_detail"].ToString();
                model.discount=row["discount"].ToString();
                model.Paycell =bool.Parse(row["Paycell"].ToString());
                model.hexiao = bool.Parse(row["hexiao"].ToString());




            }
            return model;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Card_BaseInfo ");
            strSql.Append(" where Wx_Card_id=@Wx_Card_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Wx_Card_id", SqlDbType.NVarChar,100)
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
        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Upadata_kucun(XCWeiXin.Model.Card_wx.Card_BaseInfo model)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update Card_BaseInfo set ");
            strsql.Append("quantity=@quantity");
            strsql.Append(" where Wx_Card_id=@Wx_Card_id");
            SqlParameter[] parameters = {
        	new SqlParameter("@quantity", SqlDbType.VarChar,100),
            new SqlParameter("@Wx_Card_id", SqlDbType.VarChar,100)};
            parameters[0].Value = model.quantity;
            parameters[1].Value = model.Wx_Card_id;
            int rows = DbHelperSQL.ExecuteSql(strsql.ToString(), parameters);
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
        /// 更新库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exit_card(XCWeiXin.Model.Card_wx.Card_BaseInfo model)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update Card_BaseInfo set ");
            strsql.Append("logo_url=@logo_url, ");
            strsql.Append("color=@color, ");
            strsql.Append("notice=@notice, ");
            strsql.Append("service_phone=@service_phone, ");
            strsql.Append("description=@description, ");
            strsql.Append("use_limit=@use_limit, ");
            strsql.Append("get_limit=@get_limit, ");
            strsql.Append("can_share=@can_share, ");
            strsql.Append("can_give_friend=@can_give_friend, ");
            strsql.Append("custom_url_name=@custom_url_name, ");
            strsql.Append("custom_url_sub_title=@custom_url_sub_title, ");
            strsql.Append("custom_url=@custom_url, ");
            strsql.Append("promotion_url_name=@promotion_url_name, ");
            strsql.Append("promotion_url=@promotion_url, ");
            strsql.Append("Paycell=@Paycell, ");
            strsql.Append("hexiao=@hexiao ");
            strsql.Append(" where Wx_Card_id=@Wx_Card_id and wid=@wid");
            SqlParameter[] parameters = {
        	new SqlParameter("@logo_url", SqlDbType.VarChar,100),
            new SqlParameter("@color", SqlDbType.VarChar,100),
            new SqlParameter("@notice", SqlDbType.VarChar,100),
            new SqlParameter("@service_phone", SqlDbType.VarChar,100),
            new SqlParameter("@description", SqlDbType.VarChar,100),
            new SqlParameter("@use_limit", SqlDbType.VarChar,100),
            new SqlParameter("@get_limit", SqlDbType.VarChar,100),
            new SqlParameter("@can_share", SqlDbType.Bit),
            new SqlParameter("@can_give_friend", SqlDbType.Bit),
            new SqlParameter("@custom_url_name", SqlDbType.VarChar,100),
            new SqlParameter("@custom_url_sub_title", SqlDbType.VarChar,100),
            new SqlParameter("@custom_url", SqlDbType.VarChar,100),
            new SqlParameter("@promotion_url_name", SqlDbType.VarChar,100),
            new SqlParameter("@promotion_url", SqlDbType.VarChar,100),
            new SqlParameter("@Paycell",SqlDbType.Bit),
            new SqlParameter("@hexiao",SqlDbType.Bit),
            new SqlParameter("@Wx_Card_id", SqlDbType.VarChar,100),
            new SqlParameter("@wid", SqlDbType.Int,5)};
            parameters[0].Value = model.logo_url;
            parameters[1].Value = model.color;
            parameters[2].Value = model.notice;
            parameters[3].Value = model.service_phone;
            parameters[4].Value = model.description;
            parameters[5].Value = model.use_limit;
            parameters[6].Value = model.get_limit;
            parameters[7].Value = model.can_share;
            parameters[8].Value = model.can_give_friend;
            parameters[9].Value = model.custom_url_name;
            parameters[10].Value = model.custom_url_sub_title;
            parameters[11].Value = model.custom_url;
            parameters[12].Value = model.promotion_url_name;
            parameters[13].Value = model.promotion_url;
            parameters[14].Value = model.Paycell;
            parameters[15].Value = model.hexiao;
            parameters[16].Value = model.Wx_Card_id;
            parameters[17].Value = model.wid;
        
            int rows = DbHelperSQL.ExecuteSql(strsql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      


    }
}
