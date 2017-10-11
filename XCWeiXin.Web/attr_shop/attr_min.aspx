<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="attr_min.aspx.cs" Inherits="XCWeiXin.Web.attr_shop.attr_min" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../admin/js/layout.js"></script>
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../../admin/skin/default/style.css" rel="stylesheet" type="text/css" />

     <script type="text/javascript">
         $(function () {
             //初始化表单验证
             $("#form1").initValidform();

             //初始化上传控件
             $(".upload-img").each(function () {
                 $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.mp3;" });
             });
             $(".upload-album").each(function () {
                 $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
             });
             $(".attach-btn").click(function () {
                 showAttachDialog();
             });


         });
    </script>
    

   
    
</head>
<body>
    <form id="form1" runat="server">
  
               <!--导航栏-->
          <!--导航栏-->
        <div class="location" style="margin-top:20px">
            <a href="attrlist.aspx" class="home"><i></i><span>商品属性列表</span></a>
            <i class="arrow"></i>
             
            <span>添加商品属性</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                         <li><a href="javascript:;" onclick="tabs(this);" class="selected">商品属性配置</a></li>
                   
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>
          <div  class="tab-content" >
               <dl>       
                   <dt>所属大商品名称</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="attr" CssClass="input normal" datatype="*0-100"  sucmsg=" " nullmsg="不能为空 " ></asp:TextBox>
                        <span class="Validform_title">商品属性必填</span>
                    </dd>
                </dl>  
                
              <dl>
                  <dt>商品属性备注</dt>
                  <dd>
                       <asp:TextBox ID="text" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">选项属性备注</span>
                  </dd>
              </dl>  
      
        </div>
                <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn"  OnClick="btnSubmit_Click" />
                <a href="attrlist.asp.aspx"><span class="btn yellow">返回商品属性列表</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
