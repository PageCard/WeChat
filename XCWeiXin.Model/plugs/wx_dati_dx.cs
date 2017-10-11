using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 在线答题－单选
	/// </summary>
	[Serializable]
	public partial class wx_dati_dx
	{
		public wx_dati_dx()
		{}
		#region Model
		private int _id;
		private int? _pid;
		private string _title;
        private int? _score;     
        private bool _isshow;
        private string _answer;
        private string _summary;
        private string _xA;
        private string _xB;
        private string _xC;
        private string _xD;
        private string _xE;
        private string _xF;
        private int _sid;
		
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
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 上级id
		/// </summary>
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}

		/// <summary>
		/// 题目标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 题目分值
		/// </summary>
        public int? score
		{
            set { _score = value; }
            get { return _score; }
		}		
		/// <summary>
		/// 是否显示题目
		/// </summary>
        public bool isshow
		{
            set { _isshow = value; }
            get { return _isshow; }
		}
		/// <summary>
		/// 答案
		/// </summary>
        public string answer
		{
            set { _answer = value; }
            get { return _answer; }
		}
        /// <summary>
        /// 题目注解
        /// </summary>
        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }

        /// <summary>
        /// 选项A
        /// </summary>
        public string xA
        {
            set { _xA = value; }
            get { return _xA; }
        }
        /// <summary>
        /// 选项B
        /// </summary>
        public string xB
        {
            set { _xB = value; }
            get { return _xB; }
        }

        /// <summary>
        /// 选项B
        /// </summary>
        public string xC
        {
            set { _xC = value; }
            get { return _xC; }
        }

        /// <summary>
        /// 选项D
        /// </summary>
        public string xD
        {
            set { _xD = value; }
            get { return _xD; }
        }

        /// <summary>
        /// 选项E
        /// </summary>
        public string xE
        {
            set { _xE = value; }
            get { return _xE; }
        }

        /// <summary>
        /// 选项A
        /// </summary>
        public string xF
        {
            set { _xF = value; }
            get { return _xF; }
        }


		#endregion Model

	}
}

