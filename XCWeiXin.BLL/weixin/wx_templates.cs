using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;
using XCWeiXin.Model;
namespace XCWeiXin.BLL
{
	/// <summary>
	/// 微网站模版表
	/// </summary>
	public partial class wx_templates
	{
		private readonly XCWeiXin.DAL.wx_templates dal=new XCWeiXin.DAL.wx_templates();
		public wx_templates()
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
		public int  Add(XCWeiXin.Model.wx_templates model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCWeiXin.Model.wx_templates model)
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
		public XCWeiXin.Model.wx_templates GetModel(int id)
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
		public List<XCWeiXin.Model.wx_templates> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCWeiXin.Model.wx_templates> DataTableToList(DataTable dt)
		{
			List<XCWeiXin.Model.wx_templates> modelList = new List<XCWeiXin.Model.wx_templates>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCWeiXin.Model.wx_templates model;
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
        /// 【分页】获得模版列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet GetTemplatesList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetTemplatesList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }


        /// <summary>
        /// 通过wid获得微帐号对应的首页模版名称
        /// </summary>
        public string  GetTemplatesFileNameByWid(int wid)
        {

            return dal.GetTemplatesFileNameByWid(wid);
        }


        /// <summary>
        /// 通过wid获得微帐号对应的二级分类模版名称
        /// </summary>
        public string GetErJiTemplatesFileNameByWid(int wid)
        {

            return dal.GetErJiTemplatesFileNameByWid(wid);
        }
        /// <summary>
        /// 通过wid获得微帐号对应的LIST模版名称
        /// </summary>
        public string GetListTemplatesFileNameByWid(int wid)
        {

            return dal.GetListTemplatesFileNameByWid(wid);
        }

        /// <summary>
        /// 通过wid获得微帐号对应的详细页（内容显示）模版名称
        /// </summary>
        public string GetDetailTemplatesFileNameByWid(int wid)
        {

            return dal.GetDetailTemplatesFileNameByWid(wid);
        }
		#endregion  ExtensionMethod


       
    }
}

