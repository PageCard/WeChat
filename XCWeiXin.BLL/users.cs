using System;
using System.Data;
using System.Collections.Generic;
using XCWeiXin.Common;

namespace XCWeiXin.BLL
{
    /// <summary>
    /// �û���Ϣ
    /// </summary>
    public partial class users
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.users dal;
        public users()
        {
            dal = new DAL.users(siteConfig.sysdatabaseprefix);
        }

        #region ��������===================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }

        /// <summary>
        /// ���ͬһIPע����(Сʱ)���Ƿ����
        /// </summary>
        public bool Exists(string reg_ip, int regctrl)
        {
            return dal.Exists(reg_ip, regctrl);
        }

        /// <summary>
        /// ���Email�Ƿ����
        /// </summary>
        public bool ExistsEmail(string email)
        {
            return dal.ExistsEmail(email);
        }

        /// <summary>
        /// ����ֻ������Ƿ����
        /// </summary>
        public bool ExistsMobile(string mobile)
        {
            return dal.ExistsMobile(mobile);
        }

        /// <summary>
        /// ����һ������û���
        /// </summary>
        public string GetRandomName(int length)
        {
            string temp = Utils.Number(length, true);
            if (Exists(temp))
            {
                return GetRandomName(length);
            }
            return temp;
        }

        /// <summary>
        /// �����û���ȡ��Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            return dal.GetSalt(user_name);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.users GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �����û������뷵��һ��ʵ��
        /// </summary>
        /// <param name="user_name">�û���(����)</param>
        /// <param name="password">����</param>
        /// <param name="emaillogin">�Ƿ�����������Ϊ��¼</param>
        /// <param name="mobilelogin">�Ƿ������ֻ���Ϊ��¼</param>
        /// <param name="is_encrypt">�Ƿ���Ҫ��������</param>
        /// <returns></returns>
        public Model.users GetModel(string user_name, string password, int emaillogin, int mobilelogin, bool is_encrypt)
        {
            //���һ���Ƿ���Ҫ����
            if (is_encrypt)
            {
                //��ȡ�ø��û��������Կ
                string salt = dal.GetSalt(user_name);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //�����Ľ��м������¸�ֵ
                password = DESEncrypt.Encrypt(password, salt);
            }
            return dal.GetModel(user_name, password, emaillogin, mobilelogin);
        }

        /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.users GetModel(string user_name)
        {
            return dal.GetModel(user_name);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

        #region ��չ����===================================
        /// <summary>
        /// �û�����
        /// </summary>
        public bool Upgrade(int id)
        {
            if (!Exists(id))
            {
                return false;
            }
            Model.users model = GetModel(id);
            Model.user_groups groupModel = new user_groups().GetUpgrade(model.group_id, model.exp);
            if (groupModel == null)
            {
                return false;
            }
            int result = UpdateField(id, "group_id=" + groupModel.id);
            if (result > 0)
            {
                //���ӻ���
                if (groupModel.point > 0)
                {
                    new BLL.user_point_log().Add(model.id, model.user_name, groupModel.point, "������û���", true);
                }
                //���ӽ��
                if (groupModel.amount > 0)
                {
                    new BLL.user_amount_log().Add(model.id, model.user_name, MXEnums.AmountTypeEnum.SysGive.ToString(), groupModel.amount, "�������ͽ��", 1);
                }
            }
            return true;
        }
        #endregion

        #region ΢�Ż�Ա��


        /// <summary>
        /// ���openid�Ƿ����
        /// </summary>
        public bool ExistsOpenid(int wid,string openid)
        {
           return  dal.ExistsOpenid(wid,openid);
        }

        /// <summary>
        /// ͨ��΢���û�΢��Ψһ���룬����û���Ϣ
        /// </summary>
        /// <param name="uOpenId"></param>
        /// <returns></returns>
        public DataSet getWxUserByOpenId(int wid,string uOpenId)
        {
            return dal.getWxUserByOpenId(wid,uOpenId);
        }

        /// <summary>
        /// ͨ��΢���û�΢��Ψһ���룬��û�Ա����
        /// </summary>
        /// <param name="uOpenId"></param>
        /// <returns></returns>
        public string getCardnoByOpenId(int wid,string uOpenId)
        {
            return dal.getCardnoByOpenId(wid,uOpenId);

        }


        /// <summary>
        /// ͨ��΢�Ŷ�ע����û�
        /// ��һ���û������趨�ǳ�ʼֵ��1
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="tel"></param>
        /// <param name="username"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public int InsertUserByWX(int wid,string openId, string tel, string username, string sex, out decimal cardno)
        {
            return dal.InsertUserByWX(wid,openId,tel,username,sex,out cardno);
        }



        /// <summary>
        /// �޸�΢���û���Ϣ
        /// </summary>
        /// <param name="id">�����û���dt_users������</param>
        /// <param name="tel"></param>
        /// <param name="username"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public bool EidtUserByWX(string id, string tel, string username, string sex, DateTime birthday)
        {
            return dal.EidtUserByWX(id,tel,username,sex,birthday);
        }

        #endregion

    }
}