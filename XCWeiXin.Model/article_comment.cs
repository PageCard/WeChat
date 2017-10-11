using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// ��������:ʵ����
    /// </summary>
    [Serializable]
    public partial class article_comment
    {
        public article_comment()
        { }
        #region Model
        private int _id;
        private int _channel_id = 0;
        private int _article_id = 0;
        private int _parent_id = 0;
        private int _user_id = 0;
        private string _user_name = "";
        private string _user_ip;
        private string _content;
        private int _is_lock = 0;
        private DateTime _add_time = DateTime.Now;
        private int _is_reply = 0;
        private string _reply_content;
        private DateTime? _reply_time;
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
        /// Ƶ��ID
        /// </summary>
        public int channel_id
        {
            set { _channel_id = value; }
            get { return _channel_id; }
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
        /// ������ID
        /// </summary>
        public int parent_id
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        /// <summary>
        /// �û�ID
        /// </summary>
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// �û�IP
        /// </summary>
        public string user_ip
        {
            set { _user_ip = value; }
            get { return _user_ip; }
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
        /// �Ƿ�����
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// �Ƿ��Ѵ�
        /// </summary>
        public int is_reply
        {
            set { _is_reply = value; }
            get { return _is_reply; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string reply_content
        {
            set { _reply_content = value; }
            get { return _reply_content; }
        }
        /// <summary>
        /// �ظ�ʱ��
        /// </summary>
        public DateTime? reply_time
        {
            set { _reply_time = value; }
            get { return _reply_time; }
        }
        #endregion Model

    }
}