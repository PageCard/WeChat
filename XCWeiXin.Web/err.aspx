<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="err.aspx.cs" Inherits="XCWeiXin.Web.err" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta name="description" content="微信">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>信息提示</title> 
   <script src="/sui/js/zepto.js"></script>   
   <script src="/sui/js/sm.min.js"></script>
    <link href="/sui/css/sm.css" rel="stylesheet">
    <link href="css/activity-style2.css" rel="stylesheet" type="text/css">     
    <style>
        .page{ background:#e5e5e5}
        h1{ text-align:center}
    </style>
</head>
<body >
<form id="form1" runat="server">
 <div class="page-group">
<div class="page">
 <div class="content">
    
   <%if (rev == 100001)
     {%>   
     <h1>用户信息获取失败，可能会影响部分功能的使用</h1>
       <%}
     else if (rev == 100002)
     { %> 
     <h1>参数错误（100002）</h1>
        <%}
     else if (rev == 100003)
     { %> 
      <h1>参数错误（100003）</h1>
        <%} %>
    </div>
    </div>

    </div>
</form>
         
</body>
</html>

