<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.detail" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>护理信息</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
  
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="shortcut icon" href="/favicon.ico">
    <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
   
   
     
    <link href="../../sui/new%20font/iconfont.css" rel="stylesheet" />
    <link href="../../sui/add/iconfont.css" rel="stylesheet" />

    <link href="js/time/new/datedropper.css" rel="stylesheet" />
    <link href="js/time/new/timedropper.min.css" rel="stylesheet" />
    
  <style>
      bady {
      
        
          font-size:12px;
          color:#CEC9C9;
      }
      a:link {
          color:black;
      }
      a:visited {
           color:black;

}
    
   
        .bar .icon {
      
         
          color:#0894EC;
        
      }

      .bar .tab-label {
      color:Background;    }
      .page a:hover {
          color:#0894EC;
    
      }
      .tont {
           font-size:16px;
      }
    .page-group #router2 a:visited {color:black;text-decoration:none; }
   .page-group #router2 a:active {color:black;text-decoration:none; } 
   .page-group #router2 a:hover {color:black;text-decoration:none; }
      .page-group #router1 a:hover {
      color:black;}
     
  </style> 
    
    <script>
        function cmd() {
            var a = document.getElementById("name").value;

            if (a == "") {

                Zepto.toast("姓名不能为空");
            }

        };
        function tel() {
            var mobile = document.getElementById("telnum").value;
            if (!(/^1[34578]\d{9}$/.test(mobile))) {
                Zepto.toast("手机号码有误，请重填");
                return false;
            }
        };
     
        function By_name() {
            var Byname = document.getElementById("by_name").value;
            if (Byname == "") {
                Zepto.toast("被护理人名称不能为空")
            }
        };
        function age() {
            var byage = document.getElementById("by_age").value;
            if (byage == "") {
                Zepto.toast("被护理人年龄不能为空");
            }
            
           
            
           
        };
        function daxiao()
        {
            var byage = document.getElementById("by_age").value;
            if (byage>100 ||byage<2) {
                Zepto.toast("请填写2-110年龄");

            }
        };
        function panduan()
        {
            var pickdate = document.getElementById("").value;
            if (pickdate == "")
            {
                alert("请选择日期")
            }
        }
        pickdate
        </script>
  
</head>
    
<body >
  <form runat="server">
    <div class="page-group">
        <div class="page page-current " id='router1'>
           <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left" href="javascript:history.go(-1)" data-transition='slide-out'>
      <span class="icon icon-arrowleft"></span>
       </a>
    <h1 class="title"><span class="icon icon-dingdanguanli"></span>护工来了</h1>
  </header>
        <nav class="bar bar-tab">
    
  <div >
      
     
      <asp:Button ID="suc" CssClass=" button button-big button-fill button-success " style=" background-color:#289ce5;margin-top:-5px" runat="server" Text="微信支付"  OnClick="suc_Click" />
         
        
  </div>
     </nav>    

  <div class="content"> 
   <div class="content-block-title">基本信息</div>
  
         
       <div class="list-block">
    <ul class="tont">
      <!-- Text inputs -->
      <li>
        <div class="item-content">
          <div class="item-media"><i class="icon icon-me"></i></div>
          <div class="item-inner">
            <div class="item-title label">姓名</div>
            <div class="item-input">
            
         <asp:TextBox ID="name" CssClass="item-after tont" Text="" style="text-align:right" runat="server" Font-Bold="true" placeholder="填写您的姓名" Font-Size="14px"></asp:TextBox>

            </div>
          </div>
        </div>
      </li>
       <li>
           
        <div class="item-content">
          <div class="item-media"><i class=" iconfont icon-xingbienan"></i></div>
          <div class="item-inner">
            <div class="item-title label">性别</div>
            <div class="item-input" >
              <select id="Select1" runat="server"  dir="rtl" style="font-size:14px" >
                <option>男</option>
                <option>女</option>
              </select>
            </div>
          </div>
        </div>
      </li> 
     <li>
        <div class="item-content">
          <div class="item-media"><i class="icon icon-lianxidianhua"></i></div>
          <div class="item-inner">
            <div class="item-title label">联系电话</div>
            <div class="item-input" onclick="cmd()">
            <asp:TextBox ID="telnum" TextMode="Phone" CssClass="item-after" Text="" runat="server" style="text-align:right" Font-Bold="true" Font-Size="14px" placeholder="填写您的联系电话" ></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
          
        
       
      
      <!-- Switch (Checkbox) -->
      <li>
          
        <div class="item-content">
          <div class="item-media"><i class="iconfont icon-12"></i></div>
          <div class="item-inner">
            <div class="item-title label">设为默认</div>
            <div class="item-input" style="text-align:right" onclick="tel()"   >
              <label class="label-switch"  >
                  <asp:CheckBox ID="CheckBox1" runat="server"  Checked="True" />
                <div class="checkbox" ></div>
              </label>
            </div>
          </div>
        </div>
      </li>
     
    </ul>
  </div>
         <div class="content-block-title">护理人信息</div>
       <div class="list-block" >
    <ul class="tont">
          <a href="#router2"> <li class="item-content item-link">
        <div class="item-media"><i class="icon icon-icongj"></i></div>
        <div class="item-inner">
          <div class="item-title">被护理人信息</div>
          <div class="item-after">
                <div class="item-input" >           
             
                <asp:TextBox ID="TextBox3" CssClass="item-after" Text="" runat="server" style="text-align:right" placeholder="填写被护理人信息" Font-Size="14px" ></asp:TextBox>
          </div>
          </div>
        </div>
              </li></a> 
    </ul>
           </div>
      <div class="content-block-title">服务选项</div>
   <div class="list-block">
    <ul class="tont">
      <li class="item-content">
        <div class="item-media"><i class="icon icon-hugong2"></i></div>
        <div class="item-inner">
          <div class="item-title">服务类型</div>
           
          <div class="item-after"><asp:Label ID="huli_type" CssClass="item-after" runat="server" Text="医院护理" Font-Bold="true" Font-Size="14px"></asp:Label></div>
        </div>
      </li>
        <li class="item-content item-link">
        <div class="item-media"><i class="icon icon-fuwushiduan"></i></div>
        <div class="item-inner tont">
          <div class="item-title label">服务护工</div>
        
          <div class="item-input" >           
             
                <asp:TextBox ID="TextBox2" CssClass="item-after" runat="server" style="text-align:right" placeholder="护理人" Font-Bold="true" Font-Size="14px" ReadOnly="true" ></asp:TextBox>
          </div>
        </div>
      </li>
          <a href="#time_text"><li class="item-content item-link">
        <div class="item-media"><i class="icon icon-fuwushiduan"></i></div>
        <div class="item-inner tont">
          <div class="item-title label">服务时间</div>
        
          <div class="item-input" >           
             
                <asp:TextBox ID="text_time" CssClass="item-after" Text="" runat="server" style="text-align:right" placeholder="护理时间" Font-Size="14px" ></asp:TextBox>
          </div>
        </div>
      </li></a>
      <li class="item-content item-link">
        <div class="item-media"><i class="icon icon-hugong2"></i></div>
        <div class="item-inner">
          <div class="item-title">服务价格</div>
           
          <div class="item-after"> 
                 <asp:TextBox ID="mony" CssClass="item-after" Text="" runat="server" style="text-align:right" placeholder="服务价格" ReadOnly="true" Font-Size="14px" ></asp:TextBox>
             </div>
        </div>
      </li>
       <%--  <li class="item-content item-link">
        <div class="item-media"><i class="icon icon-icongj"></i></div>
        <div class="item-inner">
          <div class="item-title label">服务价格</div>
             <asp:TextBox ID="TextBox3" CssClass="item-after" Text="" runat="server" style="text-align:right" placeholder="服务价格" Enabled="false" Font-Size="14px" ></asp:TextBox>
       <div class="item-after"> <asp:TextBox ID="picker" CssClass="item-after" name="picker" Text="请选择护理员等级" Font-Bold="true" runat="server" style="text-align:right" Font-Size="14px" ></asp:TextBox></div>
        </div>
     </li>--%>
         <li class="align-top">
        <div class="item-content">
          <div class="item-media"><i class="icon icon-shuoming"></i></div>
          <div class="item-inner">
            <div class="item-title label">补充说明</div>
            <div class="item-input">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Font-Size="14px" placeholder="填写病人病情注意事项" ></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
    </ul>
  </div>
      <asp:HiddenField ID="hid" runat="server" />
  </div>
            </div>
        
  
        <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
        <script>

            $("#picker").picker({
                toolbarTemplate: '<header class="bar bar-nav">\
  <button class="button button-link pull-right close-picker" onclick="textw()" >确定</button>\
  <h1 class="title">请选择护理员等级</h1>\
  </header>',
                cols: [
                  {
                      textAlign: 'center',
                      values: ['初级160/天', '中级190/天', '高级220/天（推荐）', '金牌260/天']


                      //如果你希望显示文案和实际值不同，可以在这里加一个displayValues: [.....]
                  }
                ]
            })

            ;
</script>

        <div class="page" id="time_text">
             <header class="bar bar-nav">
    <a onclick="time_val()" class="button button-link button-nav pull-left back" href="/docs-demos/router">
      <span class="icon icon-left"></span>
      返回
    </a>
    <h1 class='title'>选择护理时间</h1>
                 
  </header>
                         <nav class="bar bar-tab">
   <a href="#" class=" button button-big button-fill back" onclick="time_val();textw();">立即预约 </a>
      
 
     </nav>

  <div class="content">
   <div class="list-block demo" style="font-size:15px">
    <ul>
      <!-- Text inputs -->
      <li>
        <div class="item-content">
          <div class="item-media"><i class="iconfont icon-fuwushiduan"></i></div>
          <div class="item-inner">
            <div class="item-title label">护理日期</div>
            <div class="item-input">
              <asp:TextBox ID="pickdate" runat="server" Font-size="14px" placeholder="点击此处选择日期" ></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
      <li>
        <div class="item-content">
          <div class="item-media"><i class="icon icon-alarmclock"></i></div>
          <div class="item-inner">
            <div class="item-title label">护理时间</div>
            <div class="item-input">
             <asp:TextBox ID="picktime" runat="server" Font-size="14px" placeholder="点击此处选择时间"></asp:TextBox>
               
            </div>
          </div>
        </div>
      </li>
          <li>
        <div class="item-content">
          <div class="item-media"><i class="icon icon-huangou"></i></div>
          <div class="item-inner">
            <div class="item-title label">护理天数</div>
            <div class="item-input">
               
                  <input onclick="textw()" class="sdddq" value="1"  style="font-size:14px" name="inp" id="inp" /> 
            
            </div>
          </div>
        </div>
      </li>
 </ul>
       </div>
      <script>
          function time_val() {
              var pickdat = document.getElementById("pickdate").value;
              var picktim = document.getElementById("picktime").value;
              document.getElementById("text_time").value = pickdat + "/" + picktim;
          };
          function textw() {
              var a = document.getElementById("mony").value;
              var b = document.getElementById("inp").value;
              var num = a.replace(/[^0-9]/ig, "");
              document.getElementById("hid").value=(num*b);
              document.getElementById("suc").value = "应支付" + (num * b) + "¥";



          };
      </script>
      <style>
          .sdddq {
	font-family: "宋体";
	font-size: 20px;
	height: 50px;
	width: 150px;
    line-height:40px;
}
      </style>
      <script src="js/time/new/jquery-1.12.3.min.js"></script>
      <script src="js/time/new/datedropper.min.js"></script>
      <script src="js/time/new/timedropper.min.js"></script>
      <script src="js/time/indexjs.js"></script>
       
<script>
    $("#pickdate").dateDropper({
        animate: false,
        format: 'Y-m-d',
        maxYear: '2020'
    });
    $("#picktime").timeDropper({
        meridians: false,
        format: 'HH:mm',
    });
</script>
      </div>

        </div>

   <div class="page" id='router2'>
        <script>
            function alet() {
             
                var bb = document.getElementById("TextBox3");
                bb.value = "已填写";
               
              
            };
    </script>
  <header class="bar bar-nav">
    <a class="button button-link button-nav pull-left back" href="/docs-demos/router">
      <span class="icon icon-left"></span>
      返回
    </a>
    <h1 class='title'>被护理人信息</h1>
  </header>
       
  <div class="content" >
  
      <div class="list-block" style="font-size:14px">
    <ul>
      <!-- Text inputs -->
      <li>
        <div class="item-content">
          <div class="item-media"><i class="iconfont icon-gerenziliao"></i></div>
          <div class="item-inner">
            <div class="item-title label">姓名</div>
            <div class="item-input">
             <asp:TextBox ID="by_name" CssClass="item-after"  Font-Size="14px"  runat="server" Font-Italic="true" Font-Bold="true" placeholder="填写姓名" ></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
      <li>
           
        <div class="item-content">
          <div class="item-media"><i class=" iconfont icon-xingbienan"></i></div>
          <div class="item-inner">
            <div class="item-title label">性别</div>
            <div class="item-input" onclick="By_name()">
              <select id="Sel_Test" runat="server"  style="font-size:14px" >
                <option>男</option>
                <option>女</option>
              </select>
            </div>
          </div>
        </div>
      </li>
      <li>
         <div class="item-content">
          <div class="item-media"><i class="iconfont icon-alarmclock"></i></div>
          <div class="item-inner">
            <div class="item-title label">自理能力</div>
            <div class="item-input">
              <select id="By_care" runat="server"  style="font-size:14px">
                <option>能自理</option>
                <option>不能自理</option>
              </select>
            </div>
          </div>
        </div>
      </li>
     <li>
        <div class="item-content">
          <div class="item-media"><i class="iconfont icon-renzheng"></i></div>
          <div class="item-inner">
            <div class="item-title label">年龄</div>
            <div class="item-input">
             <asp:TextBox ID="by_age" TextMode="Number" CssClass="item-after"  runat="server" placeholder="填写1-110岁" Font-Italic="true" Font-Bold="true" Font-Size="14px" ></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
          <li>
        <div class="item-content">
          <div class="item-media"><i class=" iconfont icon-weizhi"></i></div>
          <div class="item-inner">
            <div class="item-title label">护理地址</div>
            <div class="item-input">
             <asp:TextBox ID="by_adress" CssClass="item-after"  runat="server" Font-Size="14px"  Font-Bold="true"   placeholder="护理地址（详细至门牌）" onclick=" daxiao();age()"></asp:TextBox>
            </div>
          </div>
        </div>
      </li>
      <!-- Date -->
      
     
    </ul>
  </div>
  <div class="content-block">
    <div class="row"  >
      <div class="col-50"><a href="/docs-demos/router"style="background-color:#ee2828;" class="button button-big button-fill button-danger back">取消</a></div>
      <div class="col-50"><a  href="#" style="background-color:green;" class="button button-big button-fill button-success back" onclick="alet()" >提交</a></div>
   
  </div>
      </div>
       </div>
       </div>
      </form>
 

   
   <%--<script>
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
</script>--%>
    </body>

</html>



