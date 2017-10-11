using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 在线答题－用户
	/// </summary>
	[Serializable]
	public partial class wx_dati_user
	{
		public wx_dati_user()
		{}
		#region Model
		private int _id;
		private int? _wid;
        private int? _aid;
        private string _openid;
        private string _usersum;
        private int? _score;        
        private string _atitle;
        private DateTime _addtime;
     
		
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微信id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 对应题库
		/// </summary>
		public int? aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
        /// <summary>
        /// 题目标题
        /// </summary>
        public string atitle
        {
            set { _atitle = value; }
            get { return _atitle; }
        }
		/// <summary>
		/// 题目标题
		/// </summary>
        public string openid
		{
            set { _openid = value; }
            get { return _openid; }
		}
        /// <summary>
		/// 成绩
		/// </summary>
        public string usersum
		{
            set { _usersum = value; }
            get { return _usersum; }
		}
		/// <summary>
		/// 积分
		/// </summary>
        public int? score
		{
            set { _score = value; }
            get { return _score; }
		}
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
		#endregion Model

	}
}

