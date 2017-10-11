/************************************************************************ 
 * 项目名称 :  XCWeiXin.Model.attrshop   
 * 项目描述 :      
 * 类 名 称 :  min_attrid 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 10:57:26 
 * 更新时间 :  2017/8/31 10:57:26 
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
    public partial class min_attrid
    {
        public min_attrid()
        { }
        #region Model
        private int _min_attrid;
        private int? _attrid;
        private int? _sub_attrid;
        private string _min_attridname;
        private string _min_attridcontext;
        private string _min_a;
        private string _min_b;
        private string _min_c;
        /// <summary>
        /// 
        /// </summary>
        public int minattrid
        {
            set { _min_attrid = value; }
            get { return _min_attrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? attrid
        {
            set { _attrid = value; }
            get { return _attrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sub_attrid
        {
            set { _sub_attrid = value; }
            get { return _sub_attrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string min_attridname
        {
            set { _min_attridname = value; }
            get { return _min_attridname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string min_attridcontext
        {
            set { _min_attridcontext = value; }
            get { return _min_attridcontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string min_a
        {
            set { _min_a = value; }
            get { return _min_a; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string min_b
        {
            set { _min_b = value; }
            get { return _min_b; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string min_c
        {
            set { _min_c = value; }
            get { return _min_c; }
        }
        #endregion Model

    }
}
