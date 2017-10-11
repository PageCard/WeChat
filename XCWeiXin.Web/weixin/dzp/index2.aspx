<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="XCWeiXin.Web.weixin.dzp.index2" %>

<% 
    if (ErrLevel < 100)
    {
        Response.Write(ErrorInfo);
    }
    else if (ErrLevel == 101)
    {  //活动已结束，跳转到结束页面
        Response.Redirect("end.aspx?wid="+wid+"&aid="+aid+"&openid="+openid);
     }
    else
    { 
    %>
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
    <title>九宫格抽奖游戏</title> 
   <script src="/sui/js/zepto.js"></script>   
   <script src="/sui/js/sm.min.js"></script>
    <link href="/sui/css/sm.css" rel="stylesheet">
    <link href="css/activity-style2.css" rel="stylesheet" type="text/css">     
    <style>
        .page{background:#FFD818;background-size: contain;overflow: hidden;}
    </style>
</head>
<body >
<form id="form1" runat="server">
 <div class="page-group">
<div class="page">
 <div class="content">
    
        <div class="main">
        <img src="images/9bj.png" width="100%" />
            <asp:HiddenField ID="hidStatus" runat="server" Value="" EnableViewState="false" />
            <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
            <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />
           
            <div id="outercont">


            <div id="lottery">
	<table border="10" cellpadding="10" cellspacing="10"  bordercolor="#A63400" align="center" >
  <tr>
    <td class="lottery-unit lottery-unit-0"><img src="<%=jpimg[0] %>"><h5><%=jpname[0] %></h5></td>
    <td class="lottery-unit lottery-unit-1"><img src="<%=jpimg[1] %>"><h5><%=jpname[1] %></h5></td>
    <td class="lottery-unit lottery-unit-2"><img src="<%=jpimg[2] %>"><h5><%=jpname[2] %></h5></td>
  </tr>
  <tr>
    <td class="lottery-unit lottery-unit-7"><img src="<%=jpimg[7] %>"><h5><%=jpname[7] %></h5></td>
    <td class="chink"><h3>我要<br />抽奖</h3></td>
    <td class="lottery-unit lottery-unit-3"><img src="<%=jpimg[3] %>"><h5><%=jpname[3] %></h5></td>
  </tr>
  <tr>
    <td class="lottery-unit lottery-unit-6"><img src="<%=jpimg[6] %>"><h5><%=jpname[6] %></h5></td>
    <td class="lottery-unit lottery-unit-5"><img src="<%=jpimg[5] %>"><h5><%=jpname[5] %></h5></td>
    <td class="lottery-unit lottery-unit-4"><img src="<%=jpimg[4] %>"><h5><%=jpname[4] %></h5></td>
  </tr>
</table>
</div>
 <h6 class="h61">您每天可以转<asp:Literal ID="litdaysTimes" runat="server" EnableViewState="false"></asp:Literal>次,总共可以转
 <asp:Literal ID="littotTimes" runat="server" EnableViewState="false"></asp:Literal>次 你已经转了 
 <span id="zhuantimes"><asp:Literal ID="litHasUsedTimes" runat="server" EnableViewState="false"></asp:Literal></span> 次
</h6>  
            </div>
           
                <div class="card" id="zjl" style="display: none">                  
                        <div class="card-header boxtitle_1">恭喜你中奖了</div>
                        <div class="card-content">
                        <div class="card-content-inner">
                            <p>你中了：<span class="red" id="prizetype"><asp:Literal ID="litzjlJP" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p>兑奖SN码：<span class="red" id="sncode"><asp:Literal ID="litzjlSN" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p class="red"><asp:Literal ID="litContentInfo" runat="server" EnableViewState="false"></asp:Literal></p>
                            <p><input name="" class="input1" id="tel" value="" type="text" placeholder="用户请输入您的手机号"></p>
                            <asp:Literal ID="litPwd" runat="server" EnableViewState="false" Text=""></asp:Literal>
                            <p><input class="button button-big button-fill button-danger" name="提 交" id="save-btn" type="button" value="用户提交"></p>
                        </div>
                        </div>
                    </div>
                

                <div class="card" id="result" style="display: none;">                   
                        <div class="card-header boxtitle_1">恭喜你中奖了</div>
                        <div class="card-content"> 
                        <div class="card-content-inner">
                            <p>你中了：<span class="red" id="jiangping"><asp:Literal ID="litJp" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p>兑奖sn码为：<span class="red" id="jpsn"><asp:Literal ID="litSNM" runat="server" EnableViewState="false"></asp:Literal></span></p>
                            <p class="red">你已经兑奖成功，本SN码自定作废!</p>
                        </div>
                    </div>
                </div>


                <div class="card">                  
                        <div class="card-header boxtitle_1">奖项设置</div>
                         <div class="card-content">
                        <div class="card-content-inner">
                            <asp:Literal ID="litOtherTip" runat="server" EnableViewState="false"></asp:Literal>
                            <asp:Literal ID="litJiangXing" runat="server" EnableViewState="false"></asp:Literal>
                        </div>
                        </div>                  
                </div>


                <div class="card">
                   
                        <div class="card-header boxtitle_1">活动说明</div>
                        <div class="card-content">
                        <div class="card-content-inner">
                         <asp:Literal ID="litRemark" runat="server" EnableViewState="false"></asp:Literal>
                        </div>
                    </div>
                </div>


            </div>

        
            
    </div>
    </div>

    </div>
</form>
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

//九宫格
   var lottery={
	index:-1,	//当前转动到哪个位置，起点位置
	count:0,	//总共有多少个位置
	timer:0,	//setTimeout的ID，用clearTimeout清除
	speed:20,	//初始转动速度
	times:0,	//转动次数
	cycle:50,	//转动基本次数：即至少需要转动多少次再进入抽奖环节
	prize:-1,	//中奖位置
    jpend:0,
	init:function(id){
		if ($("#"+id).find(".lottery-unit").length>0) {
			$lottery = $("#"+id);
			$units = $lottery.find(".lottery-unit");
			this.obj = $lottery;
			this.count = $units.length;
			$lottery.find(".lottery-unit-"+this.index).addClass("active");
		};
	},
	roll:function(){
		var index = this.index;
		var count = this.count;
		var lottery = this.obj;
		$(lottery).find(".lottery-unit-"+index).removeClass("active");
		index += 1;
		if (index>count-1) {
			index = 0;
		};
		$(lottery).find(".lottery-unit-"+index).addClass("active");
		this.index=index;
		return false;
	},
	stop:function(index){
		this.prize=index;
		return false;
	}
};

function roll(){
	lottery.times += 1;
	lottery.roll();
	if (lottery.times > lottery.cycle+10 && lottery.prize==lottery.index) {
		clearTimeout(lottery.timer);
		lottery.prize=-1;
		lottery.times=0;
		click=false;
	}else{
		if (lottery.times<lottery.cycle) {
			lottery.speed -= 10;
		}else if(lottery.times==lottery.cycle) {
			var index = Math.random()*(lottery.count)|0;
			lottery.prize = (lottery.jpend-1);		//控制最终落点
		}else{
			if (lottery.times > lottery.cycle+10 && ((lottery.prize==0 && lottery.index==3) || lottery.prize==lottery.index+1)) {
				lottery.speed += 110;
			}else{
				lottery.speed += 20;
			}
		}
		if (lottery.speed<40) {
			lottery.speed=40;
		};
		//console.log(lottery.times+'^^^^^^'+lottery.speed+'^^^^^^^'+lottery.prize);
		lottery.timer = setTimeout(roll,lottery.speed);
	}
	return false;
}

var click=false;

window.onload=function(){
	lottery.init('lottery');
	$("#lottery .chink").click(function(){ 




		if (click) {
			return false;
		}else{

        /////
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
                    $.toast(data.content);  
                    }, 6000);                                    
                    return
            }
            else if(data.error=="notimes")//没有抽奖次数了
            {                                           
                    $("#lottery a").unbind('click');             
                                                              
            }
            else if (data.error=="succ") {//抽到有效奖时
                    //启动
                      lottery.speed=100;
                      lottery.jpend=data.sortid;
                      $("#hidAwardId").val(data.uid);                   
			          roll();
			        click=true;
			      
                    //输出
                    setTimeout(function () {
                    //alert(data.content)
                    $("#sncode").text(data.sn);
                    $("#jpsn").text(data.sn);
                    $("#jiangping").text(data.jxname+" "+data.jpname);
                    $("#prizetype").text(data.jxname+" "+data.jpname);
                    $("#outercont").remove();
                    $("#zjl").show();
                    }, 6000);  
            }
            else if (data.error=="nexttimes") {  //未到抽奖次数时继续抽奖
                    //启动
                      lottery.speed=100;
                      lottery.jpend=data.sortid;
			          roll();
			        click=true;
			       
                    //输出
                    setTimeout(function () { 
                    $.toast(data.content);                    
                    }, 6000);     
            }
             else if (data.error=="moretimes") {  //获得再来一次的机会
                     //启动
                      lottery.speed=100;
                      lottery.jpend=data.sortid;
			          roll();
			        click=true;
			      
                    //输出
                    setTimeout(function () { 
                  //  $.toast(data.content);  
                    }, 6000);      
             }
            else {//其它信息提示
                    setTimeout(function () { 
              //      $.toast(data.content);  
                    }, 6000);      
                             
            }
                          
            }


            });
return false;  


        ////
			
		}
	});
};

         
            //九宫格end         

          
            $("#save-btn").bind("click",
            function () {
            var btn = $(this);
              
            var tel = $("#tel").val();
            var pwd = "";
            var hidAwardId = $("#hidAwardId").val();
           
            if ($("#parssword").length>0 &&  $.trim($("#parssword").val()) == "") {
          
            $.toast("请输入兑奖密码!");  
            return
            }

            if ($.trim(tel) == "") {
            
            $.toast("请输入手机号!");  
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
            $.toast("提交成功！");
            $("#zjl").remove();
            $("#result").show(500);
           
            

            } else {            
            $.toast(data.msg);
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



</body>
</html>
<% }%>