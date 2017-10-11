<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="attrlist.aspx.cs" Inherits="XCWeiXin.Web.attr_shop.attrlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
<body class="mainbody">
    <form id="form1" runat="server">
         <!--导航栏-->
          <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>商品类型管理</span></a>
            <i class="arrow"></i>
            <span>商品属性管理</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                            <li><a class="icon-btn add" href="attr_add.aspx" ><span>添加商品属性</span></a></li>
                   <asp:TextBox ID="txtKeywords" runat="server" Visible="false" CssClass="keyword" />
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

    <div class="tab-content">
        
        <!--列表-->

        <asp:Repeater ID="rptList" runat="server" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
    <th align="center" width="20%">选择</th>
    <th align="center"  width="20%">商品属性名称编号</th>
    <th  align="center" width="20%">商品属性名称</th>
    <th  align="center" width="20%">可选备注</th>
    <th align="center" width="10%">删除</th>
    <th align="center" width="10">操作</th>
   
  </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("attrid")%>' runat="server" />
                    </td>
                    <td align="center">
                        <%# Eval("attrid") %>
                    </td>
                    <td align="center">
                        <%# Eval("attrname") %>
                    </td align="center">
                     <td align="center">
                        <%# Eval("attrcontext") %>
                        
                    </td>
                   <td align="center">        
                         <a  href='message_edite.aspx?openId=<%#Eval("attrid") %>' >删除</a>
                      
                    </td>
                    
                   
                     <td align="center">
                         
                        <a  href='exit_shop.aspx?attrid=<%#Eval("attrid") %>' >编辑</a>
                        <a  href='attr.aspx?id=<%#Eval("attrid") %>' >属性管理</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
                 </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->  
    </div>
    </form>
</body>
</html>
