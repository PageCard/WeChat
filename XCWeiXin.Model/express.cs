using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// �������
    /// </summary>
    [Serializable]
    public partial class express
    {
        public express()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _express_code = "";
        private decimal _express_fee = 0M;
        private string _website = "";
        private string _remark = "";
        private int _sort_id = 99;
        private int _is_lock = 0;
        private int _wid = 0;

      
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ��ݴ���
        /// </summary>
        public string express_code
        {
            set { _express_code = value; }
            get { return _express_code; }
        }
        /// <summary>
        /// ���ͷ���
        /// </summary>
        public decimal express_fee
        {
            set { _express_fee = value; }
            get { return _express_fee; }
        }
        /// <summary>
        /// �����ַ
        /// </summary>
        public string website
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// ��ע˵��
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// �Ƿ�����0����1����
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }

        /// <summary>
        /// ΢�ʺ�id
        /// </summary>
        public int wid
        {
            get { return _wid; }
            set { _wid = value; }
        }
        #endregion Model

    }
}