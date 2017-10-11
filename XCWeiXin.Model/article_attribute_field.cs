using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// ��չ���Զ����
    /// </summary>
    [Serializable]
    public partial class article_attribute_field
    {
        public article_attribute_field()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _title = "";
        private string _control_type;
        private string _data_type;
        private int _data_length = 0;
        private int _data_place = 0;
        private string _item_option = "";
        private string _default_value = "";
        private int _is_required = 0;
        private int _is_password = 0;
        private int _is_html = 0;
        private int _editor_type = 0;
        private string _valid_tip_msg = "";
        private string _valid_error_msg = "";
        private string _valid_pattern = "";
        private int _sort_id = 99;
        private int _is_sys = 0;
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
        public string name
        {
            set { _name = value; }
            get { return _name; }
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
        /// �ؼ�����
        /// </summary>
        public string control_type
        {
            set { _control_type = value; }
            get { return _control_type; }
        }
        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string data_type
        {
            set { _data_type = value; }
            get { return _data_type; }
        }
        /// <summary>
        /// �ֶγ���
        /// </summary>
        public int data_length
        {
            set { _data_length = value; }
            get { return _data_length; }
        }
        /// <summary>
        /// С����λ��
        /// </summary>
        public int data_place
        {
            set { _data_place = value; }
            get { return _data_place; }
        }
        /// <summary>
        /// ѡ���б�
        /// </summary>
        public string item_option
        {
            set { _item_option = value; }
            get { return _item_option; }
        }
        /// <summary>
        /// Ĭ��ֵ
        /// </summary>
        public string default_value
        {
            set { _default_value = value; }
            get { return _default_value; }
        }
        /// <summary>
        /// �Ƿ����0�Ǳ���1����
        /// </summary>
        public int is_required
        {
            set { _is_required = value; }
            get { return _is_required; }
        }
        /// <summary>
        /// �Ƿ������
        /// </summary>
        public int is_password
        {
            set { _is_password = value; }
            get { return _is_password; }
        }
        /// <summary>
        /// �Ƿ�����HTML
        /// </summary>
        public int is_html
        {
            set { _is_html = value; }
            get { return _is_html; }
        }
        /// <summary>
        /// �༭������0��׼��1�����
        /// </summary>
        public int editor_type
        {
            set { _editor_type = value; }
            get { return _editor_type; }
        }
        /// <summary>
        /// ��֤��ʾ��Ϣ
        /// </summary>
        public string valid_tip_msg
        {
            set { _valid_tip_msg = value; }
            get { return _valid_tip_msg; }
        }
        /// <summary>
        /// ��֤ʧ����ʾ��Ϣ
        /// </summary>
        public string valid_error_msg
        {
            set { _valid_error_msg = value; }
            get { return _valid_error_msg; }
        }
        /// <summary>
        /// ��֤������ʽ
        /// </summary>
        public string valid_pattern
        {
            set { _valid_pattern = value; }
            get { return _valid_pattern; }
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
        /// ϵͳĬ��
        /// </summary>
        public int is_sys
        {
            set { _is_sys = value; }
            get { return _is_sys; }
        }
        #endregion Model

    }
}