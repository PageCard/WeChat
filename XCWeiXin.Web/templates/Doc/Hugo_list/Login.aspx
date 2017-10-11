<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.Hugo_list.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>护工学院</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
   <script type="text/javascript" src="js/jquery.min.js"></script>
    <link href="../../../sui/css/sm.css?v=1.0" rel="stylesheet" />
    <link href="../../../sui/Fire/iconfont.css" rel="stylesheet" />
    
    <script src="../../../scripts/jquery.min.js"></script>
 
 
</head>
<body>
    <form id="form1" runat="server">
    
          
           <header class="bar bar-nav">
   
    <h1 class="title"><span class="zqlfont icon-hugong2"></span>护工登录</h1>
  </header>
           

  <div class="content">
     
      <div style="margin:20% auto">
        <p style="text-align:center"> <img src="../images/Logo.png" width="70px" /></p> 
      <div class="list-block" >
    <ul style="margin:2rem">
      <!-- Text inputs -->
      <li>
        <div class="item-content">
          <div class="item-media"><i class="zqlfont icon-hugong2"></i></div>
          <div class="item-inner">
            <div class="item-input">
              <input type="text" id="user" name="user" placeholder="用户名">
            </div>
          </div>
        </div>
      </li>
      <li>
        <div class="item-content">
          <div class="item-media"><i class="zqlfont icon-mima18"></i></div>
          <div class="item-inner">
            <div class="item-input">
              <input type="password" id="pass" name="pass" placeholder="密码">
            </div>
          </div>
        </div>
      </li>

      <!-- Select -->
       
    </ul>
  </div>
         
       <p> <asp:Button CssClass="button button-big button-round" ID="Button1" style="background-color:blue; width:80%;margin:10% auto; color:white " OnClick="Button1_Click" runat="server" Text="登录" /></p>
      
     <div style="color:#a19d9d;font-size:12px;text-align:center;margin-top:12rem;">技术支持：@Page_Load</div>
          </div>
      </div>
         
        
    </form>
      <script type='text/javascript'  src="../../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../../sui/js/sm.min.js" charset='utf-8'></script>
</body>
</html>
