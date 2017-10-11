<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XCWeiXin.Web.weixin.dati.index" %>
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
    <title><%=htmlTitle%></title> 
   <script src="/sui/js/zepto.js"></script>   
   
    <link href="/sui/css/sm.css" rel="stylesheet">
    <link href="css/css1.css" rel="stylesheet" type="text/css">     
    <style>
        .page{background:<%=bjcolor%>;}
    </style>
    <script type="text/javascript">

      //  var intDiff = parseInt(120*60); //倒计时总秒数量

        function timer(intDiff) {
            $("#bntnext").hide();
            window.setInterval(function () {
                var day = 0,
		hour = 0,
		minute = 0,
		second = 0; //时间默认值		
                if (intDiff > 0) {
                    day = Math.floor(intDiff / (60 * 60 * 24));
                    hour = Math.floor(intDiff / (60 * 60)) - (day * 24);
                    minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
                    second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
                }
                if (minute <= 9) minute = '0' + minute;
                if (second <= 9) second = '0' + second;              
                $('#hour_show').html('<s id="h"></s>' + hour + ':');
                $('#minute_show').html('<s></s>' + minute + ':');
                $('#second_show').html('<s></s>' + second + '');
                intDiff--;
            }, 1000);
        }

       
</script>

</head>
<body >
<form id="form1" runat="server">
<div class="page-group">
<div class="page" id="home">
 <div class="content">
<div class="headimg"><img src="<%=headimg%>" /></div>


 <!--成绩-->     
 <%if(isusersub){%> 
  <!--<div class="card">
    <div class="card-header">成绩单</div>
    <div class="card-content bor-top">
      <div class="card-content-inner">你在本次答题中获得：<% =usersum%>分</div>
    </div>   
  </div>-->
   <%} %>  
 <!--成绩　end--> 

 <!--活动说明-->     
  <div class="card">
    <div class="card-header">活动说明</div>
    <div class="card-content bor-top">
      <div class="card-content-inner"><%=summary%></div>
    </div>   
  </div>
 <!--按钮开始-->  
 <%if(!isusersub){%> 
   <div class="content-block-title">
   <a href="#step" id="bntnext" class="button button-big button-fill button-danger" onclick="timer(parseInt(<%=dtime %>*60))">开始答题</a>      
   </div>
   <%} %>  
    </div>
    </div>
<!--题目-->
<div class="page" id='step'>
  <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left back" href="/docs-demos/router">
      <span class="icon icon-left"></span>返回</a>
    <h1 class='title'>共<%=dxgetnum %>题</h1>
    <a class="time-item pull-right icon icon30" >	
	<span id="hour_show">00:</span>
	<span id="minute_show">00:</span>
	<span id="second_show">00</span>
</a><!--倒计时模块-->
  </header>
  <div class="content">
 
  <%for (int i = 0; i < dxDT.Tables[0].Rows.Count; i++)
    { %>  
    <input type="hidden" id="re<%=i %>val" value="" />
    <input type="hidden" id="re<%=i %>sc" value="<%=dxDT.Tables[0].Rows[i]["score"]%>" />
    <input type="hidden" id="re<%=i %>an" value="<%=dxDT.Tables[0].Rows[i]["answer"]%>" />
      <div class="card-content-inner" style="color:#fff"><%=i+1 %>. <%=dxDT.Tables[0].Rows[i]["title"]%></div>  
    <div class="list-block media-list inset bor-top" style=" margin-top:0;">     
      <ul>
      
      <%if (dxDT.Tables[0].Rows[i]["xA"] != "")
        { %>
        <li>
          <label class="label-checkbox item-content" onclick="getreval('<%=i %>','A')">
            
            <input type="radio" name="my-radio<%=i+1 %>">
            <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
            <div class="item-inner">
              A. <%=dxDT.Tables[0].Rows[i]["xA"]%>              
            </div>
          </label>
        </li>
        <%} %>
      <%if (dxDT.Tables[0].Rows[i]["xB"] != "")
        { %>
        <li>
          <label class="label-checkbox item-content" onclick="getreval(<%=i %>,'B')">
            <input type="radio" name="my-radio<%=i+1 %>">
            <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
            <div class="item-inner">
              B. <%=dxDT.Tables[0].Rows[i]["xB"]%>              
            </div>
          </label>
        </li>
        <%} %> 
              <%if (dxDT.Tables[0].Rows[i]["xC"] != "")
        { %>
        <li>
          <label class="label-checkbox item-content" onclick="getreval(<%=i %>,'C')">
            <input type="radio" name="my-radio<%=i+1 %>">
            <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
            <div class="item-inner">
              C. <%=dxDT.Tables[0].Rows[i]["xC"]%>              
            </div>
          </label>
        </li>
        <%} %>    
           <%if (dxDT.Tables[0].Rows[i]["xD"] != "")
        { %>
        <li>
          <label class="label-checkbox item-content" onclick="getreval(<%=i %>,'D')">
            <input type="radio" name="my-radio<%=i+1 %>">
            <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
            <div class="item-inner">
              D. <%=dxDT.Tables[0].Rows[i]["xD"]%>              
            </div>
          </label>
        </li>
        <%} %> 
          <%if (dxDT.Tables[0].Rows[i]["xE"] != "")
        { %>
        <li>
          <label class="label-checkbox item-content" onclick="getreval(<%=i %>,'E')">
            <input type="radio" name="my-radio<%=i+1 %>">
            <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
            <div class="item-inner">
              E. <%=dxDT.Tables[0].Rows[i]["xE"]%>              
            </div>
          </label>
        </li>
        <%} %>
              <%if (dxDT.Tables[0].Rows[i]["xF"] != "")
        { %>
        <li>
          <label class="label-checkbox item-content" onclick="getreval(<%=i %>,'F')">
            <input type="radio" name="my-radio<%=i+1 %>">
            <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
            <div class="item-inner">
              F. <%=dxDT.Tables[0].Rows[i]["xF"]%>              
            </div>
          </label>
        </li>
        <%} %>
      </ul>
    </div>     

  <%} %>
  <div class="content-block">
<a href="javascript:void 0" class="button button-big button-fill button-danger" onclick="bntajax()" id="bnt">提交答卷</a>

  </div>
  <div  class="content-block" style="text-align:center; background:#ff0000"  >
  <a href="index.aspx?wid=<%=wid %>&id=<%=id %>&v=1" class="external" id="next" style=" color:#fff" >再来一次</a>
  </div>
  </div>
</div>
<!--题目 end -->
<!--结果显示-->

    <div class="page" id="datiend">
 <div class="content">
<div class="headimg"><img src="<%=headimg%>" /></div>
 <!--成绩-->     

  <div class="card">
    <div class="card-header">提示</div>
    <div class="card-content bor-top">
      <div class="card-content-inner">你的机会已用完</div>
    </div>   
  </div>
 
 <!--成绩　end--> 

    </div>
    </div>
    <!--结果显示　end-->

    <!--结果显示-->

    <div class="page" id="hongbaoshow">
 <div class="content">
<div class="headimg"><img src="<%=headimg%>" /></div>
 <!--成绩-->     

  <div class="card">
    <div class="card-header">提示</div>
    <div class="card-content bor-top">
      <div class="card-content-inner">你获得了一次讨红包机会，请输入“向兰小招讨红包”领取红包吧</div>
    </div>   
  </div>
 
 <!--成绩　end--> 

    </div>
    </div>
    <!--结果显示　end-->
    </div>
</form>
<script src="/sui/js/sm.min.js"></script>
<script>

$("#next").hide();

var count=parseInt(<%=dxgetnum %>);
//------取选取值
    function getreval(id,reval) {  
$("#re" + id + "val").val(reval);
     }
//------ajax
function bntajax(){
//生成数据
var getsum=0;
for(var i=0;i<count;i++)
{
var reval=$("#re" + i + "val").attr("value");
var rean=$("#re" + i + "an").attr("value");
var resc=$("#re" + i + "sc").attr("value");
if(reval=="")
{
$.toast("试卷有未完成的题目！");  
return;
}
if(reval==rean)
{
getsum+=parseInt(resc);
}
}

/////

  $.ajax({
            url: "dati_ajax.ashx",
            dataType: "json",
            data: {wid:"<%=wid %>",aid:"<%=id %>",atitle:"<%=htmlTitle%>",usersum:getsum,myact: "userinfoAdd",rad: Math.random() },                       
            success: function (data) {  
          
                 if(data.re=="err")
                 {
                  $.toast(data.content);  
                 }
                 else if(data.re=="OK")
                 {
                 
                 
                  $("#cjscore").html(data.cjscore);
                 if(data.isnum=="false")
                 {
                   $("#bnt").remove();
                   // $.router.load("#datiend");
                    $.router.load("#hongbaoshow");
                    $.toast(data.content);  
                 }
                else{
               $("#next").show();
               $("#bnt").remove();
               
               $.toast(data.content);  
                }
                   
                 }   
                
            }

            });
        
}
</script>  
</body>
</html>
