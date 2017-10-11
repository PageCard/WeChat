<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adress.aspx.cs" Inherits="XCWeiXin.Web.Web_tell.adress" %>

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
    <script>
        var html = "";
        window.onload = showLogin();

        var c = 0;
        function showLogin() {
            setInterval("Gatajax()", "1000");
        }

        function removes() {
            $('.content .card').remove();
        }


        function Gatajax() {
            removes();
            $.ajax(
                {
                    url: "GetData.ashx",
                    data: { type: "back", stt: "<%=str%> " },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (msg) {
                        var html = "";



                        for (var i = 0; i < msg.count; i++) {




                            html += '<a style="color:#6D727B" href="huifu.aspx?&id=' + msg.ds[i].id + '&openid=' + msg.ds[i].wx_openid + '&request=' + msg.ds[i].reponseContent + '&createdata=' + msg.ds[i].createDate + '"> <div class="card"> <div  class="card-header"><img src="' + msg.ds[i].extStr2 + '" width=20px ; height=20px  alt="上海鲜花港 - 郁金香" />' + msg.ds[i].extStr + '</div>  <div class="card-content"> <div class="card-content-inner">' + '发送消息:' + msg.ds[i].requestContent + '</br>' + '回复：' + msg.ds[i].reponseContent + '</div> </div> <div class="card-footer">' + msg.ds[i].createDate + '</div></div></a>';

                        }

                        $('.content ').append(html);



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
    <form id="form1" runat="server">
  
      
            <!-- 你的html代码 -->
            <div class="content">
                <div class="content-block-title">会话消息详情</div>
               
    <!--<div class="card-header">卡头</div>
    <div class="card-content">
      <div class="card-content-inner">头和尾l的卡片。卡头是用来显示一些额外的信息，或自定义操作卡标题和页脚。</div>
    </div>
    <div class="card-footer">卡脚</div>
                    -->
        
              
       </div>
 
    </form>
</body>
</html>