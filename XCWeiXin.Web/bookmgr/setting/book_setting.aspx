<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book_setting.aspx.cs" Inherits="XCWeiXin.Web.bookmgr.setting.book_setting" ValidateRequest="false" %>
<%@ Import Namespace="XCWeiXin.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>在线预订设置</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../../admin/js/layout.js"></script>
    <link href="../../admin/skin/default/style.css" rel="stylesheet" type="text/css" />
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
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href=":;" class="home"><i></i><span>预订基本信息</span></a>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->


        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">预订基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">微支付配置信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">预订焦点图片</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <asp:Label ID="lblId" runat="server" Style="display: none;" Text="0"></asp:Label>

        <!--微网站基本信息-->
        <div class="tab-content">
            <dl>
                <dt>预订网址</dt>
                <dd>
                    <asp:Label ID="lblWSiteUrl" runat="server" Text="http://" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>预订名称</dt>
                <dd>
                    <asp:TextBox ID="txtbookName" runat="server" CssClass="input normal" datatype="*1-255" sucmsg=" " nullmsg="请填写预订名称"></asp:TextBox>
                    <span class="Validform_checktip">*任意字符，控制在255个字符内</span>
                </dd>
            </dl>

            <dl>
                <dt>logo</dt>
                <dd>
                    <asp:TextBox ID="txtlogo" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>背景图片</dt>
                <dd>
                    <asp:TextBox ID="txtbgPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>


            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txttel" runat="server" CssClass="input normal" datatype="*0-30" sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">非必填，区号+电话号码</span>
                </dd>
            </dl>
            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txtaddr" runat="server" CssClass="input normal" datatype="*0-200" sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">非必填</span>
                </dd>
            </dl>


            <dl>
                <dt>版权信息</dt>
                <dd>
                    <asp:TextBox ID="txtcopyright" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-100" sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">支持HTML</span>
                </dd>
            </dl>


        </div>

        <div class="tab-content">
            <dl>
                <dt>接口形式 </dt>
                <dd>
                    <asp:Label ID="lbljkxs" runat="server" Text="JS API支付" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>支付授权目录 </dt>
                <dd>
                    <asp:Label ID="lblzfsqml" runat="server" Text="http://" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>支付请求实例 </dt>
                <dd>
                    <asp:Label ID="lblzfqqsl" runat="server" Text="http://" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>维权通知URL </dt>
                <dd>
                    <asp:Label ID="lblwqtz" runat="server" Text="http://" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>警通知URL </dt>
                <dd>
                    <asp:Label ID="lbljjtz" runat="server" Text="http://" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
        </div>

       <div class="tab-content" style="display: none;">
            <dl>
                <dt>预订图片</dt>
                <dd>
                    <div class="upload-box upload-album"></div>
                    <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" />
                    <div class="photo-list">
                        <ul>
                           <asp:Repeater ID="rptAlbumList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <input type="hidden" name="hid_photo_name" value="<%#Eval("id")%>|<%#Eval("original_path")%>|<%#Eval("thumb_path")%>" />
                                        <input type="hidden" name="hid_photo_remark" value="<%#Eval("remark")%>" />
                                        <div class="img-box" onclick="setFocusImg(this);">
                                            <img src="<%#Eval("thumb_path")%>" bigsrc="<%#Eval("original_path")%>" />
                                            <span class="remark"><i><%#Eval("remark").ToString() == "" ? "暂无描述..." : Eval("remark").ToString()%></i></span>
                                        </div>
                                        <a href="javascript:;" onclick="setRemark(this);">描述</a>
                                        <a href="javascript:;" onclick="delImg(this);">删除</a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </dd>
            </dl>
        </div>
        <!--/微网站基本信息-->




        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
