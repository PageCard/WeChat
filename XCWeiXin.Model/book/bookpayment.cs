using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// ֧����ʽ
    /// </summary>
    [Serializable]
    public partial class bookpayment
    {
        public bookpayment()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _img_url = "";
        private string _remark;
        private int _type = 1;
        private int _poundage_type = 1;
        private decimal _poundage_amount = 0;
        private int _sort_id = 99;
        private int _is_lock = 0;
        private string _api_path = "";
        private int? _wid;
        private int? _ptypeid;

        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ֧������
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ��ʾͼƬ
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
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
        /// ֧������1����2����
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// ����������1�ٷֱ�2�̶����
        /// </summary>
        public int poundage_type
        {
            set { _poundage_type = value; }
            get { return _poundage_type; }
        }
        /// <summary>
        /// �����ѽ��
        /// </summary>
        public decimal poundage_amount
        {
            set { _poundage_amount = value; }
            get { return _poundage_amount; }
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
        /// �Ƿ�����
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        /// <summary>
        /// APIĿ¼����
        /// </summary>
        public string api_path
        {
            set { _api_path = value; }
            get { return _api_path; }
        }

        /// <summary>
        /// ΢�ʺ�id
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
        }
        /// <summary>
        /// ֧������
        /// </summary>
        public int? pTypeId
        {
            set { _ptypeid = value; }
            get { return _ptypeid; }
        }

        #endregion Model

    }
}