ʹ��˵����
�ο�Example.cs��ʹ�ò����Ϊ����:
��1�����û����Ĳ�����appid��paysignkey��
	wxPayHelper.SetAppId("wxf8b4f85f3a794e77");
	wxPayHelper.SetAppKey("2Wozy2aksie1puXUBpWD8oZxiD1DfQuEaiC7KcRATv1Ino3mdopKaPGQQ7TtkNySuAmCaDCrw4xhPY5qKTBl7Fzm0RgR3c0WaVYIXZARsxzHV2x7iwPPzOz94dnwPWSn");
	wxPayHelper.SetPartnerKey("8934e7d15453e97507ef794cf7b0519d");
	wxPayHelper.SetSignType("sha1");
��2������package�Ĳ����������š���Ʒ�۸��
	wxPayHelper.SetParameter("bank_type", "WX");
	wxPayHelper.SetParameter("body", "test");
	wxPayHelper.SetParameter("partner", "1900000109");
	wxPayHelper.SetParameter("out_trade_no", Wxpay.CommonUtil.CreateNoncestr());
	wxPayHelper.SetParameter("total_fee", "1");
	wxPayHelper.SetParameter("fee_type", "1");
	wxPayHelper.SetParameter("notify_url", "htttp://www.baidu.com");
	wxPayHelper.SetParameter("spbill_create_ip", "127.0.0.1");
	wxPayHelper.SetParameter("input_charset", "GBK");
��3�����ɶ�Ӧ��֧������
	����: ����jsapi������:
	System.Console.Out.WriteLine(wxPayHelper.CreateBizPackage());
