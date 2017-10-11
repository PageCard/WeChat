﻿using System;
namespace XCWeiXin.Model
{
	/// <summary>
	/// 预约用户提交的表单结果
	/// </summary>
	[Serializable]
	public partial class wx_diancai_form_result
	{
		public wx_diancai_form_result()
		{}
		#region Model
		private int _id;
		private int? _shopinfoid;
		private string _openid;
		private string _cname;
		private int? _cid;
		private string _userresult;
		private DateTime? _createdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 商家主键id
		/// </summary>
		public int? shopinfoId
		{
			set{ _shopinfoid=value;}
			get{return _shopinfoid;}
		}
		/// <summary>
		/// 微信openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 控件名称
		/// </summary>
		public string cName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 控件id
		/// </summary>
		public int? cId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 用户提交的内容
		/// </summary>
		public string userResult
		{
			set{ _userresult=value;}
			get{return _userresult;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

