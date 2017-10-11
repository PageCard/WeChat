﻿using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;
using XCWeiXin.Model;
namespace XCWeiXin.BLL
{
	/// <summary>
	/// 大转盘中奖用户信息
	/// </summary>
	public partial class wx_dzpAwardUser
	{
		private readonly XCWeiXin.DAL.wx_dzpAwardUser dal=new XCWeiXin.DAL.wx_dzpAwardUser();
		public wx_dzpAwardUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XCWeiXin.Model.wx_dzpAwardUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCWeiXin.Model.wx_dzpAwardUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XCWeiXin.Model.wx_dzpAwardUser GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		 

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_dzpAwardUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_dzpAwardUser> DataTableToList(DataTable dt)
		{
			List<XCWeiXin.Model.wx_dzpAwardUser> modelList = new List<XCWeiXin.Model.wx_dzpAwardUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCWeiXin.Model.wx_dzpAwardUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }



        public int Add(int aid, string username, string tel, string openid, string jxName, string jpName, string sn)
        {
            XCWeiXin.Model.wx_dzpAwardUser auser = new Model.wx_dzpAwardUser();
            auser.actId = aid;
            auser.uName = username;
            auser.uTel = tel;
            auser.openid = openid;
            auser.jxName = jxName;
            auser.jpName = jpName;
            auser.sn = sn;
            auser.createDate = DateTime.Now;
            return this.Add(auser);

        }

        /// <summary>
        /// 获得中奖的数据列表
        /// </summary>
        public List<XCWeiXin.Model.wx_dzpAwardUser> getHasZJList(int aid)
        {
            DataSet ds = dal.getHasZJList(aid);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 该用户的中奖信息
        /// </summary>
        /// <param name="aid">活动表主键id</param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Model.wx_dzpAwardUser getZJinfoByOpenid(int aid, string openid)
        {
            return dal.getZJinfoByOpenid(aid, openid);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }


        #endregion  ExtensionMethod
	}
}

