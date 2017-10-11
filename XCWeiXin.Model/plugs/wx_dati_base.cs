using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 在线答题设置
	/// </summary>
	[Serializable]
	public partial class wx_dati_base
	{
		public wx_dati_base()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _title;
        private string _bjcolor;
        private int? _dttime;
        private bool _isshowend;
        private DateTime? _addtime;
        private string _summary;
        private string _dxtitle;
        private int? _dxgetnum;
        private int? _dxscore;
        private string _headimg;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private int _jfval;
        private int _jftype;
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
		/// 名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 答题背景色
		/// </summary>
        public string bjcolor
		{
            set { _bjcolor = value; }
            get { return _bjcolor; }
		}
        /// <summary>
        /// 答题背景色
        /// </summary>
        public string headimg
        {
            set { _headimg = value; }
            get { return _headimg; }
        }

		/// <summary>
		/// 答题时间
		/// </summary>
        public int? dttime
		{
            set { _dttime = value; }
            get { return _dttime; }
		}
		/// <summary>
		/// 答题完成后是否显示结果
		/// </summary>
        public bool isshowend
		{
            set { _isshowend = value; }
            get { return _isshowend; }
		}
		/// <summary>
		/// 添加时间（系统）
		/// </summary>
        public DateTime? addtime
		{
            set { _addtime = value; }
            get { return _addtime; }
		}
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? starttime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }

        /// <summary>
        /// 答题介绍
        /// </summary>
        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }


		/// <summary>
		/// 单选题标题
		/// </summary>
        public string dxtitle
		{
            set { _dxtitle = value; }
            get { return _dxtitle; }
		}
		/// <summary>
		/// 单选题获取题量
		/// </summary>
        public int? dxgetnum
		{
            set { _dxgetnum = value; }
            get { return _dxgetnum; }
		}
		/// <summary>
        /// 单选题每题分值
		/// </summary>
        public int? dxscore
		{
            set { _dxscore = value; }
            get { return _dxscore; }
		}
        /// <summary>
        /// 积分类型
        /// </summary>
        public int jftype
        {
            set { _jftype = value; }
            get { return _jftype; }
        }
        /// <summary>
        /// 积分值
        /// </summary>
        public int jfval
        {
            set { _jfval = value; }
            get { return _jfval; }
        }
		#endregion Model

	}
}

