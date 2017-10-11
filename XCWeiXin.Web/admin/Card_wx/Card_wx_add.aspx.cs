using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.Common;
using XCWeiXin.BLL;
using XCWeiXin.Model;
using XCWeiXin.Model.Card_wx;
using Senparc.Weixin.Helpers;

using Senparc.Weixin.MP.CommonAPIs;
using XCWeiXin.WeiXinComm;
using XCWeiXin.Web.UI;
using Senparc.Weixin.MP.AdvancedAPIs.Card;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
namespace XCWeiXin.Web.admin.Card_wx
{
    public partial class Card_wx_add : Web.UI.ManagePage
    {
        public int wid()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
            return wid;
        }
        public string Type_show;
      
       
        protected void Page_Load(object sender, EventArgs e)
        {


            Type_show = Request.Params["type"];
           
               Model.wx_userweixin weixin = GetWeiXinCode();
                int wid = weixin.id;
            
                if (wid.ToString()==null || wid.ToString()==null)
                {
                    Response.Write("wid为空");
                }
              
            
         
           
            if (RadioButton1.Checked)
            {
                Card_type.Text = RadioButton1.Text;
               
            }
            else if (RadioButton2.Checked)
            {
                Card_type.Text = RadioButton2.Text;
            }
            else if (RadioButton3.Checked)
            {
                Card_type.Text = RadioButton3.Text;
            }
            else if (RadioButton4.Checked)
            {
                Card_type.Text = RadioButton4.Text;
            }
            if (Card_type.Text == "团购券")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
            else if(Card_type.Text=="折扣券")
            {

                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = false;
 
            }
            else if (Card_type.Text == "代金券")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
                Panel4.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = true;
 
            }

         

        }


       

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            Card_color.Text = DropDownList1.SelectedValue;
           
           
        }


        public Senparc.Weixin.MP.AdvancedAPIs.Card.Card_BaseInfoBase _BaseInfo = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_BaseInfoBase()
        {


            logo_url = "http://img15.3lian.com/2015/c1/83/d/29.jpg",
            brand_name = "海底捞",
            code_type =Senparc.Weixin.MP.Card_CodeType.CODE_TYPE_TEXT,
            title = "132 元双人火锅套餐",
            sub_title = "周末狂欢必备",
            color = "Color010",
            notice = "使用时向服务员出示此券",
            service_phone = "020-88888888",
            description = @"不可与其他优惠同享\n 如需团购券发票，请在消费时向商户提出\n 店内均可
使用，仅限堂食\n 餐前不可打包，餐后未吃完，可打包\n 本团购券不限人数，建议2 人使用，超过建议人
数须另收酱料费5 元/位\n 本单谢绝自带酒水饮料",
            date_info = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_BaseInfo_DateInfo()
            {
                type =Card_DateInfo_Type.DATE_TYPE_FIX_TIME_RANGE.ToString(),
                begin_timestamp = DateTimeHelper.GetWeixinDateTime(DateTime.Now),
                end_timestamp = DateTimeHelper.GetWeixinDateTime(DateTime.Now.AddDays(10)),
            },
            sku = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_BaseInfo_Sku()
            {
                quantity =5
            },
            use_limit = 1,
            get_limit = 3,
            use_custom_code = false,
            bind_openid = false,
            can_share = true,
            can_give_friend = true,
            url_name_type = Senparc.Weixin.MP.Card_UrlNameType.URL_NAME_TYPE_RESERVATION,
            custom_url = "http://www.weiweihi.com",
            source = "大众点评",
            custom_url_name = "立即使用",
            custom_url_sub_title = "6个汉字tips",
            promotion_url_name = "更多优惠",
            promotion_url = "http://www.qq.com",
        };
    
        /// <summary>
        /// 获取微信accessToken；
        /// </summary>
        /// <returns></returns>
        public string Token()
        {
            WeiXinCRMComm dd = new WeiXinCRMComm();
            string error = "";
            WeiXCommFun wxcomm = new WeiXCommFun();
          
            string accessToken = dd.getAccessToken(wid(), out error);
            return accessToken;

        }
     
        /// <summary>
        /// 查询门店列表
        /// </summary>
        /// <returns></returns>
        public List<string> fghj ()
        {
            List<Senparc.Weixin.MP.AdvancedAPIs.Poi.GetStoreList_Business> ss = new List<Senparc.Weixin.MP.AdvancedAPIs.Poi.GetStoreList_Business>();
            var accessToken = Token();
            var result = PoiApi.GetPoiList(accessToken, 0);
            List<string> sss = new List<string>();
            for (int i = 0; i < result.business_list.Count; i++)
            {
               
                    ss.Add(result.business_list[i]);
                 
                    sss.Add(result.business_list[i].base_info.poi_id);
             
            }
         
            return sss;
            
          
       

        }
        protected void sub_save_Click(object sender, EventArgs e)
        {
           
           
                Model.Card_wx.Card_BaseInfo Fros = new Card_BaseInfo();
                if (Card_type.Text.Length == 0 || title.Text.Length == 0 || brand_name.Text.Length == 0 || imagetext.Text.Length == 0 || Card_color.Text.Length == 0 || notice.Text.Length == 0 || description.InnerText.Length == 0 || time_day.Text.Length == 0 || Cardnumber.Text.Length == 0)
                {
                    JscriptMsg("参数不能为空！", "back", "Error");
                }
                else
                {

                    _BaseInfo.code_type = Senparc.Weixin.MP.Card_CodeType.CODE_TYPE_QRCODE;
                    Fros.logo_url = MyCommFun.getWebSite() + imagetext.Text;
                    _BaseInfo.logo_url = MyCommFun.getWebSite() + imagetext.Text.ToString();
                    _BaseInfo.brand_name = brand_name.Text;
                    Fros.brand_name = brand_name.Text;
                    _BaseInfo.title = title.Text;
                    Fros.title = title.Text;
                    _BaseInfo.sub_title = sub_title.Text;
                    Fros.sub_title = sub_title.Text;
                    _BaseInfo.color = Card_color.Text;
                    Fros.color = Card_color.Text;
                    _BaseInfo.notice = notice.Text;
                    Fros.notice = notice.Text;
                    _BaseInfo.service_phone = service_phone.Text;
                    Fros.service_phone = service_phone.Text;
                    _BaseInfo.description = description.InnerText;
                    Fros.description = description.InnerText;
                    _BaseInfo.date_info.begin_timestamp = DateTimeHelper.GetWeixinDateTime(DateTime.Now);
                    Fros.begin_timestamp = (DateTimeHelper.GetWeixinDateTime(DateTime.Now)).ToString(); ;
                    _BaseInfo.date_info.end_timestamp = DateTimeHelper.GetWeixinDateTime(DateTime.Now.AddDays(int.Parse(time_day.Text)));
                    Fros.end_timestamp = time_day.Text.ToString();
                    _BaseInfo.sku.quantity = int.Parse(Cardnumber.Text);
                    Fros.quantity = int.Parse(Cardnumber.Text); ;
                    _BaseInfo.use_limit = int.Parse(user_limit.Text);
                    Fros.use_limit = int.Parse(user_limit.Text);
                    _BaseInfo.get_limit = int.Parse(get_limit.Text);
                    Fros.get_limit = int.Parse(get_limit.Text);
                    _BaseInfo.use_custom_code = code.Checked;
                    Fros.use_custom_code = code.Checked;
                    _BaseInfo.bind_openid = false;
                    Fros.bind_openid = false;
                    _BaseInfo.can_share = share_page.Checked;
                    Fros.can_share = share_page.Checked;
                    _BaseInfo.can_give_friend = share_card.Checked;
                    _BaseInfo.url_name_type = Senparc.Weixin.MP.Card_UrlNameType.URL_NAME_TYPE_RESERVATION;
                    Fros.can_give_friend = share_card.Checked;
                    _BaseInfo.custom_url_name = url_name.Text;
                    Fros.custom_url_name = url_name.Text;
                    _BaseInfo.location_id_list = fghj();
                    _BaseInfo.custom_url_sub_title = sub_url_name.Text;
                    Fros.custom_url_sub_title = sub_url_name.Text;
                    _BaseInfo.custom_url = custom_url.Text;
                    Fros.custom_url = custom_url.Text;
                    _BaseInfo.promotion_url_name = pro_url_name.Text;
                    Fros.promotion_url_name = pro_url_name.Text;
                    _BaseInfo.promotion_url = pro_url.Text;
                    Fros.promotion_url = pro_url.Text;

                    if (Card_type.Text == "团购券")
                    {
                        Model.wx_userweixin weixin = GetWeiXinCode();
                        int wid = weixin.id;
                        string accessToken = Token();
                        var data = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_GrouponData()
                        {
                            base_info = _BaseInfo,
                            deal_detail = deal_detail.Text.ToString()
                        };
                        BLL.Card_wx.Card_BaseInfo Add = new BLL.Card_wx.Card_BaseInfo();
                        Fros.wid = wid;
                        Fros.deal_detail = deal_detail.Text;
                        Fros.Card_type = Card_type.Text;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        var result = CardApi.CreateCard(accessToken, data);
                        Fros.Wx_Card_id = result.card_id;
                        Add.Add(Fros);
                        if (paycell.Checked == true)
                        {
                            CardApi.PayCellSet(accessToken, Fros.Wx_Card_id, true);  ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                            CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Console.Write(result);
                        JscriptMsg("添加卡券成功！", "Card_wx_QR.aspx", "Success");

                    }
                    else if (Card_type.Text == "代金券")
                    {
                        Model.wx_userweixin weixin = GetWeiXinCode();
                        int wid = weixin.id;
                        string accessToken = Token();
                        var data = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_CashData()
                        {
                            base_info = _BaseInfo,
                            least_cost = int.Parse(least_cost.Text),
                            reduce_cost = int.Parse(reduce_cost.Text)
                        };

                        BLL.Card_wx.Card_BaseInfo Add = new BLL.Card_wx.Card_BaseInfo();
                        Fros.wid = wid;
                        Fros.Card_type = Card_type.Text;
                        Fros.least_cost = least_cost.Text;
                        Fros.reduce_cost = reduce_cost.Text;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        var result = CardApi.CreateCard(accessToken, data);
                        Fros.Wx_Card_id = result.card_id;
                        Add.Add(Fros);
                        if (paycell.Checked == true)
                        {
                            CardApi.PayCellSet(accessToken, Fros.Wx_Card_id, true);  ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                            CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核 销接口
                        }
                        Console.Write(result);
                        JscriptMsg("添加卡券成功！", "Card_wx_QR.aspx", "Success");

                    }
                    else if (Card_type.Text == "折扣券")
                    {
                        Model.wx_userweixin weixin = GetWeiXinCode();
                        int wid = weixin.id;
                        string accessToken = Token();
                        var data = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_DisCountData()
                        {
                            base_info = _BaseInfo,
                            discount = float.Parse(discount.Text.ToString())
                        };
                        BLL.Card_wx.Card_BaseInfo Add = new BLL.Card_wx.Card_BaseInfo();
                        Fros.wid = wid;
                        Fros.Card_type = Card_type.Text;
                        Fros.discount = discount.Text;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        var result = CardApi.CreateCard(accessToken, data);
                        Fros.Wx_Card_id = result.card_id;
                        Add.Add(Fros);
                        if (paycell.Checked == true)
                        {
                            CardApi.PayCellSet(accessToken, Fros.Wx_Card_id, true);  ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                            CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Console.Write(result);
                        JscriptMsg("添加卡券成功！", "Card_wx_QR.aspx", "Success");
                    }
                    else if (Card_type.Text == "优惠券")
                    {
                        Model.wx_userweixin weixin = GetWeiXinCode();
                        int wid = weixin.id;
                        string accessToken = Token();
                        var data = new Senparc.Weixin.MP.AdvancedAPIs.Card.Card_GeneralCouponData()
                        {
                            base_info = _BaseInfo,
                            default_detail = default_detail.Text

                        };
                        BLL.Card_wx.Card_BaseInfo Add = new BLL.Card_wx.Card_BaseInfo();
                        Fros.wid = wid;
                        Fros.Card_type = Card_type.Text;
                        Fros.default_detail = default_detail.Text;
                        Fros.Paycell = paycell.Checked;
                        Fros.hexiao = hexiao.Checked;
                        var result = CardApi.CreateCard(accessToken, data);
                        Fros.Wx_Card_id = result.card_id;
                        Add.Add(Fros);
                        if (paycell.Checked == true)
                        {
                            CardApi.PayCellSet(accessToken, Fros.Wx_Card_id, true); ///设置微信买单功能

                        }
                        if (hexiao.Checked == true)
                        {
                            CardApi.SelfConsumecellSet(Token(), Fros.Wx_Card_id, true);  ///设置自助核销接口
                        }
                        Console.Write(result);
                        JscriptMsg("添加卡券成功！", "Card_wx_QR.aspx", "Success");

                    }
                }
          
           


        }
      

 

        //protected void upfile_Click(object sender, EventArgs e)
        //{
        //    string strname = FileUpload1.PostedFile.FileName;//使用文件名
        //    newPreview.ImageUrl = strname;
        //    if (strname != "")
        //    {
        //        bool fileOK = false;
        //        int i = strname.LastIndexOf(".");
        //        string kzm = strname.Substring(i);
        //        string Newname = Guid.NewGuid().ToString();
        //       // string xingdui = @"~\images\";
        //        string juedui = Server.MapPath("~\\admin\\images\\new\\");
        //        string newFilename = juedui + Newname;
        //        if (FileUpload1.HasFile)
        //        {
        //            String[] allowedExtensions = { ".gif", ".png", ".bmp", ".jpg", ".txt" };
        //            for (int j = 0; j < allowedExtensions.Length; j++)
        //            {
        //                if (kzm == allowedExtensions[j])
        //                {
        //                    fileOK = true;
        //                }
        //            }
        //        }
        //        if (fileOK)
        //        {
        //            try
        //            {
        //                newFilename = newFilename + kzm;
        //                // 判定该路径是否存在
        //                if (!Directory.Exists(juedui))
        //                    Directory.CreateDirectory(juedui);
        //                newPreview.ImageUrl = newFilename;     //为了能看清楚我们提取出来的图片地址，在这使用label
        //                Label2.Text = "<b>原文件路径：</b>" + FileUpload1.PostedFile.FileName + "<br />" +
        //                               "<b>文件大小：</b>" + FileUpload1.PostedFile.ContentLength + "字节<br />" +
        //                               "<b>文件类型：</b>" + FileUpload1.PostedFile.ContentType + "@@@" + MyCommFun.GetRootPath() + "admin" + "\\" + "images" + "\\new" + "\\" + Newname + kzm+ "<br />";
        //             //   Label3.Text = xiangdui + newName + kzm;
        //                string ss = MyCommFun.GetRootPath().ToString();
        //                Label4.Text = "文件上传成功.";

        //                newPreview.ImageUrl = MyCommFun.GetRootPath() + "admin" + "\\" + "images" + "\\new"+"\\"+Newname+kzm;
        //                FileUpload1.PostedFile.SaveAs(newFilename);//将图片存储到服务器上
        //            }
        //            catch (Exception)
        //            {
        //                Label4.Text = "文件上传失败.";
        //            }
        //        }
        //        else
        //        {
        //            Label4.Text = "只能够上传图片文件.";
        //        }    
        //    }
        }
    }
