<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Type1.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.Type1" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>医院护理</title>
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
     <link href="css/iconfont.css" rel="stylesheet" />
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=MfWzTIuMQ3R4bFGNFtRbD1h9MRI4ZHbz"></script>

   
  
  

  <style>
      bady {
          font-size:12px;
          color:#CEC9C9;
      }
      ul li {
          list-style:none;
          float:left;
      
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
     
  </style> 
    <script>
        $(document).on('click', '.open-3-modal', function () {
            Zepto.modal({
                title: '是否同意协议',
                text: '此协议经过法律声明有效，可随时作为法律有效文件！',
                buttons: [
                  {
                      text: '取消',
                      onClick: function () {
                       
                      }
                  },
                  {
                      text: '不同意',
                      onClick: function () {

                          Zepto.toast('您取消了预定协议')
                      }
                  },
                  {
                      text: '同意',
                      bold: true,
                      onClick: function () {
                          $.ajax({
                              url: "HG_list.ashx",
                              data: { action:"File",pickname:'<%=pick_name%>' },
                              contentType: "application/json; charset=utf-8",
                              dataType: "json",
                              async: true,
                              cache: false,
                              success: function (msg) {
                                  if (msg.errCode == "false")
                                  {
                                      window.location.href = "card.aspx?type=1";

                                  }

                              }

                          })
                       
                      }
                  },
                ]
            })
        });
    </script>
  
</head>
    
<body>
  <form runat="server">
   <div class="page-group">
       
          
           <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left" href="javascript:history.go(-1)" data-transition='slide-out'>
      <span class="icon icon-arrowleft"></span>
       </a>
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>护工预约</h1>
  </header>
              <nav class="bar bar-tab">
    
  <div > <a href="#" data-popup=".popup-about" class="button button-big button-fill open-popup " style="margin-top:-5px">护理合同</a>
  </div>
     </nav>   

  <div class="content" style="background-color:#E0E5EA">
    
      <div style="display:none;" id="allmap"></div>
      <div style="position: relative; "> 
 <img src="images/index/1665782699.jpg" width="100%" />
<%--<span style="position: absolute;width:100%;color:white; top:6.0rem; left: 0;background-color:#A2A29E; opacity:0.5;filter:alpha(opacity=60);"> &nbsp &nbsp &nbsp 医院护理价格说明&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp 100元/天</span> --%>
</div> 
     
    <div style="background-color:#EFEFF4; margin-top:0.4rem; ">
        <table  style="width:100%; margin:0 auto">
            <tr style="color:#C5BB67"> 
                <th><span class="axiba icon-shimingrenzheng"></span></th>
                 <th><span class="axiba icon-jiankangzhengming"></span></th>
                 <th><span  class="axiba icon-zhuanyepeixun" style="font-size:23px"></span></th>
                 <th><span class="axiba icon-xiaolvdashitubiao33319" style="font-size:20px"></span></th>
                 <th><span class="axiba icon-shouhoubaozhang" style="font-size:20px"></span></th>
            </tr>
            <tr  >
                 <th><span class="fontds">实名认证</span></th>
                 <th><span class="fontds">健康证明</span></th>
                 <th><span class="fontds">专业培训</span></th>
                 <th><span class="fontds">全程监督</span></th>
                 <th><span class="fontds">售后保障</span></th>
            </tr>
        </table>
         
 </div>
   
      <div class="bgt" style="margin-top:-0.4rem">
      <h5 style="padding-top:1.2rem" >为住院的病患提供专业的术后及重症护理服务</h5>
      <table style="width:100%" class="fontd">
          <tr>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>床单清洁</th>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>清拭擦身及变换体位</th>
          </tr>
          <tr>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>协助进食与饮水</th>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>起床就寝护理</th>  
          </tr>
           <tr>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>协助病情观察</th>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>协助室内活动</th>  
          </tr>
           <tr >
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>遵医嘱协助康复训练</th>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>协助用药</th>  
          </tr>
           <tr>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>排泄护理</th>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>协助标本采集</th>  
          </tr>
           <tr>
              <th class="fontds"><span class="iconfont icon-jiantou spancolor"></span>引流管的护理</th>
              <th class="fontds"> </th>  
          </tr>

      </table>
     </div>
     <img width="100%" src="images/医院护理.jpg" />
      </div>
       <div class="popup popup-about">
  <div class="content-block" style="background-color:#ffffff">
     <p> <a class="button button-link button-nav pull-left close-popup" href="#" >
      <span class="icon icon-arrowleft">返回</span>
       </a></p> 
       <br />
      <br />
      <div style="background-color:#CEC9C9">
    <center>病人护理合同</center>
      <table style="width: 100%; font-size:14px">
          <tr>
              <td>甲方：甘肃维盛科技劳务服务有限公司</td> 
          </tr>
          <tr>
              <td>乙方：微信用户：<a href="#" style="color:red"><%=pick_name%></a></td>   
          </tr>
          <tr>
              <td>一、甲方从 <%=DateTime.Now %> 时开始向乙方提供医院陪护人员，护理地点为：医院。甲方给乙方陪护伤病人员。</td>  
          </tr>
           <tr>
              <td>二、甲方所提供的护理员工的义务是为病人喂饭、吃药、翻身、勤换衣物、协助病人大小便、保证卫生良好，即时找护士、大夫反应情况，以便为病人早日康复创造良好条件。</td>  
          </tr>
           <tr>
              <td>三、医院陪护人员夜间班和白班分别为10个小时，夜间班护理费为人民币        元钱。白天班护理费为人民币         元钱，全日班24小时值班陪护，全日班护理费为每班（24小时）人民币        元钱，乙方给护理人员提供夜间不离岗休息条件，乙方管吃管住。</td>  
          </tr>
           <tr>
              <td>四、乙方应先付款，付款后甲方才指派陪护员工上岗。乙方只能对甲方结算费用，陪护员工资由甲方支付。乙方不得与陪护人员私自建立陪护服务关系，不得私自将费用结算给甲方所提供的陪护员工。</td>  
          </tr>
          <tr>
              <td>五、甲方应加强对所提供陪护员工的管理，保证服务质量。乙方有权对甲方所提供的陪护员工提出以下要求：在乙方处工作值班时微笑，热情主动，勤快，不准随便远离值班岗位，值班间中午不准喝酒，不准长时间看书报。乙方有权对陪护员工监督、批评、纠正。 </td>
          </tr>
           <tr>
               <td>六、甲乙双方在合作中，如乙方对甲方所提供陪护员的工作不满意，乙方可通知甲方更换陪护人员，定价不变。所提供的陪护员只要在乙方处工作服务，本合同一直有效。</td>
           </tr>
          <tr>
              <td>七、乙方应自己管好自己的财物，不得借给员工钱物。否则对员工的债务，甲方不承担清偿责任；乙方如发生被骗、窃的后果，乙方应即时向公安部门报案处理，甲方只负责协助乙方及执法部门处理此案，甲方不负任何经济赔偿责任。乙方不得以此为由拒付甲方的陪护费。 </td>
          </tr>
          <tr>
              <td>八、乙方应提供一至两个有不亲友的家庭住址、身份证复印件及联系电话给甲方及甲方的陪护员，以便乙方被陪护的亲属由特殊情况时能及时通知。 </td>
          </tr>
           
      </table>
      <br />
      <br />
      
      <table style="width: 100%;">
         
          <tr>
              <td>
            
                  </td>
              
          </tr>
         
      </table>
    
  </div>

</div>
            <a href="#" data-popup=".popup-about" class="button button-big button-fill  open-3-modal" style="margin-top:-5px">立即预约</a>
       </div>
      </div>
      </form>
  
   <script>
       $(document).on('click', '.popup-about', function () {
           console.log('About Popup opened')
       });
   </script>
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
                             Zepto.toast("当前城市:" + addComp.city + "未开通此服务");
                             window.location.href = "index.aspx";
                             
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
    <script src="../../sui/js/jquery.js"></script>
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

