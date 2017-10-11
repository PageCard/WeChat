<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_hb.aspx.cs" Inherits="XCWeiXin.Web.admin.hunqing.edit_hb" %>


<%@ Import Namespace="XCWeiXin.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑普通红包</title>
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
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="xitielist.aspx" class="back"><i></i><span>返回红包列表</span></a>
            <i class="arrow"></i>
            <span>编辑普通红包</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑普通红包</a></li>
                    </ul>
                </div>
            </div>
        </div>

          <div class="mytips">
                该红包的展示地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
         </div>

         <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <div class="tab-content">

            <dl>
                <dt>红包名称</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-10" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*红包标题限制在十个字以内!</span>
                </dd>
            </dl>

            <dl>
                <dt>活动描述</dt>
                <dd>  <textarea name="txtDepict" rows="2" cols="20" id="txtDepict" class="input" runat="server" datatype="*1-200" sucmsg=" " nullmsg=" "></textarea>                  
                   
                </dd>
            </dl>
            

            <dl>
                <dt>祝福语</dt>
                <dd>
                    <asp:TextBox ID="txtZftxt" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*祝福语,请不要多于20字!</span>
                </dd>
            </dl>
            <dl>
                <dt>红包最小金额</dt>
                <dd>
                    <asp:TextBox ID="txtPricemin" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*红包最小金额,单位为分，最小金额为1元!</span>
                </dd>
            </dl>
            <dl>
                <dt>红包最大金额</dt>
                <dd>                 
             <asp:TextBox ID="txtPricemax" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" />
                  <span class="Validform_checktip">*红包最大金额,单位为分，最大金额为200元!</span>
                </dd>
            </dl>

            <dl>
                <dt>商户名称</dt>
                <dd>
                    <asp:TextBox ID="txtPayname" runat="server" CssClass="input normal" datatype="*1-30" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*显示在红包页上的商家名称</span>
                </dd>
            </dl>
            <dl>
                <dt>商户ID号</dt>
                <dd>
                    <asp:TextBox ID="txtPaynum" runat="server" CssClass="input normal" datatype="*1-200" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>API支付密钥</dt>
                <dd>
                 <asp:TextBox ID="txtPaypass" runat="server" CssClass="input normal" datatype="*1-200" sucmsg=" " Text="" />
                  
                    <span class="Validform_checktip">*API支付密钥</span>
                </dd>
            </dl>

            <dl>
                <dt>API证书地址</dt>
                <dd>
                    <asp:TextBox ID="txtPayZSadd" runat="server" CssClass="input normal" datatype="*0-200" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*证书地址为根目录下的目录</span>
                </dd>
            </dl>


            <dl>
                <dt>访问IP(本服务器地址)</dt>
                <dd><asp:TextBox ID="txtPayreIP" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " Text="" />                    
                    <span class="Validform_checktip">一般为本服务器地址</span>
                </dd>
            </dl>

            <dl>
                <dt>签名</dt>
                <dd>
                    <asp:TextBox ID="txtSignname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " Text="" nullmsg="请填写信息，并且不要多于50字 " ReadOnly="false" />
                    <span class="Validform_checktip">*设置微信上查看来宾名单的验证密码，请不要多于50字!</span>
                </dd>
            </dl>          
            <dl>
                <dt>活动开始时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtStartTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>活动结束时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>结束时间</i>
                    </div>
                </dd>
            </dl>

        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="xitielist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
