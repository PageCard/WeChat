<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.index" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>护工来了</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
    <link href="../../shop/templates/3/css/templates.css" rel="stylesheet" />
    
    <script src="../../scripts/jquery.min.js"></script>
    <link href="../../sui/new%20font/iconfont.css" rel="stylesheet" />
    <link href="../../sui/add/iconfont.css" rel="stylesheet" />
 <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=MfWzTIuMQ3R4bFGNFtRbD1h9MRI4ZHbz"></script>
   
  
  

  <style>
      bady {
      
          font-family:Aharoni;
          font-size:15px;
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
    
     
  </style> 

  
</head>
    
<body>
  <form runat="server">
  
          
           <header class="bar bar-nav">
  
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>护工预约</h1>
  </header>
             <nav class="bar bar-tab">
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
      <span class="tab-label">我的</span>    </a>  </nav>

  <div class="content">
    


      <div style="display:none;" id="allmap"></div>
      <!--焦点图片-->
            <div class="slider">
                <ul>
                 
                      
                       <li>
                            <a href="#" title="sdf" target="_blank"> <img src="images/index/1665782699.jpg" /></a>
                        </li>
                       <li>
                            <a href="#" title="sdf" target="_blank"><img src="images/index/1665782700.jpg" /></a>
                        </li>
                      <li>
                            <a href="#" title="sdf" target="_blank"> <img src="images/qj.jpg" /></a>
                        </li>
                 
                </ul>
            </div>
    
    <script src="../../scripts/yxMobileSlider.js"></script>
          <script>$(".slider").yxMobileSlider({ width: window.screen.width, height: (document.body.clientHeight * 0.3), during: 3000 })</script>
            <!--焦点图片 end-->
          
         
 
     

   <div style=" background-color:#E0E5EA; text-align:center; color:#CEC9C9; padding-bottom:1rem;">  
<div class="content-padded " style="color:#808080;padding-top:2px;padding-bottom:2px;">
      
         
        <div class="row" style="margin-top:0.2rem; padding-bottom:1rem;" >
            
            <div class="col-50 "; style="border:1px #EFEFF4 solid; border-radius: 8px; background-color:#EFEFF4;margin-top:1rem; ">
             
                      <a href="Type1.aspx">   <div class="item-media" style="padding-top:20px;">
                          <img width="120px" src="images/组-2@2x.png" />   </div>
                                        
                                            <h5 >医院护理</h5>
              
                                         
                       </a>                     
                                     
            </div>
            
         
             <div  class="col-50 "; style="border:1px #EFEFF4 solid; border-radius: 8px; background-color:#EFEFF4;margin-top:1rem;">
   <a href="#<%--detail.aspx?type=2--%>" onclick="show()">       
                                            <div class="item-media" style="padding-top:20px;">
                                                <img width="120px" src="images/组-3@2x.png" />
                                             <h5 >居家护理</h5> 
                                            </div>
                                           
                          </a>                 
                                      
             </div>
               
           
     
     </div>
    
    <div class="row" >
      
            <div class="col-50 "; style="border:1px #EFEFF4 solid; border-radius: 8px; background-color:#EFEFF4; ">
      <a href="#"onclick="show()">
                                            <div class="item-media" style="padding-top:20px;">
                                                <img width="120px" src="images/组-4@2x.png" />
                                            <h5 class="IPL_name">月嫂</h5>
                                                </div>
          </a>
                                          
                                          
                                     
            </div>
      
            <div  class="col-50"; style="border:1px #EFEFF4 solid; border-radius: 8px;  background-color:#EFEFF4">
              <a href="#" onclick="show()">
                                            <div class="item-media" style="padding-top:20px;">
                                                <img width="120px" src="images/组-5@2x.png" />
                                            <h5 class="IPL_name">康复公益</h5>
                                                </div>
                </a>
                                         
                                         
                                       
            </div>
        
    </div>
   
  
    
</div>
</div>
 </div>
 
    

<%--<div class="panel-overlay"></div>
<!-- Left Panel with Reveal effect -->

<div class="panel panel-left panel-reveal theme-dark"  >
  <div class="content-block" >
    <div style="font-size:15px;font-weight:bold;color:green">会话消息</div>
        <div class="list-block media-list inset">
    <ul class="mlgb"></ul>
      </div>
     <p style="float:right;"><a href="#" class="close-panel"  style="color:white;font-size:15px;font-synthesis:weight">关闭</a></p>  
  </div>
    
 
    </div>--%>
    
            
   
   


      </form>
  
   
        <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
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
                         Zepto.toast("当前城市:"+addComp.city+"未开通此服务");

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
           function show()
           {
               Zepto.toast("未开放!")
           }
       </script>
   <%--<script>
       $("#picker").picker({
           toolbarTemplate: '<header class="bar bar-nav">\
  <button class="button button-link pull-right close-picker">确定</button>\
  <h1 class="title">请选择业务类型</h1>\
  </header>',
           cols: [
             {
                 textAlign: 'center',
                 values: ['小招1', '小招2', '小招3', '李', '周', '吴', '郑', '王']
                 //如果你希望显示文案和实际值不同，可以在这里加一个displayValues: [.....]
             }
           ]
       });
</script>--%>
    </body>

</html>

