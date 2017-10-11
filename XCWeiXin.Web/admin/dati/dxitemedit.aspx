<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dxitemedit.aspx.cs" Inherits="XCWeiXin.Web.admin.dati.dxitemedit" ValidateRequest="false"  %>

<%@ Import Namespace="XCWeiXin.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑单选题</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
          
            $(".attach-btn").click(function () {
                showAttachDialog();
            });

        });
    </script>
     <style>
     p{ padding-top:10px}
     </style>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="dxitemlist.aspx" class="back"><i></i><span>返回单选题列表</span></a>
            <i class="arrow"></i>
            <span>编辑在线答题信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->      


        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">添加单选题</a></li>                      
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>题目</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="" />
                   　 分值：<asp:TextBox ID="txtscore" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" />分；
                   　 审核：<asp:RadioButtonList ID="rblisshow" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0">未审</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">已审</asp:ListItem>
                        </asp:RadioButtonList>
                    <span class="Validform_checktip">*不要超过100字.</span>
                </dd>
            </dl>
            
                <dl>
                <dt>选项</dt>
                <dd>
                <p>
                    <asp:RadioButton ID="rbxA" runat="server" Text="A" GroupName="answer" />
                    .　<asp:TextBox ID="txtxA" runat="server" CssClass="input normal" datatype="*1-100" sucmsg="至少填写一个" Text="" />
                    </p><p>
                    <asp:RadioButton ID="rbxB" runat="server" Text="B" GroupName="answer" />
                    .　<asp:TextBox ID="txtxB" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="" />
                    </p><p>
                    <asp:RadioButton ID="rbxC" runat="server" Text="C" GroupName="answer" />
                    .　<asp:TextBox ID="txtxC" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Text="" />
                     </p><p>
                    <asp:RadioButton ID="rbxD" runat="server" Text="D" GroupName="answer" />
                   .　<asp:TextBox ID="txtxD" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Text="" />
                     </p><p>
                    <asp:RadioButton ID="rbxE" runat="server" Text="E" GroupName="answer" />
                    .　<asp:TextBox ID="txtxE" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Text="" />
                     </p><p>
                    <asp:RadioButton ID="rbxF" runat="server" Text="F" GroupName="answer" />
                   .　<asp:TextBox ID="txtxF" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Text="" />
                   </p>
                </dd>
            </dl>      
            <dl>
                <dt>题目注解</dt>
                <dd><textarea name="txtsummary" rows="2" cols="20" id="txtsummary" class="input" runat="server" datatype="*0-200" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*请描述题目注解</span>
                </dd>
            </dl>
            </div>
            
          



        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="index.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
