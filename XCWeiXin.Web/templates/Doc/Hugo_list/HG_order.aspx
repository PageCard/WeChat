<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HG_order.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.Hugo_list.HG_order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>护工学院</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
   <script type="text/javascript" src="js/jquery.min.js"></script>
    <link href="../../../sui/css/sm.css?v=1.0" rel="stylesheet" />
    <link href="../../../sui/Fire/iconfont.css" rel="stylesheet" />
    
    <script src="../../../scripts/jquery.min.js"></script>
  <script>
      function ajax_update()
      {
        
          var text = document.getElementById("text_t").value;
          alert(text);
          $.ajax(
              {
                  url: "list_l.ashx",
                  data: { action:"upload_start",order_number:'<%=order_number%>',text:"进行中"},
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: true,
                  cache: false,
                  success: function (msg)
                  {
                      if (msg.errCode == "false") {
                          alert("接单成功！");
                          document.getElementById("text_t").text = "进行中";
                      }
                      else {
                          alert("有问题！");

                      }

                  }


              })
      }
  </script>
   <style>
       .top {
       font-size:14px;                                                                                                                           
       }
       .bottom {
       font-size:14px;
       }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="bar bar-nav">
   <h1 class="title"><span class="icon icon-dingdanguanli"></span>订单管理</h1>
   
  </header>
         <nav class="bar bar-tab">
    
  <div > <asp:Button ID="Button1" CssClass="button button-big button-fill" OnClick="Button1_Click"  style="margin-top:-5px" runat="server" />
  </div>
     </nav>     

  <div class="content">
      
   <div class="content-block-title">联系人信息</div>
  <div class="list-block bottom">
    <ul>
      <li class="item-content" >
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">姓名</div>
          <div class="item-after"><%=name %></div>
        </div>
      </li>
      <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">性别</div>
          <div class="item-after"><%=nur_sex %></div>
        </div>
      </li>
         <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">联系电话</div>
          <div class="item-after"><%=tel %></div>
        </div>
      </li>
    </ul>
  </div>
  <div class="content-block-title">被护理人信息</div>
  <div class="list-block bottom">
    <ul>
      <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">姓名</div>
          <div class="item-after"><%=by_name %></div>
        </div>
      </li>
       <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">性别</div>
          <div class="item-after"><%=by_sex %></div>
        </div>
      </li>
          <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">年龄</div>
          <div class="item-after"><%=by_age %></div>
        </div>
      </li>
          <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">自理能力</div>
          <div class="item-after"><%=by_care %></div>
        </div>
      </li>
          <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">护理地址</div>
          <div class="item-after"><%=by_adress %></div>
        </div>
      </li>
        
    </ul>
  </div>
      <div class="content-block-title">服务选项</div>
       <div class="list-block bottom">
    <ul>
      <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">服务时间</div>
          <div class="item-after"><%=server_time %></div>
        </div>
      </li>
       <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">服务天数</div>
          <div class="item-after"><%=server_day %></div>
        </div>
      </li>
          <li class="item-content">
        <div class="item-media"><i class="icon icon-f7"></i></div>
        <div class="item-inner">
          <div class="item-title">备注</div>
          <div class="item-after"> <textarea id="TextArea1" cols="20" rows="2"><%=Str_sm %></textarea></div>
        </div>
      </li>
        <asp:HiddenField ID="HiddenField1" runat="server" />
         <asp:HiddenField ID="HiddenField2" runat="server" />
         
        
    </ul>
  </div>
  

      </div>
    </form>
        <script type='text/javascript'  src="../../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../../sui/js/sm.min.js" charset='utf-8'></script>
</body>
</html>
