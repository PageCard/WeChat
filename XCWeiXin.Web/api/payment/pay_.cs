using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCWeiXin.Web.api.payment
{
    public class pay_
    {
        public string timeStamp
        {
            get;
            set;
           
        }
        public string nonceStr
        {
            get;
            set;
        }
        public string package
        {
            get;
            set;
        }
        public string signType
        {
            get;
            set;
        }
        public string paySign
        {
            get;
            set;
        }
    }
}