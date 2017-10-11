using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/**
 * http��httpsͨ����
 * ============================================================================
 * api˵����
 * setReqContent($reqContent),�����������ݣ�����post��get������get��ʽ�ṩ
 * getResContent(), ��ȡӦ������
 * setMethod($method),�������󷽷�,post����get
 * getErrInfo(),��ȡ������Ϣ
 * setCertInfo($certFile, $certPasswd, $certType="PEM"),����֤�飬˫��httpsʱ��Ҫʹ��
 * setCaInfo($caFile), ����CA����ʽδpem���������򲻼��
 * setTimeOut($timeOut)�� ���ó�ʱʱ�䣬��λ��
 * getResponseCode(), ȡ���ص�http״̬��
 * call(),�������ýӿ�
 * 
 * ============================================================================
 *
 */

namespace XCWeiXin.API.Payment.wxpay.tuikuan
{
    public class TenpayHttpClient
    {
        //�������ݣ�����post��get������get��ʽ�ṩ
        private string reqContent;

        //Ӧ������
        private string resContent;

        //���󷽷�
        private string method;

        //������Ϣ
        private string errInfo;

        //֤���ļ� 
        private string certFile;

        //֤������ 
        private string certPasswd;

        //ca֤���ļ� 
        private string caFile;

        //��ʱʱ��,����Ϊ��λ 
        private int timeOut;

        //httpӦ����� 
        private int responseCode;

        //�ַ�����
        private string charset;

        public TenpayHttpClient()
        {
            this.caFile = "";
            this.certFile = "";
            this.certPasswd = "";

            this.reqContent = "";
            this.resContent = "";
            this.method = "POST";
            this.errInfo = "";
            this.timeOut = 1 * 60;//5����

            this.responseCode = 0;
            this.charset = "gb2312";

        }

        //������������
        public void setReqContent(string reqContent)
        {
            this.reqContent = reqContent;
        }

        //��ȡ�������
        public string getResContent()
        {
            return this.resContent;
        }

        //�������󷽷�post����get	
        public void setMethod(string method)
        {
            this.method = method;
        }

        //��ȡ������Ϣ
        public string getErrInfo()
        {
            return this.errInfo;
        }

        //����֤����Ϣ
        public void setCertInfo(string certFile, string certPasswd)
        {
            this.certFile = certFile;
            this.certPasswd = certPasswd;
        }

        //����ca
        public void setCaInfo(string caFile)
        {
            this.caFile = caFile;
        }

        //���ó�ʱʱ��,����Ϊ��λ

        public void setTimeOut(int timeOut)
        {
            this.timeOut = timeOut;
        }


        //��ȡhttp״̬��
        public int getResponseCode()
        {
            return this.responseCode;
        }

        public void setCharset(string charset)
        {
            this.charset = charset;
        }

        //��֤������֤��
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        //ִ��http����
        public bool call()
        {
            StreamReader sr = null;
            HttpWebResponse wr = null;

            HttpWebRequest hp = null;
            try
            {
                string postData = null;
                if (this.method.ToUpper() == "POST")
                {
                    string[] sArray = System.Text.RegularExpressions.Regex.Split(this.reqContent, "\\?");

                    hp = (HttpWebRequest)WebRequest.Create(sArray[0]);

                    if (sArray.Length >= 2)
                    {
                        postData = sArray[1];
                    }

                }
                else
                {
                    hp = (HttpWebRequest)WebRequest.Create(this.reqContent);
                }


                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                if (this.certFile != "")
                {
                    hp.ClientCertificates.Add(new X509Certificate2(this.certFile, this.certPasswd));
                }
                hp.Timeout = this.timeOut * 1000;

                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(this.charset);
                if (postData != null)
                {
                    byte[] data = encoding.GetBytes(postData);

                    hp.Method = "POST";

                    hp.ContentType = "application/x-www-form-urlencoded";

                    hp.ContentLength = data.Length;

                    Stream ws = hp.GetRequestStream();

                    // ��������

                    ws.Write(data, 0, data.Length);
                    ws.Close();


                }


                wr = (HttpWebResponse)hp.GetResponse();
                sr = new StreamReader(wr.GetResponseStream(), encoding);



                this.resContent = sr.ReadToEnd();
                sr.Close();
                wr.Close();
            }
            catch (Exception exp)
            {
                this.errInfo += exp.Message;
                if (wr != null)
                {
                    this.responseCode = Convert.ToInt32(wr.StatusCode);
                }

                return false;
            }

            this.responseCode = Convert.ToInt32(wr.StatusCode);

            return true;
        }
    }
}
