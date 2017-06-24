using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Data.Xml.Dom;
// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Mid_Project
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    /// 返回错误信息和号码归属地的页面
    public sealed partial class content1 : UserControl
    {
        public string str;
        public content1(string s)
        {
            this.InitializeComponent();
            str = s;
            string xurl = "http://life.tenpay.com/cgi-bin/mobile/MobileQueryAttribution.cgi?chgmobile=";
            xml(xurl);

        }

        public async void xml(string url)
        {
            string strURL = url + str;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            //为此对象的header添加apikey
            request.Headers["apikey"] = "11fb29afb753bbfcb806a725f12347fd";
            WebResponse response;
            response = await request.GetResponseAsync();
            Stream s;
            s = response.GetResponseStream();

            //uwp中的encoding使用gb2312编码需要此行代码进行注册
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader Reader = new StreamReader(s, Encoding.GetEncoding("gb2312"));
            //读取流中所有的内容
            string res = Reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(res);
            province.Text = "1";

            if (doc.GetElementsByTagName("retmsg")[0].InnerText.Equals("OK"))
            {
                var temp = doc.GetElementsByTagName("province")[0].InnerText;
                province.Text = "该号码归属地为：" + temp;
                province.Visibility = Visibility.Visible;
            }
        }
    }
}
