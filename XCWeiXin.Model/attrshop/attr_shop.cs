/************************************************************************ 
 * 项目名称 :  XCWeiXin.Model.attrshop   
 * 项目描述 :      
 * 类 名 称 :  attr_shop 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 10:57:11 
 * 更新时间 :  2017/8/31 10:57:11 
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
    public partial class attr_shop
    {
        public attr_shop()
        { }
        #region Model
        private int _attrid;
        private string _attrname;
        private string _attrcontext;
        private string _attr_a;
        private string _attr_b;
        private string _attr_c;
        /// <summary>
        /// 
        /// </summary>
        public int attrid
        {
            set { _attrid = value; }
            get { return _attrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attrname
        {
            set { _attrname = value; }
            get { return _attrname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attrcontext
        {
            set { _attrcontext = value; }
            get { return _attrcontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attr_a
        {
            set { _attr_a = value; }
            get { return _attr_a; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attr_b
        {
            set { _attr_b = value; }
            get { return _attr_b; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attr_c
        {
            set { _attr_c = value; }
            get { return _attr_c; }
        }
        #endregion Model

    }
}
