using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Configuration;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using System.Xml;
using System.Xml.Linq;
using XCWeiXin.Common;
using System.Net;
using Newtonsoft.Json;
using XCWeiXin.Model;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;

namespace XCWeiXin.WeiXinComm.CustomMessageHandler
{

  
    /// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
      
        /*
         * 重要提示：v1.5起，MessageHandler提供了一个DefaultResponseMessage的抽象方法，
         * DefaultResponseMessage必须在子类中重写，用于返回没有处理过的消息类型（也可以用于默认消息，如帮助信息等）；
         * 其中所有原OnXX的抽象方法已经都改为虚方法，可以不必每个都重写。若不重写，默认返回DefaultResponseMessage方法中的结果。
         */

        //string agentUrl = "http://localhost:12222/App/Weixin/4";
        //string agentToken = "27C455F496044A87";
        //string souideaKey = "CNadjJuWzyX5bz5Gn+/XoyqiqMa5DjXQ";

        string agentUrl = "";
        string agentToken = "";

        public CustomMessageHandler(Stream inputStream, Senparc.Weixin.MP.Entities.Request.PostModel postModel = null, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalWeixinContext.ExpireMinutes = 3。
            WeixinContext.ExpireMinutes = 10;
            WeixinContext.MaxRecordCount = 1000;  //最多存储多少条记录

        }

        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }

        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }



        ///// <summary>
        ///// 处理位置请求
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        //public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        //{
        //    var locationService = new LocationService();
        //    var responseMessage = locationService.GetResponseMessage(requestMessage as RequestMessageLocation);
        //    return responseMessage;
        //}
        /// <summary>
        /// 位置类型请求
        /// </summary>
        /// 

        ///修改于2017:07:16   5:43 完成人:张强林
        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            string url = "https://api.seniverse.com/v3/weather/daily.json";
            string postdata = "key=gj0bzc3lhudxttxn&location=" + requestMessage.Location_X + ":" + requestMessage.Location_Y + "&language=zh-Hans&unit=c&start=0&days=3";
            var weather = HttpGet(url, postdata);

            JavaScriptSerializer js = new JavaScriptSerializer();
            Model.weather.Root team =
            team = js.Deserialize<Model.weather.Root>(weather);

          
          
            var responseMessage1 = CreateResponseMessage<ResponseMessageNews>();
            responseMessage1.Articles.Add(new Article()
            {
                Title = requestMessage.Label + "未来3天天气预报"

            });
            responseMessage1.Articles.Add(new Article()
            {
                Title =team.results[0].daily[0].date + "," + "最高气温：" + team.results[0].daily[0].high +"℃," +"气象：" + team.results[0].daily[0].text_day,
                PicUrl = MyCommFun.getWebSite() + "/weather_code/" + team.results[0].daily[0].code_day + ".png",
              
               
            });
            responseMessage1.Articles.Add(new Article()
            {
                Title = team.results[0].daily[1].date + "," + "最高气温：" + team.results[0].daily[1].high + "℃,"+"气象：" + team.results[0].daily[1].text_day,
                PicUrl = MyCommFun.getWebSite() + "/weather_code/" + team.results[0].daily[1].code_day + ".png",
             
            })
           ;
            responseMessage1.Articles.Add(new Article()
            {
               
                Title = team.results[0].daily[2].date + "," + "最高气温：" + team.results[0].daily[2].high + "℃,"+"气象：" +team.results[0].daily[2].text_day,
                PicUrl = MyCommFun.getWebSite() + "/weather_code/" + team.results[0].daily[2].code_day + ".png",

            })
          ;
            return responseMessage1;
        }
        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            int apiid = 0;
            //   apiid = wxcomm.getApiid();
            WeiXCommFun wxFun = new WeiXCommFun();
            //查询微信上墙的活动，只取一条
            BLL.wx_sq_act actBll = new BLL.wx_sq_act();
            Model.wx_sq_act act = actBll.GetModel(apiid, DateTime.Now);
            if (act != null)
            {
                //查询是否在黑名单里
                BLL.wx_sq_heimd hBll = new BLL.wx_sq_heimd();
                bool isExist = hBll.Exists(requestMessage.FromUserName, act.id);
                if (isExist)
                {
                    //存在黑名单里
                    return wxFun.GetResponseMessageTxtByContent(requestMessage, "您在黑名单里，无法上传图片", apiid);
                }
                else
                {
                    //说明有微信上墙活动
                    //1 将图片的地址保存到数据库
                    BLL.wx_sq_piclist pBll = new BLL.wx_sq_piclist();
                    Model.wx_sq_piclist pic = new Model.wx_sq_piclist();
                    pic.openid = requestMessage.FromUserName;
                    pic.aid = act.id;
                    pic.picUrl = requestMessage.PicUrl;
                    pic.hasShenghe = false;
                    pic.createDate = DateTime.Now;
                    int ret = pBll.Add(pic);
                    //2返回提示语句

                    if (ret > 0)
                    {
                        string content = "";
                        if (act.shenghe)
                        {
                            content = "已经成功上传等待审核！<br/><a href=\"" + MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid=" + apiid + "&aid=" + act.id + "\">查看相册</a>照片id为" + ret;

                        }
                        else
                        {
                            content = "已经成功上传点击查看<br/><a href=\"" + MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid=" + apiid + "&aid=" + act.id + "\">查看相册</a>照片id为" + ret;
                        }
                        return wxFun.GetResponseMessageTxtByContent(requestMessage, content, apiid);
                    }
                    else
                    {
                        return wxFun.GetResponseMessageTxtByContent(requestMessage, "图片上传失败，请重新上传", apiid);
                    }
                }

            }
            else
            {
                var responseMessage = CreateResponseMessage<ResponseMessageNews>();
                responseMessage.Articles.Add(new Article()
                {
                    Title = "这是你刚发送的图片",
                    Description = "您发送的图片将会显示在边上",
                    PicUrl = requestMessage.PicUrl,
                    Url = requestMessage.PicUrl
                });
                responseMessage.Articles.Add(new Article()
                {
                    Title = "快速预约",
                    Description = "第二条带连接的内容",
                    PicUrl = "http://www.hugongll.com/hugongll/dist/img/png/service01.png",
                    Url = "http://www.hugongll.com/hugongll/index.aspx"
                });
                return responseMessage;
             //   return wxFun.GetResponseMessageTxtByContent(requestMessage, "您刚刚上传了一个图片", apiid);
            }

            //var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            //responseMessage.Articles.Add(new Article()
            //{
            //    Title = "您刚才发送了图片信息",
            //    Description = "您发送的图片将会显示在边上",
            //    PicUrl = requestMessage.PicUrl,
            //    Url = requestMessage.PicUrl
            //});
            //responseMessage.Articles.Add(new Article()
            //{
            //    Title = "第二条",
            //    Description = "第二条带连接的内容",
            //    PicUrl = requestMessage.PicUrl,
            //    Url = "http://www.yubom.net"
            //});
            //return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        //{
        //    var responseMessage = CreateResponseMessage<ResponseMessageMusic>();
        //    responseMessage.Music.MusicUrl = "http://weixin.senparc.com/Content/music1.mp3";
        //    responseMessage.Music.Title = "这里是一条音乐消息";
        //    responseMessage.Music.Description = "来自Jeffrey Su的美妙歌声~~";
        //    return responseMessage;
        //}
        /// <summary>
        /// 小视屏处理
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnShortVideoRequest(RequestMessageShortVideo requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "小视频已收到！" + "openid=" + requestMessage.FromUserName;
            return responseMessage;
            //return DefaultResponseMessage(requestMessage);
        }
        public string stoce()
        {
            WeiXinCRMComm dd = new WeiXinCRMComm();
            string error = "";
            WeiXCommFun wxcomm = new WeiXCommFun();
            int wid = wxcomm.getApiid();
            string sctokn = dd.getAccessToken(wid, out error);
            return sctokn;

        }
        /// <summary>
        /// 语音类型请求
        /// </summary>
        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            WeiXCommFun bb = new WeiXCommFun();
            int apiid = bb.getApiid();
            IResponseMessageBase reponseMessage=null;
            //上传缩略图
            string file = MyCommFun.GetRootPath() + "/upload/thumb.jpg";
            var accessToken = stoce();
            var uploadResult = MediaApi.UploadTemporaryMedia(accessToken, UploadMediaFileType.thumb,
                                                     file);
            //设置音乐信息
            var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();
            reponseMessage = strongResponseMessage;
            strongResponseMessage.Music.Title = "南山南";
            strongResponseMessage.Music.Description = "张强林";
            strongResponseMessage.Music.MusicUrl =  MyCommFun.getWebSite()+"/nsn.mp3";
            strongResponseMessage.Music.HQMusicUrl = MyCommFun.getWebSite()+"/nsn.mp3";
            strongResponseMessage.Music.ThumbMediaId = uploadResult.thumb_media_id;
            return reponseMessage;
           
            //var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            //responseMessage.Content = "语音消息已收到";
            //return responseMessage;
        }


        /// <summary>
        /// 多客服接入会话
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_Kf_Create_SessionRequest(RequestMessageEvent_Kf_Create_Session requestMessage)
        {

            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "客服" + requestMessage.KfAccount + "为你服务！";
            return responseMessage;
        }
        /// <summary>
        /// 多客服关闭会话
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_Kf_Close_SessionRequest(RequestMessageEvent_Kf_Close_Session requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }

        /// <summary>
        /// 多客服转接会话
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_Kf_Switch_SessionRequest(RequestMessageEvent_Kf_Switch_Session requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }



        /// <summary>
        /// 处理视频请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "视频已收到！" + requestMessage.MediaId;
            return responseMessage;
        }

        /// <summary>
        /// 处理链接消息请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = string.Format(@"您发送了一条连接信息：
Title：{0}
Description:{1}
Url:{2}", requestMessage.Title, requestMessage.Description, requestMessage.Url);
            return responseMessage;
        }

        /// <summary>
        /// 处理事件请求（这个方法一般不用重写，这里仅作为示例出现。除非需要在判断具体Event类型以外对Event信息进行统一操作
        /// </summary>
        /// <param name="requestMessage"></param>
        ///// <returns></returns>
        public IResponseMessageBase OnEventRequest(RequestMessageEventBase requestMessage)
        {
            var eventResponseMessage = base.OnEventRequest(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
            //TODO: 对Event信息进行统一操作
            return eventResponseMessage;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            /* 所有没有被处理的消息会默认返回这里的结果，
             * 因此，如果想把整个微信请求委托出去（例如需要使用分布式或从其他服务器获取请求），
             * 只需要在这里统一发出委托请求，如：
             * var responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
             * return responseMessage;
             */

            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "Form:Message";
            return responseMessage;
        }


    }
}
