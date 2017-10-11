<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="card_sing.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.card_sing" %>

<!DOCTYPE html>
<html>
<head>
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>护工详情</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> 
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
  
    <link href="../../sui/css/sm.css?v=1.0" rel="stylesheet" />
   
    
    

 

    <link href="js/time/new/datedropper.css" rel="stylesheet" />
    <link href="js/time/new/timedropper.min.css" rel="stylesheet" />
 <style>
      bady {
      
       
          font-size:12px;
          color:#CEC9C9;
      }
       .card-gggg li {
        float:left;
       list-style:none;
     

      }
      .julirem {
        margin-left:0.5rem;
      }
   
  
        .bar .icon {
      
         
          color:#0894EC;
        
      }
      .bar .tab-label {
      color:Background;    }
      .page a:hover {
          color:#0894EC;
    
      }
      .jp {
    font-size: 11px;
    color: #c5bb67;
    border-radius: .1rem;
    border: 1px solid #c5bb67;
    padding: 0 .2rem;
    display: inline-block;
    line-height: 1.4em;
    vertical-align: middle;
    margin-top: -.12rem;
      }
      .ddd {
      
             position: absolute;
             right: 0.267rem;
             top: 0.3rem;
             color:#FF9648;
      }
 
 .card  .card-content img{
     border-radius:50%;
      }
      .cardfont {
      font-size:12px;
      }
   .bgt {
      background-color:#E0E5EA;  padding-bottom:0.1rem;
      height:1.5rem;
      line-height:1.5rem;
      }
     
  </style> 

  
</head>
    
<body>
  <form runat="server">
  
       
          
       
             <nav class="bar bar-tab">
  
       <asp:Button ID="Button1" CssClass="tab-item button button-fill " style="margin-top:-5px" runat="server" Text="立即预约" OnClick="Button1_Click" />
 
     </nav>
            
  <div class="content" style="background-color:#EFEFF4">
  <div class="card "">
     
      <div class="card-content">
          <div class="list-block media-list">
              <ul> 
                   <li class="item-content" > 
                       <div class="item-media">
                            <img  src="<%=head %>" width="44">

                       </div>
                       <div class="item-inner cardfont">
                            <div class="item-title-row">
                                <div class="item-title" ><%=name %>&nbsp<a href="#" class="jp"><%=dengji %></a></div>

                            </div><div class="item-subtitle">
                                <span><%=sex %></span>
                                <font>|</font>
                                <span><%=Hg_age%>岁</span>
                                <br />
                                <span class="cardfont">护工来了，服务至上</span>
                                  </div>

                       </div>
                       <span class="ddd  cardfont"><%=mony%>元/人</span>

                   </li>

              </ul>

          </div>

      </div>
      <div class="card-footer cardfont" > 
          <div class="col-40">服务范围:</div>
          <div class="col-60" style="padding-left:2rem"><a href="#" class="button button-primary cardfont "><%=Hg_st1 %></a></div>

      </div>

  </div>
      <div class="card">
    <div class="card-header">基本信息</div>
    <div class="card-content">
      <div class="card-content-inner">  <span>学历:<%=Hg_Degree %>&nbsp|&nbsp 民族:<%=nation %>&nbsp|&nbsp婚姻:<%=marry %></span><br />
            <span>个人能力:<%=Hg_Profile %></span><br />
      <span>身份证号:<%=Hg_IDcard %></span>
      </div>
    </div>
   
  </div>
    
     
     
    
    
      </div>  
    
            


        

<asp:hiddenfield runat="server" ID="hid"></asp:hiddenfield>
      <asp:hiddenfield runat="server" ID="hid2"></asp:hiddenfield>
         <asp:hiddenfield runat="server" ID="hid3"></asp:hiddenfield>
        <asp:hiddenfield runat="server" ID="hid4"></asp:hiddenfield>
      
      </form>
  
  
        <script type='text/javascript'  src="../../sui/js/zepto.js" charset='utf-8'></script>
 
        <script type='text/javascript' src="../../sui/js/sm.min.js" charset='utf-8'></script>
     
       

    </body>

</html>


