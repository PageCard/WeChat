<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ider.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.ider" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>意见反馈</title>
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
   </head>
<body>
    <form id="form1" runat="server">
     <div class="page-group">
       
          
           <header class="bar bar-nav">
   
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>意见反馈</h1>
  </header>
           <nav class="bar bar-tab">
    
  <div ><asp:Button ID="fankui" runat="server" OnClick="fankui_Click" style="margin-top:-5px" CssClass="button button-big button-fill" Text="反馈意见" />
  </div>
     </nav>   
           

  <div class="content" >
        <div class="list-block">
    <ul>
          <li class="align-top">
        <div class="item-content">
          <div class="item-media"><i class="icon icon-form-comment"></i></div>
          <div class="item-inner">
            <div class="item-title label">输入内容</div>
            <div class="item-input">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="200px" placeholder="请输入反馈内容" Font-Size="15px"></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
    </ul>
  </div>
     </div>
         </div>
    </form>
       <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>

    <script src="../../sui/js/jquery.js"></script>
</body>

</html>
