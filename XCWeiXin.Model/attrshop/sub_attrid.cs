/************************************************************************ 
 * 项目名称 :  XCWeiXin.Model.attrshop   
 * 项目描述 :      
 * 类 名 称 :  sub_attrid 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 10:57:40 
 * 更新时间 :  2017/8/31 10:57:40 
************************************************************************ 
 * Copyright @ 张强林 2017. All rights reserved. 
************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWeiXin.Model.attrshop
{
    public partial class sub_attrid
    {
        public sub_attrid()
        { }
        #region Model
        private int _sub_attrid;
        private string _sub_attrname;
        private string _sub_attrcontext;
        private string _sub_a;
        private string _sub_b;
        private string _sub_c;
        private int? _min_attrid;
        /// <summary>
        /// 
        /// </summary>
        public int subattrid
        {
            set { _sub_attrid = value; }
            get { return _sub_attrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sub_attrname
        {
            set { _sub_attrname = value; }
            get { return _sub_attrname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sub_attrcontext
        {
            set { _sub_attrcontext = value; }
            get { return _sub_attrcontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sub_a
        {
            set { _sub_a = value; }
            get { return _sub_a; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sub_b
        {
            set { _sub_b = value; }
            get { return _sub_b; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sub_c
        {
            set { _sub_c = value; }
            get { return _sub_c; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? min_attrid
        {
            set { _min_attrid = value; }
            get { return _min_attrid; }
        }
        #endregion Model

    }
}
