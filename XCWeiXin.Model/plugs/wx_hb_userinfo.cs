using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 企业红包基本信息表
	/// </summary>
	[Serializable]
	public partial class wx_hb_userinfo
	{
        public wx_hb_userinfo()
		{}
		#region Model
		private int _id;
		private int? _aid;
        private string _openid;
        private int _price;
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
		/// 上级id
		/// </summary>
		public int? aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
        /// <summary>
        /// 用户openid
        /// </summary>
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }

		/// <summary>
		/// 发放金额
		/// </summary>
        public int price
		{
            set { _price = value; }
            get { return _price; }
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

