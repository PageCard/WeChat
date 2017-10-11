<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XCWeiXin.Web.weixin.dzp.index" %>
<% 
    if (ErrLevel < 100)
   {
       Response.Write(ErrorInfo);
   }
   else if (ErrLevel == 101)  
   {  //活动已结束，跳转到结束页面
%>
<script type="text/javascript">
    window.location.href = "end.aspx?wid="+<%=wid%>+"&aid="+<%=aid%>+"&openid="+<%=openid%>+";";
</script>
<%
   }
   else
   {  %>
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
    <title>幸运大转盘抽奖</title> 
    <script type="text/javascript" src="/scripts/jquery.min-1.11.1.js"></script>
    <script src="/scripts/jquery/alert.js" type="text/javascript"></script>
     <script src="js/awardRotate.js" type="text/javascript"></script>
    <link href="css/activity-style1.css" rel="stylesheet" type="text/css">     
    <style>
        .activity-lottery-winning{ background: url(images/beijing.gif) repeat scroll 0 0 #7E65AB;background-size: 120px auto;overflow: hidden;        }
    </style>
</head>
<body class="activity-lottery-winning">
    <form id="form1" runat="server">
        <div class="main">

            <asp:HiddenField ID="hidStatus" runat="server" Value="" EnableViewState="false" />
            <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
            <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />
            <div id="outercont">



<img src="<%=jpimg[0] %>" id="img0" style="display:none;" />
<img src="<%=jpimg[1] %>" id="img1" style="display:none;" />
<img src="<%=jpimg[2] %>" id="img2" style="display:none;" />
<img src="<%=jpimg[3] %>" id="img3" style="display:none;" />
<img src="<%=jpimg[4] %>" id="img4" style="display:none;" />
<img src="<%=jpimg[5] %>" id="img5" style="display:none;" />
<img src="<%=jpimg[6] %>" id="img6" style="display:none;" />
<img src="<%=jpimg[7] %>" id="img7" style="display:none;" />
<img src="<%=jpimg[8] %>" id="img8" style="display:none;" />
<img src="<%=jpimg[9] %>" id="img9" style="display:none;" />
<div class="banner">
<div class="turnplate" style="background-image:url(images/turnplate-bg.png);background-size:100% 100%;">
<canvas class="item" id="wheelcanvas" width="422px" height="422px"></canvas>
<img class="pointer" id="inner" src="images/turnplate-pointer.png"/>
</div>
</div>


            
            </div>
            <div class="content">
                <div class="boxcontent boxwhite" id="zjl" style="display: none">

                    <div class="box">
                        <div class="title-orange"><span>恭喜你中奖了</span></div>
                        <div class="Detail">

                            <p>你中了：<span class="red" id="prizetype"><asp:Literal ID="litzjlJP" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p>兑奖SN码：<span class="red" id="sncode"><asp:Literal ID="litzjlSN" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p class="red">
                                <asp:Literal ID="litContentInfo" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                            <p>
                                <input name="" class="px" id="tel" value="" type="text" placeholder="用户请输入您的手机号">
                            </p>

                            <asp:Literal ID="litPwd" runat="server" EnableViewState="false" Text=""></asp:Literal>
                            <p>
                                <input class="pxbtn" name="提 交" id="save-btn" type="button" value="用户提交">
                            </p>
                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite" id="result" style="display: none;">
                    <div class="box">
                        <div class="title-orange"><span>恭喜你中奖了</span></div>
                        <div class="Detail">
                            <p>你中了：<span class="red" id="jiangping"><asp:Literal ID="litJp" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p>兑奖sn码为：<span class="red" id="jpsn"><asp:Literal ID="litSNM" runat="server" EnableViewState="false"></asp:Literal></span></p>
                            <p class="red">你已经兑奖成功，本SN码自定作废!</p>
                        </div>


                    </div>
                </div>



                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red"><span>奖项设置：</span></div>

                        <div class="Detail">
                            <asp:Literal ID="litOtherTip" runat="server" EnableViewState="false"></asp:Literal>
                            <asp:Literal ID="litJiangXing" runat="server" EnableViewState="false"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red">活动说明：</div>
                        <div class="Detail">
                            <p class="red">
                                本次活动每天可以转
                            <asp:Literal ID="litdaysTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次,总共可以转 
                            <asp:Literal ID="littotTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次 你已经转了 <span id="zhuantimes">
                                    <asp:Literal ID="litHasUsedTimes" runat="server" EnableViewState="false"></asp:Literal></span> 次
                            </p>
                            <p>
                                <asp:Literal ID="litRemark" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>


            <script type="text/javascript">

                 
            var thisurl= document.URL;
            var wid = <%=wid%>;
            var aid =<%=aid%>;
            var status = $("#hidStatus").val();
            var showInfo = $("#hidErrInfo").val();
            var openid ="<%=openid%>";
            var jxname="";
            var jpname="";
            var cjtip="";
           
            var zhuantimes=parseInt( $("#zhuantimes").text());
                
           
            <% if (isZhJing)
            { %>
            $("#outercont").hide();
            $("#result").show();
            <%} %>
            if (status == "2") {
            $("#outercont").hide();

            }
            else if(status=="100")
            {
            $("#outercont").hide();
            $("#result").hide();
            $("#zjl").show();
            }


            //--------------大转盘
            var turnplate={
            restaraunts:[],				//大转盘奖品名称
            colors:[],					//大转盘奖品区块对应背景颜色
            outsideRadius:192,			//大转盘外圆的半径
            textRadius:155,				//大转盘奖品位置距离圆心的距离
            insideRadius:68,			//大转盘内圆的半径
            startAngle:0,				//开始角度
		
            bRotate:false				//false:停止;ture:旋转
            };

            $(document).ready(function(){
            //动态添加大转盘的奖品与奖品区域背景颜色
            turnplate.restaraunts = [<%=jxnamelist %>];
            turnplate.colors = ["#FFF4D6", "#FFFFFF", "#FFF4D6", "#FFFFFF","#FFF4D6", "#FFFFFF", "#FFF4D6", "#FFFFFF","#FFF4D6", "#FFFFFF"];

	
            var rotateTimeOut = function (){
            $('#wheelcanvas').rotate({
            angle:0,
            animateTo:2160,
            duration:8000,
            callback:function (){
            alert('网络超时，请检查您的网络设置！');
            }
            });
            };

            //旋转转盘 item:奖品位置; txt：提示语;
            var rotateFn = function (item, txt){   
            var angles = item * (360 / turnplate.restaraunts.length) - (360 / (turnplate.restaraunts.length*2));
            if(angles<270){
            angles = 270 - angles; 
            }else{
            angles = 360 - angles + 270;
            }
            $('#wheelcanvas').stopRotate();
            $('#wheelcanvas').rotate({
            angle:0,
            animateTo:angles+1800,
            duration:8000,
            callback:function (){
            //  alert(cjtip);
           
            //}
               
            turnplate.bRotate = !turnplate.bRotate;
            }
            });
            };

            $('.pointer').click(function (){
    
		
            //获取随机数(奖品个数范围内 )
            //ajax
            if (status == "2") {
            alert(showInfo);
            }
            $("#zhuantimes").text(++zhuantimes);
            $.ajax({
            url: "dzpAct.ashx",
            dataType: "json",
            data: {openid: openid,myact: "choujiang",aid: aid,wid:wid,rad: Math.random() },                       
            success: function (data) {    
                      
            if (data.error == "sys" ||data.error == "nostart" ) {//错误提示
                    setTimeout(function () { 
                    alert(data.content)
                    }, 6000);                                    
                    return
            }
            else if(data.error=="notimes")//没有抽奖次数了
            {                                           
                    $("#inner").unbind('click');             
                                                              
            }
            else if (data.error=="succ") {//抽到有效奖时
                    //启动
                    $("#hidAwardId").val(data.uid);
                    if(turnplate.bRotate)return;
                    turnplate.bRotate = !turnplate.bRotate;
                    var item =parseInt(data.sortid);
                    rotateFn(item, turnplate.restaraunts[item-1]);		
                    console.log(item);
                    //输出
                    setTimeout(function () {
                    //alert(data.content)
                    $("#sncode").text(data.sn);
                    $("#jpsn").text(data.sn);
                    $("#jiangping").text(data.jxname+" "+data.jpname);
                    $("#prizetype").text(data.jxname+" "+data.jpname);
                    $("#zjl").slideToggle(500);
                    $("#outercont").slideUp(500);
                    }, 7000);  
            }
            else if (data.error=="nexttimes") {  //未到抽奖次数时继续抽奖
                    //启动
                    if(turnplate.bRotate)return;
                    turnplate.bRotate = !turnplate.bRotate;
                    var item =parseInt(data.sortid);
                    rotateFn(item, turnplate.restaraunts[item-1]);		
                    console.log(item);
                    //输出
                    setTimeout(function () { 
                    alert(data.content)
                    }, 6000);      
            }
             else if (data.error=="moretimes") {  //获得再来一次的机会
                     //启动
                    if(turnplate.bRotate)return;
                    turnplate.bRotate = !turnplate.bRotate;
                    var item =parseInt(data.sortid);
                    rotateFn(item, turnplate.restaraunts[item-1]);		
                    console.log(item);
                    //输出
                    setTimeout(function () { 
                    alert(data.content)
                    }, 6000);      
             }
            else {//其它信息提示
                    setTimeout(function () { 
                    alert(data.content)
                    }, 6000);      
                             
            }
                          
            }


            })
               
            //ajax end
            //奖品数量等于10,指针落在对应奖品区域的中心角度[252, 216, 180, 144, 108, 72, 36, 360, 324, 288]
	


            });
            });



            function rnd(n, m){
            var random = Math.floor(Math.random()*(m-n+1)+n);
            return random;
	
            }


            //页面所有元素加载完毕后执行drawRouletteWheel()方法对转盘进行渲染
            window.onload=function(){
            drawRouletteWheel();
            };

            function drawRouletteWheel() {    
            var canvas = document.getElementById("wheelcanvas");    
            if (canvas.getContext) {
            //根据奖品个数计算圆周角度
            var arc = Math.PI / (turnplate.restaraunts.length/2);
            var ctx = canvas.getContext("2d");
            //在给定矩形内清空一个矩形
            ctx.clearRect(0,0,422,422);
            //strokeStyle 属性设置或返回用于笔触的颜色、渐变或模式  
            ctx.strokeStyle = "#FFBE04";
            //font 属性设置或返回画布上文本内容的当前字体属性
            ctx.font = '16px Microsoft YaHei';      
            for(var i = 0; i < turnplate.restaraunts.length; i++) {       
            var angle = turnplate.startAngle + i * arc;
            ctx.fillStyle = turnplate.colors[i];
            ctx.beginPath();
            //arc(x,y,r,起始角,结束角,绘制方向) 方法创建弧/曲线（用于创建圆或部分圆）    
            ctx.arc(211, 211, turnplate.outsideRadius, angle, angle + arc, false);    
            ctx.arc(211, 211, turnplate.insideRadius, angle + arc, angle, true);
            ctx.stroke();  
            ctx.fill();
            //锁画布(为了保存之前的画布状态)
            ctx.save();   
		  
            //----绘制奖品开始----
            ctx.fillStyle = "#E5302F";
            var text = turnplate.restaraunts[i];
            var line_height = 17;
            //translate方法重新映射画布上的 (0,0) 位置
            ctx.translate(211 + Math.cos(angle + arc / 2) * turnplate.textRadius, 211 + Math.sin(angle + arc / 2) * turnplate.textRadius);
		  
            //rotate方法旋转当前的绘图
            ctx.rotate(angle + arc / 2 + Math.PI / 2);
		  
            /** 下面代码根据奖品类型、奖品名称长度渲染不同效果，如字体、颜色、图片效果。(具体根据实际情况改变) **/
            if(text.indexOf("p")>0){//流量包
            var texts = text.split("p");
            for(var j = 0; j<texts.length; j++){
            ctx.font = j == 0?'bold 20px Microsoft YaHei':'16px Microsoft YaHei';
            if(j == 0){
            ctx.fillText(texts[j]+"", -ctx.measureText(texts[j]+"p").width / 2, j * line_height);
            }else{
            ctx.fillText(texts[j].replace("p",""), -ctx.measureText(texts[j]).width / 2, j * line_height);
            }
            }
            }else if(text.indexOf("p") == -1 && text.length>6){//奖品名称长度超过一定范围 
            text = text.substring(0,6)+"||"+text.substring(6);
            var texts = text.split("||");
            for(var j = 0; j<texts.length; j++){
            ctx.fillText(texts[j], -ctx.measureText(texts[j]).width / 2, j * line_height);
            }
            }else{
            //在画布上绘制填色的文本。文本的默认颜色是黑色
            //measureText()方法返回包含一个对象，该对象包含以像素计的指定字体宽度
            ctx.fillText(text, -ctx.measureText(text).width / 2, 0);
            }
		
            //添加对应图标	
            var img= document.getElementById("img"+i);			
            ctx.drawImage(img,-35,25,50,50); 			
            //把当前画布返回（调整）到上一个save()状态之前 
            ctx.restore();
            //----绘制奖品结束----
            }     
            } 
            }

         
            //大转盘end         

          
            $("#save-btn").bind("click",
            function () {
            var btn = $(this);
              
            var tel = $("#tel").val();
            var pwd = "";
            var hidAwardId = $("#hidAwardId").val();
            if ($("#parssword").length>0 &&  $.trim($("#parssword").val()) == "") {
            alert("请输入兑奖密码!");
            return
            }

            if ($.trim(tel) == "") {
            alert("请输入手机号!");
            return
            }
            if($("#parssword").length>0){
            pwd= $("#parssword").val();
            }
            var rad = Math.random();
                 
            var submitData = {
            id: hidAwardId,
            aid: aid,
            pwd: pwd,
            snumber:$("#sncode").text(),
            tel: tel,
            rad: rad,
            openid:openid
            };
                 
            $.post('dzpAct.ashx?myact=update', submitData,
            function (data) {
            if (data.success == "1") {
            alert("提交成功！");
            $("#result").slideToggle(500);
            $("#zjl").slideToggle(500);
            $("#outercont").slideUp(500);

            } else {
            alert(data.msg);
            }
            },
            "json") 

            });

           
            </script>
        <script type="text/javascript">
            document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
                window.shareData = {
                    "imgUrl": "",
                    "timeLineLink":  thisurl + "&is_share=1",
                    "sendFriendLink":  thisurl + "&is_share=1",
                    "weiboLink":  thisurl + "&is_share=1",
                    "tTitle": "<%=dzpAction.actName%>",
                    "tContent": "请关注后，再来抽奖。<%=dzpAction.brief%>",
                    "fTitle": "请关注后，再来抽奖。<%=dzpAction.actName%>",
                    "fContent": "请关注后，再来抽奖。<%=dzpAction.brief%>",
                    "wContent": "请关注后，再来抽奖。<%=dzpAction.brief%>"
                };
                // 发送给好友
                WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                    WeixinJSBridge.invoke('sendAppMessage', {
                        "img_url": window.shareData.imgUrl,
                        "img_width": "640",
                        "img_height": "640",
                        "link": window.shareData.sendFriendLink,
                        "desc": window.shareData.fContent,
                        "title": window.shareData.fTitle
                    }, function (res) {
                        _report('send_msg', res.err_msg);
                    })
                });

                // 分享到朋友圈
                WeixinJSBridge.on('menu:share:timeline', function (argv) {
                    WeixinJSBridge.invoke('shareTimeline', {
                        "img_url": window.shareData.imgUrl,
                        "img_width": "640",
                        "img_height": "640",
                        "link": window.shareData.timeLineLink,
                        "desc": window.shareData.tContent,
                        "title": window.shareData.tTitle
                    }, function (res) {
                        _report('timeline', res.err_msg);
                    });
                });

                // 分享到微博
                WeixinJSBridge.on('menu:share:weibo', function (argv) {
                    WeixinJSBridge.invoke('shareWeibo', {
                        "content": window.shareData.wContent,
                        "url": window.shareData.weiboLink,
                    }, function (res) {
                        _report('weibo', res.err_msg);
                    });
                });
            }, false)
        </script>


    </form>
</body>
</html>
<% }%>