<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List_this.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.Hugo_list.List_this" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>护工学院</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
   <script type="text/javascript" src="js/jquery.min.js"></script>
    <link href="../../../sui/css/sm.css?v=1.0" rel="stylesheet" />
    <link href="../../../sui/Fire/iconfont.css" rel="stylesheet" />
    
    <script src="../../../scripts/jquery.min.js"></script>
   

 <style>
     .top {
          position:relative;
     }
 </style>
</head>
<body onload="Pay_suc()">
    <form id="form1" runat="server">
    
          
           <header class="bar bar-nav">
   <h1 class="title"> <marquee  scrollamount=5 FONT style="COLOR:#808080; FILTER: shadow(color=FFFF33 );   FONT-SIZE:15px; WIDTH: 100%">订单详情</marquee></h1>
   
  </header>
           

  <div class="content">
      
     <div class="buttons-tab" >
    <a href="#tab1" class="tab-link active button" onclick="Pay_suc()">新订单</a>
    <a href="#tab2" class="tab-link button" onclick="all_suc()">已完成</a>
  
  </div>
  <div class="content-block">
    <div class="tabs">
      <div id="tab1" class="tab active">
     
        </div>
  
      <div id="tab2" class="tab">
      
         
       
     
        </div>
     
    
    </div>
  </div>
      </div>
         
        
    </form>
   <script>
       function remove_sub() {
         
           $('.content .content-block .tabs #tab1 div').remove();

       };
       function remove_su() {

           $('.content .content-block .tabs #tab2 div').remove();

       };
       function Pay_suc() {
           remove_sub();
           Zepto.ajax(
 {

     url: "list_l.ashx",
     data: { action: "Suc_pay", Hg_number: '<%=HG_number%>' },
     contentType: "application/json; charset=utf-8",
     dataType: "json",
     async: true,
     cache: false,
     success: function (msg) {
         var html = "";
         if (msg.count == null) {
             alert("你暂时没有新订单");
         }
         else {
             for (var i = 0; i < msg.count; i++) {
                 html += '<div class="list-block media-list "  style="margin-bottom:-1rem;">'
      + ' <ul>'

       + '<li>'
         + '   <a href="HG_order.aspx?orderdd=' + msg.ds[i].Order_dd + '" class="item-link item-content"  style="margin-bottom:-1rem">'
           + '   <div class="item-media"><img src="../images/Logo.png" style="width:4rem;"></div>'
           + '   <div class="item-inner">'
             + '   <div class="item-title-row">'
             + '     <div class="item-title">' + msg.ds[i].Nursing_name + '</div>'
            + '      <div class="item-after">￥' + msg.ds[i].Total + '</div>'
            + '    </div>'
             + '   <div class="item-subtitle">' + msg.ds[i].By_sex + '</div>'
            + '    <div class="item-text">' + msg.ds[i].By_adress + '</div>'
           + '   </div>'
          + '  </a>'
      + '    </li>'
     + '   </ul>'
     + ' </div>'
             }
             $('.content .content-block .tabs #tab1').append(html);
         }


     }
 });
       };
       function all_suc() {
           remove_su();
           Zepto.ajax(
 {

     url: "list_l.ashx",
     data: { action: "all_suc", Hg_number: '<%=HG_number%>' },
     contentType: "application/json; charset=utf-8",
     dataType: "json",
     async: true,
     cache: false,
     success: function (msg) {
         var html = "";
         if (msg.count == null) {
             alert("你暂时没有订单");
         }
         else {
             for (var i = 0; i < msg.count; i++) {
                 html += '<div class="list-block media-list "  style="margin-bottom:-1rem;">'
      + ' <ul>'

       + '<li>'
         + '   <a href="HG_order_ok.aspx?orderdd=' + msg.ds[i].Order_dd + '" class="item-link item-content"  style="margin-bottom:-1rem">'
           + '   <div class="item-media"><img src="../images/Logo.png" style="width:4rem;"></div>'
           + '   <div class="item-inner">'
             + '   <div class="item-title-row">'
             + '     <div class="item-title">' + msg.ds[i].Nursing_name + '</div>'
            + '      <div class="item-after">' + msg.ds[i].Status_order + '</div>'
            + '    </div>'
             + '   <div class="item-subtitle">' + msg.ds[i].By_sex + '</div>'
            + '    <div class="item-text">' + msg.ds[i].By_adress + '</div>'
           + '   </div>'
          + '  </a>'
      + '    </li>'
     + '   </ul>'
     + ' </div>'
             }
             $('.content .content-block .tabs #tab2').append(html);
         }


     }
 });
       };
    </script>
      <script type='text/javascript'  src="../../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../../sui/js/sm.min.js" charset='utf-8'></script>
</body>
</html>

