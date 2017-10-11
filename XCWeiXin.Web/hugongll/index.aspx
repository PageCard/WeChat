<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XCWeiXin.Web.hugongll.index" %>

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
            <!-- We have home navbar without left link-->
            <div class="center " style=" font-weight:100">护工来了</div>
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
               
               <div id="map2"></div> 
                <!----> 
              <%--  <div class="row no-gutter" style="width:100%; height:100px;margin-top:0.5rem;" >
                 
    <!-- Each "cell" has col-[widht in percents] class -->
    <div class="col-50" id="boy" style="background-color:white;border-right:1px solid #EFEFF4" >
        <div  style="padding-left:2rem;padding-top:5px">
            <span style="color:#FE4165;font-size: 1.1rem;"><strong>医院专享</strong></span><strong><label style="border:0.1px solid blue;color:blue;font-size: 1.1rem;" >特价</label></strong><br /><span style="color:#9c9c9c;font-size: 0.939rem;">医院护理专项包</span>
          </div>
           <div  style="padding-left:40%">
               <img style="padding-bottom:5px;width:50%; height:40px"  src="云家政素材/index_icon_01.png" />
           </div>
              
           
    </div>
    <div   class="col-50" style="background-color:white">
          <div  style="padding-left:2rem;padding-top:5px">
            <span style="color:#FE4165;font-size: 1.1rem;"><strong>居家专享</strong></span><strong><label style="border:0.1px solid red;color:red;font-size: 1.1rem;" >最热</label></strong><br /><span style="color:#9c9c9c;font-size: 0.939rem;">医院护理专项包</span>
          </div>
           <div style="padding-left:40%">
               <img style="padding-bottom:5px;width:50%; height:40px"  src="云家政素材/index_icon_04.png" />
           </div>
        </div>

                </div>  --%>
                <div class="div_news " style="margin-top:0.5rem">
                    <a href="http://www.hugongll.com/list.aspx?wid=44&cid=191" class="external"><img  style="width:100%;height:80px;" src="云家政素材/new_qj.jpg" class="lazy" /></a></div>
                 <div  style="margin-top:0.8rem">
                  <div class="row no-gutter" style="border-bottom:1px solid  #EFEFF4">
        <div class="col-50 " id="doc" style="background-color:white;border-right:1px solid #EFEFF4">
          <div class="row ">
            <div class="col-33" style="padding-left:1rem;padding-top:1rem">
                <img style="width:3rem; height:3rem" src="dist/img/png/组-2@2x.png" /></div>
            <div class="col-66" style="padding-left:1.2rem;padding-top:0.2rem;margin :0.2rem auto; line-height:22px"> <span>医院护理</span><br /><span style="color:#9c9c9c;font-size: 0.739rem;" >专业护工</span><br /><span  style="color:red;font-size: 0.739rem;">不满意可退换</span></div>
          </div>
        </div>
         <div class="col-50 " style="background-color:white;border-right:1px solid #EFEFF4">
          <div class="row jujia ">
            <div class="col-33" style="padding-left:1rem;padding-top:1rem">
                <img style="width:3rem; height:3rem" src="dist/img/png/组-3@2x.png" /></div>
            <div class="col-66" style="padding-left:1.2rem;padding-top:0.2rem;margin :0.2rem auto; line-height:22px"> <span>居家周期护理</span><br /><span style="color:#9c9c9c;font-size: 0.739rem;">短期居家陪护</span><br /><span  style="color:red;font-size: 0.739rem;">不满意可退换</span></div>
          </div>
        </div>
      </div>
                       <div class="row no-gutter" style="border-bottom:1px solid  #EFEFF4">
        <div class="col-50 doc1 " id="doc1" style="background-color:white;border-right:1px solid #EFEFF4">
          <div class="row ">
            <div class="col-33" style="padding-left:1rem;padding-top:1rem">
                <img style="width:3rem; height:3rem" src="dist/img/png/service02.png" /></div>
            <div class="col-66" style="padding-left:1.2rem;padding-top:0.2rem;margin :0.2rem auto; line-height:22px"> <span>标准居家护理</span><br /><span style="color:#9c9c9c;font-size: 0.739rem;" >适合能自理</span><br /><span  style="color:red;font-size: 0.739rem;">4500元/月</span></div>
          </div>
        </div>
         <div class="col-50 type1 " style="background-color:white;border-right:1px solid #EFEFF4">
          <div class="row ">
            <div class="col-33" style="padding-left:1rem;padding-top:1rem">
                <img style="width:3rem; height:3rem" src="dist/img/png/service04.png" /></div>
            <div class="col-66" style="padding-left:1.2rem;padding-top:0.2rem;margin :0.2rem auto; line-height:22px"> <span>重症居家护理</span><br /><span style="color:#9c9c9c;font-size: 0.739rem;">适合不能自理</span><br /><span  style="color:red;font-size: 0.739rem;">5500元/月</span></div>
          </div>
        </div>
      </div>
                        <div class="row no-gutter" style="border-bottom:1px solid  #EFEFF4">
        <div class="col-50 yuesao " style="background-color:white;border-right:1px solid #EFEFF4">
          <div class="row ">
            <div class="col-33" style="padding-left:1rem;padding-top:1rem">
                <img style="width:3rem; height:3rem" src="dist/img/png/组-4@2x.png" /></div>
            <div class="col-66" style="padding-left:1.2rem;padding-top:0.2rem;margin :0.2rem auto; line-height:22px"> <span>月嫂服务</span><br /><span  style="color:#9c9c9c;font-size: 0.739rem;">专业月嫂</span><br /><span  style="color:red;font-size: 0.739rem;">不满意可退换</span></div>
          </div>
        </div>
           <div class="col-50 " style="background-color:white;border-right:1px solid #EFEFF4">
          <div class="row kang ">
            <div class="col-33" style="padding-left:1rem;padding-top:1rem">
                <img style="width:3rem; height:3rem" src="dist/img/png/组-5@2x.png" /></div>
            <div class="col-66" style="padding-left:1.2rem;padding-top:0.2rem;margin :0.2rem auto; line-height:22px"> <span>公益中心</span><br /><span style="color:#9c9c9c;font-size: 0.739rem;" >公益活动</span><br /><span  style="color:red;font-size: 0.739rem;">社会公益</span></div>
          </div>
        </div>
        </div>
      </div>  
                 
                 <div class="div_news " style="margin-top:0.5rem">
                    <img  style="width:100%;height:80px;" src="云家政素材/news.png" class="lazy" /></div>

</div>
              
                <!--栅格结束-->
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
      <script src="../sui/js/jquery.js"></script>
 <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script>
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: '<%=appid%>', // 必填，公众号的唯一标识
            timestamp: '<%=timestamp%>', // 必填，生成签名的时间戳
            nonceStr: '<%=nonceStr%>', // 必填，生成签名的随机串
            signature: '<%=signature%>',// 必填，签名
            jsApiList: [
                    'checkJsApi',
                    'onMenuShareTimeline',
                    'onMenuShareAppMessage',
                    'onMenuShareQQ',
                    'onMenuShareWeibo',
                    'hideMenuItems',
                    'showMenuItems',
                    'hideAllNonBaseMenuItem',
                    'showAllNonBaseMenuItem',
                    'translateVoice',
                    'startRecord',
                    'stopRecord',
                    'onRecordEnd',
                    'playVoice',
                    'pauseVoice',
                    'stopVoice',
                    'uploadVoice',
                    'downloadVoice',
                    'chooseImage',
                    'previewImage',
                    'uploadImage',
                    'downloadImage',
                    'getNetworkType',
                    'openLocation',
                    'getLocation',
                    'hideOptionMenu',
                    'showOptionMenu',
                    'closeWindow',
                    'scanQRCode',
                    'chooseWXPay',
                    'openProductSpecificView',
                    'addCard',
                    'chooseCard',
                    'openCard'
            ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2。详见：http://mp.weixin.qq.com/wiki/7/aaa137b55fb2e0456bf8dd9148dd613f.html
        });

        wx.error(function (res) {
            alert('<%=appid%>' + '签名' + '<%=signature%>');
            console.log(res);
            alert('验证失败');
        });

        wx.ready(function () {
          
            var url = 'http://www.hugongll.com';
            var link = url + '<%=Request.Url.PathAndQuery%>';
            var imgUrl = 'http://www.hugongll.com/hugongll/dist/img/png/service01.png';

            //转发到朋友圈
            wx.onMenuShareTimeline({
                title: '护工来了',
                link: link,
                imgUrl: imgUrl,
                desc: '护工来了,在线预约护工，专业陪护',
                success: function () {
                    alert('感谢亲的分享！');
                },
                cancel: function () {
                    alert('手抖！取消了。。');
                }
            });
            //转发给朋友
            wx.onMenuShareAppMessage({
                title: '护工来了',
                desc: '我分享护工来了,在线预约护工，专业陪护',
                link: link,
                imgUrl: imgUrl,
                type: 'link',
                dataUrl: '',
                success: function () {
                    alert('感谢亲的分享！！');
                },
                cancel: function () {
                    alert('手抖！取消了。。');
                }
            });
        });
    </script>
      <script>
         

        
          // 1 Slide Per View, 50px Between
          var mySwiper1 = myApp.swiper('.swiper-1', {
              pagination: '.swiper-1 .swiper-pagination',
              spaceBetween: 50,
              autoplay: 2000
          });



      </script>
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
                  if (addComp.city != "兰州市")
                  {
                      myApp.alert('当前城市：'+addComp.city+'未开通此服务', '温馨提醒');
                      
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
       $$('.jujia').on('click', function () {
           myApp.alert("正在开拓者","小护提醒");
       });
       $$('.yuesao').on('click', function () {
           myApp.alert("月嫂正在培训中", "小护提醒");
       });
       $$('.type1').on('click', function () {
           myApp.showPreloader('加载中')
           setTimeout(function () {
               myApp.hidePreloader();
           }, 2000);
           window.location = "type2.aspx";
       });
       $$('.doc1').on('click', function () {
           myApp.showPreloader('加载中')
           setTimeout(function () {
               myApp.hidePreloader();
           }, 2000);
           window.location = "type3.aspx";
       });
       $$('.kang').on('click', function () {
           myApp.showPreloader('加载中')
           setTimeout(function () {
               myApp.hidePreloader();
           }, 2000);
           window.location = "http://www.hugongll.com/list.aspx?wid=44&cid=193";
       });
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