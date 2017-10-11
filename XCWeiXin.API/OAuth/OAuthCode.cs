/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：OAuthUserInfo.cs
    文件功能描述：通过OAuth的获取到的用户信息
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCWeiXin.API.OAuth
{/// <summary>
    /// 通过OAuth的获取到的用户信息（snsapi_userinfo=scope）
    /// </summary>
    public class OAuthCode
    {
        public string code { get; set; }
        
    }
}
