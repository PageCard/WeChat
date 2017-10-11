/************************************************************************ 
 * 项目名称 :  XCWeiXin.BLL.attr_shop   
 * 项目描述 :      
 * 类 名 称 :  sub_attrid 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 11:05:57 
 * 更新时间 :  2017/8/31 11:05:57 
************************************************************************ 
 * Copyright @ 张强林 2017. All rights reserved. 
************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWeiXin.DAL;
using XCWeiXin.Model;

namespace XCWeiXin.BLL.attr_shop
{
   public  class sub_attrid
    {
       DAL.attr_shop.sub_attrid dal = new DAL.attr_shop.sub_attrid();
       public int sub_attr(Model.attrshop.sub_attrid model)
       {
           return dal.sub_Add(model);
       }
    }
}
