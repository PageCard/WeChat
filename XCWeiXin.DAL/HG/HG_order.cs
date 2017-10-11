using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWeiXin.DBUtility;
using XCWeiXin.Model;

namespace XCWeiXin.DAL.HG
{
    ///CopyRight @ 20161118 张强林
  public  class HG_order
    {
      public int add_order_new(Model.HG.A_HG_new_order order)
      {
          StringBuilder str = new StringBuilder();
          str.Append("insert into A_HG_new_order (");
          str.Append("openid_,name_,tel_,sex_,weixin_name,pick_many,type_,time_,pick_day,adress,order_dd,Fw_name,Fw_zt,order_from,str_1,str_2,str_3,total,strat_time,Delet_) ");
          str.Append(" values( ");
          str.Append("@openid_,@name_,@tel_,@sex_,@weixin_name,@pick_many,@type_,@time_,@pick_day,@adress,@order_dd,@Fw_name,@Fw_zt,@order_from,@str_1,@str_2,@str_3,@total,@strat_time,@Delet_)");
          SqlParameter[] par ={
                                new SqlParameter("@openid_",SqlDbType.NVarChar,50),
                                new SqlParameter("@name_",SqlDbType.NVarChar,50),
                                new SqlParameter("@tel_",SqlDbType.NVarChar,50),
                                new SqlParameter("@sex_",SqlDbType.NVarChar,50),
                                new SqlParameter("@weixin_name",SqlDbType.NVarChar,100),
                                new SqlParameter("@pick_many",SqlDbType.NVarChar,10),
                                new SqlParameter("@type_",SqlDbType.NVarChar,50),
                                new SqlParameter("@time_",SqlDbType.NVarChar,50),
                                new SqlParameter("@pick_day",SqlDbType.NVarChar,50),
                                new SqlParameter("@adress",SqlDbType.NVarChar,250),
                                new SqlParameter("@order_dd", SqlDbType.NVarChar,100),
                                new SqlParameter("@Fw_name",SqlDbType.NVarChar,50),
                                new SqlParameter("@Fw_zt",SqlDbType.NVarChar,50),
                                new SqlParameter("@order_from",SqlDbType.NVarChar,100),
                                new SqlParameter("@str_1",SqlDbType.NVarChar,100),
                                new SqlParameter("@str_2",SqlDbType.NVarChar,50),
                                new SqlParameter("@str_3",SqlDbType.NVarChar,100),
                                new SqlParameter("@total",SqlDbType.NVarChar,50),
                                new SqlParameter("@strat_time",SqlDbType.NVarChar,50),
                                new SqlParameter("@Delet_",SqlDbType.NVarChar,20)
                            };
          par[0].Value = order.Openid_;
          par[1].Value = order.Name_;
          par[2].Value = order.Tel_;
          par[3].Value = order.Sex_;
          par[4].Value = order.Weixin_name;
          par[5].Value = order.Pick_many;
          par[6].Value = order.Type_;
          par[7].Value = order.Time_;
          par[8].Value = order.Pick_day;
          par[9].Value = order.Adress;
          par[10].Value = order.Order_dd;
          par[11].Value = order.Fw_name;
          par[12].Value = order.Fw_zt;
          par[13].Value = order.Order_from;
          par[14].Value = order.Str_1;
          par[15].Value = order.Str_2;
          par[16].Value = order.Str_3;
          par[17].Value=order.total;
          par[18].Value = order.start_time;
          par[19].Value = order.Delet_;
          object obj = DbHelperSQL.GetSingle(str.ToString(), par);
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
      /// 添加预约订单
      /// </summary>
      /// <param name="order"></param>
      /// <returns></returns>  
      
      public int add_order( Model.HG.HG_order order)
      {
          StringBuilder str = new StringBuilder();
          str.Append("insert into A_HG_oreder (");
          str.Append("Openid,Nursing_name,Nursing_sex,Nursing_tel,Nursing_adress,By_name,By_sex,By_care,By_age,By_adress,Start_time,End_time,Hg_number,Status_order,Rated_hg,Rated_status,Pay_type,Total,wid,Service_time,Service_day,Str_sm,HUli_type,Order_dd,Hg_name) ");
          str.Append(" values ( ");
          str.Append("@Openid,@Nursing_name,@Nursing_sex,@Nursing_tel,@Nursing_adress,@By_name,@By_sex,@By_care,@By_age,@By_adress,@Start_time,@End_time,@Hg_number,@Status_order,@Rated_hg,@Rated_status,@Pay_type,@Total,@wid,@Service_time,@Service_day,@Str_sm,@HUli_type,@Order_dd,@Hg_name)");
          SqlParameter[] parameters ={
                                        new SqlParameter("@Openid",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Nursing_name",SqlDbType.NVarChar,250),
                                        new SqlParameter("@Nursing_sex",SqlDbType.NVarChar,50),
                                        new SqlParameter("@Nursing_tel",SqlDbType.NVarChar,50),
                                        new SqlParameter("@Nursing_adress",SqlDbType.NVarChar,500),
                                        new SqlParameter("@By_name",SqlDbType.NVarChar,150),
                                        new SqlParameter("@By_sex",SqlDbType.NVarChar,50),
                                        new SqlParameter("@By_care",SqlDbType.NVarChar,50),
                                        new SqlParameter("@By_age",SqlDbType.NVarChar,50),
                                        new SqlParameter("@By_adress",SqlDbType.NVarChar,500),
                                        new SqlParameter("@Start_time",SqlDbType.NVarChar,100),
                                        new SqlParameter("@End_time",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Hg_number",SqlDbType.Int,100000),
                                        new SqlParameter("@Status_order",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Rated_hg",SqlDbType.NVarChar,10000),
                                        new SqlParameter("@Rated_status",SqlDbType.NVarChar,50),
                                        new SqlParameter("@Pay_type",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Total",SqlDbType.Float),
                                        new SqlParameter("@wid",SqlDbType.Int,4),
                                        new SqlParameter("@Service_time",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Service_day",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Str_sm",SqlDbType.NVarChar,10000),
                                        new SqlParameter("@HUli_type",SqlDbType.NVarChar,50),
                                        new SqlParameter("@Order_dd",SqlDbType.NVarChar,50),
                                        new SqlParameter("@Hg_name",SqlDbType.NVarChar,100)
                                      
                        
                                     };
          parameters[0].Value = order.Openid;
          parameters[1].Value = order.Nursing_name;
          parameters[2].Value = order.Nursing_sex;
          parameters[3].Value = order.Nursing_tel;
          parameters[4].Value = order.Nursing_adress;
          parameters[5].Value = order.By_name;
          parameters[6].Value = order.By_sex;
          parameters[7].Value = order.By_care;
          parameters[8].Value = order.By_age;
          parameters[9].Value = order.By_adress;
          parameters[10].Value = order.Start_time;
          parameters[11].Value = order.End_time;
          parameters[12].Value = order.Hg_number;
          parameters[13].Value = order.Status_order;
          parameters[14].Value = order.Rated_hg;
          parameters[15].Value = order.Rated_status;
          parameters[16].Value = order.Pay_type;
          parameters[17].Value = order.Total;
          parameters[18].Value = order.Wid;
          parameters[19].Value = order.Service_time;
          parameters[20].Value = order.Service_day;
          parameters[21].Value = order.str_sm;
          parameters[22].Value = order.HUli_type;
          parameters[23].Value = order.Order_dd;
          parameters[24].Value = order.Hg_name;
        
          object obj = DbHelperSQL.GetSingle(str.ToString(), parameters);
          if (obj == null)
          {
              return 0;
          }
          else
          {
              return Convert.ToInt32(obj);
          }
 
      }

      public Model.HG.A_HG_new_order getorder(string order)
      {
          StringBuilder str = new StringBuilder();
          str.Append("select top 1 * from A_HG_new_order where order_dd=@order");
          SqlParameter[] par ={
                                 new SqlParameter("@order",SqlDbType.NVarChar,50)
                             };
          par[0].Value = order;
          Model.HG.A_HG_new_order model = new Model.HG.A_HG_new_order();
          DataSet ds = DbHelperSQL.Query(str.ToString(), par);
          if (ds.Tables[0].Rows.Count > 0)
          {
              return Datarow_model(ds.Tables[0].Rows[0]);
          }
          else
          {
              return null;
          }
      }
      public Model.HG.A_HG_new_order Datarow_model(DataRow row)
      {
          Model.HG.A_HG_new_order model = new Model.HG.A_HG_new_order();
          if (row != null)
          {
              model.Openid_ = row["openid_"].ToString();
              model.Name_ = row["name_"].ToString();
              model.Tel_ = row["tel_"].ToString();
              model.Sex_ = row["sex_"].ToString();
              model.Weixin_name = row["weixin_name"].ToString();
              model.Pick_many = row["pick_many"].ToString();
              model.Type_ = row["type_"].ToString();
              model.Time_ = row["time_"].ToString();
              model.Pick_day = row["pick_day"].ToString();
              model.Adress = row["adress"].ToString();
              model.Fw_name = row["Fw_name"].ToString();
              model.Fw_zt = row["Fw_zt"].ToString();
              model.Order_from = row["order_from"].ToString();
              model.Str_1 = row["str_1"].ToString();
              model.Str_2 = row["str_2"].ToString();
              model.Str_3 = row["str_3"].ToString();
              model.total = row["total"].ToString();
              model.start_time=row["strat_time"].ToString();
          }
          return model;
      }
      /// <summary>
      /// 获取订单详情
      /// </summary>
      /// <param name="order"></param>
      /// <returns></returns>
      public Model.HG.HG_order Getorder(string order)
      {
          StringBuilder str = new StringBuilder();
          str.Append(" select top 1 * from A_HG_oreder where Order_dd=@order");
                     
          SqlParameter[] prm ={
                                new SqlParameter("@order",SqlDbType.NVarChar,250)
                            };
          prm[0].Value = order;
          Model.HG.HG_order model = new Model.HG.HG_order();
          DataSet ds = DbHelperSQL.Query(str.ToString(), prm);
          if (ds.Tables[0].Rows.Count > 0)
          {
              return DataRowToModel_order(ds.Tables[0].Rows[0]);
          }
          else
          {
              return null;
          }
      }
      public Model.HG.HG_order DataRowToModel_order(DataRow row)
      {
          Model.HG.HG_order model  = new Model.HG.HG_order();
          if (row != null)
          {
             

              model.Total  =double.Parse( row["Total"].ToString());
              model.By_name = row["By_name"].ToString();
              model.Openid = row["Openid"].ToString();
              model.Service_time = row["Service_time"].ToString();
              model.Hg_name = row["Hg_name"].ToString();
              model.By_adress = row["By_adress"].ToString();
              model.Nursing_name = row["Nursing_name"].ToString();
              model.Nursing_tel = row["Nursing_tel"].ToString();
              model.Nursing_sex = row["Nursing_sex"].ToString();
              model.By_age = row["By_age"].ToString();
              model.By_name = row["By_name"].ToString();
              model.By_sex = row["By_sex"].ToString();
              model.By_care = row["By_care"].ToString();
              model.str_sm = row["Str_sm"].ToString();
              model.HUli_type = row["Huli_type"].ToString();
          
              model.Service_day = row["Service_day"].ToString();
              model.Status_order = row["Status_order"].ToString();
              model.Hg_number = row["Hg_number"].ToString();
          }
          return model;
 
      }


      public Model.HG.A_HG_new_order getorder_(string order)
      {
          StringBuilder str = new StringBuilder();
          str.Append("select top 1 * from A_HG_new_order where order_dd=@order");
          SqlParameter[] par ={
                                 new SqlParameter("@order",SqlDbType.NVarChar,50)
                             };
          par[0].Value = order;
          Model.HG.A_HG_new_order model = new Model.HG.A_HG_new_order();
          DataSet ds = DbHelperSQL.Query(str.ToString(), par);
          if (ds.Tables[0].Rows.Count > 0)
          {
              return Datarow_model1(ds.Tables[0].Rows[0]);
          }
          else
          {
              return null;
          }
      }
      public Model.HG.A_HG_new_order Datarow_model1(DataRow row)
      {
          Model.HG.A_HG_new_order model = new Model.HG.A_HG_new_order();
          if (row != null)
          {
              model.Openid_ = row["openid_"].ToString();
              model.Name_ = row["name_"].ToString();
              model.Tel_ = row["tel_"].ToString();
              model.Sex_ = row["sex_"].ToString();
              model.Weixin_name = row["weixin_name"].ToString();
              model.Pick_many = row["pick_many"].ToString();
              model.Type_ = row["type_"].ToString();
              model.Time_ = row["time_"].ToString();
              model.Pick_day = row["pick_day"].ToString();
              model.Adress = row["adress"].ToString();
              model.Fw_name = row["Fw_name"].ToString();
              model.Fw_zt = row["Fw_zt"].ToString();
              model.Order_from = row["order_from"].ToString();
              model.Str_1 = row["str_1"].ToString();
              model.Str_2 = row["str_2"].ToString();
              model.Str_3 = row["str_3"].ToString();
              model.total = row["total"].ToString();
              model.start_time = row["strat_time"].ToString();
              model.Order_dd = row["order_dd"].ToString();
              model.end_time = row["end_time"].ToString();
          }
          return model;
      }
      /// <summary>
      /// 删除订单数据
      /// </summary>
      public bool DeleteList(int idlist)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete from A_HG_oreder ");
          strSql.Append(" where Oreder_id="+idlist+" ");
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
      public bool Login_hg(string user, string pass)
      {
          string str = "select count(*) from A_HG_HG where (Phone='" + user + "') and (lg_pwd='" + pass + "')";
          int a =int.Parse( DbHelperSQL.GetSingle(str.ToString()).ToString());
          if (a > 0)
          {
              return true;
          }
          else
          {
              return false;
          }
     }
      public bool Update(string idlist,string orderid)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update  A_HG_oreder ");
          strSql.Append(" set Status_order='" + idlist + "' where Order_dd='" + orderid + "' ");
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
      
      public Model.HG.HGlist Getxinxi(string user)
      {
          StringBuilder str = new StringBuilder();
          str.Append(" select top 1 * from A_HG_HG where Phone=@Phone;");
              SqlParameter[]pam={
                                    new SqlParameter("@Phone",SqlDbType.NVarChar,150)
                                };
          pam[0].Value=user;
          DataSet ds=DbHelperSQL.Query(str.ToString(),pam);
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
      /// 根据护工id获取信息
      /// </summary>
      /// <param name="Number"></param>
      /// <returns></returns>
      public Model.HG.HGlist Getmodel(int Number)
      {
          StringBuilder str = new StringBuilder();
          str.Append(" select top 1 * from A_HG_HG where Hg_number=@number;");
          SqlParameter[]pam={
                                new SqlParameter("@number",SqlDbType.Int)
                            };
         pam[0].Value=Number;
          Model.HG.HGlist model = new Model.HG.HGlist();
          DataSet ds = DbHelperSQL.Query(str.ToString(), pam);
          if (ds.Tables[0].Rows.Count > 0)
          {
              return DataRowToModel(ds.Tables[0].Rows[0]);
          }
          else
          {
              return null;
          }
      }
      public Model.HG.HGlist DataRowToModel(DataRow row)
      {
          Model.HG.HGlist model = new Model.HG.HGlist();
          if (row != null)
          {
              model.Hg_name = row["Hg_name"].ToString();
              model.Hg_sex = row["Hg_sex"].ToString();
              model.Hg_Degree = row["Hg_Degree"].ToString();
              model.Hg_Profile = row["Hg_Profile"].ToString();
              model.Hg_IDcard = row["Hg_IDcard"].ToString();
              model.Hg_age = int.Parse(row["Hg_age"].ToString());
              model.nation = row["Nation"].ToString();
              model.marry = row["Marry"].ToString();
              model.dengji = row["dengji"].ToString();
              model.Hg_st1 = row["Hg_st1"].ToString();
              model.Hg_st2 = row["Hg_st2"].ToString();
              model.Techer = int.Parse(row["Teacher_i"].ToString());
              model.Hg_number = int.Parse(row["Hg_number"].ToString());
              model.Mony = row["Mony"].ToString();
              model.Phone = row["Phone"].ToString();
              model.Headurl = row["Headurl"].ToString();
              model.open_id_hg = row["open_id_hg"].ToString();

          }
          return model;
      }
      /// <summary>
      /// 更改护工状态
      /// </summary>
      /// <returns></returns>
      public bool update_list(int number_hg)

      {
          StringBuilder str=new StringBuilder();
          str.Append(" update  A_HG_HG ");
          str.Append(" set Hg_st2='预约' where Hg_number="+ number_hg+"; ");
          int row = DbHelperSQL.ExecuteSql(str.ToString());
          if (row > 0)
          {
              return true;
          }
          else
          {
              return false;
          }

 
      }
      /// <summary>
      /// 更改评价
      /// </summary>
      /// <returns></returns>
      public bool update_star(Model.HG.HG_order nn)
      {
          StringBuilder str = new StringBuilder();
          str.Append(" update  A_HG_oreder ");
          str.Append(" set Rated_status='" + nn.Rated_status + "',Status_order='已完成',Rated_hg='" + nn.Rated_hg + "' where Order_dd='" + nn.Order_dd + "'; ");
          int row = DbHelperSQL.ExecuteSql(str.ToString());
          if (row > 0)
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
