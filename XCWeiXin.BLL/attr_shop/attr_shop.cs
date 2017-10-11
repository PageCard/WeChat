/************************************************************************ 
 * 项目名称 :  XCWeiXin.BLL.attr_shop   
 * 项目描述 :      
 * 类 名 称 :  attr_shop 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Page_load 
 * 创建时间 :  2017/8/31 11:06:10 
 * 更新时间 :  2017/8/31 11:06:10 
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
   
  public  class attr_shop
    {
      
      DAL.attr_shop.attr_shop dal = new DAL.attr_shop.attr_shop();
      public int attr_add(Model.attrshop.attr_shop model)
      {
          return dal.attr_Add(model);
      }

    }
}
