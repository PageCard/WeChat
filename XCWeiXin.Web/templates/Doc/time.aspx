<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="time.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.time" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>在线聊天</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
    <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
   
    
    

 

    <link href="js/time/new/datedropper.css" rel="stylesheet" />
    <link href="js/time/new/timedropper.min.css" rel="stylesheet" />
    
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
   <div class="page-group">
        <div class="page page-current">
          
           <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left" href="javascript:history.go(-1)" data-transition='slide-out'>
      <span class="icon icon-arrowleft"></span>
       </a>
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>护理时间</h1>
  </header>
             <nav class="bar bar-tab">
  
       <asp:Button ID="Button1" CssClass="tab-item button button-fill" runat="server" Text="立即预约" OnClick="Button1_Click" />
 
     </nav>

  <div class="content">
   <div class="list-block demo">
    <ul>
      <!-- Text inputs -->
      <li>
        <div class="item-content">
          <div class="item-media"><i class="icon icon-form-name"></i></div>
          <div class="item-inner">
            <div class="item-title label">护理日期</div>
            <div class="item-input">
              <asp:TextBox ID="pickdate" runat="server"></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
      <li>
        <div class="item-content">
          <div class="item-media"><i class="icon icon-form-email"></i></div>
          <div class="item-inner">
            <div class="item-title label">护理时间</div>
            <div class="item-input">
             <asp:TextBox ID="picktime" runat="server"></asp:TextBox>
               
            </div>
          </div>
        </div>
      </li>
 </ul>
       </div>
      <script src="js/time/new/jquery-1.12.3.min.js"></script>
      <script src="js/time/new/datedropper.min.js"></script>
      <script src="js/time/new/timedropper.min.js"></script>
<script>
    $("#pickdate").dateDropper({
        animate: false,
        format: 'Y-m-d',
        maxYear: '2020'
    });
    $("#picktime").timeDropper({
        meridians: false,
        format: 'HH:mm',
    });
</script>
  <%--<article class="jq22-container">
		
		<div id="wrap">
		  
		    
		    <ul class="hiSlider hiSlider1">
		        <li data-title="11111" class="hiSlider-item"><img  src="../../templatesstore/images/fxPic.jpg" style="width:100%" alt="11111"></li>
		        <li data-title="22222" class="hiSlider-item"><img src="../../templatesstore/images/fxPic.jpg"  style="width:100%"alt="22222"></li>
		        <li data-title="33333" class="hiSlider-item"><img src="../../templatesstore/images/fxPic.jpg"  style="width:100%" alt="33333"></li>
		        <li data-title="44444" class="hiSlider-item"><img src="../../templatesstore/images/fxPic.jpg"  style="width:100%" alt="44444"></li>
		        <li data-title="55555" class="hiSlider-item"><img src="../../templatesstore/images/fxPic.jpg"  style="width:100%" alt="55555"></li>
		    </ul>

		    
		</div>
		
	</article>
	<script src="../../scripts/lunbo/jquery.1.9.1.js"></script>
	
	
      <script src="../../scripts/lunbo/jquery.hiSlider.min.js"></script>
	<script>
	    $('.hiSlider1').hiSlider();

	</script>
                      --%>
                      
                 
               
            
    
    
          
      
            <!--焦点图片 end-->
 
     


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
    
            
   </div>
   


      </form>
  
  
        <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
       
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

