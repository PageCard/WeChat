using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 企业红包基本信息表
	/// </summary>
	[Serializable]
	public partial class wx_hb_base
	{
		public wx_hb_base()
		{}
		#region Model
		private int _id;
		private int? _wid;
        private string _appID;
        private string _title;
        private string _depict;
        private string _zftxt;
        private int? _pricemin;
        private int? _pricemax;
        private string _payname;
        private string _paynum;
        private string _paypass;
        private string _payZSadd;       
        private string _payreIP;
        private string _signname;
        private DateTime? _startTime;
        private DateTime? _endTime;
		 private DateTime? _addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
        /// <summary>
        /// 公众号appid
        /// </summary>
        public string appID
        {
            set { _appID = value; }
            get { return _appID; }
        }

		/// <summary>
		/// 红包标题
		/// </summary>
        public string title
		{
            set { _title = value; }
            get { return _title; }
		}
		/// <summary>
		/// 红包描述
		/// </summary>
        public string depict
		{
            set { _depict = value; }
            get { return _depict; }
		}
		/// <summary>
		/// 祝福语
		/// </summary>
        public string zftxt
		{
            set { _zftxt = value; }
            get { return _zftxt; }
		}
		/// <summary>
		/// 红包最小金额
		/// </summary>
        public int? pricemin
		{
            set { _pricemin = value; }
            get { return _pricemin; }
		}
		/// <summary>
        /// 红包最大金额
		/// </summary>
        public int? pricemax
		{
            set { _pricemax = value; }
            get { return _pricemax; }
		}
		/// <summary>
		/// 商户名称
		/// </summary>
        public string payname
		{
            set { _payname = value; }
            get { return _payname; }
		}
		/// <summary>
		/// 商户ID
		/// </summary>
        public string paynum
		{
            set { _paynum = value; }
            get { return _paynum; }
		}
		/// <summary>
		/// 商户支付密钥
		/// </summary>
        public string paypass
		{
            set { _paypass = value; }
            get { return _paypass; }
		}
		/// <summary>
		/// API支付证书地址，服务器地址
		/// </summary>
        public string payZSadd
		{
            set { _payZSadd = value; }
            get { return _payZSadd; }
		}
		/// <summary>
		///支付三方服务器IP地址
		/// </summary>
        public string payreIP
		{
            set { _payreIP = value; }
            get { return _payreIP; }
		}
		/// <summary>
		/// 签名
		/// </summary>
        public string signname
		{
            set { _signname = value; }
            get { return _signname; }
		}
        /// <summary>
		/// 活动开始时间
		/// </summary>
        public DateTime? startTime
		{
            set { _startTime = value; }
            get { return _startTime; }
		} 
        /// <summary>
		/// 活动结束时间
		/// </summary>
        public DateTime? endTime
		{
            set { _endTime = value; }
            get { return _endTime; }
		}
		/// <summary>
		/// 添加时间
		/// </summary>
        public DateTime? addtime
		{
            set { _addtime = value; }
            get { return _addtime; }
		}
      
		#endregion Model

	}
}

