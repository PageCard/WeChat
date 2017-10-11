using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;
using XCWeiXin.Model;
namespace XCWeiXin.BLL
{
	/// <summary>
	/// 用户的微信基本表
	/// </summary>
	public partial class wx_userweixin
	{
		private readonly XCWeiXin.DAL.wx_userweixin dal=new XCWeiXin.DAL.wx_userweixin();
		public wx_userweixin()
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
        /// openid的方式查询是否存在该记录
        /// </summary>
        public bool openidExists(string openid)
        {
            return dal.OpenidExists(openid);
        }
        /// <summary>
        /// 获取微信号ID
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string Get_id(string sql)
        {
            return dal.Get_id(sql);
        }
 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XCWeiXin.Model.wx_userweixin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCWeiXin.Model.wx_userweixin model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 更新客服 extInt
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Updata_kefu(XCWeiXin.Model.wx_userweixin model)
        {
            return dal.Upadata_Kefu(model);
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
		public XCWeiXin.Model.wx_userweixin GetModel(int id)
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
		public List<XCWeiXin.Model.wx_userweixin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_userweixin> DataTableToList(DataTable dt)
		{
			List<XCWeiXin.Model.wx_userweixin> modelList = new List<XCWeiXin.Model.wx_userweixin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCWeiXin.Model.wx_userweixin model;
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
		/// 获取记录总和
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
        /// 删除一条数据,假删除
        /// </summary>
        public bool DeleteWeixin(int id)
        {

            return dal.DeleteWeixin(id);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }


        /// <summary>
        /// 获得用户的微信帐号信息【查询分页数据】
        /// </summary>
        public DataSet GetUserWeiXinList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetUserWeiXinList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }


        /// <summary>
        /// 得到一个token
        /// </summary>
        public string  GetWeiXinToken(int id)
        {

            return dal.GetWeiXinToken(id);
        }

        /// <summary>
        /// 取该用户已经有的微信个数
        /// </summary>
        public int GetUserWxNumCount(int uId)
        {
            return dal.GetUserWxNumCount(uId);
        }

        
		#endregion  ExtensionMethod
	}
}

