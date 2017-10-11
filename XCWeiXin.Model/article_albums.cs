using System;

namespace XCWeiXin.Model
{
    /// <summary>
    /// ͼƬ���
    /// </summary>
    [Serializable]
    public partial class article_albums
    {
        public article_albums()
        { }
        #region Model
        private int _id;
        private int _article_id = 0;
        private string _thumb_path = "";
        private string _original_path = "";
        private string _remark = "";
        private DateTime _add_time = DateTime.Now;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// ����ͼ��ַ
        /// </summary>
        public string thumb_path
        {
            set { _thumb_path = value; }
            get { return _thumb_path; }
        }
        /// <summary>
        /// ԭͼ��ַ
        /// </summary>
        public string original_path
        {
            set { _original_path = value; }
            get { return _original_path; }
        }
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// �ϴ�ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}