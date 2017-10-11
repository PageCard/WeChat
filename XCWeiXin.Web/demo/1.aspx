<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1.aspx.cs" Inherits="XCWeiXin.Web.demo._1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <link href="css/sucaijiayuan.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".showdiv").click(function () {
            var box = 300;
            var th = $(window).scrollTop() + $(window).height() / 1.6 - box;
            var h = document.body.clientHeight;
            var rw = $(window).width() / 2 - box;
            $(".showbox").animate({ top: th, opacity: 'show', width: 600, height: 540, right: rw }, 500);
            $("#zhezhao").css({
                display: "block", height: $(document).height()
            });
            return false;
        });
        $(".showbox .close").click(function () {
            $(this).parents(".showbox").animate({ top: 0, opacity: 'hide', width: 0, height: 0, right: 0 }, 500);
            $("#zhezhao").css("display", "none");
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div >
      
      <a class="showdiv" href="">点击我弹出浮层</a>
	<div class="showbox" >
		<h2>请选择卡券类型<a class="close" href="#">关闭</a></h2>
        <div class="mainlist" style="width:500px; height:900px">
              <asp:RadioButton ID="RadioButton1" runat="server" GroupName="dd"  Text="优惠券"/>
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="dd" Text="折扣券"/>
        <br />
        <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="dd" Text="代金券"/>
            <br />
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="dd" Text="团购券" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="下一步" />
        </div>
	</div>	
	<div id="zhezhao"></div>
      
    </div>
    </form>
</body>
</html>
