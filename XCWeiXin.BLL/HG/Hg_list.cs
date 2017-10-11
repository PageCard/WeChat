using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWeiXin.BLL.HG
{
    public class Hg_list
    {
        DAL.HG.HG_order order = new DAL.HG.HG_order();
       
        /// <summary>
        /// 获取护工详情
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Model.HG.HGlist Getmodel (int number)
       {
        return order.Getmodel(number);
        
      }
        public Model.HG.HGlist Get_xinxi(string user)
        {
            return order.Getxinxi(user);
        }
        public bool update_list(int number)
        {
            return order.update_list(number);
        }
        public bool update_star(Model.HG.HG_order nn)
        {
          return  order.update_star(nn);
        }
        public bool update(string idlist, string orderid)
        {
            return order.Update(idlist, orderid);
        }
        public bool Login_Hg(string phone, string pass)
        {
            return order.Login_hg(phone, pass);
        }
        public bool DeleteList(int idlist)
        {
            return order.DeleteList(idlist);
        }
        public Model.HG.A_HG_new_order getorder_(string oo)
        {
            return order.getorder_(oo);
        }
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="order_s"></param>
        /// <returns></returns>
        public Model.HG.HG_order Getorder(string order_s)
        {
            return order.Getorder(order_s);
        }
        public Model.HG.A_HG_new_order getorder(string order1)
        {
            return order.getorder(order1);
        }
        /// <summary>
        /// 添加预约
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        public int Add_order(Model.HG.HG_order add)
        {

            return order.add_order(add);
 
        }
        public int Add_order_new(Model.HG.A_HG_new_order add)
        {
            return order.add_order_new(add);
        }

    }
}
