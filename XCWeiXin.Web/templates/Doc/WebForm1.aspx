<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="XCWeiXin.Web.templates.Doc.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript">

        function showLogin() {

            if (document.getElementById("datetimepicker3")) {
                var date = new Date();
                var v = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
                var b = document.getElementById("datetimepicker3").value = v;
                alert(b);
            }
            else {
                alert("not define");
            }
        }

</script>
<style>
	body{font-family:'microsoft yahei';}
	em{font-style:normal;font-size:14px;}
	.form-group {position: relative;width:140px;}
	.form-group-txt{height:32px;line-height:32px;padding:0 10px;}
	.form-group-select {/*padding-left: 1px;*/}
	.form-control,
	.simulation-input {
		width: 100%;
		line-height: 16px;
		font-size: 12px;
		color: #4b555b;
		background: none;
		outline: none;
		border: 1px solid #d3dcdd;
		background-color: #fff;
		-webkit-box-sizing: border-box;
		-moz-box-sizing: border-box;
		-ms-box-sizing: border-box;
		box-sizing: border-box;
		margin: 0 -1px;
		padding: 7px 8px;
		*padding-left: 0;
		*padding-right: 0;
		*text-indent: 8px;
		*float: left;
		transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
	}
	.float-left{float:left;}
</style>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
        <input type="file" name="file0"id="file0" />
    <!--主体开始-->
<div class="container" style="width:500px;margin:80px auto;">
    <div class="inner">
        <div class="service-wrap">
            <div class="main-form">
                <div class="table-form service-form">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table table-cell">
                        <tbody>
                            <tr>
                                <th width="14%"><span>时间：</span></th>
                                <td>
                                    <div class="form-group float-left w140">
                                        <input type="text" name="datepicker" id="datetimepicker1" class="form-control" value="9:00"/>
                                    </div>
                                    <div class="float-left form-group-txt">至</div>
                                    <div class="form-group float-left w140">
                                        <input type="text" name="datepicker" id="datetimepicker2" class="form-control" value="23:00"/>
                                    </div>

                                </td>
                            </tr>
							<tr>
								<th><span></span></th>
								<td>&nbsp;</td>
							</tr>
                            <tr>
                                <th><span>日期：</span></th>
                                <td>
                                    <div class="form-group float-left w140">
                                        <input type="text" name="datepicker" id="datetimepicker3" class="form-control" value="2016-11-5"/>
                                    </div>

                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
         <input type="range" name="range" min="0" max="360" step="1" value="0" />

        <asp:Button ID="bt1" runat="server"  Text="上传" OnClick="bt1_Click"/>
<!--主体结束-->

<link rel="stylesheet" type="text/css" href="css/lq.datetimepick.css"/>
<script src="js/jquery.js" type="text/javascript"></script>
<script src='js/selectUi.js' type='text/javascript'></script>
<script src='js/lq.datetimepick.js' type='text/javascript'></script>
<script type="text/javascript">

    $(function () {
        $("#datetimepicker1").on("click", function (e) {
            e.stopPropagation();
            $(this).lqdatetimepicker({
                css: 'datetime-hour'
            });

        });



        $("#datetimepicker2").on("click", function (e) {
            e.stopPropagation();
            $(this).lqdatetimepicker({
                css: 'datetime-hour'
            });

        });

        $("#datetimepicker3").on("click", function (e) {
            e.stopPropagation();
            $(this).lqdatetimepicker({
                css: 'datetime-day',
                dateType: 'D',
                selectback: function () {

                }
            });

        });
    });
</script>



    </form>
</body>
</html>
