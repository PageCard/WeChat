using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using XCWeiXin.DBUtility;
using XCWeiXin.Common;
using System.IO;
namespace XCWeiXin.Web.templates.Doc
{
    ///CopyRight @ 20161118 张强林
    /// <summary>
    /// HG_list 的摘要说明 上拉加载护工列表
    /// </summary>
    public class HG_list : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            int number = MyCommFun.RequestInt("number");
            int page = MyCommFun.RequestInt("page");
            string where = MyCommFun.RequestParam("where");
            string open_id = MyCommFun.RequestParam("open_idss");
            string action = MyCommFun.RequestParam("action");
            string mmm = "Hg_number asc";
            int recordCount = 0;
            int ord = MyCommFun.RequestInt("orderid");
            string order_123 = MyCommFun.RequestParam("order_123");
            string pic_name = MyCommFun.RequestParam("pickname");
            if (action == "no_order")
            {
                context.Response.ContentType = "text/json";
                context.Response.Write(MyCommFun.GetJsonByDataset(No_order(open_id, where)));

            }
            else if (action == "delete_order")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                jsonDict = new Dictionary<string, string>();

                BLL.HG.Hg_list order = new BLL.HG.Hg_list();
                order.DeleteList(ord);
                jsonDict.Add("errCode", "false");
                jsonDict.Add("recontent", "删除成功!");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));

            }
            else if (action == "pay_update")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                jsonDict = new Dictionary<string, string>();

                BLL.HG.Hg_list order = new BLL.HG.Hg_list();
                order.update("已支付", order_123);
                jsonDict.Add("errCode", "false");
                jsonDict.Add("recontent", "更新成功!");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));


            }
            else if (action == "File")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                jsonDict = new Dictionary<string, string>();

                BLL.HG.Hg_list order = new BLL.HG.Hg_list();
                WriteTextLog(DateTime.Now);
                jsonDict.Add("errCode", "false");
                jsonDict.Add("recontent", "更新成功!");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));

            }
            else
            {

                context.Response.Write(MyCommFun.GetJsonByDataset(Hgdata(8, page)));
            }
        }
        /// <summary>  
        /// 写入日志到文本文件  
        /// </summary>  
        /// <param name="action">动作</param>  
        /// <param name="strMessage">日志内容</param>  
        /// <param name="time">时间</param>  
        public static void WriteTextLog(DateTime time)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"合同\Log\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileFullPath = path + MyCommFun.RequestParam("pickname") + "护理合同" + time.ToString("yyyy-MM-dd") + ".txt";
            StringBuilder str = new StringBuilder();


            str.Append(" 甲方：甘肃维盛科技劳务服务有限公司 ");
            str.AppendLine("\n");

            str.Append(" 乙方：微信用户：" + MyCommFun.RequestParam("pickname") + "  ");
            str.AppendLine();

            str.Append(" 一、甲方从 " + DateTime.Now.ToString() + " 时开始向乙方提供医院陪护人员，护理地点为：医院。甲方给乙方陪护伤病人员。");
            str.AppendLine("\n");

            str.Append(" 二、感谢你的反馈、吃药、翻身、勤换衣物、协助病人大小便、保证卫生良好，即时找护士、大夫反应情况，以便为病人早日康复创造良好条件。");

            str.AppendLine("\n");
            str.Append(" 三、医院陪护人员夜间班和白班分别为10个小时，夜间班护理费为人民币        元钱。白天班护理费为人民币         元钱，全日班24小时值班陪护，全日班护理费为每班（24小时）人民币        元钱，乙方给护理人员提供夜间不离岗休息条件，乙方管吃管住。 ");
            str.AppendLine();

            str.Append(" 四、乙方应先付款，付款后甲方才指派陪护员工上岗。乙方只能对甲方结算费用，陪护员工资由甲方支付。乙方不得与陪护人员私自建立陪护服务关系，不得私自将费用结算给甲方所提供的陪护员工。   ");
            str.AppendLine();

            str.Append(" 五、甲方应加强对所提供陪护员工的管理，保证服务质量。乙方有权对甲方所提供的陪护员工提出以下要求：在乙方处工作值班时微笑，热情主动，勤快，不准随便远离值班岗位，值班间中午不准喝酒，不准长时间看书报。乙方有权对陪护员工监督、批评、纠正。  ");

            str.AppendLine();
            str.Append(" 六、甲乙双方在合作中，如乙方对甲方所提供陪护员的工作不满意，乙方可通知甲方更换陪护人员，定价不变。所提供的陪护员只要在乙方处工作服务，本合同一直有效。  ");
            str.AppendLine();

            str.Append(" 七、乙方应自己管好自己的财物，不得借给员工钱物。否则对员工的债务，甲方不承担清偿责任；乙方如发生被骗、窃的后果，乙方应即时向公安部门报案处理，甲方只负责协助乙方及执法部门处理此案，甲方不负任何经济赔偿责任。乙方不得以此为由拒付甲方的陪护费。 ");
            str.AppendLine();

            str.Append(" 八、乙方应提供一至两个有不亲友的家庭住址、身份证复印件及联系电话给甲方及甲方的陪护员，以便乙方被陪护的亲属由特殊情况时能及时通知。   ");

            str.AppendLine();
            str.Append("--------------------------------------------------------------");
            str.AppendLine();

            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
        public DataSet No_order(string openid, string where)
        {
            string str = "select * from A_HG_oreder where (Openid='" + openid + "') and " + where + "";
            return DbHelperSQL.Query(str.ToString());

        }
      
        public DataSet GetList_hg(int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM A_HG_HG");
            strSql.Append(" where Hg_st2='空闲'");


            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        public DataSet Hgdata(int number, int page)
        {



            //---完成版   （改版）完成日期：2017.03.22
            //select top 8* from(SELECT A_HG_HG.Hg_number,A_HG_HG.Headurl,A_HG_HG.dengji,A_HG_HG.Hg_sex,A_HG_HG.Hg_age,A_HG_HG.Hg_st1,A_HG_HG.Mony,A_HG_HG.Hg_st2, A_HG_HG.Hg_name, AVG(A_HG_oreder.Rated_status)as Jungle,COUNT(A_HG_oreder.Hg_number)as ordercount,( ROW_NUMBER() OVER (ORDER BY AVG(A_HG_oreder.Rated_status) DESC )) AS RowNumber
            //FROM A_HG_HG
            //LEFT JOIN A_HG_oreder
            //ON A_HG_HG.Hg_number=A_HG_oreder.Hg_number 
            //group by A_HG_HG.Hg_number ,A_HG_HG.Headurl,A_HG_HG.dengji,A_HG_HG.Hg_sex,A_HG_HG.Hg_age,A_HG_HG.Hg_st1,A_HG_HG.Mony,A_HG_HG.Hg_st2, A_HG_HG.Hg_name
            //) a where a.Hg_st2='空闲' and a.RowNumber>0;


            //旧版：完成时间：2016.11.11
            //  string bb = "SELECT * FROM (SELECT TOP '" + number + "' * FROM (SELECT TOP '" + pageindex + "' * FROM A_HG_HG  where " + where + "  ORDER BY  id ASC)  f ORDER BY f.id DESC) s ORDER BY s.id ASC ";

            //SELECT TOP 8 *
            //FROM A_HG_HG
            //WHERE Hg_number >=
            //(
            //SELECT ISNULL(MAX(Hg_number),0) 
            //FROM 
            //(
            //SELECT TOP 9 Hg_number FROM A_HG_HG ORDER BY Hg_number
            //) A
            //)(页大小*(页数-1)+1) 
            //ORDER BY Hg_number
            //               SELECT TOP 8 * 
            //FROM 
            //        (
            //        SELECT ROW_NUMBER() OVER (ORDER BY Hg_number) AS RowNumber,* FROM A_HG_HG where Hg_st2='空闲'
            //        ) A
            //WHERE RowNumber > 8



            int pageindex = (number * (page - 1));
            StringBuilder str = new StringBuilder();
            str.Append("select top " + number + "* from(SELECT A_HG_HG.Hg_number,A_HG_HG.Headurl,A_HG_HG.dengji,A_HG_HG.Teacher_i,A_HG_HG.Hg_Profile,A_HG_HG.Hg_sex,A_HG_HG.Hg_age,A_HG_HG.Hg_st1,A_HG_HG.Mony,A_HG_HG.Hg_st2, A_HG_HG.Hg_name, AVG(A_HG_oreder.Rated_status)as Jungle,COUNT(A_HG_oreder.Hg_number)as ordercount,( ROW_NUMBER() OVER (ORDER BY  AVG(A_HG_oreder.Rated_status) DESC )) AS RowNumber ");
            str.Append("  FROM A_HG_HG ");
            str.Append(" LEFT JOIN A_HG_oreder ");
            str.Append(" ON A_HG_HG.Hg_number=A_HG_oreder.Hg_number and  A_HG_HG.Hg_st2='空闲' ");
            str.Append(" group by A_HG_HG.Hg_number ,A_HG_HG.Teacher_i,A_HG_HG.Hg_Profile,A_HG_HG.Headurl,A_HG_HG.dengji,A_HG_HG.Hg_sex,A_HG_HG.Hg_age,A_HG_HG.Hg_st1,A_HG_HG.Mony,A_HG_HG.Hg_st2, A_HG_HG.Hg_name ");
            str.Append(" ) a where a.Hg_st2='空闲' and a.RowNumber>" + pageindex + "");


            return DbHelperSQL.Query(str.ToString());
        }

        /// <summary>
        /// 分页查询护工类表数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet Hgdata(int number, int page, string where)
        {

            //  string bb = "SELECT * FROM (SELECT TOP '" + number + "' * FROM (SELECT TOP '" + pageindex + "' * FROM A_HG_HG  where " + where + "  ORDER BY  id ASC)  f ORDER BY f.id DESC) s ORDER BY s.id ASC ";

            //SELECT TOP 8 *
            //FROM A_HG_HG
            //WHERE Hg_number >=
            //(
            //SELECT ISNULL(MAX(Hg_number),0) 
            //FROM          SELECT TOP 8 * from (select ROW_NUMBER() OVER(ORDER BY Hg_number) AS RowNumber,CONVERT(varchar(11) , Hg_number, 21) as  tDateLines,* from A_HG_HG)A WHERE RowNumber > 24  and wid=44   order by RowNumber;
            //(
            //SELECT TOP 9 Hg_number FROM A_HG_HG ORDER BY Hg_number
            //) A
            //)(页大小*(页数-1)+1)  
            //ORDER BY Hg_number
            int pageindex = (8 * (page - 1));

            StringBuilder str = new StringBuilder();
            str.Append("  SELECT TOP 8 * from ");
            str.Append("  (select ROW_NUMBER() OVER(ORDER BY Hg_number) ");
            str.Append("   AS RowNumber,CONVERT(varchar(11) , Hg_number, 21) as ");

            str.Append(" tDateLines,* from A_HG_HG)A  ");

            str.Append(" WHERE RowNumber > " + pageindex + "  and   Hg_st2='空闲'  order by RowNumber;");

            return DbHelperSQL.Query(str.ToString());
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}