using System;
using System.Collections.Generic;

namespace XCWeiXin.Model
{
    /// <summary>
    /// ϵͳƵ����
    /// </summary>
    [Serializable]
    public partial class channel
    {
        public channel()
        { }
        #region Model
        private int _id;
        private int _category_id = 0;
        private string _name;
        private string _title = "";
        private int _is_albums = 0;
        private int _is_attach = 0;
        private int _is_group_price = 0;
        private int _page_size = 0;
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
        /// ����ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// Ƶ������
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// Ƶ������
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// �Ƿ�����Ṧ��
        /// </summary>
        public int is_albums
        {
            set { _is_albums = value; }
            get { return _is_albums; }
        }
        /// <summary>
        /// �Ƿ�����������
        /// </summary>
        public int is_attach
        {
            set { _is_attach = value; }
            get { return _is_attach; }
        }
        /// <summary>
        /// �Ƿ�����Ա��۸�
        /// </summary>
        public int is_group_price
        {
            set { _is_group_price = value; }
            get { return _is_group_price; }
        }
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        public int page_size
        {
            set { _page_size = value; }
            get { return _page_size; }
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

        private List<channel_field> _channel_fields;
        /// <summary>
        /// ��չ�ֶ� 
        /// </summary>
        public List<channel_field> channel_fields
        {
            set { _channel_fields = value; }
            get { return _channel_fields; }
        }
    }
}