using Senparc.Weixin.MP.AdvancedAPIs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.WeiXinComm;
using LitJson;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace XCWeiXin.Web.api
{
    public partial class openid : System.Web.UI.Page
    {
        WeiXinCRMComm bb = new WeiXinCRMComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            string err = "err";
           IList<string> openlist = baseUserOpenid(44,out err);
           List<string> jj = new List<string>(openlist);

            DataContractJsonSerializer json = new DataContractJsonSerializer(jj.GetType());

            string szJson = "";

            //序列化

            using (MemoryStream stream = new MemoryStream())
            {

                json.WriteObject(stream, jj);

                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
          
          Response.Write(szJson);
        }
    
          

        
        /// <summary>
        /// 获得所有关注用户的openid字符串（别的方法调用此方法）
        /// </summary>
        /// <returns></returns>
        private IList<string> baseUserOpenid(int wid, out string error)
        {
           
            IList<string> ret = new List<string>();
         
            string access_token = bb.getAccessToken(wid, out error);
            if (error != "")
            {
                return null;
            }
            OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Get(access_token, "");
            if (openidJson.count == openidJson.total)
            {
                ret = openidJson.data.openid;
            }
            else
            {
                getNextUserOpenid(wid, openidJson.next_openid, ret);
            }

            return ret;
        }
        /// <summary>
        /// （基础方法）获得所有关注用户的openid字符串
        /// 递归算法
        /// </summary>
        /// <param name="nexOpenid"></param>
        /// <param name="openidList"></param>
        private void getNextUserOpenid(int wid, string nexOpenid, IList<string> openidList)
        {
            string err = "";
            string access_token =bb.getAccessToken(wid, out err);
            OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Get(access_token, nexOpenid);

            if (openidJson == null || openidJson.count <= 0)
            {
                //return openidJson.data.openid;
                return;
            }
            else
            {
                for (int i = 0; i < openidJson.data.openid.Count; i++)
                {
                    openidList.Add(openidJson.data.openid[i]);
                }
                getNextUserOpenid(wid, openidJson.next_openid, openidList);
            }


        }

    }
}