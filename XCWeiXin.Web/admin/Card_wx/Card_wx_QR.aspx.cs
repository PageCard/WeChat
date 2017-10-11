using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCWeiXin.WeiXinComm;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP.CommonAPIs;

namespace XCWeiXin.Web.admin.Card_wx
{
    public partial class Card_QR : Web.UI.ManagePage
    {

        public Senparc.Weixin.MP.Entities.AccessTokenResult normalReturn;
        BLL.Card_wx.Card_BaseInfo bll = new BLL.Card_wx.Card_BaseInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
          
            string  strwhere = "wid="+wid()+" and Card_type='团购券'";
             Rqlistb(strwhere);
            }
        }
    
        private void Rqlistb(string strwhere)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
          
            DataSet ds = bll.Date(strwhere);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                int count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                }
                ds.AcceptChanges();
            }         
            this.rptList.DataSource = ds;
            this.rptList.DataBind();
        }
        /// <summary>
        /// 获取accesstoken方法
        /// </summary>
        /// <returns></returns>
        public string Token()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(weixin.id, out error);
            return accessToken;
           

        }
        public int wid()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
            return wid;
        }
        public string appid()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            string appid = weixin.AppId;
            return appid;
        }
        protected void button_click(object sender, EventArgs e)
        {
          
                
        }

        public static string GetShowQrCodeUrl(string ticket)
        {
            var urlFormat = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}";
            return string.Format(urlFormat, ticket.AsUrlData());
        }
     
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "toufang")
            {
             
              //  int dd = int.Parse(lbtn_Update.CommandArgument.ToString());
                    int dd = int.Parse(e.Item.ItemIndex.ToString());
                   string  Cardid = ((HiddenField)rptList.Items[dd].FindControl("HiddenField1")).Value;
                    var cardId = Cardid;
                    string accessToken = Token();
                    var result = CardApi.CreateQR(accessToken, cardId);


                    string ticket = result.ticket;
                    string url_image = GetShowQrCodeUrl(ticket);
                    int ss =int.Parse( e.Item.ItemIndex.ToString());
                   Image sss = (Image)rptList.Items[ss].FindControl("Image2");
                    sss.ImageUrl = url_image;
                
 
            }
            else if (e.CommandName == "deletecard")
            {
                DropDownList dr = new DropDownList();
                dr = (DropDownList)rptList.Controls[0].FindControl("DropDownList2");
                string dd = dr.SelectedValue;
                int cardid = int.Parse(e.Item.ItemIndex.ToString());
                string card_wx_id = ((HiddenField)rptList.Items[cardid].FindControl("HiddenField1")).Value;
              var result= CardApi.CardDelete(Token(), card_wx_id);
              if (result.errmsg == "ok")
              {
                  bll.delete(card_wx_id);

              }
              else {
                  string ss= result.errmsg;
              }
              string where = "wid=" + wid() + " and Card_type=团购券";
                Rqlistb(where);
               
 
            }
            else if (e.CommandName == "update_q")
            {
              
                int dd = int.Parse(e.Item.ItemIndex.ToString());
                string Cardid = ((HiddenField)rptList.Items[dd].FindControl("HiddenField1")).Value;
                var cardId = Cardid;
               string  Cardtype = ((HiddenField)rptList.Items[dd].FindControl("hd2")).Value;
                string accessToken = Token();
                int ss =int.Parse( e.Item.ItemIndex.ToString());
                TextBox sss = (TextBox)rptList.Items[ss].FindControl("quantity");
               
                var result = CardApi.CardDetailGet(accessToken, cardId);
                if (Cardtype == "团购券")
                {
                    sss.Text = result.card.groupon.base_info.sku.quantity.ToString();
                }
                else if (Cardtype == "代金券")
                {
                    sss.Text = result.card.cash.base_info.sku.quantity.ToString();
                }
                else if (Cardtype == "折扣券")
                {
                    sss.Text = result.card.discount.base_info.sku.quantity.ToString();
                }
                else if (Cardtype == "优惠券")
                {
                    sss.Text = result.card.general_coupon.base_info.sku.quantity.ToString();
                }
               
                Model.Card_wx.Card_BaseInfo Base = new Model.Card_wx.Card_BaseInfo();
                Base.quantity = int.Parse(sss.Text);
                Base.Wx_Card_id = cardId;
                Base.wid = wid();
                bll.Upadata_kucun(Base);
             
              //  var result= CardApi.ModifyStock(Token(), Cardid, int.Parse(sss.Text));
              //  try
              //  {
              //      if (result.errmsg == "ok")
              //      {
                 
              //      }
              //  }
              //  catch (Exception ex)
              //  {
                        //  }
                
 
            }
            else if (e.CommandName == "exit")
            {
                int dd = int.Parse(e.Item.ItemIndex.ToString());
                string Cardid = ((HiddenField)rptList.Items[dd].FindControl("HiddenField1")).Value;
                var cardId = Cardid;
                string Cardtype = ((HiddenField)rptList.Items[dd].FindControl("hd2")).Value;
                Response.Redirect("Card_wx_exid.aspx?cardtype=" + Cardtype + "&cardid=" + cardId + "&type=exit");

 
            }
        }
        

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dr = new DropDownList();
            dr = (DropDownList)rptList.Controls[0].FindControl("DropDownList2");
        //    dr = ((DropDownList)rptList.Parent.FindControl("DropDownList2"));
         //   dr = rptList.FindControl("DropDownList2") as DropDownList;
            string dd = dr.SelectedValue; ;
            string vvv = dd;
            string where = "wid="+wid()+ "and Card_type="+"'"+dd+"'";
            Rqlistb(where);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
           // SendTextTest("oFo2Hjq6_yMhyz6cQ2MZtmxODOVU");
            string error = "";
            XCWeiXin.WeiXinComm.WeiXinCRMComm cpp = new XCWeiXin.WeiXinComm.WeiXinCRMComm();
            string accessToken = Token();
            string openId = "oFo2Hjq6_yMhyz6cQ2MZtmxODOVU";
            string contents = "Form:requestMessage.Content.ToString";
            string URL_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
            var data = new
            {
                touser = openId,
                msgtype = "text",
                text = new
                {
                    content = contents
                }
            };
            CommonJsonSend.Send(accessToken, URL_FORMAT, data, timeOut: 1000);
        }
        public void SendTextTest(string openId)

        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm cpp = new WeiXinCRMComm();
            string error = "";
            string accessToken = cpp.getAccessToken(weixin.id, out error);

            var result = CustomApi.SendText(accessToken, openId, "sdfdsdf");


          

        }


        
    }
}