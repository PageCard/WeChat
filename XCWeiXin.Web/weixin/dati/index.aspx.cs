using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;
using System.Data;
using System.Collections;

namespace XCWeiXin.Web.weixin.dati
{
    /// <summary>
    /// 答题
    /// </summary>
    public partial class index : WeiXinPage
    {
        /// <summary>
        /// 
        /// </summary>
        protected int id, wid,dxgetnum;
        protected int? dtime;
        protected string openid,htmlTitle,summary,headimg,bjcolor,usersum;
        protected bool isusersub = false;
        wx_dati_dx dxBLL = new wx_dati_dx();
        public DataSet dxDT;
        protected void Page_Load(object sender, EventArgs e)
        {

            OnlyWeiXinLook();
            MyCommFun.getTotalUrl();
           
            id = MyCommFun.RequestInt("id", 0);
            wid = MyCommFun.RequestWid();
            openid = MyCommFun.RequestOpenid();

            string whereStr = " wid=" + wid + " and id=" + id;
            wx_dati_base baseBll = new wx_dati_base();
            Model.wx_dati_base baseDT = baseBll.GetModel(whereStr);
            
            //红包设置
            bool hbreISopen = false;
            int reMsg = 0;
            bool hbISopen = true;//红包是否开启
            int hbWhere = 0; //红包参与条件
            int hbMTnum = 10; //第天领取人数
            int hbMRnum =5; //每人领取次数
            int hbRCnum = 3; //容错次数

            if (hbISopen) hbreISopen = true;
            //红包参与条件
            //取用户答题记录
         //   int getUseridCount = baseBll.GetRecordCount(" openid='" + openid + "'");
          //  if (getUseridCount >= hbRCnum) hbreISopen = false;


            //用户信息
            wx_dati_user userBLL = new wx_dati_user();
            Model.wx_dati_user usermodel = userBLL.GetModel(" openid='"+openid+"' ");
            int getUseridCount = userBLL.GetRecordCount(" openid='" + openid + "'");
            if (getUseridCount >= 3)
            { 
            isusersub = true;
            }

            if (usermodel != null)
            {
                
                usersum = usermodel.score.ToString();
            }
            ///end
            if (id == 0 || wid == 0 || openid.Trim() == "")
            {
                Response.Redirect("err.aspx?rev=1");
                return;
            }
            if (baseDT.starttime > DateTime.Now)
            {
                //说明活动未开始
                Response.Redirect("err.aspx?rev=2");
                return;
            }
            if (baseDT.endtime <= DateTime.Now)
            {   //说明活动已经结束
                Response.Redirect("err.aspx?rev=3");
                return;
            }




            htmlTitle = baseDT.title;
            summary = baseDT.summary;
            headimg = baseDT.headimg;
            bjcolor = baseDT.bjcolor;
            dtime = baseDT.dttime;
            dxgetnum = int.Parse(baseDT.dxgetnum.ToString());
            //////    
            string dxwhereStr;
            if (dxgetnum > 0)
            {//抽取
           
                int count = dxBLL.GetRecordCount(" pid=" + id);
                //////生成随机题号
                string inStr="";
                Hashtable hashtable = new Hashtable();
                Random rm = new Random();
                int RmNum = dxgetnum;
                for (int i = 0; hashtable.Count < RmNum; i++)
                {
                    int nValue = rm.Next(1, count);
                    if (!hashtable.ContainsValue(nValue) && nValue != 0)
                    {
                        hashtable.Add(nValue, nValue);                       
                    }
                }
               

                foreach (DictionaryEntry de in hashtable)
                {
                    inStr+=de.Value.ToString()+",";    
                }                              
                /////       
                dxwhereStr = " pid=" + id + " and isshow=1 and sid in (" + inStr.Substring(0, inStr.Length - 1) +")";
            }
            else
            {
                dxwhereStr = " pid=" + id + " and isshow=1 ";
            }
                dxDT = dxBLL.GetList(dxwhereStr);
        }

       

        
    }
}