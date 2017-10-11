<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tell_.aspx.cs" Inherits="XCWeiXin.Web.Web_tell.Tell_" %>

<!DOCTYPE html>
<html>
<head>
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>在线聊天</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
   
    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm.min.css">
    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm-extend.min.css">

    <script>
        window.onload = showLogin();
        var pageindex = 1;
        var c = 0;
        function showLogin() {
            setInterval("getajaxs()", "3000");
        }


        function removemm() {
            var html = "";
            $('ul li').remove();
           
        }
        function getajaxs() {
            removemm();
            var value_q = document.getElementById("picker").value;
            var b = "'" + value_q + "'";
            $.ajax(
                {

                    url: "GetData.ashx",
                    data: { type: "list", pagesize: 180, pageindex: pageindex, str: "<%=str%>" + 'and extStr3=' + b + '' },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (msg) {
                        var html = "";

                        for (var i = 0; i < msg.count; i++) {

                            html += '<li ><a href=adress.aspx?like=' + b + '&create=' + msg.ds[i].wx_openid + '&id=' + msg.ds[i].id + ' style="color:#999999" class="item-link item-content" > <div class="item-media"><img src="' + msg.ds[i].extStr2 + '" style="width: 2.2rem;"></div>  <div class="item-inner"><div class="item-title-row">    <div class="item-title">' + msg.ds[i].extStr + '</div>  </div> </div></a></li>';


                        }
                        $('.theme-dark .mlgb').append(html);



                    },
                    error: function (x, e) {
                        alert("Error" + x.responseText);
                    }
                }
                    )
            }
            function getajax(pageindex) {
                removemm();
                $.ajax(
                    {
                        url: "GetData.ashx",
                        data: { type: "list", pagesize: 180, pageindex: pageindex, str: "<%=str%> " },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (msg) {
                        var html = "";

                        for (var i = 0; i < msg.count; i++) {

                            html += '<li ><a href=adress.aspx?create=' + msg.ds[i].wx_openid + '&id=' + msg.ds[i].id + ' style="color:#999999" class="item-link item-content" > <div class="item-media"><img src="' + msg.ds[i].extStr2 + '" style="width: 2.2rem;"></div>  <div class="item-inner"><div class="item-title-row">    <div class="item-title">' + msg.ds[i].extStr + '</div>  </div> </div></a></li>';


                        }
                        $('.theme-dark .mlgb').append(html);



                    },
                    error: function (x, e) {
                        alert("Error" + x.responseText);
                    }
                }
                )
            }

    </script>
   
</head>

<body>
  <form runat="server">
   <div class="page-group">
        <div class="page page-current">
          
              <header class="bar bar-nav">
    <h1 class='title'>兰州招商银行</h1>
  </header>

  <div class="content">
    <div class="content-block" >
    <p>选择客服身份</p>
 <asp:TextBox ID="picker"  runat="server"></asp:TextBox>
          <p><a href="#" class="button button-fill open-panel" onclick="getajaxs()" >在线聊天</a></p>
    </div>
  </div>
</div>

<div class="panel-overlay"></div>
<!-- Left Panel with Reveal effect -->

<div class="panel panel-left panel-reveal theme-dark"  >
  <div class="content-block" >
    <div style="font-size:15px;font-weight:bold;color:green">会话消息</div>
        <div class="list-block media-list inset">
    <ul class="mlgb"></ul>
      </div>
     <p style="float:right;"><a href="#" class="close-panel"  style="color:white;font-size:15px;font-synthesis:weight">关闭</a></p>  
  </div>
    
 
    </div>
    </div>
      </form>
        <script type='text/javascript' src='//g.alicdn.com/sj/lib/zepto/zepto.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='//g.alicdn.com/msui/sm/0.6.2/js/sm.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='//g.alicdn.com/msui/sm/0.6.2/js/sm-extend.min.js' charset='utf-8'></script>
   <script>
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
</script>
    </body>

</html>

