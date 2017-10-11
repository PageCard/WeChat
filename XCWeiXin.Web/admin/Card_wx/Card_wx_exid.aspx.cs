using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.Card;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.Helpers;
using XCWeiXin.Model.Card_wx;
using XCWeiXin.Model.Card_wx.CardMange;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace XCWeiXin.Web.admin.Card_wx
{

    public partial class Card_wx_exid : Web.UI.ManagePage
    {
        
        public Senparc.Weixin.MP.Entities.AccessTokenResult normalReturn;
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Card_wx.Card_BaseInfo bll = new BLL.Card_wx.Card_BaseInfo();
            string cardtype = Request.Params["cardtype"];
            string cardid = Request.QueryString["cardid"];
            string acctoken = Token();
            if (!IsPostBack)
            {
                Label1.Text = cardtype;
                Label2.Text = cardid;
                Model.Card_wx.Card_BaseInfo dd = bll.Getmodel(cardid);
                brand_name.Text = dd.brand_name.ToString();
                title.Text = dd.title;
                sub_title.Text = dd.sub_title;
                imagetext.Text = dd.logo_url;
                Card_color.Text = dd.color;
                notice.Text = dd.notice;
                description.InnerText = dd.description;
                service_phone.Text = dd.service_phone;
                url_name.Text = dd.custom_url_name;
                custom_url.Text = dd.custom_url;
                sub_url_name.Text = dd.custom_url_sub_title;
                pro_url.Text = dd.promotion_url;
                pro_url_name.Text = dd.promotion_url_name;
                time_day.Text = dd.end_timestamp;
                user_limit.Text = dd.use_limit.ToString();
                get_limit.Text = dd.get_limit.ToString();
                share_page.Checked = dd.can_share;
                share_card.Checked = dd.can_give_friend;
                paycell.Checked = dd.Paycell;
                hexiao.Checked = dd.hexiao;
                imgbjurl.ImageUrl = imagetext.Text;


        }

            

        }
        public  WxJsonResult Cardupdate(string accessTokenOrid, string Cardtype, object cardInfo, string Cardid, int timeOut = 10000)
        {

            return ApiHandlerWapper.TryCommonApi(accessToken =>
                {
                    var urlFormat = string.Format("https://api.weixin.qq.com/card/update?access_token={0}", accessTokenOrid);
                     Model.Card_wx.CardMange.BaseCardUpdateInfo cardData = null;
                    if (Cardtype == "团购券")
                    {
                        cardData = new CardUpdata_groupon()
                        {
                            card_id = Cardid,
                            groupon = cardInfo as Card_groupon

                        };
                        
 
                    }
                    else if (Cardtype == "优惠券")
                    {
                        cardData = new CardUpdata_general_coupon()
                         {
                             card_id = Cardid,
                             general_coupon = cardInfo as Card_general_coupon


                         };
 
                    }
                    else if (Cardtype == "代金券")
                    {
                        cardData = new CardUpdata_cash()
                        {
                            card_id = Cardid,
                            cash = cardInfo as Card_cash
                        };
 
                    }
                    else if (Cardtype == "折扣券")
                    {

                        cardData = new CardUpdata_discount()
                        {
                             card_id = Cardid,
                          
                            discount = cardInfo as Card_discount
                          
                        };
                    }

                    var jsonSetting = new JsonSetting(true, null,
                        new List<Type>()
                    {
        //typeof (Modify_Msg_Operation),
        //typeof (CardCreateInfo),
        typeof (Card_BaseInfoBase)//过滤Modify_Msg_Operation主要起作用的是这个
                    });

                    var result = CommonJsonSend.Send<CardCreateResultJson>(null, urlFormat, cardData, timeOut: timeOut,
                        //针对特殊字段的null值进行过滤
                        jsonSetting: jsonSetting);
                    return result;

                }, accessTokenOrid);

                //    return CommonJsonSend.Send<WxJsonResult>(null, urlFormat, cardInfo, timeOut: timeOut);
                //}, accessTokenOrid);


        }
      
        public string Token()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            string appid = weixin.AppId;
            string app_secret = weixin.AppSecret;
            normalReturn = new Senparc.Weixin.MP.Entities.AccessTokenResult();
            normalReturn = CommonApi.GetToken(appid, app_secret);
            var accesstoken = normalReturn.access_token;
            return accesstoken;


        }
        /// <summary>
        /// 转化成UTC事件机制
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToGMTFormat(DateTime dt)
        {
            return dt.ToString("r") + dt.ToString("zzz").Replace(":", "");
        }  
        public Model.Card_wx.CardMange.Update_BaseCardInfo _BaseInfo = new Model.Card_wx.CardMange.Update_BaseCardInfo()
        {


            logo_url = "http://img15.3lian.com/2015/c1/83/d/29.jpg",
         
            code_type = Senparc.Weixin.MP.Card_CodeType.CODE_TYPE_QRCODE,
           
            
            color = "Color010",
            notice = "使用时向服务员出示此券",
            service_phone = "020-88888888",
            description = @"不可与其他优惠同享\n 如需团购券发票，请在消费时向商户提出\n 店内均可
使用，仅限堂食\n 餐前不可打包，餐后未吃完，可打包\n 本团购券不限人数，建议2 人使用，超过建议人
数须另收酱料费5 元/位\n 本单谢绝自带酒水饮料",
           
          
             
          
            use_limit = 1,
            get_limit = 3,
           
            
            can_share = true,
            can_give_friend = true,
            custom_url_name="df",
            custom_url_sub_title="sdf",
            custom_url = "http://www.weiweihi.com",
             promotion_url="http://www.baidu.com",
             promotion_url_name="dgf",
             promotion_url_sub_title="df"
            
          
        };

        protected void sub_save_Click(object sender, EventArgs e)
        {
            if ( imagetext.Text.Length == 0|| notice.Text.Length == 0|| user_limit.Text.Length==0 || get_limit.Text.Length==0)
            {
                JscriptMsg("参数不能为空！", "back", "Error");
            }
            else
            {
                BLL.Card_wx.Card_BaseInfo exit = new BLL.Card_wx.Card_BaseInfo();
                Model.wx_userweixin weixin = GetWeiXinCode();
                int wid = weixin.id;
                Model.Card_wx.Card_BaseInfo Fros = new Card_BaseInfo();
                _BaseInfo.logo_url = imagetext.Text;
                Fros.logo_url = imagetext.Text;
                _BaseInfo.color = Card_color.Text;
                Fros.color = Card_color.Text;
                _BaseInfo.notice = notice.Text;
                Fros.notice = notice.Text;
                _BaseInfo.service_phone = service_phone.Text;
                Fros.service_phone = service_phone.Text;
                _BaseInfo.description = description.InnerText;
                Fros.description = description.InnerText;
                _BaseInfo.use_limit = int.Parse(user_limit.Text);
                Fros.use_limit = int.Parse(user_limit.Text);
                _BaseInfo.get_limit = int.Parse(get_limit.Text);
                Fros.get_limit = int.Parse(get_limit.Text);
                _BaseInfo.can_share = share_page.Checked;
                Fros.can_share = share_page.Checked;
                _BaseInfo.can_give_friend = share_card.Checked;
                Fros.can_give_friend = share_card.Checked;
                _BaseInfo.custom_url_name = url_name.Text;
                Fros.custom_url_name = url_name.Text;
                _BaseInfo.custom_url_sub_title = sub_url_name.Text;
                Fros.custom_url_sub_title = sub_url_name.Text;
                _BaseInfo.custom_url = custom_url.Text;
                Fros.custom_url = custom_url.Text;
                _BaseInfo.promotion_url_name = pro_url_name.Text;
                Fros.promotion_url_name = pro_url_name.Text;
                _BaseInfo.promotion_url = pro_url.Text;
                Fros.promotion_url = pro_url.Text;

                if (Label1.Text == "团购券")
                {
                    var data = new Model.Card_wx.CardMange.Card_groupon()
                    {

                        base_info = _BaseInfo,

                    };
                    var result = Cardupdate(Token(), Label1.Text, data, Label2.Text);
                    if (result.errmsg == "ok")
                    {
                        if (paycell.Checked == true)
                        {
                            //   CardApi.PayCellSet(Token(), Fros.Wx_Card_id, true); ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                            //  CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Fros.wid = wid;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        Fros.Wx_Card_id = Label2.Text;
                        Fros.Card_type = Label1.Text;
                        exit.Exit_card(Fros);
                        Console.Write(result);
                        JscriptMsg("编辑卡券成功！", "Card_wx_QR.aspx", "Success");

                    }

                }
                else if (Label1.Text == "代金券")
                {
                    var data = new Model.Card_wx.CardMange.Card_cash()
                    {
                        base_info = _BaseInfo,

                    };
                    var result = Cardupdate(Token(), Label1.Text, data, Label2.Text);
                    if (result.errmsg == "ok")
                    {
                        if (paycell.Checked == true)
                        {
                          //  CardApi.PayCellSet(Token(), Fros.Wx_Card_id, true); ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                           // CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Fros.wid = wid;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        Fros.Wx_Card_id = Label2.Text;
                        Fros.Card_type = Label1.Text;
                        exit.Exit_card(Fros);
                        Console.Write(result);
                        JscriptMsg("编辑卡券成功！", "Card_wx_QR.aspx", "Success");

                    }

                }
                else if (Label1.Text == "折扣券")
                {
                    var data = new Model.Card_wx.CardMange.Card_discount()
                    {
                        base_info = _BaseInfo,
                    };
                    var result = Cardupdate(Token(), Label1.Text, data, Label2.Text);
                    if (result.errmsg == "ok")
                    {
                        if (paycell.Checked == true)
                        {
                         //   CardApi.PayCellSet(Token(), Fros.Wx_Card_id, true); ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                          //  CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Fros.wid = wid;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        Fros.Wx_Card_id = Label2.Text;
                        Fros.Card_type = Label1.Text;
                        exit.Exit_card(Fros);
                        Console.Write(result);
                        JscriptMsg("编辑卡券成功！", "Card_wx_QR.aspx", "Success");

                    }
                    if (paycell.Checked == true)
                    {

                    }
                }
                else if (Label1.Text == "优惠券")
                {
                    var data = new Model.Card_wx.CardMange.Card_general_coupon()
                    {
                        base_info = _BaseInfo,
                    };
                    var result = Cardupdate(Token(), Label1.Text, data, Label2.Text);
                    if (result.errmsg == "ok")
                    {
                        if (paycell.Checked == true)
                        {
                       //     CardApi.PayCellSet(Token(), Fros.Wx_Card_id, true); ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                      //      CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Fros.wid = wid;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        Fros.Wx_Card_id = Label2.Text;
                        Fros.Card_type = Label1.Text;
                        exit.Exit_card(Fros);
                        Console.Write(result);
                        JscriptMsg("编辑卡券成功！", "Card_wx_QR.aspx", "Success");

                    }
                }
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Card_color.Text = DropDownList1.SelectedValue;
            DropDownList1.Text = DropDownList1.SelectedValue;
        }
    }
}