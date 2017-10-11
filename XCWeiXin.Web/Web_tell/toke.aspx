<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toke.aspx.cs" Inherits="XCWeiXin.Web.Web_tell.toke" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>在线聊天</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm.min.css">
    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm-extend.min.css">
    <script type='text/javascript' src='//g.alicdn.com/sj/lib/zepto/zepto.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='//g.alicdn.com/msui/sm/0.6.2/js/sm.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='//g.alicdn.com/msui/sm/0.6.2/js/sm-extend.min.js' charset='utf-8'></script>
</head>
<body>
    <form id="form1" runat="server">
   
  <div>
     <div class="content">
            <!-- 你的html代码 -->
         
           
       <div class="card">
    <div class="card-header"><%=load %></div>
    <div class="card-content">
      <div class="card-content-inner"><%=quest %></div>
    </div>
    <div class="card-footer"><%=create %></div>
  </div>
   
</div>
          </div>      
         <div class="card" style="position:fixed;bottom:0px;right:0px;left:0px">
          <div style="width:79%; float:left; height:25px;">
              <asp:TextBox ID="TextBox1" CssClass="modal-text" runat="server" Width="100%"></asp:TextBox>
             </div>
        <div style="width:20%;float:right; height:25px ;">
            <asp:Button ID="Button1" runat="server" CssClass="buttons-tab"  Text="发送" OnClick="Button1_Click"  />
            </div>
                
       </div> 
     

    
 
    </form>
</body>
</html>
