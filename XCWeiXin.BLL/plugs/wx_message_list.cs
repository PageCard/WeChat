﻿using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;
using XCWeiXin.Model;
namespace XCWeiXin.BLL
{
	/// <summary>
	/// 数据表2
	/// </summary>
	public partial class wx_message_list
	{
		private readonly XCWeiXin.DAL.wx_message_list dal=new XCWeiXin.DAL.wx_message_list();
		public wx_message_list()
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
		public int  Add(XCWeiXin.Model.wx_message_list model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCWeiXin.Model.wx_message_list model)
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

        public bool Deleteopenid(string id)
		{

            return dal.Deleteopenid(id);
		}
        

        public bool Delete(int id,int wid)
        {

            return dal.Delete(id,wid);
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
		public XCWeiXin.Model.wx_message_list GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public XCWeiXin.Model.wx_message_list GetModelByCache(int id)
        //{
			
        //    string CacheKey = "wx_message_listModel-" + id;
        //    object objModel = XCWeiXin.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = XCWeiXin.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                XCWeiXin.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (XCWeiXin.Model.wx_message_list)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
		}

        public DataSet  GetListDetail(int wid)
        {
            return dal.GetListDetail(wid);
        }

   

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList( string strWhere)
        {
            return dal.GetList( strWhere);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCWeiXin.Model.wx_message_list> GetModelList(string strWhere )
        {
            DataSet ds = dal.GetList( strWhere );
            return DataTableToList(ds.Tables[0]);
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<XCWeiXin.Model.wx_message_list> GetModelList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			DataSet ds = dal.GetList(pageSize,pageIndex,  strWhere, filedOrder, out recordCount);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_message_list> DataTableToList(DataTable dt)
		{
			List<XCWeiXin.Model.wx_message_list> modelList = new List<XCWeiXin.Model.wx_message_list>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCWeiXin.Model.wx_message_list model;
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
        public DataSet GetAllList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			return GetList(pageSize, pageIndex, strWhere,  filedOrder, out  recordCount);
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

		#endregion  ExtensionMethod
	}
}

