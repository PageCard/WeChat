<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload_new.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.Upload_new" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <title>在线聊天</title>
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
</head>
<body class="mainbody">
   　<form id="formid" name="myform" action="Upload" method='post' enctype="multipart/form-data">
　　　　<table>
　　　　　　<tr>
　　　　　　　　<td>图片：</td>
　　　　　　　　<td><input type="file" name="file" accept="image/*" value="选择" /></td>
　　　　　　</tr>
　　　　</table>
　　　　<input type="submit" value="上传" />
　　</form>
       <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
</body>
</html>
