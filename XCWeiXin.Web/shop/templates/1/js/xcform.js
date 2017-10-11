// 表单验证　V1.0

//通过文本验证，不为空，长度限制
function xctxet(str,minleg,maxleg){
var regex =eval("/[\u4E00-\u9FA5]{"+minleg+","+maxleg+"}/g");
return regex.test(str);
}

//手机号码验证
function xcphone(str,minleg,maxleg){
var regex =/^(13[0-9]{9})|(15[0-9]{9})|(17[0-9]{9})$/
return regex.test(str);
}

