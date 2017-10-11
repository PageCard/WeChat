<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hg_pay.aspx.cs" Inherits="XCWeiXin.Web.api.payment.Hg_pay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微支付</title>
    <meta http-equiv="Content-type" content="text/html; charset=utf-8">
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
   <%-- <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js" type="text/javascript"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js" type="text/javascript"></script>--%>
    <script src="Payjs/WX_jquery.js"></script>
    <script src="Payjs/WX_v3.js"></script>
    <script src="Payjs/Jweixin.js"></script>
  
  <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
    
  <%--  <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>--%>
    <script src="../../sui/js/zepto.js"></script>
    <script src="../../sui/js/sm.min.js"></script>

</head>
<body>
      <div class="page-group">
        <!-- 单个page ,第一个.page默认被展示-->
        <div class="page">
            <!-- 标题栏 -->
          

          
            <!-- 这里是页面内容区 -->
            <div class="content">
             <div style="height:150px;text-align:center ;margin:50px auto">
           <span style="margin-top:30px" ><%=oreder_name%></span>
                 <br />
          <strong style="font-size:60px">￥<%=litMoney%></strong>
                 </div> 
                <div style="text-align:center; border-top:1px solid #E0E0E0;border-bottom:1px solid #E0E0E0;margin-top:-50px">
               <table  style="width:80%;text-align:center;font-size:15px;margin-top:10px;margin-bottom:10px">
                   <tr>
                       <td>收款方：</td>
                       <td>护工来了</td>
                   </tr>
                    <tr>
                       <td>支付方式：</td>
                       <td>微信支付</td>
                   </tr>
                   <tr>
                       <td>支付时间：</td>
                       <td><%=litDate%></td>
                   </tr>
               </table>
                    </div>
                <br />
                <br />
       <p> <a href="javascript:void(0);" class="btn button button-fill button-big button-success " style="width:80%; background-color:green;margin:20px auto" id="getBrandWCPayRequest">确认支付</a> </p>
          <div style="color:#a19d9d;font-size:12px;text-align:center;margin-top:110px;">技术支持：@Page_Load</div>
                  </div>
        </div>

      
    </div>

   

    <!-- 默认必须要执行$.init(),实际业务里一般不会在HTML文档里执行，通常是在业务页面代码的最后执行 -->
    <script>$.init()</script>
      <script>
          // 当微信内置浏览器完成内部初始化后会触发WeixinJSBridgeReady事件。
          document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
              //公众号支付
              jQuery('a#getBrandWCPayRequest').click(function (e) {

                  WeixinJSBridge.invoke('getBrandWCPayRequest', {
                      "appId": "wx172ece37e2ed2939", //公众号名称，由商户传入
                      "timeStamp": "<%=paytimeStamp%>", //时间戳
                      "nonceStr": "<%=paynonceStr%>", //随机串
                      "package": "<%=paypackageValue%>",//扩展包
                      "signType": "MD5", //微信签名方式:MD5
                      "paySign": "<%=paypaySign%>" //微信签名
                  }, function (res) {
                     
                      if (res.err_msg == "get_brand_wcpay_request:ok") { 
                        alert("支付成功");
                        location.href = "../../hugongll/order.aspx?order=<%=order_dd%>&Fail=suc";     
                      }
                      else {
                         
                       
                        alert("你取消了支付");
                        location.href = "../../hugongll/order.aspx?order=<%=order_dd%>&Fail=fail";
                      
                          
                      }
                    // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                    //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
                });

              });

              WeixinJSBridge.log('yo~ ready.');

          }, false);


      </script>
   

</body>

</html>

