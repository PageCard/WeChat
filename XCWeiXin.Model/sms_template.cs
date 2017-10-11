using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// �ֻ�����ģ��
    /// </summary>
    [Serializable]
    public partial class sms_template
    {
        public sms_template()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _call_index = "";
        private string _content = "";
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
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ���ñ���
        /// </summary>
        public string call_index
        {
            set { _call_index = value; }
            get { return _call_index; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
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