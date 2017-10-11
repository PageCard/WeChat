using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCWeiXin.Common;

namespace XCWeiXin.Web.weixin.dati
{
    /// <summary>
    /// dati_ajax 的摘要说明
    /// </summary>
    public class dati_ajax : IHttpHandler
    {
        public HttpContext content;
        public void ProcessRequest(HttpContext context)
        {
            content = context;
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");           
            if (_action == "userinfoAdd") { 
            userinfoAdd();
            }
        }

        public void userinfoAdd() {
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            //取值
            int? wid = MyCommFun.RequestInt("wid", 0);
            int aid = MyCommFun.RequestInt("aid");
            string openid=MyCommFun.RequestOpenid();
            string atitle = MyCommFun.QueryString("atitle");
            string usersum = MyCommFun.QueryString("usersum");
            bool ISnum = true;
            if (wid == 0 || aid == 0 || openid == "" || usersum == "")
            {
                jsonDict.Add("re", "err");
                jsonDict.Add("content", "参数错误！");
                jsonDict.Add("isnum", "false");
                content.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }
            BLL.wx_dati_user userBLL = new BLL.wx_dati_user();
           // Model.wx_dati_user usermodel = userBLL.GetModel(" openid='" + openid + "' ");
            int getcont = userBLL.GetRecordCount(" openid='" + openid + "' ");
            if (getcont == 3) {
                jsonDict.Add("re", "err");
                jsonDict.Add("content", "你已参加过了");
                jsonDict.Add("isnum", "false");
                content.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }
            int sy=2-getcont;
          

            BLL.wx_dati_base baseBLL = new BLL.wx_dati_base();
            Model.wx_dati_base baseModel = baseBLL.GetModel(aid);
            int? jf=0;
            int jftype = baseModel.jftype;
            int jfval = baseModel.jfval;
            if (jftype == 0) {
                jf = 0;
            }
            else if (jftype == 1)
            {
                jf = jfval;
            }
            else if (jftype == 2)
            {
                jf = int.Parse(usersum);
            }
            BLL.wx_dati_user dxBLL = new BLL.wx_dati_user();
            Model.wx_dati_user dxmodel=new Model.wx_dati_user();
            dxmodel.wid = wid;
            dxmodel.openid = openid;
            dxmodel.aid = aid;
            dxmodel.atitle = atitle;
            dxmodel.usersum = usersum;
            dxmodel.score = jf;
            dxmodel.addtime = DateTime.Now;
            dxBLL.Add(dxmodel);
            //得分
            if (jf == 5) {
                jsonDict.Add("re", "OK");
                jsonDict.Add("cjscore", jf.ToString());
                jsonDict.Add("content", "你获得了一次红包机会！");
                jsonDict.Add("isnum", "false");
                content.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }
            else
            {
                jsonDict.Add("re", "OK");
                jsonDict.Add("cjscore", jf.ToString());
                jsonDict.Add("content", "答卷提交成功！(" + sy + ")次机会");
                jsonDict.Add("isnum", "true");
                content.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }
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