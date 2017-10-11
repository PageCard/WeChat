<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="true"  CodeBehind="Card_wx_QR.aspx.cs" Inherits="XCWeiXin.Web.admin.Card_wx.Card_QR" %>

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
            <a href="javascript:;" class="home"><i></i><span>卡券管理</span></a>
        </div>
        <!--/导航栏-->
        <asp:Label ID="lblWid" runat="server" Text="" Style="display: none;"></asp:Label>
       


        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <asp:Image ID="Image1" runat="server" />

                        <li><a class="icon-btn add" href="Card_wx_add.aspx" shape="rect"><i></i><span>添加卡券</span></a></li>
                        <li>
                            <asp:Button ID="Button5" runat="server" Text="Button" OnClick="Button5_Click" /></li>
                      
                    </ul>
                </div>        
   
            
            </div>
        </div>
        <!--/工具栏-->
        
        <!--列表-->

        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" >
            <HeaderTemplate>
                <table width="80%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            

                            
                            <th width="5%"> 
                               <asp:DropDownList ID="DropDownList2" AutoPostBack="true"   OnSelectedIndexChanged ="DropDownList2_SelectedIndexChanged"  runat="server" >
                            <asp:ListItem>请选择卡券类型</asp:ListItem>
                            <asp:ListItem>团购券</asp:ListItem>
                            <asp:ListItem>代金券</asp:ListItem>
                            <asp:ListItem>折扣券</asp:ListItem>
                            <asp:ListItem>优惠券</asp:ListItem>
                                        </asp:DropDownList>
                                      </th>
                              
                            <th width="5%">投放二维码</th>
                            <th width="10%">卡券名称</th>
                            <th width="10%">卡券类型</th>
                            <th width="5%">卡券库存</th>
                            <th width="15%">卡券编号</th>
                            <th width="5%">删除卡券</th>
                            <th width="10%">更改库存</th>
                            <th width="5%">投放卡券</th>
                            <th width="5%">编辑卡券</th>

                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("BaseInfoID")%>' runat="server" />
                    </td>
                      <td>
                  
                      <asp:Image ID="Image2" runat="server" ImageUrl="/admin/Card_wx/image/Fale.png" Height="70" Width="70" />
                    </td>
                     <td style=" text-align:center; padding-left:8px">
                        <%# Eval("title") %>
                    </td>
                    <td style=" text-align:center; padding-left:8px">
                        <%# Eval("Card_type") %>
                           <asp:HiddenField ID="hd2" Value='<%#Eval("Card_type")%>' runat="server" />
                    </td>
                    
                    <td>
                        <asp:TextBox ID="quantity"  Text=<%#Eval("quantity")%> runat="server" ForeColor="#003399" class="txtname"></asp:TextBox>
                     
                    
                    </td>
                     <td>
                        <%# Eval("Wx_Card_id")%>
                    </td>
                 <!--   <td style=" text-align:center; padding-left:8px">
                        <asp:Image ID="Image1" runat="server" ImageUrl=<%#Eval("logo_url") %> Height="50" Width="50" />
                    </td>
               --><td>               
                      <asp:Button  ID="button2" runat="server"  CommandArgument='<%#Eval("BaseInfoID") %>' CommandName="deletecard" CssClass="btn yellow"  Text="删除卡券" />           
                  </td>
                    <td> <asp:Button  ID="button3" runat="server" CommandArgument='<%#Eval("BaseInfoID") %>' CommandName="update_q" CssClass="btn  green"  Text="更改库存" ForeColor="White" /> </td>
                    <td>
                       <asp:Button  ID="button1" runat="server" CommandArgument='<%#Eval("BaseInfoID") %>' CommandName="toufang" Text="投放卡券" CssClass="btn" />
                          <asp:HiddenField ID="HiddenField1" Value='<%#Eval("Wx_Card_id")%>' runat="server" />
                    </td>
                    <td>
                       
                         <asp:Button ID="Button4" runat="server" Text="卡券编辑" CommandName="exit"  CssClass="btn  green"  ForeColor="White" />

                   
                    
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
            <div class="l-btns technorati">      
                 <span class="Validform_title">  数据均通过更新库存按钮实时更新，使用时，请点击更新库存获取存货；</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>