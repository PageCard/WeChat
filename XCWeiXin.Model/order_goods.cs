using System;

namespace XCWeiXin.Model
{
    /// <summary>
    /// ������Ʒ��
    /// </summary>
    [Serializable]
    public partial class order_goods
    {
        public order_goods()
        { }
        #region Model
        private int _id;
        private int _order_id = 0;
        private int _goods_id = 0;
        private string _goods_title = "";
        private decimal _goods_price = 0M;
        private decimal _real_price = 0M;
        private int _quantity = 0;
        private int _point = 0;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// ��ƷID
        /// </summary>
        public int goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string goods_title
        {
            set { _goods_title = value; }
            get { return _goods_title; }
        }
        /// <summary>
        /// ��Ʒ�۸�
        /// </summary>
        public decimal goods_price
        {
            set { _goods_price = value; }
            get { return _goods_price; }
        }
        /// <summary>
        /// ʵ�ʼ۸�
        /// </summary>
        public decimal real_price
        {
            set { _real_price = value; }
            get { return _real_price; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// ����,��������|��������
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
        }
        #endregion Model

    }
}