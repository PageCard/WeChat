﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_editepicture.aspx.cs" Inherits="XCWeiXin.Web.admin.vote.vote_editepicture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
          <!--导航栏-->
        <div class="location">
            <a href="message_list.aspx" class="home"><i></i><span>文本投票设置</span></a>
            <i class="arrow"></i>
             
            <span>文本投票设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">图片投票设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">投票选项</a></li>
                      
                    </ul>
                </div>
            </div>
        </div>


        <div  class="tab-content" >
            
                <dl>
                    <dt>投票标题：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="title" CssClass="input normal" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
          
               

                <dl>
                    <dt >投票图片：</dt>
                    <dd>
             
                    <asp:TextBox runat="server" CssClass="input normal upload-path" ID="votepic" datatype="*1-100" ></asp:TextBox>
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">填写图片外链地址，大小为720x400;</span>
                   
                    </dd>
                </dl>

   
                <dl>
                    <dt>
                      图片显示：
                    </dt>
                    <dd>
                         <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="picdisplay" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="True" Selected="True">显示在投票页面</asp:ListItem>
                            <asp:ListItem  Value="False" >不显示在投票页面</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    </dd>
                </dl>
               
                <dl>
                    <dt>投票说明：</dt>
                    <dd>
                     
                  <textarea name="txtactContent" rows="2" cols="20" id="txtactContent" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                    </dd>
                </dl>
                  

                  <dl>
                    <dt>单选/多选：</dt>
                    <dd>
                         <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="Radio" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="True" Selected="True">单选</asp:ListItem>
                            <asp:ListItem  Value="False" >多选</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    </dd>
                </dl>
                <dl>
                    <dt>截止时间：</dt>
                    <dd>
                       <div class="input-date">
                      <asp:TextBox runat="server" ID="begindate" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                      </div>
                      到
                      <div class="input-date">
                      <asp:TextBox runat="server" ID="enddate" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                      </div>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                <dl>
                    <dt>投票结果：</dt>
                    <dd>
                        <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="resultShowtype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="1" Selected="True" >投票前可见</asp:ListItem>
                            <asp:ListItem  Value="2" >投票后可见</asp:ListItem>
                            <asp:ListItem  Value="3" >投票结束可见</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                      
                    </dd>
                </dl>

              <dl style="display:none">
                    <dt>投票后参加活动：</dt>
                    <dd>
                      <asp:TextBox runat="server" CssClass="input normal upload-path" ID="actUrl"></asp:TextBox>
                      
                    </dd>
                </dl>

        </div>
         <div  class="tab-content" style="display: none">
              <div class="mytips">
                至少2项，每项最多20字。 图片最小266×148或者532×296，最大720x400，图越大越清晰，但是越费流量，打开速度越慢。
                  <br />
                  图片跳转地址以http://开头.
         </div>

                <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle1" runat="server" CssClass="input" datatype="*1-20" sucmsg="*必填项" nullmsg="*必填项" Text=""  />
                    排序：<asp:TextBox ID="Sortid1" runat="server" CssClass="input small" datatype="n"  />
                    图片：<asp:TextBox ID="pic_ur1" runat="server" CssClass="input normal upload-path" datatype="*0-800" style="width:120px;" sucmsg=" " Text=""  />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：<asp:TextBox ID="pic_jump1" runat="server" CssClass="input " datatype="*0-800" sucmsg=" " Text=""  />
                    <asp:HiddenField ID="toupiaoTimes1" runat="server" Value="0" />
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

             <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle2" runat="server" CssClass="input " datatype="*1-20" sucmsg=" " Text=""  />
                    排序：<asp:TextBox ID="Sortid2" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text=""  />
                    图片：<asp:TextBox ID="pic_ur2" runat="server" CssClass="input normal upload-path" datatype="*0-800" style="width:120px;" sucmsg=" " Text="" />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：<asp:TextBox ID="pic_jump2" runat="server" CssClass="input " datatype="*0-800" sucmsg=" " Text="" />
                     <asp:HiddenField ID="toupiaoTimes2" runat="server" Value="0" />
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

                 <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle3" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text=" " />
                    排序：<asp:TextBox ID="Sortid3" runat="server" CssClass="input  small" datatype="/^\d*$/"  sucmsg=" " Text="" />
                    图片：<asp:TextBox ID="pic_ur3" runat="server" style="width:120px;" datatype="*0-800"  CssClass="input normal upload-path"   sucmsg=" " Text=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：<asp:TextBox ID="pic_jump3" runat="server" CssClass="input " datatype="*0-800"  sucmsg=" " Text="" />
                   <asp:HiddenField ID="toupiaoTimes3" runat="server" Value="0" />
                </dd>
            </dl>

              <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle4" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid4" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                    图片：<asp:TextBox ID="pic_ur4" runat="server" CssClass="input normal upload-path" datatype="*0-800" style="width:120px;"  sucmsg=" " Text="" />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：<asp:TextBox ID="pic_jump4" runat="server" CssClass="input " datatype="*0-800"  sucmsg=" " Text="" />
                   <asp:HiddenField ID="toupiaoTimes4" runat="server" Value="0" />
                </dd>
            </dl>

                            <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle5" runat="server" CssClass="input "  datatype="*0-20" sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid5" runat="server" CssClass="input small"   datatype="/^\d*$/" sucmsg=" " Text="" />
                    图片：<asp:TextBox ID="pic_ur5" runat="server" CssClass="input normal upload-path" datatype="*0-800" style="width:120px;"  sucmsg=" " Text="" />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：<asp:TextBox ID="pic_jump5" runat="server" CssClass="input " datatype="*0-800"  sucmsg=" " Text="" />
                    <asp:HiddenField ID="toupiaoTimes5" runat="server" Value="0" />
                </dd>
            </dl>

           <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle6" runat="server" CssClass="input " datatype="*0-20"  sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid6" runat="server" CssClass="input small "  datatype="/^\d*$/" sucmsg=" " Text="" />
                    图片：<asp:TextBox ID="pic_ur6" runat="server" CssClass="input normal upload-path" datatype="*0-800" style="width:120px;"  sucmsg=" " Text="" />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：<asp:TextBox ID="pic_jump6" runat="server" CssClass="input" datatype="*0-800" sucmsg=" " Text="" />
                    <asp:HiddenField ID="toupiaoTimes6" runat="server" Value="0" />
                </dd>
            </dl>

             </div>
           <div class="page-footer" >
            <div class="btn-list">
                  <asp:Button ID="Button1" runat="server"  CssClass="btn" Text="保存" OnClick="Button1_Click" />
                <a href="ggklist.aspx"><span class="btn yellow">取消</span></a>

            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
