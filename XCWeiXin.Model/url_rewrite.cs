﻿using System;
using System.Collections.Generic;

namespace XCWeiXin.Model
{
    #region URL字典实体类============================================
    /// <summary>
    /// URL字典实体类
    /// </summary>
    [Serializable]
    public partial class url_rewrite
    {
        //无参构造函数
        public url_rewrite() { }

        private string _name = "";
        private string _type = "";
        private string _page = "";
        private string _inherit = "";
        private string _templet = "";
        private string _channel = "";
        private string _url_rewrite_str = "";
        private List<url_rewrite_item> _url_rewrite_items;

        /// <summary>
        /// 名称标识
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 频道类型
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// 源页面地址
        /// </summary>
        public string page
        {
            get { return _page; }
            set { _page = value; }
        }

        /// <summary>
        /// 页面继承的类名
        /// </summary>
        public string inherit
        {
            get { return _inherit; }
            set { _inherit = value; }
        }

        /// <summary>
        /// 模板文件名称
        /// </summary>
        public string templet
        {
            get { return _templet; }
            set { _templet = value; }
        }

        /// <summary>
        /// 所属频道ID
        /// </summary>
        public string channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        /// <summary>
        /// URL重写表达式连接字符串，后台编辑用到
        /// </summary>
        public string url_rewrite_str
        {
            get { return _url_rewrite_str; }
            set { _url_rewrite_str = value; }
        }

        /// <summary>
        /// URL字典重写表达式
        /// </summary>
        public List<url_rewrite_item> url_rewrite_items
        {
            set { _url_rewrite_items = value; }
            get { return _url_rewrite_items; }
        }

    }
    #endregion

    #region URL字典重写表达式实体类==================================
    /// <summary>
    /// URL字典重写表达式实体类
    /// </summary>
    [Serializable]
    public partial class url_rewrite_item
    {
        //无参构造函数
        public url_rewrite_item() { }

        private string _path = "";
        private string _pattern = "";
        private string _querystring = "";

        /// <summary>
        /// URL重写表达式
        /// </summary>
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }

        /// <summary>
        /// 传输参数
        /// </summary>
        public string querystring
        {
            get { return _querystring; }
            set { _querystring = value; }
        }
    }
    #endregion
}