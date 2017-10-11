﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="business_adver_list.aspx.cs" Inherits="XCWeiXin.Web.admin.ucard.business_adver_list" %>

<%@ Import Namespace="XCWeiXin.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员卡商城头部广告位设置</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
       <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
     <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }

        $(function () {


        });



    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
          <!--导航栏-->
        <div class="location">
            <a href="business_list.aspx" class="back"><i></i><span>返回会员卡商家管理</span></a>
             <a href="business_list.aspx" class="home"><i></i><span>会员卡商家管理</span></a>
         
            <i class="arrow"></i>
            <span>会员卡商城头部广告位设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="business_adver_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>"  id="itemAddButton"><i></i><span>新增广告</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                        
                         <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->

        <asp:Repeater ID="rptList" runat="server" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                             <th width="20%">广告名称</th>
                            <th width="15%">图片</th>
                            <th width="20%">外部网站或者活动</th>
                             <th width="8%">排序</th>
                            <th width="10%">操作</th>
                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td>
                        <%# Eval("adverName") %> 
                    </td>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl=' <%# Eval("picUrl") %> ' style="max-width:150px; max-height:80px;" />
                    </td>
                     <td>
                         <%# Eval("linkUrl") %> 
                    </td>
                    <td>
                       <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" />
                    </td>
                     <td>
                        <a  href='business_adver_edit.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>' class="operator">编辑</a>
                       
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
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
    </form>
</body>
</html>
