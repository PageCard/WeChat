using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XCWeiXin.DAL.Card_wx;
using XCWeiXin.Model.Card_wx;

namespace XCWeiXin.BLL.Card_wx
{
  public  class Card_BaseInfo
    {
      Card_Base dal = new Card_Base();
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Card_wx.Card_BaseInfo model)
		{
			return dal.Add(model);
		}

      /// <summary>
      /// 获取数据列表。返回Dateset
      /// </summary>
      /// <param name="where"></param>
      /// <returns></returns>
        public DataSet Date(string where)
        {
            return dal.GetList(where);
        }
      /// <summary>
      /// 删除一条数据
      /// </summary>
      /// <param name="wx_id"></param>
      /// <returns></returns>
        public bool delete(string wx_id)
        {
            return dal.Delete(wx_id);
        }
      /// <summary>
      /// 更改库存
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
        public bool Upadata_kucun(Model.Card_wx.Card_BaseInfo model)
        {
            return dal.Upadata_kucun(model);
        }
      /// <summary>
      /// 更新卡券（编辑）
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
        public bool Exit_card(Model.Card_wx.Card_BaseInfo model)
        {
            return dal.Exit_card(model);
        }
      /// <summary>
      /// 获取卡券信息（对象）
      /// </summary>
      /// <param name="Card_wx"></param>
      /// <returns></returns>
        public Model.Card_wx.Card_BaseInfo Getmodel(string Card_wx)
        {
            return dal.GetModel(Card_wx);
        }
       
     
    }
}
