<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Card_wx_add.aspx.cs" Inherits="XCWeiXin.Web.admin.Card_wx.Card_wx_add" %>
<%@ Import Namespace="XCWeiXin.Common" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../../sui/js/jquery.js"></script>
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
  <link href="../../sui/css/sucaijiayuan.css" rel="stylesheet" type="text/css" />

   
<script type="text/javascript">
    $(document).ready(function () {
        $(".showdiv").click(function () {
            var box = 300;
            var th = $(window).scrollTop() + $(window).height() / 1.6 - box;
            var h = document.body.clientHeight;
            var rw = $(window).width() / 2 - box;
            $(".showbox").animate({ top: th, opacity: 'show', width: 500, height: 480, right: rw }, 500);
            $("#zhezhao").css({
                display: "block", height: $(document).height()
            });
            return false;
        });
        $(".showbox .close").click(function () {
            $(this).parents(".showbox").animate({ top: 0, opacity: 'hide', width: 0, height: 0, right: 0 }, 500);
            $("#zhezhao").css("display", "none");
        });
    });
</script>
    

   
    
</head>
<body>
    <form id="form1" runat="server">
  
               <!--导航栏-->
          <!--导航栏-->
        <div class="location">
            <a href="message_list.aspx" class="home"><i></i><span>创建卡券</span></a>
            <i class="arrow"></i>
             
            <span>卡券设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                         <li><a href="javascript:;" onclick="tabs(this);" class="selected">卡券设置</a></li>
                   
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>
          <div  class="tab-content" >
                <dl>
                    <dt>请先选择卡券类型：</dt>
                    <dd>
                        
                             <span><a class="showdiv" name="type_c"  href="#"><asp:Label ID="Card_type" runat="server">选择卡券类型</asp:Label></a></span>
                    
                        <span class="Validform_title"></span>
                    </dd>
                </dl>
              
                <dl>
                    <dt>卡券名称：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="title" CssClass="input normal"  datatype="*0-100" sucmsg=" "  ></asp:TextBox>
                        <span class="Validform_title">券名，字数上限为9 个汉字。(建议涵盖卡券属性、服务及金额)。必填</span>
                    </dd>
                </dl>
                 <dl>
                    <dt>卡券副标题：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="sub_title" CssClass="input normal"   sucmsg=" "></asp:TextBox>
                        <span class="Validform_title">券名的副标题，字数上限为18个汉字。非必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>商户名称：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="brand_name" CssClass="input normal" datatype="*0-100"  sucmsg=" " nullmsg="不能为空 " ></asp:TextBox>
                        <span class="Validform_title">商户名字,字数上限为12 个汉字。（填写直接提供服务的商户名， 第三方商户名填写在source 字段）。必填</span>
                    </dd>
                </dl>
               
              <dl>
                <dt>商户logo:</dt>
                <dd>
                    <asp:Image ID="imgbjurl" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" /><br />
                    <asp:TextBox ID="imagetext" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_title">卡券的商户logo，尺寸为300*300  小于200k; 必填</span>

                </dd>
            </dl>
              
               <dl>
                <dt>卡券颜色:</dt>
                <dd>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                         <ContentTemplate>
                            
                       <p> <asp:Label ID="Card_color" runat="server" Text="请选择卡券颜色"  ></asp:Label></p>
                   
                            
                    <asp:DropDownList ID="DropDownList1"  style="font-size:25px" runat="server" BackColor="White" CssClass="absbg" AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged">
                       
                            <asp:ListItem  value="Color010" style="color: #63b359">█</asp:ListItem>
                            <asp:ListItem  value="Color020" style="color: #2c9f67">█</asp:ListItem>
                            <asp:ListItem  value="Color030" style="color: #509fc9">█</asp:ListItem>
                            <asp:ListItem  value="Color040" style="color: #5885cf">█</asp:ListItem>
                            <asp:ListItem  value="Color050" style="color: #9062c0">█</asp:ListItem>
                            <asp:ListItem  value="Color060" style="color: #d09a45">█</asp:ListItem>
                            <asp:ListItem  value="Color070" style="color: #e4b138">█</asp:ListItem>
                            <asp:ListItem  value="Color080" style="color: #ee903c">█</asp:ListItem>
                            <asp:ListItem  value="Color081" style="color: #f08500">█</asp:ListItem>
                            <asp:ListItem  value="Color082" style="color: #a9d92d">█</asp:ListItem>
                            <asp:ListItem  value="Color090" style="color: #dd6549">█</asp:ListItem>
                            <asp:ListItem  value="Color100" style="color: #cc463d">█</asp:ListItem>
                            <asp:ListItem  value="Color101" style="color: #cf3e36">█</asp:ListItem>
                            <asp:ListItem  value="Color102" style="color: #5E6671">█</asp:ListItem>
                       
                    </asp:DropDownList>
                        </ContentTemplate>
                          
                        </asp:UpdatePanel>
                 
                </dd>
              </dl>
               <dl>
                    <dt>使用提醒：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="notice" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">使用提醒，字数上限为9 个汉字。（一句话描述，展示在首页，示例：请出示二维码核销卡券 必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>使用说明：</dt>
                    <dd>
                        <textarea name="characters" rows="2" cols="20" id="description"  sucmsg=" " nullmsg=""  class="input" runat="server"></textarea>
                        <span class="Validform_title">使用说明。长文本描述，可以分行，上限为1000 个汉字。 必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>客服电话：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="service_phone" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">客服电话。 非必填</span>
                    </dd>
                </dl>
              <dl>
                    <dt>使用时间类型：</dt>
                    <dd>
                        <asp:RadioButton ID="time_last" runat="server" GroupName="time" Text="固定日期区间" Enabled="False" />
                        <asp:RadioButton ID="time" runat="server"  GroupName="time" Text=" 固定时长（自领取后按天算）" Checked="True"/>
                        <asp:RadioButton ID="alltime" runat="server" GroupName="time" Text="永久有效" Enabled="False" />
                        
                    </dd>
                  <dd>
                      <asp:TextBox runat="server" ID="time_day" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">填入天数（从当天投放卡券开始计算）。 必填</span>
                  </dd>
             
                </dl>
               <dl>
                    <dt>上架数量：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="Cardnumber" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">上架的数量。（不支持填写0或无限大）。 必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>每人使用次数：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="user_limit" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">每人使用次数限制。 非必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>每人最大领取次数：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="get_limit" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">每人最大领取次数，不填写默认等于quantity。 非必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>是否自定义code码：</dt>
                   <dd>
                        <div class="rule-single-checkbox">
                        <asp:CheckBox ID="code" runat="server" Enabled="False" />
                    </div>
                   
                        <span class="Validform_title">是否自定义code码。 （默认code为false）非必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>领取卡券页面是否可分享：</dt>
                    <dd>
                        <div class="rule-single-checkbox">
                        <asp:CheckBox ID="share_page" runat="server" Checked="True" AutoPostBack="True" />
                    </div>
                   
                        <span class="Validform_title">领取卡券页面是否可分享。（默认code为false）非必填</span>
                    </dd>
                </dl>
                <dl>
                <dt>卡券是否可以被转赠</dt>
                <dd>
                    <div class="rule-single-checkbox">
                        <asp:CheckBox ID="share_card" runat="server" Checked="True" />
                    </div>
                    <span class="Validform_title">卡券是否可以被转赠 。 默认为true   非必填</span>
                </dd>
                </dl>
              <br />
              <p style="color: #16a0d3;"">下面的微信买单和自助核销只能选择一个，请查看自己相关权限</p>
              <br />
              <dl>
                <dt>卡券是否需要微信买单</dt>
                <dd>
                    <div class="rule-single-checkbox">
                        <asp:CheckBox ID="paycell" runat="server" />
                    </div>
                    <span class="Validform_title">卡券是否需要微信买单，默认为false （注：使用之前，请确认商户是否支持微信支付）</span>
                </dd>
                </dl>
              <dl>
                <dt>卡券是否支持自助核销</dt>
                <dd>
                    <div class="rule-single-checkbox">
                        <asp:CheckBox ID="hexiao" runat="server"  Checked="false"/>
                    </div>
                    <span class="Validform_title">消费者到店后可通过自助点击卡券上的核销按钮，选择门店完成卡券核销</span>
                </dd>
                  <dd>
                      <span  class="Validform_title">注意：设置自助核销的card_id必须已经配置了门店，否则会报错。
        /// 错误码，0为正常；43008为商户没有开通微信支付权限</span>
                  </dd>
                </dl>
               <dl>
                    <dt>自定义链接入口名称：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="url_name" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">自定义跳转外链的入口名字。 非必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>自定义链接副标题：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="sub_url_name" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">自定义跳转外链的入口名字(右侧显示副标题;最多 6个汉字)。 非必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>自定义链接：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="custom_url" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">自定义跳转外链。 非必填</span>
                    </dd>
                </dl>
               <dl>
                    <dt>营销场景入口名称：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="pro_url_name" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">营销场景的自定义入口名称。 非必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>营销场景入口链接：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="pro_url" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">入口跳转外接连接。 非必填</span>
                    </dd>
                </dl>
                <p style="color: #16a0d3;">以下为卡券高级功能配置，必填项</p>
              <asp:Panel ID="Panel1" runat="server" Visible="False">
                   <dl>
                    <dt>团购券专用</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="deal_detail" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">团购券专用，团购详情。 必填</span>
                    </dd>
                 </dl>

              </asp:Panel>
               <asp:Panel ID="Panel2" runat="server" Visible="False">
                   <dl>
                    <dt>折扣券专用</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="discount" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">折扣券专用，表示打折额度（百分比）。填30 就是七折。 必填</span>
                    </dd>
                 </dl>

              </asp:Panel>
               <asp:Panel ID="Panel3" runat="server" Visible="False">
                   <dl>
                    <dt>起用金额</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="least_cost" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">代金券专用，表示起用金额。 非必填</span>
                    </dd>
                        <dt>减免金额</dt>
                         <dd>
                        <asp:TextBox runat="server" ID="reduce_cost" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">代金券专用，表示减免金额（单位为分）。 必填</span>
                    </dd>
                 </dl>

              </asp:Panel>
               <asp:Panel ID="Panel4" runat="server" Visible="False">
                   <dl>
                    <dt>优惠券专用</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="default_detail" CssClass="input normal"   sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_title">优惠券描述文本。 必填</span>
                    </dd>
                 </dl>

              </asp:Panel>
              <div class="btn-list">
                  <asp:Button ID="sub_save" runat="server"  CssClass="btn" Text="保存" OnClick="sub_save_Click"  />
              </div>

             
              </div>
        
        
          <div>
   
	<div class="showbox" >
		<h2>请选择卡券类型<a class="close" href="#">关闭</a></h2>
        <div class="mainlist" >
            <table class="nlist-2">
                <tr>
                    <td>
                       <asp:RadioButton ID="RadioButton1" runat="server" GroupName="dd" Text="团购券" /></td>
                    </tr>
                 <tr> <td>可为用户提供团购套餐服务</td></tr>  
                
                <tr>
                    <td>    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="dd" Text="折扣券" /></td></tr>
                   <tr> <td>可为用户提供消费折扣，支持优惠抵扣快速买单</td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="dd" Text="代金券" /></td> </tr>
                 <tr>   <td>可为用户提供抵扣现金服务。可设置成为“满*元，减*元”，支持优惠抵扣快速买单</td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="dd" Text="优惠券" /></td> </tr>
                   <tr>  <td> 即“通用券”，建议当以上四种无法满足需求时采用可为用户提供团购套餐服务</td>
                </tr>
            </table> 
          <asp:Button ID="Savecards" runat="server"  CssClass="btn" Text="保存"  />
        </div>
	</div>	
	<div id="zhezhao"></div>
      
    </div>
    </form>
</body>
</html>
