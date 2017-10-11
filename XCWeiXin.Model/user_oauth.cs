using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// OAuth��Ȩ�û���Ϣ
    /// </summary>
    [Serializable]
    public partial class user_oauth
    {
        public user_oauth()
        { }
        #region Model
        private int _id;
        private int _user_id;
        private string _user_name;
        private string _oauth_name = "0";
        private string _oauth_access_token = "";
        private string _oauth_openid;
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
        /// ����ƽ̨����
        /// </summary>
        public string oauth_name
        {
            set { _oauth_name = value; }
            get { return _oauth_name; }
        }
        /// <summary>
        /// access_token
        /// </summary>
        public string oauth_access_token
        {
            set { _oauth_access_token = value; }
            get { return _oauth_access_token; }
        }
        /// <summary>
        /// ��Ȩkey
        /// </summary>
        public string oauth_openid
        {
            set { _oauth_openid = value; }
            get { return _oauth_openid; }
        }
        /// <summary>
        /// ��Ȩʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}