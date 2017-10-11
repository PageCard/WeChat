using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs.CustomService;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.TenPayLibV3;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using XCWeiXin.Common;
using XCWeiXin.Web.UI;

namespace XCWeiXin.Web.admin.kefu
{
    public partial class Kefu_list : Web.UI.ManagePage
    {
        public AccessTokenResult normalReturn;
        /// <summary>
        /// 时间戳转化成普通时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        private DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
        BLL.wx_userweixin bll = new BLL.wx_userweixin();




      
     
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
          
            ///添加客服（不发送微信请求给用户）
            // Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.AddCustom(actokn, account, nickpick, password);
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            string ssdd = epoch.ToString();

            string getg = GetTime(ssdd).ToString();
        
                if ( wid == 0)
                {
                    Response.Redirect("err1_1.aspx");
                }
 
          
        }


        public string stoce()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
                Model.wx_userweixin model = bll.GetModel(wid);
                string _appId = model.AppId;
                string _appSecret = model.AppSecret;

                normalReturn = new AccessTokenResult();
                normalReturn = CommonApi.GetToken(_appId, _appSecret);
                string sctokn = normalReturn.access_token;


                return sctokn;
         
          
        }

        public void GetCustomBasicInfo()
        {
            /////获取客服基本信息
            CustomInfoJson no = new CustomInfoJson();

            if(stoce()==null)
            {

            }
            string kid = "";
            no = Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.GetCustomBasicInfo(stoce());
            List<CustomInfoJson> ss = new List<CustomInfoJson>();

            for (int a = 0; a < no.kf_list.Count; a++)
            {
                for (int b = 0; b < a; b++)
                {
                    ss.Add(no);
                }
            
                //  Label1.Text = no.kf_list.Count.ToString();
                //  ssa += no.kf_list[a].kf_id + "/" + no.kf_list[a].kf_account;
            }
            if (no.kf_list.Count == 0)
            {
                kid = "该公众号未添加客服";
            }
            else
            {
                kid = no.kf_list[0].kf_account + "完整客服账号格式为：账号前缀@公众号微信号";
            }

         Label1.Text = kid;
        }
        ///获取在线客服信息
        public string GetCustomOnlineInfo()
        {
            string ssa = "";
            CustomOnlineJson yes = new CustomOnlineJson();
            yes = Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.GetCustomOnlineInfo(stoce());
            List<CustomOnlineJson> lists = new List<CustomOnlineJson>();


            for (int b = 0; b < yes.kf_online_list.Count; b++)
            {
                for (int a = 0; a < b; a++)
                {
                    lists.Add(yes);
                }
                ssa += yes.kf_online_list[b].kf_account + "/";

            }
            return ssa;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetCustomBasicInfo();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
            Model.wx_userweixin model = new Model.wx_userweixin();
            if (wx_number.Text == null || wx_number.Text=="")
            {
                Button2.Text = "规则不能为空";
            }
            else
            {
                model.extInt = int.Parse(wx_number.Text.Trim());
                model.id = wid;
                bll.Updata_kefu(model);
                Button2.Text = "写入成功";
            }
          
        }
        //  Label1.Text=ssa;
        // Label1.Text= ssa.Substring(ssa.Length - 1, 1);
        //if (ssa.Contains("kf2001@anju0088"))
        //{
        //    Label1.Text = "yes";
        //}
        //else
        //{
        //    Label1.Text = "no";
        //}



        //int conut = lists.Count;
        //  Label1.Text = conut.ToString();
        //  Senparc.Weixin.MP.AdvancedAPIs.CustomServiceApi.GetSessionList(actokn, account);
        // RequestHandler pack = new RequestHandler();
        // pack.SetParameter("ToUserName", "123");
        // pack.SetParameter("FromUserName", "123");
        // pack.SetParameter("CreateTime", "123");
        // pack.SetParameter("MsgType", "123");
        // pack.SetKey("asd");
        // pack.SetParameter("KfAccount", "VIP_zql_99@anju0088");
        // pack.SetKey("asd");

        // string data = pack.ParseXML();
        //string ss=  "<xml><ToUserName><![CDATA["+data+"]]></ToUserName><CreateTime><![CDATA[123]]></CreateTime><KfAccount><![CDATA[VIP_zql_99@anju0088]]></KfAccount><FromUserName><![CDATA[123]]></FromUserName><MsgType><![CDATA[123]]></MsgType></xml>"

        // "<xml>
        //  <ToUserName><![CDATA[123]]></ToUserName>
        // <CreateTime><![CDATA[123]]></CreateTime>
        // <KfAccount><![CDATA[VIP_zql_99@anju0088]]></KfAccount>
        // <FromUserName><![CDATA[123]]></FromUserName>
        //  <MsgType><![CDATA[123]]></MsgType>
        //   </xml>"

        // Label1.Text = data.ToString();


    }
}

    