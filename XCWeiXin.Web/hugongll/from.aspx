<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="from.aspx.cs" Inherits="XCWeiXin.Web.hugongll.from" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no, minimal-ui">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <title>用户下单</title>
      
      <link href="dist/css/framework7.ios.css" rel="stylesheet" />
      <link href="dist/css/framework7.ios.colors.css" rel="stylesheet" />
      <link href="dist/css/my-app.css" rel="stylesheet" />
      <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=MfWzTIuMQ3R4bFGNFtRbD1h9MRI4ZHbz"></script>
   
     <link href="文字图库/font_z76q39lgak2zkt9/iconfont.css" rel="stylesheet" />
     <style>
         .font {
        font-size:0.8rem;
         }
       
</style>


    
      
    <!-- Path to your custom app styles-->
    <%--<link rel="stylesheet" href="dist/css/my-app.css">--%>
  </head>
  <body>
     
      <div style="display:none;" id="allmap"></div>
    <!-- Status bar overlay for fullscreen mode-->
   
    <!-- Panels overlay-->
  
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
            <div class="center " style=" font-weight:100">用户下单</div>
            <div class="right"><a href="#" class="link create-links "><i class="axiba icon-fenlei"></i></a></div>
          </div>
        </div>

        <!-- Pages, because we need fixed-through navbar and toolbar, it has additional appropriate classes-->
        <div class="pages navbar-through toolbar-through">
            <form id="form"  runat="server">
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
                
 <div class="content-block-title">信息资料</div>
<div class="list-block inset">
  <ul>
    <!-- Text inputs -->
    <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-wode"></i></div>
        <div class="item-inner">
          <div class="item-input">
            <input type="text" style="font-size:1rem" id="name" name="name" placeholder="请输入雇主姓名">
          </div>
        </div>
      </div>
    </li>
    <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-lianxidianhua"></i></div>
        <div class="item-inner">
          <div class="item-input">
            <input type="tel" style="font-size:1rem" id="tel" name="tel" placeholder="请输入雇主电话">
          </div>
        </div>
      </div>
    </li>

        <!-- Select -->
    <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-xingbie"></i></div>
        <div class="item-inner">
          <div class="item-input ">
            <select runat="server" id="sex_">
              <option>男</option>
              <option>女</option>
            </select>
          </div>
        </div>
      </div>
    </li>
  

  </ul>
   
   
 
</div> 
                 <div class="content-block-title">服务选项</div>
    <!-- Inset content block -->
   <div class="list-block inset">
  <ul>
    <!-- Text inputs -->
    <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-battery1002"></i></div>
        <div class="item-inner">
          <div class="item-input">
           <input type="text" id="pick_many" onclick="jiesuan()" name="pick_many" style="font-size:1rem" placeholder="请选择金额">
          </div>
        </div>
      </div>
    </li>
    <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-fuwushiduan"></i></div>
        <div class="item-inner">
          <div class="item-input">
           <input type="text" style="font-size:1rem" placeholder="服务类型" value="<%=type_ %>" readonly  >
          </div>
        </div>
      </div>
    </li>
       <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-bell2"></i></div>
        <div class="item-inner">
          <div class="item-input">
           <input type="date" id="time" name="time_"    >
          </div>
        </div>
      </div>
    </li>
       <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-battery80"></i></div>
        <div class="item-inner">
          <div class="item-input">
          <input type="text" id="pick_day" onclick="jiesuan()" name="pick_day" style="font-size:1rem" placeholder="请选择服务天数">
          </div>
        </div>
      </div>
    </li>
       <li>
      <div class="item-content">
        <div class="item-media"><i class="axiba icon-weizhi"></i></div>
        <div class="item-inner">
          <div class="item-input">
          <input type="text" style="font-size:1rem" id="adress" name="adress" placeholder="请输入服务地址(详细至门牌)" >
          </div>
        </div>
      </div>
    </li>

        <!-- Select -->
   

  </ul>
   
   
 
</div> 
                

</div>
                  
              
                <!--栅格结束-->
    </div>

               
  
        </div>
                      
           <!--工具栏-->
  <div class="toolbar">
        
       
      
     <div class="row no-gutter">
         <div class="col-33"><asp:HiddenField  ID="hid"  runat="server"/><asp:Label ID="lb1" CssClass="button button-big button-fill color-pink" runat="server" Text="总计:"></asp:Label></div>
         <div class="col-66"><asp:Button  ID="pay" runat="server" CssClass="button button-big button-fill" OnClick="pay_Click" Text="一键支付"/></div>

     </div>
      
   
        </div>
    
   
       </form> 
   

          
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
          function jiesuan() {
              var day = document.getElementById("pick_day").value;
              var pick_many = document.getElementById("pick_many").value;
              var a = day.replace(/[^0-9]/ig, "");
              var b = pick_many.replace(/[^0-9]/ig, "");
              var bb = document.getElementById("lb1");
              bb.innerText = "总计:" + (a * b) + "￥";
              var cc = document.getElementById("hid");
              cc.value = a * b;




          };
          // 1 Slide Per View, 50px Between
          var mySwiper1 = myApp.swiper('.swiper-1', {
              pagination: '.swiper-1 .swiper-pagination',
              spaceBetween: 50,
              autoplay: 2000
          });
          $$('#range').on('change', function () {
              var num = document.getElementById("range");
              var day = document.getElementById("day");
              day.innerText = num.value;
          }
                   );
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

       $$('#btn').on('click', function () {
           myApp.showPreloader('加载中')
           setTimeout(function () {
               myApp.hidePreloader();
           }, 2000);
           window.location = "index.aspx";
       });
       var pickerDevice = myApp.picker({
           input: '#pick_many',
           rotateEffect: true,
           toolbarTemplate:
               '<div class="toolbar">' +
                   '<div class="toolbar-inner">' +
                       '<div class="left">' +
                           '<a href="#" class="link toolbar-randomize-link">请选择服务标准</a>' +
                       '</div>' +
                       '<div class="right">' +
                           '<a href="#" class="link close-picker" onclick="jiesuan()">完成</a>' +
                       '</div>' +
                   '</div>' +
               '</div>',
           cols: [
               {
                   textAlign: 'center',
                   values: ['180元/天', '190元/天', '200元/天', '220元/天']
               }
           ]
       });

       var pickerDevice = myApp.picker({
           input: '#pick_day',
           rotateEffect: true,
           toolbarTemplate:
               '<div class="toolbar">' +
                   '<div class="toolbar-inner">' +
                       '<div class="left">' +
                           '<a href="#" class="link toolbar-randomize-link">请选择服务天数</a>' +
                       '</div>' +
                       '<div class="right">' +
                           '<a href="#" class="link close-picker" onclick="jiesuan()">完成</a>' +
                       '</div>' +
                   '</div>' +
               '</div>',
           cols: [
               {
                   textAlign: 'center',
                   values: ['1天', '2天', '3天', '4天', '5天', '6天', '7天', '8天', '9天', '10天', '11天', '12天', '13天', '14天', '15天', '16天', '17天', '18天', '19天', '20天', '21天', '22天', '23天', '24天', '25天', '26天', '27天', '28天', '29天', '30天', '如需包月，请来点电话预约']
               }
           ]
       });
   </script>
       
   
  </body>
    
</html>