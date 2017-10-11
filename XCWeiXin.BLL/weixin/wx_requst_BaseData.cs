using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;
using XCWeiXin.Model;
namespace XCWeiXin.BLL
{
	/// <summary>
	/// 所有用户请求的信息
	/// </summary>
	public partial class wx_requst_BaseData
	{
		private readonly XCWeiXin.DAL.wx_requst_BaseData dal=new XCWeiXin.DAL.wx_requst_BaseData();
		public wx_requst_BaseData()
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
		public int  Add(XCWeiXin.Model.wx_requst_BaseData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCWeiXin.Model.wx_requst_BaseData model)
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
		public XCWeiXin.Model.wx_requst_BaseData GetModel(int id)
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
		public List<XCWeiXin.Model.wx_requst_BaseData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_requst_BaseData> DataTableToList(DataTable dt)
		{
			List<XCWeiXin.Model.wx_requst_BaseData> modelList = new List<XCWeiXin.Model.wx_requst_BaseData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCWeiXin.Model.wx_requst_BaseData model;
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
        /// 增加一条数据
        /// </summary>
        public int Add(string msgType, string openid, string createTime, string content, string xmlContent)
        {
            XCWeiXin.Model.wx_requst_BaseData baseData = new Model.wx_requst_BaseData();
            baseData.wx_msgType = msgType;
            baseData.wx_openid = openid;
            baseData.wx_createTime = createTime;
            baseData.wx_dataContent = content;
            baseData.wx_xmlContent = xmlContent;
            baseData.createDate = DateTime.Now;
            return dal.Add(baseData);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string msgType, string openid, string createTime, string content, string url, string eventKey, string xmlContent)
        {
            XCWeiXin.Model.wx_requst_BaseData baseData = new Model.wx_requst_BaseData();
            baseData.wx_msgType = msgType;
            baseData.wx_openid = openid;
            baseData.wx_createTime = createTime;
            baseData.wx_dataContent = content;
            baseData.wx_url = url;
            baseData.wx_eventKey = eventKey;
            baseData.wx_xmlContent = xmlContent;
            baseData.createDate = DateTime.Now;
            return dal.Add(baseData);
        }

		#endregion  ExtensionMethod
	}
}

