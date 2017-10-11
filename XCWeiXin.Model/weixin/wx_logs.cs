﻿using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 微信相关日志表
	/// </summary>
	[Serializable]
	public partial class wx_logs
	{
		public wx_logs()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _modelname;
		private string _remark;
		private int? _logstype;
		private string _logstypename;
		private DateTime? _createdate= DateTime.Now;
		private string _logscontent;
		private string _logstitle;
		private string _funname;
		private string _createperson;
		private int? _extint;
		private string _extstr;
		private string _extstr2;
		private string _extstr3;
		private string _flg;
		private string _flg2;
		private string _flg3;
		private int? _flgint;
		private DateTime? _flgdate;
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
		/// 模版名称
		/// </summary>
		public string modelName
		{
			set{ _modelname=value;}
			get{return _modelname;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 日志类型（0错误，1正常）
		/// </summary>
		public int? logsType
		{
			set{ _logstype=value;}
			get{return _logstype;}
		}
		/// <summary>
		/// 日志类型名称
		/// </summary>
		public string logsTypeName
		{
			set{ _logstypename=value;}
			get{return _logstypename;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 日志内容
		/// </summary>
		public string logsContent
		{
			set{ _logscontent=value;}
			get{return _logscontent;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string logsTitle
		{
			set{ _logstitle=value;}
			get{return _logstitle;}
		}
		/// <summary>
		/// 方法名称
		/// </summary>
		public string funName
		{
			set{ _funname=value;}
			get{return _funname;}
		}
		/// <summary>
		/// 创建者
		/// </summary>
		public string createPerson
		{
			set{ _createperson=value;}
			get{return _createperson;}
		}
		/// <summary>
		/// 扩展int
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		/// <summary>
		/// 扩展str
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展str2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}
		/// <summary>
		/// 扩展str3
		/// </summary>
		public string extStr3
		{
			set{ _extstr3=value;}
			get{return _extstr3;}
		}
		/// <summary>
		/// 标志
		/// </summary>
		public string flg
		{
			set{ _flg=value;}
			get{return _flg;}
		}
		/// <summary>
		/// 标志2
		/// </summary>
		public string flg2
		{
			set{ _flg2=value;}
			get{return _flg2;}
		}
		/// <summary>
		/// 标志3
		/// </summary>
		public string flg3
		{
			set{ _flg3=value;}
			get{return _flg3;}
		}
		/// <summary>
		/// 标志int
		/// </summary>
		public int? flgInt
		{
			set{ _flgint=value;}
			get{return _flgint;}
		}
		/// <summary>
		/// 标志时间
		/// </summary>
		public DateTime? flgDate
		{
			set{ _flgdate=value;}
			get{return _flgdate;}
		}
		#endregion Model

	}
}

