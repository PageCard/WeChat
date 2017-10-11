// 加载flag
var loading = false;
// 最多可加载的条目
var maxItems = 100;
var pageindex = 1;
// 每次加载添加多少条目
var itemsPerLoad = 20;
function ajax_card(pageindex) {
    var where = "wid=37";
    $.ajax(
{

    url: "HG_list.ashx",
    data: { number: "8", page: pageindex, where: where },
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    async: false,
    cache: false,
    success: function (msg) {
        var html = "";
        if (msg.count == 8) {
            for (var i = 0; i < 8; i++) {
                //加载开始Start
                html += '<li><div class="card "><div class="card-content"><div class="list-block media-list"><ul>  <li class="item-content"> <div class="item-media"> <img  src="http://gqianniu.alicdn.com/bao/uploaded/i4//tfscom/i3/TB10LfcHFXXXXXKXpXXXXXXXXXX_!!0-item_pic.jpg_250x250q60.jpg" width="44"></div><div class="item-inner cardfont"> <div class="item-title-row"><div class="item-title" >' + msg.ds[i].Hg_name + '<a href="#" class="jp">' + msg.ds[i].dengji + '</a></div></div><div class="item-subtitle"><span>' + msg.ds[i].Hg_sex + '</span><font>|</font><span>' + msg.ds[i].Hg_age + '岁</span><br /><span class="cardfont">服务过8个家庭，好评率95%</span></div></div><span class="ddd  cardfont">260元/人</span></li></ul></div></div><div class="card-footer cardfont" > <div class="col-25">服务范围:</div><div class="col-25"><a href="#" class="button button-primary cardfont">' + msg.ds[i].Hg_str1 + '</a></div><div class="col-25"><a href="#" class="button button-primary cardfont">' + msg.ds[i].Hg_str2 + '</a></div><div class="col-25"><a href="#" class="button button-primary cardfont">' + msg.ds[i].Hg_str3 + '</a></div> </div></div></li>';
                //护工列表加载End

            }

        }
        else {
            for (var i = 0; i < msg.count; i++) {
                //加载开始Start
                html += '<li><div class="card"><div class="card-content"><div class="list-block media-list"><ul>  <li class="item-content"> <div class="item-media"> <img  src="http://gqianniu.alicdn.com/bao/uploaded/i4//tfscom/i3/TB10LfcHFXXXXXKXpXXXXXXXXXX_!!0-item_pic.jpg_250x250q60.jpg" width="44"></div><div class="item-inner cardfont"> <div class="item-title-row"><div class="item-title" >' + msg.ds[i].Hg_name + '<a href="#" class="jp">' + msg.ds[i].dengji + '</a></div></div><div class="item-subtitle"><span>' + msg.ds[i].Hg_sex + '</span><font>|</font><span>' + msg.ds[i].Hg_age + '岁</span><br /><span class="cardfont">服务过8个家庭，好评率95%</span></div></div><span class="ddd  cardfont">260元/人</span></li></ul></div></div><div class="card-footer cardfont" > <div class="col-25">服务范围:</div><div class="col-25"><a href="#" class="button button-primary cardfont">' + msg.ds[i].Hg_str1 + '</a></div><div class="col-25"><a href="#" class="button button-primary cardfont">' + msg.ds[i].Hg_str2 + '</a></div><div class="col-25"><a href="#" class="button button-primary cardfont">' + msg.ds[i].Hg_str3 + '</a></div> </div></div></li>';
                //护工列表加载End
            }
            $('.infinite-scroll-preloader').remove();
        }

        // 添加新条目
        $('.infinite-scroll-bottom .list-container').append(html);


    },
    error: function (x, e) {
        alert("The call to the server side failed. " +
x.responseText);
    }
});

};
function addItems(number, lastIndex) {
    // 生成新条目的HTML
    var html = '';
    for (var i = lastIndex + 1; i <= lastIndex + number; i++) {
        html += '<li class="item-content"><div class="item-inner"><div class="item-title">Item ' + i + '</div></div></li>';
    }
    // 添加新条目
    $('.infinite-scroll-bottom .list-container').append(html);

}
//预先加载20条
ajax_card(1);



// 上次加载的序号

var lastIndex = 20;

// 注册'infinite'事件处理函数
$(document).on('infinite', '.infinite-scroll-bottom', function () {

    // 如果正在加载，则退出
    if (loading) return;

    // 设置flag
    loading = true;

    // 模拟1s的加载过程
    setTimeout(function () {
        // 重置加载flag
        loading = false;

        if (lastIndex >= maxItems) {
            // 加载完毕，则注销无限加载事件，以防不必要的加载
            $.detachInfiniteScroll($('.infinite-scroll'));
            // 删除加载提示符
            $('.infinite-scroll-preloader').remove();
            return;
        }

        // 添加新条目
        addItems(itemsPerLoad, lastIndex);
        // 更新最后加载的序号
        pageindex++;
        ajax_card(pageindex);
        lastIndex = $('.list-container li').length;
        //容器发生改变,如果是js滚动，需要刷新滚动
        $.refreshScroller();
    }, 1000);
});