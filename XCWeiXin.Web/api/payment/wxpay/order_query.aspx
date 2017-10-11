<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_query.aspx.cs" Inherits="XCWeiXin.Web.api.payment.wxpay.order_query" %>
<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>{$category.title}</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta charset="utf-8">
    <script src="/sui/js/zepto.js"></script>
    <link href="/templatesstore/css/listhome1_.css" rel="stylesheet" type="text/css" />

    <script src="/scripts/jquery/jquery.query.js" type="text/javascript"></script>


    <link href="/sui/css/sm.css" rel="stylesheet">
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <div class="content">
                <div class="content-block-title">订单详情</div>
                <div class="card">
                    <div class="card-content">
                        <div class="card-content-inner">
                        
                        <p>交易状态:<%=result_code %></p>
                        <p>支付方式<%=bank_type %></p>
                        <p>总金额:<%=total_fee%></p>
                        <p>微信支付订单号:<%=transaction_id %></p>
                        <p>商家订单号:<%=out_trade_no %></p>
                        <p>付款时间:<%=time_end %></p>

                        
                        </div>
                    </div>
                </div>
              
             
              

            </div>
        </div>
    </div>



</body>
</html>
