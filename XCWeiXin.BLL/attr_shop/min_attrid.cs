/************************************************************************ 
 * 项目名称 :  XCWeiXin.BLL.attr_shop   
 * 项目描述 :      
 * 类 名 称 :  min_attrid 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 11:06:32 
 * 更新时间 :  2017/8/31 11:06:32 
************************************************************************ 
 * Copyright @ 张强林 2017. All rights reserved. 
************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWeiXin.DAL;

namespace XCWeiXin.BLL.attr_shop
{
    
   public  class min_attrid
    {
        DAL.attr_shop.min_attrid dal=new DAL.attr_shop.min_attrid();
        public int add_min(Model.attrshop.min_attrid model)
        {
            return dal.Add(model);
        }
    }
}
