using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using XCWeiXin.Common;

namespace XCWeiXin.BLL
{
	/// <summary>
	/// Ƶ�������
	/// </summary>
	public partial class channel_category
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.channel_category dal;

		public channel_category()
		{
            dal = new DAL.channel_category(siteConfig.sysdatabaseprefix);
        }
		#region ��������========================================

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

        /// <summary>
        /// ��ѯ����Ŀ¼���Ƿ����
        /// </summary>
        public bool Exists(string build_path)
        {
            //��վ��Ŀ¼�µ�һ���ļ����Ƿ�ͬ��
            if (DirPathExists(siteConfig.webpath, build_path))
            {
                return true;
            }
            //��վ��aspxĿ¼�µ�һ���ļ����Ƿ�ͬ��
            if (DirPathExists(siteConfig.webpath + "/" + MXKeys.DIRECTORY_REWRITE_ASPX + "/", build_path))
            {
                return true;
            }
            //��Ƶ�������Ƿ�ͬ��
            if (new DAL.channel(siteConfig.sysdatabaseprefix).Exists(build_path))
            {
                return true;
            }
            //��Ƶ����������Ŀ¼�Ƿ�ͬ��
            if (dal.Exists(build_path))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// �����������
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// ����Ƶ�����������Ŀ¼��
        /// </summary>
        public string GetBuildPath(int id)
        {
            return dal.GetBuildPath(id);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Model.channel_category model)
		{
            int newCategoryId = dal.Add(model);
            if (newCategoryId > 0)
            {
                //��ӵ����˵�
                int newNavId = new BLL.navigation().Add("sys_contents", "channel_" + model.build_path, model.title, "", model.sort_id, 0, "Show");
                if (newNavId < 1)
                {
                    dal.Delete(newCategoryId);
                    return 0;
                }
            }
            return newCategoryId;
		}

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(string build_path, string strValue)
        {
            return dal.UpdateField(build_path, strValue);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.channel_category model)
		{
            Model.channel_category oldModel = dal.GetModel(model.id);
            if (dal.Update(model))
            {
                if (oldModel.build_path.ToLower() != model.build_path.ToLower())
                {
                    //����Ƶ�������Ӧ��Ŀ¼����
                    Utils.MoveDirectory(siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_ASPX + "/" + oldModel.build_path,
                        siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_ASPX + "/" + model.build_path);
                    Utils.MoveDirectory(siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_HTML + "/" + oldModel.build_path,
                        siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_HTML + "/" + model.build_path);
                }
                //�޸Ķ�Ӧ�ĵ���
                new BLL.navigation().Update("channel_" + oldModel.build_path, "channel_" + model.build_path, model.title);
                
                return true;
            }
            return false;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int id)
		{
			return dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.channel_category GetModel(int id)
		{
			return dal.GetModel(id);
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.channel_category GetModel(string build_path)
        {
            return dal.GetModel(build_path);
        }

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

		#endregion

        #region ��չ����========================================
        /// <summary>
        /// ����Ĭ�ϵ�����Ŀ¼
        /// </summary>
        public string GetDefaultPath()
        {
            DataTable dt = GetList(1, "is_default=1", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["build_path"].ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// ����Ƶ�������������Ŀ¼
        /// </summary>
        public Dictionary<string, string> GetCategoryDirs()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (siteConfig.mobilestatus == 1)
            {
                dic.Add("mobile", siteConfig.mobiledomain);
            }

            List<Model.channel_category> modelList = DataTableToList(GetList(0, "", "sort_id asc,id desc").Tables[0]);
            foreach (Model.channel_category model in modelList)
            {
                dic.Add(model.build_path.ToLower(), model.domain.ToLower());
            }
            return dic;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Model.channel_category> DataTableToList(DataTable dt)
        {
            List<Model.channel_category> modelList = new List<XCWeiXin.Model.channel_category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.channel_category model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new XCWeiXin.Model.channel_category();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.build_path = dt.Rows[n]["build_path"].ToString();
                    model.domain = dt.Rows[n]["domain"].ToString();
                    if (dt.Rows[n]["is_default"].ToString() != "")
                    {
                        model.is_default = int.Parse(dt.Rows[n]["is_default"].ToString());
                    }
                    if (dt.Rows[n]["sort_id"].ToString() != "")
                    {
                        model.sort_id = int.Parse(dt.Rows[n]["sort_id"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// �������Ŀ¼����ָ��·���µ�һ��Ŀ¼�Ƿ�ͬ��
        /// </summary>
        /// <param name="dirPath">ָ����·��</param>
        /// <param name="build_path">����Ŀ¼��</param>
        /// <returns>bool</returns>
        private bool DirPathExists(string dirPath, string build_path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(dirPath));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if (build_path.ToLower() == dir.Name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}

