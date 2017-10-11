<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeBehind="login.aspx.cs" Inherits="XCWeiXin.Web.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>微好客微信管理平台</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <meta name="keywords" content="护工来了,兰州护工,兰州家政,甘肃维盛科技劳务服务有限公司"/>
        <meta name="description" content="“护工来了”通过手机客户端将病患（家属）、护工两者有机结合起来，形成完美的闭环。病患（家属）在平台挑选需陪护人适合的护理工作者，护理工作者到岗进行陪护，并对整个陪护过程负有全部责任，最终陪护结束后，病患（家属）通过质量评分体系，给予评价。"/>
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<meta name="baidu-site-verification" content="pT5DMyE23Z" />
<link href="skin/default/showlogin.css" rel='stylesheet' type='text/css' />
<!--webfonts-->

<script type="text/javascript">
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
    });
</script>
</head>

<body class="loginbody">
   
    <form runat="server" id="form1">
<!--SIGN UP-->
 <h1><img src="skin/images/Logo.png" /></h1>
<div class="login-form">
	<div class="close"> </div>
		<div class="head-info">
		   <%-- <label class="lbl-1"> </label>
			<label class="lbl-2"> </label>--%>
			<%--<label class="lbl-3"> </label>--%>
		</div>
			<div class="clear"> </div>
	<div class="avtar">
		<img src="skin/images/avtar_wx.png" />
	</div>
   
			
    <div>
                  <label class="login-field-icon user" for="txtUserName"></label>
    <input type="text" name="username" id="username" class="text" placeholder="请输入用户名"   />
				
            <label class="login-field-icon user" for="txtUserName"></label>
						<div class="key">
                             <label class="login-field-icon pwd" for="txtPassword"></label>
                            <input type="password" name="pass" id="pass" class="password" placeholder="请输入密码"   />
					   
            <label class="login-field-icon pwd" for="txtPassword"></label>
						</div>
		
    </div>	
	<div class="signin" runat="server">
         <span class="login-tips"><i></i><b id="msgtip" runat="server" style="color:red"></b></span>
        <asp:Button ID="btnSubmit" type="submit" runat="server" Text="Login" CssClass="btn-login" onclick="btnSubmit_Click" />
		
	</div>
</div>
 <div class="copy-rights" >
                                                         <p style="font-size:15px,larger; color:black;font-style:italic;font-weight:500">甘肃维盛科技劳务服务有限公司</p>
					<p style="color:#939393">Copyright ©2014-2016 <a href="http://pc.hugonll.com" style="color:#939393">page_load</a> Corporation, All Rights Reserved</p>
			</div>
    </form>
</body>
</html>