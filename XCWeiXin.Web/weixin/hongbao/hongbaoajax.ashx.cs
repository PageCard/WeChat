using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCWeiXin.Common;


namespace XCWeiXin.Web.weixin.hongbao
{
    /// <summary>
    /// hongbaoajax 的摘要说明
    /// </summary>
    public class hongbaoajax : IHttpHandler
    {
        HttpContext content;
        Dictionary<string, string> jsonDict = new Dictionary<string, string>();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            content = context;
          
            
            string action = MyCommFun.QueryString("myact");

            if (action == "GetHongNao")
            {
                GetHongNao();
            
            }

        }

        public void GetHongNao() {
            int wid = MyCommFun.RequestInt("wid");
            int aid = MyCommFun.RequestInt("aid");
            string openid = MyCommFun.RequestParam("openid");

            if (openid == "" && openid == null)
            {
                jsonDict.Add("re", "error");
                jsonDict.Add("remsg", "参数错误！");
                content.Response.Write(MyCommFun.getJsonStr(jsonDict));             
                return;
            }
            Model.wx_hb_base hb = new Model.wx_hb_base();
            BLL.wx_hb_base hbbll = new BLL.wx_hb_base();
            hb= hbbll.GetModel(aid);
            Random ran = new Random();
            int RandKey = ran.Next(int.Parse(hb.pricemin.ToString()),int.Parse(hb.pricemax.ToString()));
            string nonceStr = "";
            string paySign = "";
      //      NormalRedPackResult normalReturn = new NormalRedPackResult();
      //      normalReturn = RedPayApi.SendNormalRedPack(hb.appID, hb.paynum, hb.paypass, hb.payZSadd, openid, hb.payname, hb.payreIP, RandKey, hb.zftxt, hb.title, hb.depict, out nonceStr, out paySign);

       //     if (normalReturn.return_msg == "发送成功")
       //     {
           
                Model.wx_hb_userinfo hbuserM = new Model.wx_hb_userinfo();
                DAL.wx_hb_userinfo hbuserDAL = new DAL.wx_hb_userinfo();

                hbuserM.aid = aid;
                hbuserM.openid = openid;
                hbuserM.price = RandKey;
                hbuserM.addtime = DateTime.Now;
                hbuserDAL.Add(hbuserM);

        //    }
            jsonDict.Add("re", "ok");
        //   jsonDict.Add("remsg", normalReturn.return_msg);
           content.Response.Write(MyCommFun.getJsonStr(jsonDict));
           return;
        
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