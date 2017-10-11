using System;
using System.Security.Cryptography;
using System.Text;

namespace XCWeiXin.API.Payment.wxpay.comm
{
	/// <summary>
	/// MD5Util ��ժҪ˵����
	/// </summary>
	public class MD5Util
	{
		public MD5Util()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/** ��ȡ��д��MD5ǩ����� */
		public static string GetMD5(string encypStr, string charset)
		{
			string retStr;
			MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

			//����md5����
			byte[] inputBye;
			byte[] outputBye;

			//ʹ��GB2312���뷽ʽ���ַ���ת��Ϊ�ֽ����飮
			try
			{
				inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
			}
			catch (Exception ex)
			{
				inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
			}
			outputBye = m5.ComputeHash(inputBye);

			retStr = System.BitConverter.ToString(outputBye);
			retStr = retStr.Replace("-", "").ToUpper();
			return retStr;
		}

        public static String MD5(String s)
        {
            char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
					'A', 'B', 'C', 'D', 'E', 'F' };
            try
            {

                byte[] btInput = System.Text.Encoding.Default.GetBytes(s);
                // ���MD5ժҪ�㷨�� MessageDigest ����
                MD5 mdInst = System.Security.Cryptography.MD5.Create();
                // ʹ��ָ�����ֽڸ���ժҪ
                mdInst.ComputeHash(btInput);
                // �������
                byte[] md = mdInst.Hash;
                // ������ת����ʮ�����Ƶ��ַ�����ʽ
                int j = md.Length;
                char[] str = new char[j * 2];
                int k = 0;
                for (int i = 0; i < j; i++)
                {
                    byte byte0 = md[i];
                    str[k++] = hexDigits[(int)(((byte)byte0) >> 4) & 0xf];
                    str[k++] = hexDigits[byte0 & 0xf];
                }
                return new string(str);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                return null;
            }
        }

	}
}
