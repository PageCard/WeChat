
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editDati.aspx.cs" Inherits="XCWeiXin.Web.admin.dati.editDati" ValidateRequest="false"  %>

<%@ Import Namespace="XCWeiXin.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑在线答题信息</title>
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
            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '98%',
                height: '350px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });
            var editorMini = KindEditor.create('.editor-mini', {
                width: '98%',
                height: '250px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });         
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
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
        <div class="location">
            <a href="index.aspx" class="back"><i></i><span>返回题库列表</span></a>
            <i class="arrow"></i>
            <span>编辑在线答题信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <div class="mytips">
            该在线答题的地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
        </div>


        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑基本信息</a></li>      
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">答题得红包设置</a></li>                   
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>题库名称</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*尽量简单，不要超过50字.</span>
                </dd>
            </dl>
            <dl>
                <dt>LOGO图片</dt>
                <dd>
                    <asp:Image ID="imgbjurl" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" /><br />
                    <asp:TextBox ID="txtHeadimg" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>

                </dd>
            </dl>
            <dl>
                <dt>背景色</dt>
                <dd>                  
                    <asp:TextBox ID="txtbjcolor" runat="server" CssClass="input small" />                   
                    <span class="Validform_checktip">#000000</span>

                </dd>
            </dl>
            <dl>
                <dt>题库说明</dt>
                <dd><textarea id="txtsummary" class="editor" style="visibility: hidden;" runat="server"></textarea>

                    <span class="Validform_checktip">*请描述题库说明</span>
                </dd>
            </dl>
            <dl>
                <dt>答题时间</dt>
                <dd>
                    <asp:TextBox ID="txtdttime" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0" />分钟
                    <span class="Validform_checktip">为0时不做时间限制</span>
                </dd>
            </dl>      
             <dl>
                <dt>答题结束后是否显示结果</dt>
                <dd>
                      <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblisshowend" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
             <dt>积分策略</dt>
                <dd>
                    
                       <asp:DropDownList ID="ddlJFtype" runat="server">
                        <asp:ListItem Text="不参与积分策略" Value="0" Selected="True">不参与积分策略</asp:ListItem>
                        <asp:ListItem Text="参与送积分" Value="1" >参与送积分</asp:ListItem>
                        <asp:ListItem Text="根据成绩得积分" Value="2">根据成绩得积分</asp:ListItem>                        
                    </asp:DropDownList>
                   
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
             <dl>
             <dt>积分值</dt>
                <dd>
                  <asp:TextBox ID="txtjfval" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0" />                    
                    <span class="Validform_checktip">如果选择根据成绩得积分此栏不填写</span>
                </dd>
            </dl>
           
            <dl>
                <dt>单选题设置</dt>
                <dd>                    
                   标题： <asp:TextBox ID="txtdxtitle" runat="server" CssClass="input small" datatype="*1-50" sucmsg=" " Text="单选题" />；
                   每题分值：<asp:TextBox ID="txtdxscore" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="1" />分；
                   每次抽取数：<asp:TextBox ID="txtdxgetnum" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0" />道。
                    <span class="Validform_checktip">*抽取数为0时为全部显示</span>
                </dd>
            </dl>
            <dl>
                <dt>活动时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtstarttime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                    到
                  
                    <div class="input-date">
                        <asp:TextBox ID="txtendtime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>结束时间</i>
                    </div>
                    <span class="Validform_checktip">*</span>

                </dd>
            </dl>
        </div>
      
       <div class="tab-content">
        <dl>
          <dt>是否开启红包</dt>
                <dd>
                      <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
             <dt>领取红包条件</dt>
                <dd>
                       <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Text="满分领取" Value="0" Selected="True">满分领取</asp:ListItem>
                        <asp:ListItem Text="参与领取" Value="1" >参与领取</asp:ListItem>
                                     
                    </asp:DropDownList>
                   
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
             <dt>每天领取次数</dt>
                <dd>
               <asp:TextBox ID="TextBox2" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0" />  
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
             <dl>
             <dt>每人领取次数</dt>
                <dd>
               <asp:TextBox ID="TextBox3" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0" />  
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

             <dl>
             <dt>容错次数</dt>
                <dd>
                  <asp:TextBox ID="TextBox1" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0" />                    
                    <span class="Validform_checktip">用户可以有几次机会，0表示不限制</span>
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
