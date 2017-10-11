using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// Ƶ�������
    /// </summary>
    [Serializable]
    public partial class channel_category
    {
        public channel_category()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _build_path = "";
        private string _templet_path = "";
        private string _domain = "";
        private int _is_default = 0;
        private int _sort_id = 99;
        private int? _wid;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// �����ļ�������
        /// </summary>
        public string build_path
        {
            set { _build_path = value; }
            get { return _build_path; }
        }

        /// <summary>
        /// ģ���ļ�������
        /// </summary>
        public string templet_path
        {
            set { _templet_path = value; }
            get { return _templet_path; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string domain
        {
            set { _domain = value; }
            get { return _domain; }
        }
        /// <summary>
        /// �Ƿ�Ĭ��
        /// </summary>
        public int is_default
        {
            set { _is_default = value; }
            get { return _is_default; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// ΢�ʺ�����Id
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
        }

        #endregion Model

    }
}