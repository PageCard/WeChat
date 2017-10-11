<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select1.aspx.cs" Inherits="XCWeiXin.Web.demo.select1" %>

<!DOCTYPE html>

<html>
<head>
<meta charset="utf-8">
<title>确认投资</title>
<link rel="stylesheet" href="css/min.css">
<link rel="stylesheet" href="css/min_123.css">
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript">
    $(function () {
        $('.reginpblu-yqm').hide();
        $(".regerror2").toggle(function () {
            $(this).find("span").attr("class", "nle-sicon2")
            $(this).parent().find(".reginpblu-yqm").show();
        }, function () {
            $(this).find("span").attr("class", "nle-sicon")
            $(this).parent().find(".reginpblu-yqm").hide();
        })
    })
</script>
</head>
<body id="invest_content">
<div class="ctn-960 mg shadow-5">
  <form  action="#" class="js-form-validate" method="post" onSubmit="return false" data-arg-one="#" data-arg-two="100">
    <div class="confirm-info-list mgt clearfix" style="position: relative; margin:0 auto;">
      <dl class="confirm-info-list-dl confirm-info-list-project">
        <dt class="tc1-title">
          <h2>确认项目</h2>
        </dt>
        <dd class="clearfix">
          <ul class="list-style-1 list-style-1-first">
            <li>项目名称：<span><a href="#">省心计划 I-201604132</a></span></li>
            <li>年化收益：<span>10.00%</span></li>
            <li>还款方式：<span>按月付息，到期还本</span></li>
          </ul>
          <ul class="list-style-1 list-style-1-two">
            <li><span style="letter-spacing:4px">债务方：</span><span>WHBL1507101014416（债务方编号）</span></li>
            <li><span style="letter-spacing:4px">保障方：</span><span>微弘商业保理（深圳）有限公司</span></li>
            <li><span style="letter-spacing:4px">债权方：</span><span>（92672156185417_qq）</span></li>
          </ul>
        </dd>
      </dl>
      <dl class="confirm-info-list-dl">
        <dt class="tc1-title">
          <h2>确认投资</h2>
        </dt>
        <dd>
          <ul class="confirm-info-list-money-ul clearfix">
            <li>
              <div class="td-name" style="margin-bottom:7px;"><strong>投资金额</strong></div>
              <div class="td-value"><span id="changeMoney" style="display:inline-block;padding:0px 4px;font-weight:normal;">100</span> <span style="_vertical-align:text-top;*vertical-align:text-top;font-family:'microsoft yahei';">元</span></div>
            </li>
            <li>
              <div class="td-name">到期总回款</div>
              <div class="td-value"><strong>105.12</strong> 元</div>
            </li>
            <li>
              <div class="td-name">净收益</div>
              <div class="td-value"><strong>5.12</strong> 元</div>
            </li>
            <li>
              <div class="td-name">投资期限</div>
              <div class="td-value"><strong id="jiFenHuiBao">30</strong> 天</div>
            </li>
          </ul>
          <div class="confirm-info-list-money-div clearfix blingbling" style="_height:30px;*height:30px;"> <span class="td-operate td-operate-money-not-enough"> 余额不足，请 <a class="goChargeBtn" href="#" target="_blank" id="top_up" onClick="_hmt.push(['_trackEvent', 'recharge', 'click', 'rec1']);"> 立即充值 </a> </span>
            <label> 
              <!--input type="checkbox" id="use_remain_amount" checked="true" /--> 
              <span class="td-name"><strong>中赢投账户余额：</strong></span> <span class="td-value" style="width:160px;font-weight:bold;font-size:14px;"> <strong id="remain_amount" style="font-size:18px;">0.00</strong> 元</span> </label>
            <span class="td-name" style="font-weight:bold;">还需金额：</span> <span class="td-value td-value-need-more-money" style="font-weight:bold;font-size:14px;"> <strong style="font-size:18px; color: #E24F1A; font-family:Arial;"> 100.00 </strong> 元 </span> </div>
          <label class="regerror regerror2"><span class="nle-sicon"></span>使用红包</label>
          <div class="reginpblu reginpblu-yqm" style=" margin-bottom:20px;    border: 1px solid #E24F1A;">
            <table id="table1" class="accounttable" border="0" cellspacing="0" cellpadding="0" pa_ui_name="table,exinput" pa_ui_hover="true" pa_ui_selectable="true" pa_ui_select_mode="multi" pa_ui_select_trigger="tr" pa_ui_select_column="0" pa_ui_select_triggerelement=":checkbox">
              <thead style="background:#fdeee5;">
                <tr>
                  <td>选择</td>
                  <td>红包名称</td>
                  <td>返现金额</td>
                  <td>使用条件</td>
                </tr>
              </thead>
              <tbody>
                <tr pa_ui_table_hoverable="true" pa_ui_table_selectable="true" class="">
                  <td><input type="radio" name="z"></td>
                  <td>张三</td>
                  <td>2009-01-02</td>
                  <td>12.35</td>
                </tr>
                <tr pa_ui_table_hoverable="true" pa_ui_table_selectable="true" class="">
                  <td><input type="radio" name="z"></td>
                  <td>张三</td>
                  <td>2009-02-02</td>
                  <td>12.35</td>
                </tr>
              </tbody>
            </table>
          </div>
          <div class="confirmationForm clearfix">
            <div id="invest-paypwd">
              <ul class="agree-protocol">
                <li>
                  <label class="plain-text"><span class="td-name" style="font-weight:bolder;">支付密码：</span><span class="plain-text">
                    <input  type="password" value="" placeholder="请输入支付密码" >
                    </span></label>
                  <div class="error-container error" id="form-invest-confirm-error-pass"></div>
                </li>
                <li>
                  <label class="plain-text"><span class="td-name" style="font-weight:bolder;">验 证 码：</span><span class="input-text input-vcode">
                    <input id="valicode" name="valicode" class="valicode_1 input-fucus" type="text" maxlength="4" style="width:80px;margin-right:10px" tabindex="2">
                    </span><span class="vcode"> <img id="vcodeImg" alt="点击刷新" title="点击刷新" class="yanzhengma" src="#"> </span><a style="margin-left:6px;font-size:12px;color:#bdbdbd;" id="vcodeA"> 看不清换一个<span class="pro_tips-1" _title="验证码有效时间15分钟"> </span></a>
                    <input type="hidden" name="id" value="#">
                  </label>
                  <div class="error-container error" id="form-invest-confirm-error-vcode"></div>
                </li>
                <li>
                  <label class="input-checkbox" style="font-size:12px;display:inline;">
                    <input id="agree-protocol" name="agree-protocol" type="checkbox" checked="true">
                    我已阅读并同意按<a href="#" style="color:#E24F1A" target="_blank">《投资合同范本》</a>的格式和条款生成借款协议</label>
                  <div class="error-container error" id="form-invest-confirm-error-proto"></div>
                </li>
              </ul>
              <div class="invest-btn-line">
                <input tabindex="3" id="confirm-btn" type="button" value="确认投资" class="i-p-c-i-btn clearButton">
                <span id="confirmERR" class="error" style="vertical-align:top;color:#CB282D;padding-left:20px;line-height:45px"></span> </div>
            </div>
          </div>
        </dd>
      </dl>
    </div>
  </form>
</div>

<!--投资确认页结束-->

</body>
</html>