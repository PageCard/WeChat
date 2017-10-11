﻿using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;
using XCWeiXin.Model;
namespace XCWeiXin.BLL
{
	/// <summary>
	/// 商品表
	/// </summary>
	public partial class wx_book_product
	{
		private readonly XCWeiXin.DAL.wx_book_product dal=new XCWeiXin.DAL.wx_book_product();
		public wx_book_product()
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
		public int  Add(XCWeiXin.Model.wx_book_product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCWeiXin.Model.wx_book_product model)
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
		public List<XCWeiXin.Model.wx_book_product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_book_product> DataTableToList(DataTable dt)
		{
			List<XCWeiXin.Model.wx_book_product> modelList = new List<XCWeiXin.Model.wx_book_product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCWeiXin.Model.wx_book_product model;
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
        /// 得到一个对象实体
        /// </summary>
        public XCWeiXin.Model.wx_book_product GetModel(int id)
        {
            Model.wx_book_product product = new Model.wx_book_product();
            product= dal.GetModel(id);
            product.albums = new wx_book_albums().GetModelList("productId="+id);
            product.attrs = new DAL.wx_book_productAttr_value().GetAttrModelList(id);
            product.skulist = new DAL.wx_book_sku().GetpSkuModelList(id);

            return product;
        }



        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int wid, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(wid,category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

		#endregion  ExtensionMethod
	}
}

