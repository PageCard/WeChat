<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>订单评价</title>
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
  
       
          
           <header class="bar bar-nav">
   
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>订单评价</h1>
  </header>
         
        <nav class="bar bar-tab">
    
  <div >
      <asp:Button ID="bt1" runat="server" class="button  button-big button-round button-fill" Text="确定评价" OnClick="bt1_Click" />
  </div>
     </nav>         

  <div class="content" >
   <div style="text-align:center">
       <div class="content-block-title">订单<%=order_number %></div>
  <div class="list-block">
    <ul>
      <li class="item-content">
        <div class="item-inner">
          <div class="item-title">被护理人</div>
          <div class="item-after"><%=by_name %></div>
        </div>
      </li>
      <li class="item-content">
        <div class="item-inner">
          <div class="item-title">护理类型</div>
          <div class="item-after"><%=HUli_type %></div>
        </div>
      </li>
         <li class="item-content">
        <div class="item-inner">
          <div class="item-title">护理地址</div>
          <div class="item-after"><%=by_adress %></div>
        </div>
      </li>
        <li class="item-content">
        <div class="item-inner">
          <div class="item-title">护工名称</div>
          <div class="item-after"><%=hg_name %></div>
        </div>
      </li>
    </ul>
  </div>
       <div><asp:Label ID="Label1" Text="为本次服务评分" runat="server"></asp:Label></div>
       <div>
		<a href="javascript:click(1)"><img src="js/star/img/star.png" id="star1" onMouseOver="over(1)" onMouseOut="out(1)"/></a>
		<a href="javascript:click(2)"><img src="js/star/img/star.png" id="star2" onMouseOver="over(2)" onMouseOut="out(2)" /></a>
		<a href="javascript:click(3)"><img src="js/star/img/star.png" id="star3" onMouseOver="over(3)" onMouseOut="out(3)" /></a>
		<a href="javascript:click(4)"><img src="js/star/img/star.png" id="star4" onMouseOver="over(4)" onMouseOut="out(4)"/></a>
		<a href="javascript:click(5)"><img src="js/star/img/star.png" id="star5" onMouseOver="over(5)" onMouseOut="out(5)"/></a>
		<input  type="text" id="lb1"class=" button-light disabled" readonly="readonly" style="width:50px" name="lb1"/>
      
         </div>
        <div class="list-block">
    <ul>
      <li class="align-top">
        <div class="item-content">
          <div class="item-media"><i class="icon icon-form-comment"></i></div>
          <div class="item-inner">
            <div class="item-title label">服务评价</div>
            <div class="item-input">
  <asp:TextBox ID="t1" runat="server" TextMode="MultiLine" Font-Size="14px" placeholder="请为本次服务做点评" ></asp:TextBox>

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
    <script type="text/javascript">
        var check = 0;//该变量是记录当前选择的评分
        var time = 0;//该变量是统计用户评价的次数，这个是我的业务要求统计的（改变评分不超过三次），可以忽略

        /*over()是鼠标移过事件的处理方法*/
        function over(param) {
            if (param == 1) {
                $("#star1").attr("src", "js/star/img/star_red.png");//第一颗星星亮起来，下面以此类推
                $("#message").html("");//设置提示语，下面以此类推
            } else if (param == 2) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#message").html("");
            } else if (param == 3) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star_red.png");
                $("#message").html("");
            } else if (param == 4) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star_red.png");
                $("#star4").attr("src", "js/star/img/star_red.png");
                $("#message").html("");
            } else if (param == 5) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star_red.png");
                $("#star4").attr("src", "js/star/img/star_red.png");
                $("#star5").attr("src", "js/star/img/star_red.png");
                $("#message").html("");
            }
        }
        /*out 方法是鼠标移除事件的处理方法，当鼠标移出时，恢复到我的打分情况*/
        function out() {
            if (check == 1) {//打分是1，设置第一颗星星亮，其他星星暗，其他情况以此类推
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star.png");
                $("#star3").attr("src", "js/star/img/star.png");
                $("#star4").attr("src", "js/star/img/star.png");
                $("#star5").attr("src", "js/star/img/star.png");
                $("#message").html("");
            } else if (check == 2) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star.png");
                $("#star4").attr("src", "js/star/img/star.png");
                $("#star5").attr("src", "js/star/img/star.png");
                $("#message").html("");
            } else if (check == 3) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star_red.png");
                $("#star4").attr("src", "js/star/img/star.png");
                $("#star5").attr("src", "js/star/img/star.png");
                $("#message").html("");
            } else if (check == 4) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star_red.png");
                $("#star4").attr("src", "js/star/img/star_red.png");
                $("#star5").attr("src", "js/star/img/star.png");
                $("#message").html("");
            } else if (check == 5) {
                $("#star1").attr("src", "js/star/img/star_red.png");
                $("#star2").attr("src", "js/star/img/star_red.png");
                $("#star3").attr("src", "js/star/img/star_red.png");
                $("#star4").attr("src", "js/star/img/star_red.png");
                $("#star5").attr("src", "js/star/img/star_red.png");
                $("#message").html("");
            } else if (check == 0) {
                $("#star1").attr("src", "js/star/img/star.png");
                $("#star2").attr("src", "js/star/img/star.png");
                $("#star3").attr("src", "js/star/img/star.png");
                $("#star4").attr("src", "js/star/img/star.png");
                $("#star5").attr("src", "js/star/img/star.png");
                $("#message").html("");
            }
        }
        /*click()点击事件处理，记录打分*/
        function click(param) {
            time++;//记录打分次数
            check = param;//记录当前打分
            $("#lb1").val(check+"星");;
          
            out();//设置星星数
        }
</script>
</body>

</html>


