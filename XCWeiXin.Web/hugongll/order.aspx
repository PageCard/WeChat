<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="XCWeiXin.Web.hugongll.order" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no, minimal-ui">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <title>护理记录</title>
       <link href="dist/css/my-app.css" rel="stylesheet" /> 
    <!-- Path to Framework7 Library CSS-->
    <link href="dist/css/framework7.ios.min.css" rel="stylesheet" />
    <link href="dist/css/framework7.ios.colors.min.css" rel="stylesheet" />
    <link href="dist/css/toast.css" rel="stylesheet" />
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=MfWzTIuMQ3R4bFGNFtRbD1h9MRI4ZHbz"></script>
      <link href="文字图库/font_z76q39lgak2zkt9/iconfont.css" rel="stylesheet" />
    <!-- Path to your custom app styles-->
    <%--<link rel="stylesheet" href="dist/css/my-app.css">--%>
  </head>
  <body onload="bb_order()">
      <div style="display:none;" id="allmap"></div>
    <!-- Status bar overlay for fullscreen mode-->
    <div class="statusbar-overlay"></div>
    <!-- Panels overlay-->
    <div class="panel-overlay"></div>
    <!-- Left panel with reveal effect-->
    <div class="panel panel-left panel-reveal">
      <div class="content-block">
        <p>Left panel content goes here</p>
      </div>
    </div>
    <!-- Right panel with cover effect-->
 <%--   <div class="panel panel-right panel-cover">
      <div class="content-block">
        <p>Right panel content goes here</p>
      </div>
    </div>--%>
    <!-- Views-->
    <div class="views">
      <!-- Your main view, should have "view-main" class-->
      <div class="view view-main toolbar-through">
        <!-- Top Navbar-->
        <div class="navbar">
          <div class="navbar-inner">
            <!-- We have home navbar without left link-->
            <div class="center " style=" font-weight:100">护理记录</div>
             <div class="right"><a href="#" class="link create-links "><i class="axiba icon-fenlei"></i></a></div>
          </div>
        </div>

        <!-- Pages, because we need fixed-through navbar and toolbar, it has additional appropriate classes-->
        <div class="pages navbar-through toolbar-through">
          <!-- Page, data-page contains page name-->
          <div data-page="index" class="page">
                <!-- Speed Dial Wrap -->
  <div class="speed-dial">
    <!-- FAB inside will open Speed Dial actions -->
    <a href="#" class="floating-button">
      <!-- First icon is visible when Speed Dial actions are closed -->
      <i class="axiba  icon-tianjia"></i>
      <!-- Second icon is visible when Speed Dial actions are opened -->
      <i class="axiba icon-shuaxin"></i>
    </a>
    <!-- Speed Dial Actions -->
    <div class="speed-dial-buttons">
      <!-- First Speed Dial button -->
     <a href="http://www.hugongll.com/templates/Doc/ider.aspx"  class="external ">
        <i class="axiba icon-youxiang18"></i>
           
      </a>
      <!-- Second Speed Dial  button -->
      <a href="https://ikefu.baidu.com/wise/hugongll" class="external ">
        <i class="axiba icon-icongj"></i>
      </a>
      <!-- Third Speed Dial  button -->
     
          <a href="tel:09314619604" class="external ">
        <i class="axiba icon-dianhua"></i>
      </a>
    </div>
  </div>
  <!-- End of Speed Dial -->
            <!-- Scrollable page content-->
            <div class="page-content">
                
    <!-- On both sides -->
  <div class="list-block">
  <ul>
     
  </ul>
</div>
</div>
              
                <!--栅格结束-->
    </div>
               
  
        </div>
                      
           <!--工具栏-->
 <div class="toolbar tabbar tabbar-labels">
    <div class="toolbar-inner">
        <a href="index.aspx" class="tab-link external  ">
            <i class="axiba icon-tubiao11"></i>
            <span class="tabbar-label">首页</span>
        </a>
        <a href="order.aspx" class="tab-link external active ">
            <i class="axiba icon-dingdan4">
              
            </i>
            <span class="tabbar-label">订单</span>
        </a>
        <a href="Hugong.aspx" class="tab-link external ">
            <i class="axiba icon-shuoming"></i>
            <span class="tabbar-label">护工学院</span>
        </a>
        <a href="account.aspx" class="tab-link external ">
            <i class="axiba icon-gerenzhongxin"></i>
            <span class="tabbar-label">个人中心</span>
        </a>
    </div>
</div>
          <!--工具栏end-->      
              </div>
         
        
            </div>
         
      
 
    
    <!-- Path to Framework7 Library JS-->

     <script src="dist/js/framework7.js"></script>
      <script src="dist/js/my-app.js"></script>
      <script src="../templates/Doc/js/jquery.js"></script>
      <script>

          $$('.create-links').on('click', function () {
              var clickedLink = this;
              var popoverHTML = '<div class="popover" style="width:100px">' +
                                  '<div class="popover-inner">' +
                                    '<div class="list-block">' +
                                      '<ul>' +
                                         '<li><a href="https://ikefu.baidu.com/wise/hugongll" class="item-link list-button external">客服咨询</li>' +
                                    '<li><a href="tel:09314619604" class="item-link list-button external">电话预约</li>' +
                                      '</ul>' +
                                    '</div>' +
                                  '</div>' +
                                '</div>'
              myApp.popover(popoverHTML, clickedLink);
          });
      </script>
      <script>
          function oo(data)
          {
              var bb = $(".confirm-title-ok" + data + "").attr("cid");
              $$('.confirm-title-ok' + data + '').on('click', function () {
                  myApp.confirm('确实删除?', '小护提醒', function () {
                      $.ajax({
                          url: "order.ashx",
                          data: { order_dd: bb, action: 'delete_order' },
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          async: false,
                          cache: false,
                          success: function (msg) {
                              if (msg.errCode == "false") {
                                  myApp.alert('删除成功','小护提醒');
                                  location.reload();
                              }
                          },
                          error: function (x, e) {
                              alert("Error" + x.responseText);
                          }
                      }
                      )
                  });
              });
            
                 
              };
             


             


        
          function bb_order() {
              var where = "(Delet_='未删除')";
              $.ajax(
                  {
                  url: "order.ashx",
                  data: {  where: where,openid:'<%=openid%>',action:'order' },
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: false,
                  cache: false,
                  success: function (msg)
                  {
                      var html = "";
                      if (msg.count == null) {
                          html = '<li style="text-align:center">暂无订单</li>';
                      }
                      else {
                          for(var i=0;i<msg.count;i++)
                              html += ' <li class="swipeout"> <div class="swipeout-content"><div class="card"> <div class="card-header row"><div class="col-75" style="font-size:0.8rem">' + msg.ds[i].type_ + '</div><div class="col-25">' + msg.ds[i].Fw_zt + '</div></div><div class="card-content"><div class="card-content-inner">订单号：' + msg.ds[i].order_dd + '</div><div class="card-content-inner">地址：' + msg.ds[i].adress + '</div></div><div class="card-footer row"><div class="col-70">金额:' + msg.ds[i].total + '元</div><div class="col-30">' + msg.ds[i].time_ + '</div></div> </div></div> <div class="swipeout-actions-right"><a href="#" class=" bg-green confirm-title-ok' + i + '" cid=' + msg.ds[i].order_dd + '   onclick="oo(' + i + ')" >删除</a> </div> </li>';

                      }
                      $('.page-content .list-block ul').append(html);
                       
                  },
                  error: function (x, e) {
                      alert("Error" + x.responseText);
                  }
                   
                  }
                  )
          }
      </script>
      <script>



          // 1 Slide Per View, 50px Between
          var mySwiper1 = myApp.swiper('.swiper-1', {
              pagination: '.swiper-1 .swiper-pagination',
              spaceBetween: 50,
              autoplay: 2000
          });



      </script>
  <script type="text/javascript">
      // 百度地图API功能
      var map = new BMap.Map("allmap");
      var point = new BMap.Point(116.331398, 39.897445);
      map.centerAndZoom(point, 12);

      var geolocation = new BMap.Geolocation();
      geolocation.getCurrentPosition(function (r) {
          if (this.getStatus() == BMAP_STATUS_SUCCESS) {
              var mk = new BMap.Marker(r.point);
              map.addOverlay(mk);
              map.panTo(r.point);
              var point1 = new BMap.Point(r.point.lng, r.point.lat);

              var gc = new BMap.Geocoder();
              gc.getLocation(point1, function (rs) {
                  var addComp = rs.addressComponents;
                  //alert(addComp.province + ", " + addComp.city + ", " + addComp.district + ", " + addComp.street + ", " + addComp.streetNumber);省市区街道，门牌号
                  if (addComp.city != "兰州市") {
                      myApp.alert('当前城市：' + addComp.city + '未开通此服务', '温馨提醒');

                  }
              });

          }
          else {
              alert('failed' + this.getStatus());
          }
      }, { enableHighAccuracy: true })
      //关于状态码
      //BMAP_STATUS_SUCCESS	检索成功。对应数值“0”。
      //BMAP_STATUS_CITY_LIST	城市列表。对应数值“1”。
      //BMAP_STATUS_UNKNOWN_LOCATION	位置结果未知。对应数值“2”。
      //BMAP_STATUS_UNKNOWN_ROUTE	导航结果未知。对应数值“3”。
      //BMAP_STATUS_INVALID_KEY	非法密钥。对应数值“4”。
      //BMAP_STATUS_INVALID_REQUEST	非法请求。对应数值“5”。
      //BMAP_STATUS_PERMISSION_DENIED	没有权限。对应数值“6”。(自 1.1 新增)
      //BMAP_STATUS_SERVICE_UNAVAILABLE	服务不可用。对应数值“7”。(自 1.1 新增)
      //BMAP_STATUS_TIMEOUT	超时。对应数值“8”。(自 1.1 新增)
</script>
   <script>
       $$('#doc').on('click', function () {
           myApp.showPreloader('加载中')
           setTimeout(function () {
               myApp.hidePreloader();
           }, 2000);
           window.location = "type1.aspx?type=1";
       });
       $$('#btn').on('click', function () {
           myApp.showPreloader('加载中')
           setTimeout(function () {
               myApp.hidePreloader();
           }, 2000);
           window.location = "index.aspx";
       });
   </script>
       
    
  </body>
</html>