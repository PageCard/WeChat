using XCWeiXin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCWeiXin.DAL
{
    public class bookSKUDal
    {

        public IList<bookSKU> SKUConvert(IList<Model.wx_book_sku> psku)
       {
           IList<bookSKU> newSKUList = new List<bookSKU>();
           if (psku != null && psku.Count > 0)
           {
               //查找有几种配件
               var attrlist = from e in psku group e by new { e.attributeId } into g select g.FirstOrDefault();
             
               bookSKU skuEntity = new bookSKU();
               IList<SKUSelectItem> selectItemList = new List<SKUSelectItem>();
               SKUSelectItem item = new SKUSelectItem();
               foreach (var attr in attrlist)
               {
                   selectItemList = new List<SKUSelectItem>();
                   skuEntity = new bookSKU();
                   skuEntity.attributeId = attr.attributeId.Value;
                   skuEntity.productId = attr.productId.Value;
                   skuEntity.attrName = attr.attrName;

                   //该场馆下的所有时间段信息
                   IList<Model.wx_book_sku> orginSkulist = (from e in psku where e.attributeId == attr.attributeId group e by new { e.attributeValue } into g select g.FirstOrDefault()).ToArray<Model.wx_book_sku>();
                   foreach (Model.wx_book_sku orginSKu in orginSkulist)
                   {
                       item = new SKUSelectItem();
                       item.attributeValue = orginSKu.attributeValue;
                       item.sku = orginSKu.sku;
                       item.stock = orginSKu.stock == null ? -1 : orginSKu.stock.Value;
                       item.price = orginSKu.price == null ? 0 : orginSKu.price.Value;
                       selectItemList.Add(item);
                   }
                   skuEntity.selectItem = selectItemList;
                   newSKUList.Add(skuEntity);
                    
               }
           }
           return newSKUList;
       }
    }
}
