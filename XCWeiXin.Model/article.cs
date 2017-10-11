using System;
using System.Collections.Generic;

namespace XCWeiXin.Model
{
    #region ��������ʵ����============================================
    /// <summary>
    /// article:ʵ����
    /// </summary>
    [Serializable]
    public partial class article
    {
        //�޲ι��캯��
        public article() { }

        private int _id;
        private int _channel_id = 0;
        private int _category_id = 0;
        private string _call_index = "";
        private string _title = "";
        private string _link_url = "";
        private string _img_url = "";
        private string _seo_title = "";
        private string _seo_keywords = "";
        private string _seo_description = "";
        private string _zhaiyao = "";
        private string _content;
        private int _sort_id = 99;
        private int _click = 0;
        private int _status = 0;
        private string _groupids_view = "";
        private int _vote_id = 0;
        private int _is_top = 0;
        private int _is_red = 0;
        private int _is_hot = 0;
        private int _is_slide = 0;
        private int _is_sys = 0;
        private int _is_msg = 0;
        private string _user_name;
        private DateTime _add_time = DateTime.Now;
        private DateTime? _update_time;
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
        /// ���ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
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
        /// ����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// �ⲿ����
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// SEO����
        /// </summary>
        public string seo_title
        {
            set { _seo_title = value; }
            get { return _seo_title; }
        }
        /// <summary>
        /// SEO�ؽ���
        /// </summary>
        public string seo_keywords
        {
            set { _seo_keywords = value; }
            get { return _seo_keywords; }
        }
        /// <summary>
        /// SEO����
        /// </summary>
        public string seo_description
        {
            set { _seo_description = value; }
            get { return _seo_description; }
        }
        /// <summary>
        /// ����ժҪ
        /// </summary>
        public string zhaiyao
        {
            set { _zhaiyao = value; }
            get { return _zhaiyao; }
        }
        /// <summary>
        /// ��ϸ����
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
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
        /// �������
        /// </summary>
        public int click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// ״̬0����1δ���2����
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// �Ķ�Ȩ��
        /// </summary>
        public string groupids_view
        {
            set { _groupids_view = value; }
            get { return _groupids_view; }
        }
        /// <summary>
        /// ����ͶƱID
        /// </summary>
        public int vote_id
        {
            set { _vote_id = value; }
            get { return _vote_id; }
        }
        /// <summary>
        /// �Ƿ��ö�
        /// </summary>
        public int is_top
        {
            set { _is_top = value; }
            get { return _is_top; }
        }
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public int is_red
        {
            set { _is_red = value; }
            get { return _is_red; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public int is_hot
        {
            set { _is_hot = value; }
            get { return _is_hot; }
        }
        /// <summary>
        /// �Ƿ�õ�Ƭ
        /// </summary>
        public int is_slide
        {
            set { _is_slide = value; }
            get { return _is_slide; }
        }
        /// <summary>
        /// �Ƿ����Ա����0����1��
        /// </summary>
        public int is_sys
        {
            set { _is_sys = value; }
            get { return _is_sys; }
        }
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        public int is_msg
        {
            set { _is_msg = value; }
            get { return _is_msg; }
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
        /// ����ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime? update_time
        {
            set { _update_time = value; }
            get { return _update_time; }
        }

        /// <summary>
        /// ��չ�ֶ��ֵ�
        /// </summary>
        private Dictionary<string, string> _fields;
        public Dictionary<string, string> fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        /// <summary>
        /// ͼƬ���
        /// </summary>
        private List<article_albums> _albums;
        public List<article_albums> albums
        {
            set { _albums = value; }
            get { return _albums; }
        }

        /// <summary>
        /// ���ݸ���
        /// </summary>
        private List<article_attach> _attach;
        public List<article_attach> attach
        {
            set { _attach = value; }
            get { return _attach; }
        }

        private List<user_group_price> _group_price;
        /// <summary>
        /// ��Ա��۸�
        /// </summary>
        public List<user_group_price> group_price
        {
            set { _group_price = value; }
            get { return _group_price; }
        }

        /// <summary>
        /// ΢�ʺ�����Id
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
        }

    }
    #endregion Model
}