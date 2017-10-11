<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mycont.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.Mycont" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>个人中心</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
    <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
   
     <link href="js/time/new/datedropper.css" rel="stylesheet" />
    <link href="js/time/new/timedropper.min.css" rel="stylesheet" />
    

 

    <link href="js/time/new/datedropper.css" rel="stylesheet" />
    <link href="js/time/new/timedropper.min.css" rel="stylesheet" />
    
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
      .kk {
       text-align:center;
       border:0.1px solid #D8DEE0;
       font-size:0.6rem;
       
      }
     
  </style> 

  
</head>
    
<body>
  <form runat="server">
  
           <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left" href="#" data-transition='slide-out'>
      <span class="icon icon-arrowleft"></span>
       </a>
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>个人中心</h1>
  </header>
           <%--  <nav class="bar bar-tab">
  
       <asp:Button ID="Button1" CssClass="tab-item button button-fill" runat="server" Text="立即预约" />
 
     </nav>--%>
              <nav class="bar bar-tab">
   <a class="tab-item open-indicator" href="index.aspx">
      <span class="icon icon-shouye"></span>
      <span class="tab-label">首页</span>    </a>
    <a class="tab-item open-indicator" href="Hugo_list/Login.aspx">
      <span class="icon icon-hugong2"></span>
        <span class="tab-label">护工学院</span>
      
</a>
    <a class="tab-item  open-indicator" href="order.aspx">
      <span class="icon icon-chanpinguanli"></span>
      <span class="tab-label">订单</span>
          
    </a>
    <a class="tab-item open-indicator" href="#">
      <span class="icon  icon-wode"></span>
      <span class="tab-label">我的</span>    </a>  </nav>


  <div class="content" style="background-color:#F0F3F5">
   <div class="img0" style="width:100%; height:8rem;background-color:#36BC9B; ">
      <div>
       <img  style="width:3rem; margin:2.3rem 42%;border-radius:50%;" src="<%=headimg %>" /><h5 style="text-align:center; margin-top:-2.5rem"; ><%=pick_name %></h5></div></div>
      <div style="background-color:#FFFFFF; margin-top:0.5rem" >
      <table style="width: 100%;height:15rem">
          <tr>
              <td class="kk">
                  <img  style="width:1.5rem"  src="images/会员卡@2x.png" />
                   
      <br />
          <span>会员卡</span>
              </td>
              <td class="kk">  <img  style="width:1.5rem"  src="images/个人@2x.png" />
      <br />
          <span>账户管理</span></td>
             <td class="kk"> <img  style="width:1.5rem"  src="images/健康@2x.png" />
      <br />
          <span>健康管理</span></td>
          </tr>
          <tr>
             <td class="kk">
                 <img  style="width:1.5rem"  src="images/地址@2x.png" />
      <br />
          <span>地址管理</span></td>
             <td class="kk"> <img  style="width:1.5rem"  src="images/收藏@2x.png" />
      <br />
          <span>收藏</span></td>
             <td class="kk"> <img   style="width:1.5rem" src="images/分享@2x.png" />
      <br />
          <span>分享</span></td>
          </tr>
          <tr>
             <td class="kk"> <img  style="width:1.5rem"  src="images/信息@2x.png" />
      <br />
          <span>信息中心</span></td>
             <td class="kk"> <img  style="width:1.5rem"  src="images/设置@2x.png" />
      <br />
          <span>设置</span></td>
             <td class="kk"> <img  style="width:1.5rem"  src="images/更多@2x.png" />
      <br />
          <span>更多</span></td>
          </tr>
      </table>
          </div>
     

 


    
            
   </div>
   


      </form>
  
  
        <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
       

    </body>

</html>

