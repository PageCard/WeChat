using System;
namespace XCWeiXin.Model
{
    /// <summary>
    /// Ƶ�����Ա�
    /// </summary>
    [Serializable]
    public partial class channel_field
    {
        public channel_field()
        { }
        #region Model
        private int _id;
        private int _channel_id;
        private int _field_id;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// Ƶ��ID
        /// </summary>
        public int channel_id
        {
            set { _channel_id = value; }
            get { return _channel_id; }
        }
        /// <summary>
        /// �ֶ�ID
        /// </summary>
        public int field_id
        {
            set { _field_id = value; }
            get { return _field_id; }
        }
        #endregion Model

    }
}