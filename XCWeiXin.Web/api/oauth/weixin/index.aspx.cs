using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using XCWeiXin.BLL;
using XCWeiXin.API.OAuth;
using XCWeiXin.Common;

namespace XCWeiXin.Web.api.oauth.weixin
{
    public partial class index : System.Web.UI.Page
    {

        public string reurl ="";
        public int wid = 0;
      public string appid = "";  
      public string appsecret = "";
      public string openid="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取从wxProcess.aspx传递过来的跳转地址reurl
                reurl =HttpContext.Current.Session["session_reurl"].ToString();// "/shop/index.aspx?wid=40"
                wid = 40;

                if (reurl == "" && reurl == null)
                {
                    Response.Redirect("/err.aspx?rev=100002");
                }
                if (wid == 0)
                {
                    Response.Redirect("/err.aspx?rev=100003");
                }

              int re=  init();
              if (re == 0)//成功
              {
                  Response.Redirect("" + reurl + "&openid=" + openid + "");
              }
              else if (re == 1)//未取openid
              {
                  Response.Redirect("wxProcess.aspx?auth=1");
              }
              else { //未取code
                  SetMyOPenid();
                  Response.Redirect("" + reurl + "&openid=" + openid + "");
              }


                }
            }
        

        public int init() { 
         BLL.wx_userweixin wx = new BLL.wx_userweixin();
                Model.wx_userweixin wxModel = wx.GetModel(wid);
                appid = wxModel.AppId;
               appsecret = wxModel.AppSecret;
                string code = "";
                if (Request.QueryString["code"] != null && Request.QueryString["code"] != "")
                {
                    //获取微信回传的code
                    code = Request.QueryString["code"].ToString();
                    OAuth_Token Model = Get_token(code);  //获取token
                    OAuthUser OAuthUser_Model = Get_UserInfo(Model.access_token, Model.openid);
                    if (OAuthUser_Model.openid != null && OAuthUser_Model.openid != "")  //已获取得openid及其他信息
                    {
                        //绑定数据
                        wx_ucard_users userBLL = new wx_ucard_users();
                        Model.wx_ucard_users userModel = new XCWeiXin.Model.wx_ucard_users();
                        bool Isuser = userBLL.getUserExists(OAuthUser_Model.openid);
                        if (Isuser)
                        {
                            userModel = userBLL.GetModel(OAuthUser_Model.openid);                            
                        }
                        userModel.wid = wid;
                        userModel.openid = OAuthUser_Model.openid;
                        userModel.wxName = OAuthUser_Model.nickname;
                        userModel.sex = OAuthUser_Model.sex;
                        userModel.language = OAuthUser_Model.language;
                        userModel.province = OAuthUser_Model.province;
                        userModel.city = OAuthUser_Model.city;
                        userModel.country = OAuthUser_Model.country;
                        userModel.headimgul = OAuthUser_Model.headimgurl;
                        userModel.subscribe = OAuthUser_Model.subscribe;
                        //   userModel.subscribe_time =DateTime.Parse(OAuthUser_Model.subscribe_time.Trim());
                        userModel.groupid = OAuthUser_Model.groupid;

                        openid = OAuthUser_Model.openid;
                    if (!Isuser)//没有记录，添加
                    {
                        HttpCookie cookie = new HttpCookie("xcopenid" + wid + "");
                        cookie.Value = OAuthUser_Model.openid;
                        cookie.Expires = DateTime.Now.AddDays(3650);
                        HttpContext.Current.Response.Cookies.Add(cookie);

                        userBLL.Add(userModel);
                        return 0;
                    }
                    else//有记录更新
                    {
                        HttpCookie cookie = new HttpCookie("xcopenid" + wid + "");
                            cookie.Value = OAuthUser_Model.openid;
                            cookie.Expires = DateTime.Now.AddDays(3650);
                            HttpContext.Current.Response.Cookies.Add(cookie);

                            userBLL.Update(userModel);
                            return 0;
                    }

                    //  Response.Redirect("" + reurl + "&openid=" + OAuthUser_Model.openid + "");
                    //   Response.Redirect(reurl);
                }
                    else  //未获得openid，回到wxProcess.aspx，访问弹出微信授权页面，提示用户授权
                    {
                        return 1;
                    }



                }
                else { //取code失败
                 return 2;
                }

           
        }
        /// <summary>
        /// 未取到code值时
        /// </summary>

        public void SetMyOPenid() { 
        
          //根据操作系统生成用户ID,生成结果：系统类型+6位随机数
                    string mate = HttpContext.Current.Request.UserAgent.Trim().ToLower();
                    string getmate = "";
                    if (mate.Contains("ios"))
                        getmate = "ios";
                    else if (mate.Contains("android"))
                        getmate = "android";
                    else if (mate.Contains("windows"))
                        getmate = "windows";
                    else
                        getmate = "other";
                    Random ra = new Random();
                  string  openidStr = getmate + ra.Next(000000, 999999).ToString();


                  HttpCookie cookie = new HttpCookie("xcopenid" + wid + "");
                cookie.Value = openidStr;
                cookie.Expires = DateTime.Now.AddDays(3650);
                HttpContext.Current.Response.Cookies.Add(cookie); 
        }

        #region 属性

        //            TTK
        //                wxfef3c2c5833330ea
        //AppSecret(应用密钥)a808ad45e740c0fa04fc1ca2579b83b5 隐藏 重置
        //public string appid = "wx57d365e74490cf2f";  //公众微信平台下可以找到
        //public string appsecret = "a891edd957f2aede546f9256096bf95a";  //公众微信平台下可以找到
        #endregion

        //根据appid，secret，code获取微信openid、access token信息
        protected OAuth_Token Get_token(string Code)
        {
            //获取微信回传的openid、access token
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
            //微信回传的数据为Json格式，将Json格式转化成对象
            OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
            return Oauth_Token_Model;
        }

        //刷新Token(好像这个刷新Token没有实际作用)
        protected OAuth_Token refresh_token(string REFRESH_TOKEN)
        {
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=" + appid + "&grant_type=refresh_token&refresh_token=" + REFRESH_TOKEN);
            OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
            return Oauth_Token_Model;
        }

        //根据openid，access token获得用户信息
        protected OAuthUser Get_UserInfo(string REFRESH_TOKEN, string OPENID)
        {
            string Str = GetJson("https://api.weixin.qq.com/sns/userinfo?access_token=" + REFRESH_TOKEN + "&openid=" + OPENID);
            OAuthUser OAuthUser_Model = JsonHelper.ParseFromJson<OAuthUser>(Str);
            return OAuthUser_Model;
        }

        //访问微信url并返回微信信息
        protected string GetJson(string url)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            if (returnText.Contains("errcode"))
            {
                //可能发生错误
            }
            return returnText;
        }


        /// <summary>
        /// token类
        /// </summary>
        public class OAuth_Token
        {
            public OAuth_Token()
            {

                //
                //TODO: 在此处添加构造函数逻辑
                //
            }
            //access_token	网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
            //expires_in	access_token接口调用凭证超时时间，单位（秒）
            //refresh_token	用户刷新access_token
            //openid	用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
            //scope	用户授权的作用域，使用逗号（,）分隔
            public string _access_token;
            public string _expires_in;
            public string _refresh_token;
            public string _openid;
            public string _scope;
            public string access_token
            {
                set { _access_token = value; }
                get { return _access_token; }
            }
            public string expires_in
            {
                set { _expires_in = value; }
                get { return _expires_in; }
            }

            public string refresh_token
            {
                set { _refresh_token = value; }
                get { return _refresh_token; }
            }
            public string openid
            {
                set { _openid = value; }
                get { return _openid; }
            }
            public string scope
            {
                set { _scope = value; }
                get { return _scope; }
            }

        }

        /// <summary>
        /// 用户信息类
        /// </summary>
        public class OAuthUser
        {
            public OAuthUser()
            { }
            #region 数据库字段
            private int? _subscribe;
            private string _openID;
            private string _searchText;
            private string _nickname;
            private int _sex;
            private string _language;
            private string _province;
            private string _city;
            private string _country;
            private string _headimgUrl;
            private string _subscribe_time;
            private string _privilege;
            private string _remark;
            private int? _groupid;
            #endregion

            #region 字段属性
            /// <summary>
            /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
            /// </summary>
            public int? subscribe
            {
                set { _subscribe = value; }
                get { return _subscribe; }
            }
            /// <summary>
            /// 用户的唯一标识
            /// </summary>
            public string openid
            {
                set { _openID = value; }
                get { return _openID; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SearchText
            {
                set { _searchText = value; }
                get { return _searchText; }
            }
            /// <summary>
            /// 用户昵称 
            /// </summary>
            public string nickname
            {
                set { _nickname = value; }
                get { return _nickname; }
            }
            /// <summary>
            /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知 
            /// </summary>
            public int sex
            {
                set { _sex = value; }
                get { return _sex; }
            }
            /// <summary>
            /// 用户的语言，简体中文为zh_CN
            /// </summary>
            public string language
            {
                set { _language = value; }
                get { return _language; }
            }
            /// <summary>
            /// 用户个人资料填写的省份
            /// </summary>
            public string province
            {
                set { _province = value; }
                get { return _province; }
            }
            /// <summary>
            /// 普通用户个人资料填写的城市 
            /// </summary>
            public string city
            {
                set { _city = value; }
                get { return _city; }
            }
            /// <summary>
            /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
            /// </summary>
            public string subscribe_time
            {
                set { _subscribe_time = value; }
                get { return _subscribe_time; }
            }
            /// <summary>
            /// 国家，如中国为CN 
            /// </summary>
            public string country
            {
                set { _country = value; }
                get { return _country; }
            }
            /// <summary>
            /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
            /// </summary>
            public string headimgurl
            {
                set { _headimgUrl = value; }
                get { return _headimgUrl; }
            }
            /// <summary>
            /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
            /// </summary>
            public string remark
            {
                set { _remark = value; }
                get { return _remark; }
            }
            /// <summary>
            /// 	用户所在的分组ID
            /// </summary>
            public int? groupid
            {
                set { _groupid = value; }
                get { return _groupid; }

            }

            /// <summary>
            /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）其实这个格式称不上JSON，只是个单纯数组
            /// </summary>
            public string privilege
            {
                set { _privilege = value; }
                get { return _privilege; }
            }
            #endregion
        }

        /// <summary>
        /// 将Json格式数据转化成对象
        /// </summary>
        public class JsonHelper
        {
            /// <summary>  
            /// 生成Json格式  
            /// </summary>  
            /// <typeparam name="T"></typeparam>  
            /// <param name="obj"></param>  
            /// <returns></returns>  
            public static string GetJson<T>(T obj)
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    json.WriteObject(stream, obj);
                    string szJson = Encoding.UTF8.GetString(stream.ToArray()); return szJson;
                }
            }
            /// <summary>  
            /// 获取Json的Model  
            /// </summary>  
            /// <typeparam name="T"></typeparam>  
            /// <param name="szJson"></param>  
            /// <returns></returns>  
            public static T ParseFromJson<T>(string szJson)
            {
                T obj = Activator.CreateInstance<T>();
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                    return (T)serializer.ReadObject(ms);
                }
            }
        }
    }
}