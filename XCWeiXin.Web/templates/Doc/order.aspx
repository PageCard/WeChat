<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.order" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>订单管理</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
  
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="shortcut icon" href="/favicon.ico">
   
     <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
    <link href="../../sui/new%20font/iconfont.css" rel="stylesheet" />
    <link href="../../sui/add/iconfont.css" rel="stylesheet" />
    <script src="../../scripts/jquery.min.js"></script>
     <link href="../../sui/new%20font/iconfont.css" rel="stylesheet" />
    <link href="../../sui/add/iconfont.css" rel="stylesheet" />

   
      <!--F7库-->
    <link href="css/F7/framework7.ios.min.css" rel="stylesheet" />
    <link href="css/F7/framework7.material.colors.min.css" rel="stylesheet" />
    <link href="css/F7/my-app.css" rel="stylesheet" />
    <!--结束-->
   
    
  

  <style>
      bady {
          font-size:12px;
          color:#CEC9C9;
      }
   
  
        .bar .icon {
      
         
          color:#0894EC;
        
      }
      .bar .tab-label {
      color:Background;    }
      .page a:hover {
          color:#0894EC;
    
      }
      .fontds {
          color:black;
          font-size:13px;
          font-weight:normal;
            color:#7E807F;

      }
        .fontd {
          color:black;
          font-size:12px;
          font-weight:normal;
          text-align:left;
       
      }


      .bgtp {
      background-color:#EFEFF4; margin-top:0.1rem; padding-bottom:0.1rem;
      }
       .bgt {
      background-color:#EFEFF4;  padding-bottom:0.1rem;
      }

      .spancolor {
          color:blue;
        
      }
      .page .buttons-tab  a:link {
           color:black;
          
    
      }
     
  </style> 
      <%-- <script>
         
          $(document).on('click', '.confirm-title-ok-cancel', function () {
              Zepto.confirm('确定删除订单?', '订单删除',
                function () {
                    
                    var bb = $(".confirm-title-ok-cancel").attr("cid");
                    var cc = $(this).attr("ord");
                    Zepto.alert(cc);
                  
                },
                function () {
                    Zepto.alert('取消成功');
                }
              )
          });
          
    </script>--%>
   <script>
       function oo(data)
       {
           var bb = $(".confirm-title-ok-cancel"+data+"").attr("cid");
         
           Zepto.confirm('确定删除?', function () {
               Zepto.ajax({
                   url: "HG_list.ashx",
                   data: { orderid: bb, action: "delete_order" },
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   async: false,
                   cache: false,
                   success: function (msg) {
                       if (msg.errCode == "false")
                       {
                           Zepto.alert('删除成功');
                           No_reder();
                           End_order();
                       }
                   }
               }
                   )
              
           });
        
       }
   </script>
   
   <script>
   
       function removedd()
       {
           $('.page .page-content .content-block #tab1 .mlgb li').remove();
       };
       function removedd1() {
           $('.page .page-content .content-block .mlgb1 li').remove();
       };
       function removedd2() {
           $('.page .page-content .content-block .mlgb2 li').remove();
       };
          
         function No_reder() {
             var where = "((wid=44) and (Status_order='未完成') or (Status_order='进行中') or(Status_order='已支付'))";
             removedd();
             Zepto.ajax(
       {

       url: "HG_list.ashx",
       data: {  where: where,open_idss:'<%=open_id%>', action: "no_order" },
       contentType: "application/json; charset=utf-8",
       dataType: "json",
       async: false,
       cache: false,
       success: function (msg) {
           var html = "";
          
           if (msg.count ==null)
           {
               html = '<li style="text-align:center">暂无订单</li>';
           }
           else
               {
           for (var i = 0; i < msg.count; i++) {
               
               html += '<li class="swipeout" style="width:100%"><div class="swipeout-content "> <div class="card"><div class="card-header card_' + i + '" style="font-size:12px;">订单：' + msg.ds[i].Order_dd + '<div style="float:right">' + msg.ds[i].Status_order + '</div> </div><div class="card-content">  <div class="card-content-inner" ><table width="100%" ><tr style="font-size:13px;"> <th >护理人:' + msg.ds[i].Hg_name + '</th> <th >被护理人:' + msg.ds[i].By_name + ' </th> <th >价格:' + msg.ds[i].Total + '￥</th> </tr></table></div></div> <div class="card-footer" style="font-size:12px;">护理时间:' + msg.ds[i].Service_time + ' &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp 天数:' + msg.ds[i].Service_day + '天</div></div></div><div class="swipeout-actions-right">  <!-- Add this button and item will be deleted automatically -->  <a href="#" class="swipeout-context confirm-title-ok-cancel' + i + '"  style=" background-color:red;"  cid= ' + msg.ds[i].Oreder_id + '  ord=' + msg.ds[i].Order_dd + ' onclick="oo(' + i + ')" >删除</a> </div></li>';


           }
           }

           $('.page .page-content .content-block #tab1 .mlgb ').append(html);



       },
       error: function (x, e) {
           alert("Error" + x.responseText);
       }
   }
                  )
         };
       function End_order() {
           var where = "wid=44 and Status_order='已完成' ";
           removedd1();
           Zepto.ajax(
     {

       url: "HG_list.ashx",
       data: { where: where, open_idss: '<%=open_id%>', action: "no_order" },
       contentType: "application/json; charset=utf-8",
       dataType: "json",
       async: false,
       cache: false,
       success: function (msg) {
           var html = "";

           if (msg.count == null) {
               html = '<li style="text-align:center">暂无订单</li>';
           }
           else {
               for (var i = 0; i < msg.count; i++) {

                   html += '<li class="swipeout" style="width:100%"><div class="swipeout-content "> <div class="card"><div class="card-header card_' + i + '" style="font-size:12px;">订单：' + msg.ds[i].Order_dd + '<div style="float:right">' + msg.ds[i].Status_order + '</div> </div><div class="card-content">  <div class="card-content-inner" ><table width="100%" ><tr style="font-size:13px;"> <th >护理人:' + msg.ds[i].Hg_name + '</th> <th >被护理人:' + msg.ds[i].By_name + ' </th> <th >价格:' + msg.ds[i].Total + '￥</th> </tr></table></div></div> <div class="card-footer" style="font-size:12px;">护理时间:' + msg.ds[i].Service_time + ' &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp 天数:' + msg.ds[i].Service_day + '天</div></div></div><div class="swipeout-actions-right">  <!-- Add this button and item will be deleted automatically -->  <a href="#" class="swipeout-context confirm-title-ok-cancel' + i + '"  style=" background-color:red;"  cid= ' + msg.ds[i].Oreder_id + '  ord=' + msg.ds[i].Order_dd + ' onclick="oo(' + i + ')" >删除</a> </div></li>';

               }
               } 

           $('.page .page-content .content-block #tab2 .mlgb1 ').append(html);



       },
       error: function (x, e) {
           alert("Error" + x.responseText);
       }
       }
                  )
       };
       function atr_order() {
           var where = "wid=44 and Status_order='待评价' ";
           removedd2();
           Zepto.ajax(
     {

         url: "HG_list.ashx",
         data: { where: where, open_idss: '<%=open_id%>', action: "no_order" },
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         async: false,
         cache: false,
         success: function (msg) {
             var html = "";

             if (msg.count == null) {
                 html = '<li style="text-align:center">暂无订单</li>';
             }
             else {
                 for (var i = 0; i < msg.count; i++) {

                     html += '<a href="start.aspx?order_dd=' + msg.ds[i].Order_dd + '"><li class="swipeout" style="width:100%"><div class="swipeout-content "> <div class="card"><div class="card-header card_' + i + '" style="font-size:12px;">订单：' + msg.ds[i].Order_dd + '<div style="float:right">' + msg.ds[i].Status_order + '</div> </div><div class="card-content">  <div class="card-content-inner" ><table width="100%" ><tr style="font-size:13px;"> <th >护理人:' + msg.ds[i].Hg_name + '</th> <th >被护理人:' + msg.ds[i].By_name + ' </th> <th >价格:' + msg.ds[i].Total + '￥</th> </tr></table></div></div> <div class="card-footer" style="font-size:12px;">护理时间:' + msg.ds[i].Service_time + ' &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp 天数:' + msg.ds[i].Service_day + '天</div></div></div><div class="swipeout-actions-right">  <!-- Add this button and item will be deleted automatically -->  <a href="#" class="swipeout-context confirm-title-ok-cancel' + i + '"  style=" background-color:red;"  cid= ' + msg.ds[i].Oreder_id + '  ord=' + msg.ds[i].Order_dd + ' onclick="oo(' + i + ')" >删除</a> </div></li></a>';

                 }
             }

             $('.page .page-content .content-block #tab3 .mlgb2 ').append(html);



         },
         error: function (x, e) {
             alert("Error" + x.responseText);
         }
     }
                  )
 };



      
         

   </script>
 
</head>
    
<body onload="No_reder()">
  <form runat="server">
 
       
           <header class="bar bar-nav">
   
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>订单管理</h1>
  </header>
  
  
    
  
       
   
           <div data-page="index" class="page">

            <!-- Scrollable page content -->
            <div class="page-content">
                 <div class="buttons-tab" >
    <a href="#tab1"  class="tab-link active button" onclick="No_reder()">未完成</a>
    <a href="#tab2" class="tab-link button" onclick="End_order()">已完成</a>
    <a href="#tab3" class="tab-link button" onclick="atr_order()">待评价</a>
  </div>
  <div class="content-block">
    <div class="tabs">
      <div id="tab1" class="tab active no_order">
      
         <div class="list-block">
  <ul class="mlgb">
 
 

  </ul>
</div>
     
      </div>
      <div id="tab2" class="tab">
          <div class="list-block">
  <ul class="mlgb1">
 
 

  </ul>
</div>
      </div>
      <div id="tab3" class="tab">
        <div class="list-block">
  <ul class="mlgb2">
</ul>
         
        </div>
      </div>
    </div>
  </div>
 
 </div>
                
          <div class="toolbar-inner ">
            <!-- Toolbar links -->
         <div class="bar bar-tab">
   <a class="tab-item open-indicator" href="index.aspx">
      <span class="icon icon-shouye"></span>
      <span class="tab-label">首页</span>    </a>
    <a class="tab-item open-indicator" href="Hugo_list/Login.aspx">
      <span class="icon icon-hugong2"></span>
        <span class="tab-label">护工学院</span>
      
</a>
    <a class="tab-item open-indicator" href="order.aspx">
      <span class="icon icon-chanpinguanli"></span>
      <span class="tab-label">订单</span> 
        
    </a>
    <a class="tab-item open-indicator" href="Mycont.aspx">
      <span class="icon  icon-wode"></span>
      <span class="tab-label">我的</span>    </a>  </div>
          </div>
        </div>
               
        
      </form>
  
   
        <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
  
  
    <script src="js/F7/framework7.js"></script>
    <script src="js/F7/my-app.js"></script>
    </body>

</html>

