using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCWeiXin.Model.Card_wx.CardMange
{
    public class BaseCardUpdateInfo
    {
        /// <summary>
        /// 卡券信息部分
        /// </summary>
        public string card_id { get; set; }
    }
    /// <summary>
    /// 团购券
    /// </summary>
    public class CardUpdata_groupon : BaseCardUpdateInfo
    {
        public Card_groupon groupon { get; set; }
    }
    /// <summary>
    /// 优惠券
    /// </summary>
    public class CardUpdata_general_coupon : BaseCardUpdateInfo
    {
        public Card_general_coupon general_coupon { get; set; }
    }
    public class CardUpdata_cash : BaseCardUpdateInfo
    {
        public Card_cash cash { get; set; }
    }
    public class CardUpdata_discount : BaseCardUpdateInfo
    {
        public Card_discount discount { get; set; }
    }
    /// <summary>
    /// 会员卡
    /// </summary>
    public class CardUpdate_MemberCard : BaseCardUpdateInfo
    {
        public Card_MemberCardUpdateData member_card { get; set; }
    }

    /// <summary>
    /// 门票
    /// </summary>
    public class CardUpdate_ScenicTicket : BaseCardUpdateInfo
    {
        public Card_ScenicTicketData scenic_ticket { get; set; }
    }

    /// <summary>
    /// 电影票
    /// </summary>
    public class CardUpdate_MovieTicket : BaseCardUpdateInfo
    {
        public Card_MovieTicketData movie_ticket { get; set; }
    }
    /// <summary>
    /// 飞机票
    /// </summary>
    public class CardUpdate_BoardingPass : BaseCardUpdateInfo
    {
        public Card_BoardingPassData boarding_pass { get; set; }
    }

    public class BaseUpdateInfo
    {
        /// <summary>
        /// 基本的卡券数据
        /// </summary>
        public Update_BaseCardInfo base_info { get; set; }
    }

    #region 基本的卡券数据，所有卡券通用(相当于BaseInfo)
    /// <summary>
    /// 基本的卡券数据，所有卡券通用。
    /// </summary>
    public class Update_BaseCardInfo
    {
        /// <summary>
        /// 卡券的商户logo，尺寸为300*300。
        /// 必填
        /// </summary>
        public string logo_url { get; set; }
        /// <summary>
        /// 券颜色。按色彩规范标注填写Color010-Color100
        /// 必填
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 使用提醒，字数上限为9 个汉字。（一句话描述，展示在首页，示例：请出示二维码核销卡券）
        /// 非必填
        /// </summary>
        public string notice { get; set; }
        /// <summary>
        /// 客服电话
        /// 非必填
        /// </summary>
        public string service_phone { get; set; }
        /// <summary>
        /// 使用说明。长文本描述，可以分行，上限为1000 个汉字。
        /// 必填
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// code 码展示类型
        /// 必填
        /// </summary>
        public Card_CodeType code_type { get; set; }
        /// <summary>
        /// 每人使用次数限制
        /// 非必填
        /// </summary>
        public int use_limit { get; set; }
        /// <summary>
        /// 每人最大领取次数，不填写默认等于quantity。
        /// 非必填
        /// </summary>
        public int get_limit { get; set; }
        /// <summary>
        /// 领取卡券原生页面是否可分享，填写true 或false，true 代表可分享。默认可分享。
        /// 非必填
        /// </summary>
        public bool can_share { get; set; }
        /// <summary>
        /// 卡券是否可转赠，填写true 或false,true 代表可转赠。默认可转赠。
        /// 非必填
        /// </summary>
        public bool can_give_friend { get; set; }
        /// <summary>
        /// 门店位置ID。商户需在mp 平台上录入门店信息或调用批量导入门店信息接口获取门店位置ID。
        /// 非必填
        /// </summary>
        public string location_id_list { get; set; }
        /// <summary>
        /// 使用日期，有效期的信息
        /// 必填
        /// </summary>
       public Card_UpdateDateInfo date_info { get; set; }
        /// <summary>
        /// 商户自定义cell 名称
        /// 非必填
        /// </summary>

       public string custom_url { get; set; }
       /// <summary>
       /// 自定义跳转外链的入口名字
       /// 非必填
       /// </summary>
       public string custom_url_name { get; set; }
       /// <summary>
       /// 显示在入口右侧的提示语
       /// 非必填
       /// </summary>
       public string custom_url_sub_title { get; set; }
       /// <summary>
       /// 营销场景的自定义入口名称
       /// 非必填
       /// </summary>
       public string promotion_url_name { get; set; }
       /// <summary>
       /// 入口跳转外链的地址链接
       /// 非必填
       /// </summary>
       public string promotion_url { get; set; }
       /// <summary>
       /// 显示在营销入口右侧的提示语
       /// 非必填
       /// </summary>
       public string promotion_url_sub_title { get; set; }
    }
    /// <summary>
    /// 使用日期，有效期的信息
    /// </summary>
    public class Card_UpdateDateInfo
    {
        /// <summary>
        /// 使用时间的类型 1：固定日期区间，2：固定时长（自领取后按天算）
        /// 必填
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 固定日期区间专用，表示起用时间。从1970 年1 月1 日00:00:00 至起用时间的秒数，最终需转换为字符串形态传入，下同。（单位为秒）
        /// 非必填
        /// </summary>
        public long begin_timestamp { get; set; }
        /// <summary>
        /// 固定日期区间专用，表示结束时间。（单位为秒）
        /// 非必填
        /// </summary>
        public long end_timestamp { get; set; }
    }

    #endregion
}
