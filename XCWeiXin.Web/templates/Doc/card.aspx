<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="card.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.card" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>在线护工</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
    <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
   
   
   
  <style>
      bady {
      
       
          font-size:12px;
          color:#CEC9C9;
      }
       a:link {
          color:black;
      }
      a:visited {
           color:black;

}
   
      .julirem {
        margin-left:0.5rem;
      }
   
  
        .bar .icon {
      
         
          color:#0894EC;
        
      }
      .bar .tab-label {
      color:Background;    }
      .page a:hover {
          color:#0894EC;
    
      }
      .jp {
    font-size: 11px;
    color: #c5bb67;
    border-radius: .1rem;
    border: 1px solid #c5bb67;
    padding: 0 .2rem;
    display: inline-block;
    line-height: 1.4em;
    vertical-align: middle;
    margin-top: -.12rem;
      }
      .ddd {
      
             position: absolute;
             right: 0.267rem;
             top: 0.3rem;
             color:#FF9648;
      }
 
 .card  .card-content img{
     border-radius:50%;
      }
      .cardfont {
      font-size:12px;
      }
  
#bg{
	width: 60px;
	height: 16px;
	background: url("js/star/img/star_gray.png");
}
#over{
	height:16px;
	background:url("js/star/img/star_org.png") no-repeat;
}

     
  </style> 
 
  
</head>
    
<body onload="bb();" >
  <form runat="server">
   
          <div  id="page-infinite-scroll-bottom" class="page">
           <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left" href="javascript:history.go(-1)" data-transition='slide-out'>
      <span class="icon icon-arrowleft"></span>
       </a>
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>护工列表</h1>
  </header>
       <!-- 添加 class infinite-scroll 和 data-distance  向下无限滚动可不加infinite-scroll-bottom类，这里加上是为了和下面的向上无限滚动区分-->
        <div class="content infinite-scroll infinite-scroll-bottom" data-distance="100" style="background-color:#E5E8E8" >
            <div class="list-block" >
                <ul class="list-container" style="margin-top:-1.2rem;background-color:#E5E8E8 ; ">
                </ul>
            </div>
            <!-- 加载提示符 -->
            <div class="infinite-scroll-preloader">
                <div class="preloader">
                </div>
            </div>
        </div>  

  
     </div>
      <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
        <script src="js/demos.js"></script>
     
       <script>
           window.onload = bb();getajax();
          function bb() {
              Zepto.toast('护工来了，为您提供安全可靠的护工！', 5000);
          };
           function getajax() {
               var where = "wid=44";
               Zepto.ajax(
     {

         url: "HG_list.ashx",
         data: {  page: 1 },
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         async:false,
         cache: false,
         success: function (msg) {
             var html = "";
           
          
             if (msg.count==8) {
                 for (var i = 0; i < 8; i++) {
                     var widt = 12 * msg.ds[i].Jungle;
                    //说明，这里的width就是设置分数啦，以我写的为例，一个星星的长度是12px，也就是1分12px，如果是4.3分，就是4.3*12px = 51.6px的长度，当然这个一般是取得数据后用js或者其他模板语言去控制的--> 
                     //加载开始Start
                     html += '<a href="card_sing.aspx?type=1&number=' + msg.ds[i].Hg_number + '&techer=' + msg.ds[i].Teacher_i + '"><li><div class="card "> <div class="card-header cardfont " style="color:#0894EC">  <tr> <td><div id="bg"><div id="over" style="width:' + widt + 'px"></div><!--这里是遮罩，设置宽度以达到评分的效果--></div></td> <td  style="color: #c5bb67";>服务了' + msg.ds[i].ordercount + '位用户</td></tr></div><div class="card-content"><div class="list-block media-list"><ul>  <li class="item-content" style="margin-left:-2.2rem"> <div class="item-media" > <img  src="' + msg.ds[i].Headurl + '" width="44"></div><div class="item-inner cardfont"  style="margin-left:0.8rem"> <div class="item-title-row"><div class="item-title" >' + msg.ds[i].Hg_name + '<span href="#" class="jp">' + msg.ds[i].dengji + '</span></div></div><div class="item-subtitle"><span>' + msg.ds[i].Hg_sex + '</span><font>|</font><span>' + msg.ds[i].Hg_age + '岁</span><br /><span class="cardfont">' + msg.ds[i].Hg_Profile + '</span></div></div><span class="ddd  cardfont">' + msg.ds[i].Mony + '元/人</span></li></ul></div></div><div class="card-footer cardfont" > <div class="col-40">服务范围:</div><div class="col-60"><span href="#" class="button button-primary cardfont ">' + msg.ds[i].Hg_st1 + '</span></div> </div></div></li></a>';
                     //护工列表加载End
                 }
                 // 添加新条目
                 $('.infinite-scroll-bottom .list-container').append(html);
                

             }
             else if (msg.count == null)
             {
                 $.alert('护工预约完毕，稍后查看', '温馨提醒!', function () {
                     location.href = "../../templates/Doc/index.aspx?";
                 });
              
              
                 // 删除加载提示符
                 $('.infinite-scroll-preloader').remove();
             }
             else {
                 for (var i = 0; i < msg.count; i++) {

                     var widt = 12 * msg.ds[i].Jungle;
                     //说明，这里的width就是设置分数啦，以我写的为例，一个星星的长度是12px，也就是1分12px，如果是4.3分，就是4.3*12px = 51.6px的长度，当然这个一般是取得数据后用js或者其他模板语言去控制的--> 
                     //加载开始Start
                     html += '<a href="card_sing.aspx?type=1&number=' + msg.ds[i].Hg_number + '&techer=' + msg.ds[i].Teacher_i + '"><li><div class="card "> <div class="card-header cardfont " style="color:#0894EC">  <tr> <td><div id="bg"><div id="over" style="width:' + widt + 'px"></div><!--这里是遮罩，设置宽度以达到评分的效果--></div></td> <td  style="color: #c5bb67";>服务了' + msg.ds[i].ordercount + '位用户</td></tr></div><div class="card-content"><div class="list-block media-list"><ul>  <li class="item-content" style="margin-left:-2.2rem"> <div class="item-media" > <img  src="' + msg.ds[i].Headurl + '" width="44"></div><div class="item-inner cardfont"  style="margin-left:0.8rem"> <div class="item-title-row"><div class="item-title" >' + msg.ds[i].Hg_name + '<span href="#" class="jp">' + msg.ds[i].dengji + '</span></div></div><div class="item-subtitle"><span>' + msg.ds[i].Hg_sex + '</span><font>|</font><span>' + msg.ds[i].Hg_age + '岁</span><br /><span class="cardfont">' + msg.ds[i].Hg_Profile + '</span></div></div><span class="ddd  cardfont">' + msg.ds[i].Mony + '元/人</span></li></ul></div></div><div class="card-footer cardfont" > <div class="col-40">服务范围:</div><div class="col-60"><span href="#" class="button button-primary cardfont ">' + msg.ds[i].Hg_st1 + '</span></div> </div></div></li></a>';
                     //护工列表加载End
                    
                 }
                 // 删除加载提示符
                 $('.infinite-scroll-preloader').remove();
                 // 添加新条目
                 $('.infinite-scroll-bottom .list-container').append(html);
                 // 加载完毕，则注销无限加载事件，以防不必要的加载
                 $.detachInfiniteScroll($('.infinite-scroll'));

               





             }

           
           

         },
         error: function (x, e) {
             alert("The call to the server side failed. " +
     x.responseText);
         }
     });

           };
         
  </script>
      
      
   <!--护工列表加载-end-->  
     



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

