using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCWeiXin.Model.Card_wx
{
    /// <summary>
    /// 卡券基本信息
    /// </summary>
    public class Card_BaseInfo
    {
        /// <summary>
        /// 基本卡券信息
        /// </summary>
        private int _baseinfoid;
        private int _wid;
        private string _logo_url;
        private string _brand_name;
        private string _title;
        private string _sub_title;
        private string _color;
        private string _notice;
        private string _service_phone;
        private string _source;
        private string _description;
        private int _use_limit;
        private int _get_limit;
        private bool _use_custom_code;
        private bool _bind_openid;
        private bool _can_share;
        private string _type;
        private string _begin_timestamp;
        private string _end_timestamp;
        private int _quantity;
        private bool _can_give_friend;
        private string _url_name_type;
        private string _custom_url;
        private string _custom_url_name;
        private string _custom_url_sub_title;
        private string _promotion_url;
        private string _promotion_url_name;
        private bool _Paycell;
        private bool _hexiao;


     /// <summary>
     /// 代金券专用
     /// </summary>
        private int _card_id;
    //  private int _wid;
        private string _least_cost;
        private string _reduce_cost;

        /// <summary>
        /// 通用券（优惠券）详情
        /// </summary>
        private string _default_detail;

        /// <summary>
        /// 团购券详情
        /// </summary>
        private string _deal_detail;
        
        /// <summary>
        ///折扣券专用，表示打折额度（百分比）
        /// </summary>
        private string _discount;

        /// <summary>
        /// code码展示类型
        /// </summary>
        public string code_type { get; set; }


        public Card_BaseInfo date_info { get; set; }
        public Card_BaseInfo sku { get; set; }
        public string url_name_type { get; set; }
        public Card_BaseInfo()
        {
        }
        public Card_BaseInfo base_info { get; set; }
        /// <summary>
        /// 卡券基本信息ID  BaseInfoID
        /// </summary>
        public int BaseInfoID    
        {
            get { return _baseinfoid; }
            set { _baseinfoid = value; }
        }

        /// <summary>
        /// 是否支持微信快速买单
        /// </summary>
        public bool Paycell
        {
            get { return _Paycell; }
            set { _Paycell = value; }
        }
        /// <summary>
        /// 卡券id
        /// </summary>
        public  string card_id { get; set; }
        /// <summary>
        /// 是否支持自助核销
        /// </summary>
        public bool hexiao
        {
            get { return _hexiao; }
            set { _hexiao = value; }
        }

        /// <summary>
        /// 微信号id  wid
        /// </summary>
        public int wid
        {
            get { return _wid; }
            set { _wid = value; }
        }
        /// <summary>
        /// 卡券类型
        /// </summary>
        public string Card_type
        {
            get;
            set;
        }
        /// <summary>
        /// 微信创建卡券成功以后进行接收到的卡券ID
        /// </summary>
        public string Wx_Card_id
        {
            get;
            set;
        }

        /// <summary>
        ///logo图片（300*300） logo_url
        ///必填
        /// </summary>
        public string logo_url
        {
            get { return _logo_url; }
            set { _logo_url = value; }
        }

        /// <summary>
        /// 商户名字（字数上限为12个汉字） brand_name
        /// 必填
        /// </summary>
        public string brand_name
        {
            get { return _brand_name; }
            set { _brand_name = value; }
        }

        /// <summary>
        ///卡券名称（字数上限为9个汉字） title
        ///必填
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 卡券名称的副标题（字数上限18个汉字） sub_title
        /// 非必填
        /// </summary>
        public string sub_title
        {
            get { return _sub_title; }
            set { _sub_title = value; }
        }

        /// <summary>
        ///卡券颜色，按照微信色彩规范标准 color10-color100 
        ///必填
        /// </summary>
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        ///使用提醒：字数上限为9个汉字（实例：请出示二维码卡券） notice
        ///必填
        /// </summary>
        public string notice
        {
            get { return _notice; }
            set { _notice = value; }
        }

        /// <summary>
        /// 客服电话（ service_phone）
        /// 非必填
        /// </summary>
        public string service_phone
        {
            get { return _service_phone; }
            set { _service_phone = value; }
        }

        /// <summary>
        ///第三方来源 （实例：同程旅游） source
        ///非必填
        /// </summary>
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        /// <summary>
        ///使用说明（长文本描述。可分行，上限1000字，） description
        ///必填
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// 每人使用次数限制 use_limit
        /// 非必填
        /// </summary>
        public int use_limit
        {
            get { return _use_limit; }
            set { _use_limit = value; }
        }

        /// <summary>
        ///没人最大领取次数，不填默认为quantity，get_limit
        ///非必填
        /// </summary>
        public int get_limit
        {
            get { return _get_limit; }
            set { _get_limit = value; }
        }

        /// <summary>
        ///是否自定义code码。必填默认false ； use_custom_code
        ///非必填
        /// </summary>
        public bool use_custom_code
        {
            get { return _use_custom_code; }
            set { _use_custom_code = value; }
        }

        /// <summary>
        ///是否指定用户领取，填写true或false。不填默认为否； bind_openid
        ///非必填
        /// </summary>
        public bool bind_openid
        {
            get { return _bind_openid; }
            set { _bind_openid = value; }
        }

        /// <summary>
        ///领取卡券原生页面是否可分享。填写true或false，true代表可分享，默认可分享 can_share
        ///非必填
        /// </summary>
        public bool can_share
        {
            get { return _can_share; }
            set { _can_share = value; }
        }

        /// <summary>
        /// 使用时间的类型 1：固定日期区间，2：固定时长，3： 永久有效（自领取后按天算） type
        /// 必填
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// 固定日期区间专用，表示起用时间。从1970 年1 月1 日00:00:00 至起用时间的秒数，最终需转换为字符串形态传入，下同。（单位为秒）begin_timestamp
        /// 必填 
        /// </summary>
        public string begin_timestamp
        {
            get { return _begin_timestamp; }
            set { _begin_timestamp = value; }
        }

        /// <summary>
        /// 固定日期区间专用，表示结束时间。（单位为秒）end_timestamp
        /// 必填 
        /// </summary>
        public string end_timestamp
        {
            get { return _end_timestamp; }
            set { _end_timestamp = value; }
        }

        /// <summary>
        ///上架的数量。（不支持填写0或无限大）quantity
        /// 必填 
        /// </summary>
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        /// <summary>
        ///卡券是否可转增，填写true或false，true代表可分享，默认可分享 can_give_friend
        ///非必填
        /// </summary>
        public bool can_give_friend
        {
            get { return _can_give_friend; }
            set { _can_give_friend = value; }
        }
        /// <summary>
        /// 使用门店列表
        /// </summary>
        public List<string> location_id_list { get; set; }

        /// <summary>
        ///商户自定义cell名称 url_name_type
        ///非必填
        /// </summary>
       // public Card_UrlNameType url_name_type { get; set; }
       

        /// <summary>
        /// 商户自定义url 地址，支持卡券页内跳转,跳转页面内容需与自定义cell 名称保持一致。
        /// 非必填
        /// </summary>
        public string custom_url
        {
            get { return _custom_url; }
            set { _custom_url = value; }
        }

        /// <summary>
        ///自定义跳转外链的入口名字 custom_url_name
        /// 非必填 
        /// </summary>
        public string custom_url_name
        {
            get { return _custom_url_name; }
            set { _custom_url_name = value; }
        }

        /// <summary>
        /// 显示在入口右侧的提示语 custom_url_sub_title
        /// 非必填 
        /// </summary>
        public string custom_url_sub_title
        {
            get { return _custom_url_sub_title; }
            set { _custom_url_sub_title = value; }
        }

        /// <summary>
        ///入口跳转外链的地址链接 promotion_url
        /// 非必填 
        /// </summary>
        public string promotion_url
        {
            get { return _promotion_url; }
            set { _promotion_url = value; }
        }

        /// <summary>
        /// 营销场景的自定义入口名称 promotion_url_name
        /// 非必填 
        /// </summary>
        public string promotion_url_name
        {
            get { return _promotion_url_name; }
            set { _promotion_url_name = value; }
        }


        ///Cost  代金券专用
       
      
        /// <summary>
        ///代金券卡券ID Card_ID
        /// </summary>
        public int Card_ID
        {
            get { return _card_id; }
            set { _card_id = value; }
        }

     

        /// <summary>
        ///代金券专用，表示起用金额（单位为分） least_cost
        /// 非必填 
        /// </summary>
        public string  least_cost
        {
            get { return _least_cost; }
            set { _least_cost = value; }
        }

        /// <summary>
        ///代金券专用，表示减免金额（单位为分） reduce_cost
        /// 必填 
        /// </summary>
        public string reduce_cost
        {
            get { return _reduce_cost; }
            set { _reduce_cost = value; }
        }





        //通用券（优惠券详情）
        /// <summary>
        ///通用券，通用券详情 default_detail
        /// </summary>
        public string default_detail
        {
            get { return _default_detail; }
            set { _default_detail = value; }
        }


        /// <summary>
        /// 团购券专用，团购详情
        /// 必填
        /// </summary>
        public string deal_detail
        {
            get { return _deal_detail; }
            set { _deal_detail = value; }
        }


        /// <summary>
        ///折扣券专用，表示打折额度（百分比）。填30 就是七折。discount
        /// 必填 
        /// </summary>
        public string discount
        {
            get { return _discount; }
            set { _discount = value; }
        }



    }

}
