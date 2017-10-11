using XCWeiXin.API.Payment.wxpay.comm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace XCWeiXin.API.Payment.wxpay
{

    public class MD5SignUtil
    {
        public static String Sign(String content, String key)
        {
            String signStr = "";

            if ("" == key)
            {
                throw new SDKRuntimeException("�Ƹ�ͨǩ��key����Ϊ�գ�");
            }
            if ("" == content)
            {
                throw new SDKRuntimeException("�Ƹ�ͨǩ�����ݲ���Ϊ��");
            }
            signStr = content + "&key=" + key;

            return MD5Util.MD5(signStr).ToUpper();

        }

        public static bool VerifySignature(String content, String sign,
                String md5Key)
        {
            String signStr = content + "&key=" + md5Key;
            String calculateSign = MD5Util.MD5(signStr).ToUpper();
            String tenpaySign = sign.ToUpper();
            return (calculateSign == tenpaySign);
        }
    }
}
