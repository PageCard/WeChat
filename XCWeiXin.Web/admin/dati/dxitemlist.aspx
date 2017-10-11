<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dxitemlist.aspx.cs" Inherits="XCWeiXin.Web.admin.dati.dxitemlist" %>


<%@ Import Namespace="XCWeiXin.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>在线答题－题目管理</title>
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
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>在线答题－题目管理</span></a>
        </div>
        <!--/导航栏-->
        <asp:Label ID="lblWid" runat="server" Text="" Style="display: none;"></asp:Label>
       


        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="dxitemedit.aspx?action=<%=MXEnums.ActionEnum.Add %>&pid=<%=pid%>" id="itemAddButton"><i></i><span>新增题目</span></a></li>

                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
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

        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th width="5%">sid</th>
                            <th width="25%">题目</th>
                            <th width="5%">答案</th>
                            <th width="40%">选项</th>
                            <th width="5%">状态</th>
                            <th width="5%">编辑</th>
                            <th width="5%">用户提交结果</th>

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
                     <td style=" text-align:left; padding-left:8px">
                        <%# Eval("sid") %>
                    </td>
                    <td style=" text-align:left; padding-left:8px">
                        <%# Eval("title") %>
                    </td>
                     <td>
                        <%# Eval("answer")%>
                    </td>
                    <td style=" text-align:left; padding-left:8px">
                   A.<%# Eval("xA")%>　　<%# Eval("xB")!="" ? "B.":""%><%# Eval("xB")%> 　　<%# Eval("xC")!="" ? "C.":""%><%# Eval("xC")%>　　<%# Eval("xD")!="" ? "D.":""%><%# Eval("xD")%>　　<%# Eval("xE")!="" ? "E.":""%><%# Eval("xE")%>　　<%# Eval("xF")!="" ? "F.":""%><%# Eval("xF")%>
                    </td>
                     <td>
                        <%#Convert.ToInt32(Eval("isshow")) == 1 ? "是" : "<font color='red'>否</font>"%>
                    </td>
                  <td>
                        <a href='dxitemedit.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>&pid=<%#Eval("pid") %>' class="operator">编辑</a>
                    </td>

                    <td>
                        <a href='userResult.aspx?id=<%#Eval("id") %>' class="operator">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
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
