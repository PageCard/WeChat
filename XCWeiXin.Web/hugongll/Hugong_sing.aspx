<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hugong_sing.aspx.cs" Inherits="XCWeiXin.Web.hugongll.Hugong_sing" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no, minimal-ui">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <title>护工来了</title>
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
  <body>
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
               <div class="left"><a href="javascript:history.go(-1)" class="link "><i class="axiba icon-fanhui6"></i></a></div>
            <!-- We have home navbar without left link-->
            <div class="center " style=" font-weight:100">护工来了</div>
            <div class="right">
              <!-- Right link contains only icon - additional "icon-only" class--><a href="#" class="link icon-only open-panel"> <i class="icon icon-bars"></i></a>
            </div>
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
     
          <a href="tel:10010" class="external ">
        <i class="axiba icon-dianhua"></i>
      </a>
    </div>
  </div>
  <!-- End of Speed Dial -->
            <!-- Scrollable page content-->
            <div class="page-content">
                
          
  <div class="swiper-container swiper-1" >
    <div class="swiper-pagination"></div>
    <div class="swiper-wrapper" >
      <div class="swiper-slide" >
          <img  width="100%" height="130px" src="dist/img/banner1.png" /></div>
      <div class="swiper-slide">
          <img width="100%" height="130px" src="dist/img/qj.jpg" /></div>
    
      <div class="swiper-slide">
          <img width="100%" height="130px" src="dist/img/day3.png" /></div>
    </div>
  </div>
               
              <div class="card "">
     
      <div class="card-content">
          <div class="list-block media-list">
              <ul> 
                   <li class="item-content" > 
                       <div class="item-media">
                            <img  src="<%=head %>" width="44">

                       </div>
                       <div class="item-inner cardfont">
                            <div class="item-title-row row">
                                <div class="col-70 item-title" style="font-size:1rem"><%=name %>&nbsp<a href="#" style="color:#EAAD0F"><%=dengji %></a></div>
                                <div class="col-30 "><%=mony%>元/天</div>

                            </div><div class="item-subtitle">
                                <span><%=sex %></span>
                                <font>|</font>
                                <span><%=Hg_age%>岁</span>
                                <br />
                                <span class="cardfont">护工来了，服务至上</span>
                                  </div>

                       </div>
                      

                   </li>

              </ul>

          </div>

      </div>
      <div class="card-footer cardfont" > 
          <div class="col-40">服务范围:</div>
          <div class="col-60" style="padding-left:2rem"><a href="#" class="button button-primary  " ><%=Hg_st1 %></a></div>

      </div>

  </div>
      <div class="card">
    <div class="card-header">基本信息</div>
    <div class="card-content">
      <div class="card-content-inner">  <span>学历:<%=Hg_Degree %>&nbsp|&nbsp 民族:<%=nation %>&nbsp|&nbsp婚姻:<%=marry %></span><br />
            <span>个人能力:<%=Hg_Profile %></span><br />
      <span>身份证号:<%=Hg_IDcard %></span>
      </div>
    </div>
   
  </div>
        <form  runat="server" id="form1">       <!----> 
    <asp:hiddenfield runat="server" ID="hid"></asp:hiddenfield>
      <asp:hiddenfield runat="server" ID="hid2"></asp:hiddenfield>
         <asp:hiddenfield runat="server" ID="hid3"></asp:hiddenfield>
        <asp:hiddenfield runat="server" ID="hid4"></asp:hiddenfield>          
         </form>    
    </div>
               
  
        </div>
                      
           <!--工具栏-->
 <div class="toolbar tabbar tabbar-labels">
    <div class="toolbar-inner">
        <a href="index.aspx" class="tab-link external active">
            <i class="axiba icon-tubiao11"></i>
            <span class="tabbar-label">首页</span>
        </a>
        <a href="order.aspx" class="tab-link external">
            <i class="axiba icon-dingdan4">
              
            </i>
            <span class="tabbar-label">订单</span>
        </a>
        <a href="Hugong.aspx" class="tab-link external">
            <i class="axiba icon-shuoming"></i>
            <span class="tabbar-label">护工学院</span>
        </a>
        <a href="account.aspx" class="tab-link external">
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