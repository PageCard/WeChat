using XCWeiXin.API.Payment.wxpay.comm;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Xml;

namespace XCWeiXin.API.Payment.wxpay
{

    /** 
    '============================================================================
    'api˵����
    'getKey()/setKey(),��ȡ/������Կ
    'getParameter()/setParameter(),��ȡ/���ò���ֵ
    'getAllParameters(),��ȡ���в���
    'isTenpaySign(),�Ƿ���ȷ��ǩ��,true:�� false:��
    'isWXsign(),�Ƿ���ȷ��ǩ��,true:�� false:��
    ' * isWXsignfeedback�ж�΢��άȨǩ��
    ' *getDebugInfo(),��ȡdebug��Ϣ
    '============================================================================
    */

    public class ResponseHandler
	{
		// ��Կ 
		private string key;

        // appkey
        private string appkey;

        //xmlMap
        private Hashtable xmlMap;

		// Ӧ��Ĳ���
		protected Hashtable parameters;
		
		 //debug��Ϣ
		private string debugInfo;
        //ԭʼ����
        protected string content;

        private string charset = "UTF-8";

        //����ǩ���Ĳ����б�
        private static string SignField = "appid,appkey,timestamp,openid,noncestr,issubscribe";

		protected HttpContext httpContext;

        //��ʼ������
        public virtual void init()
        {
        }

        //��ȡҳ���ύ��get��post����
        public ResponseHandler(HttpContext httpContext)
        {
            parameters = new Hashtable();
            xmlMap = new Hashtable();

            this.httpContext = httpContext;
            NameValueCollection collection;
            //post data
            if (this.httpContext.Request.HttpMethod == "POST")
            {
                collection = this.httpContext.Request.Form;
                foreach (string k in collection)
                {
                    string v = (string)collection[k];
                    this.setParameter(k, v);
                }
            }
            //query string
            collection = this.httpContext.Request.QueryString;
            foreach (string k in collection)
            {
                string v = (string)collection[k];
                this.setParameter(k, v);
            }
            if (this.httpContext.Request.InputStream.Length > 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(this.httpContext.Request.InputStream);
                XmlNode root = xmlDoc.SelectSingleNode("xml");
                XmlNodeList xnl = root.ChildNodes;

                foreach (XmlNode xnf in xnl)
                {
                    xmlMap.Add(xnf.Name, xnf.InnerText);
                }
            }
        }
    

		/** ��ȡ��Կ */
		public string getKey() 
		{ return key;}

		/** ������Կ */
		public void setKey(string key, string appkey) 
		{
            this.key = key;
            this.appkey = appkey;
        }

		/** ��ȡ����ֵ */
		public string getParameter(string parameter) 
		{
			string s = (string)parameters[parameter];
			return (null == s) ? "" : s;
		}

		/** ���ò���ֵ */
		public void setParameter(string parameter,string parameterValue) 
		{
			if(parameter != null && parameter != "")
			{
				if(parameters.Contains(parameter))
				{
					parameters.Remove(parameter);
				}
	
				parameters.Add(parameter,parameterValue);		
			}
		}

		/** �Ƿ�Ƹ�ͨǩ��,������:����������a-z����,������ֵ�Ĳ������μ�ǩ���� 
		 * @return boolean */
        public virtual Boolean isTenpaySign() 
		{
			StringBuilder sb = new StringBuilder();

			ArrayList akeys=new ArrayList(parameters.Keys); 
			akeys.Sort();

			foreach(string k in akeys)
			{
				string v = (string)parameters[k];
				if(null != v && "".CompareTo(v) != 0
					&& "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0) 
				{
					sb.Append(k + "=" + v + "&");
				}
			}

			sb.Append("key=" + this.getKey());
            string sign = MD5Util.GetMD5(sb.ToString(), getCharset()).ToLower();
            this.setDebugInfo(sb.ToString() + " => sign:" + sign);
			//debug��Ϣ
			return getParameter("sign").ToLower().Equals(sign); 
		}

        //�ж�΢��ǩ��
        public virtual Boolean isWXsign()
        {
            StringBuilder sb = new StringBuilder();
            Hashtable signMap = new Hashtable();

            foreach (string k in xmlMap.Keys)
            {
                if (k != "SignMethod" && k != "AppSignature")
                {
                    signMap.Add(k.ToLower(), xmlMap[k]);
                }
            }
            signMap.Add("appkey", this.appkey);


            ArrayList akeys = new ArrayList(signMap.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)signMap[k];
                if (sb.Length == 0)
                {
                    sb.Append(k + "=" + v);
                }
                else
                {
                    sb.Append("&" + k + "=" + v);
                }
            }

            string sign = SHA1Util.getSha1(sb.ToString()).ToString().ToLower();

            this.setDebugInfo(sb.ToString() + " => SHA1 sign:" + sign);

            return sign.Equals(xmlMap["AppSignature"]);

        }

        //�ж�΢��άȨǩ��
        public virtual Boolean isWXsignfeedback()
        {
            StringBuilder sb = new StringBuilder();
            Hashtable signMap = new Hashtable();
       
            foreach (string k in xmlMap.Keys)
            {
                if (SignField.IndexOf(k.ToLower()) != -1)
                {
                    signMap.Add(k.ToLower(), xmlMap[k]);
                }
            }
            signMap.Add("appkey", this.appkey);
          

            ArrayList akeys = new ArrayList(signMap.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)signMap[k];
                if ( sb.Length == 0 )
                {
                    sb.Append(k + "=" + v);
                }
                else
                {
                    sb.Append("&" + k + "=" + v);
                }
            }
            
            string sign = SHA1Util.getSha1(sb.ToString()).ToString().ToLower();
            
            this.setDebugInfo(sb.ToString() + " => SHA1 sign:" + sign);

            return sign.Equals( xmlMap["AppSignature"] );

        }
   
		/** ��ȡdebug��Ϣ */
		public string getDebugInfo() 
		{ return debugInfo;}
				
		/** ����debug��Ϣ */
		protected void setDebugInfo(String debugInfo)
		{ this.debugInfo = debugInfo;}

		protected virtual string getCharset()
		{
			return this.httpContext.Request.ContentEncoding.BodyName;
			
		}

        /// <summary>
        /// ��ȡXML�����ķ���(����add 2014-5-13)
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string getMpParameter(string parameter)
        {
            string s = (string)xmlMap[parameter];
            return (null == s) ? "" : s;
        }

		
	}
}
