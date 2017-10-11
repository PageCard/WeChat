using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.MP.Entities.Menu;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.Exceptions;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using Senparc.Weixin.HttpUtility;
using Newtonsoft.Json;

namespace XCWeiXin.WeiXinComm
{
    public class Config
    {
        public int QrCodeId { get; set; }
        public List<string> Versions { get; set; }
        public int DownloadCount { get; set; }

    }
}
