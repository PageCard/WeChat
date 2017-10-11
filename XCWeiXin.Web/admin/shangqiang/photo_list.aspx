﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photo_list.aspx.cs" Inherits="XCWeiXin.Web.admin.shangqiang.photo_list" %>

<%@ Import Namespace="XCWeiXin.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>微信上墙-图片管理</title>
    <link rel="stylesheet" type="text/css" href="../../images/font-awesome/css/font-awesome.css" media="all" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="baseinfo.aspx"><span class="home"><i></i><span>微信上墙活动管理</span></a>
            <i class="arrow"></i>
            <span>编辑活动</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="folder" OnClick="btnShenghe_Click"><i></i><span>通过审核</span></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="del" OnClick="btnLaHei_Click"><i></i><span>拉黑</span></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本图片，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
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
        <asp:Repeater ID="rptList" runat="server"  >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="6%">选择</th>
                        <th align="left" width="6%">编号</th>
                        <th align="left" width="20%">图片</th>
                        <th align="left" width="15%">openid</th>
                        <th align="left" width="15%">时间</th>
                        <th align="left" width="12%">审核信息</th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        <asp:HiddenField ID="hidOpenid" Value='<%#Eval("openid")%>' runat="server" />
                    </td>
                    <td><%#Eval("id")%></td>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("picUrl") %>'  style="max-height:150px; max-width:150px;" />

                    </td>
                    <td><%#Eval("openid")%></td>
                    <td>
                        <%#Eval("createDate")%> 
                    </td>
                    <td>
                        <%#Eval("hasShenghe").ToString().ToLower()=="true"?"通过":"未通过"%> 
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
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
