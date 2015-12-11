using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace http_finder
{
    public partial class Form1 : Form
    {
        readonly List<Task> _taskList = new List<Task>(); 
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(HttpScan);
            Task.Factory.StartNew(HttpsScan);
        }
        private void btnGetHtml_Click(object sender, EventArgs e)
        {
            if (_taskList.Count > 0)
            {
                for (var i = 0; i < _taskList.Count; i++)
                {
                    if (_taskList[i].IsCompleted == false)
                    {
                        _taskList[i].Wait();
                    }
                    else
                    {
                        _taskList.Clear();
                    }
                }
            }
            Task.Factory.StartNew(HttpRequest);
            Task.Factory.StartNew(HttpsRequest);
        }

        private void HttpScan()
        {
            const int finOctet = 255;
            const int firstOctet = 1;
            var ip = txtTarget.Text.Trim();
            const int port1 = 80;
            try
            {
                var parse = ip.Split('.');
                for (var i = firstOctet; i < finOctet; i++)
                {
                    var status = $"{parse[0]}.{parse[1]}.{parse[2]}.{i}{":"}{port1}";
                    var t1 = $"{parse[0]}.{parse[1]}.{parse[2]}.{i}";
                    txtStatus.Text += $"{Environment.NewLine}{status} için tarama işlemi başladı.";
                    _taskList.Add(Task.Factory.StartNew(() => ConnectTcp(t1, port1)));
                }
            }
            catch (Exception)
            {
                //todo:dasda
            }
            finally
            {
                if (_taskList.Count > 0)
                {
                    for (var i = 0; i < _taskList.Count; i++)
                    {
                        if (_taskList[i].IsCompleted == false)
                        {
                            _taskList[i].Wait();
                        }
                        else
                        {
                            txtStatus.Text += Environment.NewLine + @"HTTP servisi tespit işlemi tamamlandı...";
                        }
                    }
                }
            }
        }
        private void HttpsScan()
        {
            const int finOctet = 255;
            const int firstOctet = 1;
            var ip = txtTarget.Text.Trim();
            const int port2 = 443;
            try
            {
                var parse = ip.Split('.');
                for (var i = firstOctet; i < finOctet; i++)
                {
                    var status = $"{parse[0]}.{parse[1]}.{parse[2]}.{i}{":"}{port2}";
                    var t1 = $"{parse[0]}.{parse[1]}.{parse[2]}.{i}";
                    txtStatus.Text += $"{Environment.NewLine}{status} için tarama işlemi başladı.";
                    _taskList.Add(Task.Factory.StartNew(() => ConnectTcp(t1, port2)));
                }
            }
            catch (Exception)
            {
                //todo:dasda
            }
            finally
            {
                if (_taskList.Count > 0)
                {
                    for (var i = 0; i < _taskList.Count; i++)
                    {
                        if (_taskList[i].IsCompleted == false)
                        {
                            _taskList[i].Wait();
                        }
                        else
                        {
                            txtStatus.Text += Environment.NewLine + @"HTTPS servisi tespit işlemi tamamlandı...";
                        }
                    }
                }
            }
        }
        private void ConnectTcp(string t1, int port1)
        {
            var client = new TcpClient();
            try
            {
                client.SendTimeout = 1000;
                client.Connect(t1, port1);
                txtFound.Text += $"{Environment.NewLine}{t1}:{port1}";
                client.Close();
            }
            catch (SocketException)
            {
                //todo:sdasd
            }
            finally
            {
                GetThreadControl(t1+":"+port1);
            }
        }

        private void HttpRequest()
        {
            var urlList = new List<string>();
            var parseUrlFirst = txtFound.Text.Trim().Split('\n');
            for (var i = 0; i < parseUrlFirst.Count(); i++)
            {
                if (parseUrlFirst[i].Replace("\r", "").Contains("80"))
                {
                    var ip = parseUrlFirst[i].Replace("\r","").Split(':');
                    urlList.Add(ip[0]);
                }
            }
            foreach (var t in urlList)
            {
                var url = $"{"http://"}{t}";
                txtStatus.Text += Environment.NewLine + url + @" için http sorgusu başladı.";
                var uri = new Uri(url);
                _taskList.Add(Task.Factory.StartNew(() => HttpConnect(url, uri, false)));
            }
        }
        private void HttpsRequest()
        {
            var urlList = new List<string>();
            var parseUrlFirst = txtFound.Text.Trim().Split('\n');
            for (var i = 0; i < parseUrlFirst.Count(); i++)
            {
                if (parseUrlFirst[i].Replace("\r", "").Contains("443"))
                {
                    var ip = parseUrlFirst[i].Replace("\r", "").Split(':');
                    urlList.Add(ip[0]);
                }
            }
            foreach (var t in urlList)
            {
                var url = $"{"https://"}{t}";
                txtStatus.Text += Environment.NewLine + url + @" için https sorgusu başladı.";
                var uri = new Uri(url);
                _taskList.Add(Task.Factory.StartNew(() => HttpConnect(url, uri, true)));
            }
        }
        private void HttpConnect(string url, Uri uri, bool isHttps)
        {
            try
            {
                if (!isHttps)
                {
                    var documentName = url.Replace("http://", "");
                    var saveLocation = Application.StartupPath + @"\Scanner\Saved\" + documentName + ".html";
                    var request = (HttpWebRequest) WebRequest.Create(uri);
                    request.UserAgent = "Googlebot/2.1 (+http://www.adeosecurity.com.tr)";
                    request.Referer = url;
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    request.AllowAutoRedirect = false;
                    request.Headers[HttpRequestHeader.AcceptEncoding] = "sdch";
                    request.Headers[HttpRequestHeader.AcceptLanguage] = "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4";
                    try
                    {
                        using (var response = request.GetResponse())
                        {
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                var htmlsource = reader.ReadToEnd();
                                response.Close();
                                reader.Close();
                                var createHtmlCopy = new StreamWriter(saveLocation);
                                createHtmlCopy.Write(htmlsource);
                                createHtmlCopy.Flush();
                                createHtmlCopy.Close();
                                txtStatus.Text += Environment.NewLine + url + @" için " + documentName +
                                                  @".html dosyası kaydedildi";
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        txtStatus.Text += Environment.NewLine + @"İşlem sırasında bir hata oluştu. Oluşan hata: " +
                                          exp.Message;
                    }
                }
                else
                {
                    var documentName = url.Replace("https://", "");
                    var saveLocation = Application.StartupPath + @"\Scanner\Saved\" + documentName + ".html";
                    var request = (HttpWebRequest) WebRequest.Create(uri);
                    request.UserAgent = "Googlebot/2.1 (+http://www.adeosecurity.com.tr)";
                    request.Referer = url;
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    request.AllowAutoRedirect = false;
                    request.Headers[HttpRequestHeader.AcceptEncoding] = "sdch";
                    request.Headers[HttpRequestHeader.AcceptLanguage] = "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4";

                    request.AllowWriteStreamBuffering = true;
                    request.ProtocolVersion = HttpVersion.Version11;
                    ServicePointManager.ServerCertificateValidationCallback +=
                        new RemoteCertificateValidationCallback(ValidateServerCertificate);
                    try
                    {
                        using (var response = request.GetResponse())
                        {
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                var htmlsource = reader.ReadToEnd();
                                response.Close();
                                reader.Close();
                                var createHtmlCopy = new StreamWriter(saveLocation);
                                createHtmlCopy.Write(htmlsource);
                                createHtmlCopy.Flush();
                                createHtmlCopy.Close();
                                txtStatus.Text += Environment.NewLine + url + @" için " + documentName +
                                                  @".html dosyası kaydedildi";
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        txtStatus.Text += Environment.NewLine + @"İşlem sırasında bir hata oluştu. Oluşan hata: " +
                                          exp.Message;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_taskList.Count > 0)
                {
                    for (var i = 0; i < _taskList.Count; i++)
                    {
                        if (_taskList[i].IsCompleted == false)
                        {
                            _taskList[i].Wait();
                        }
                        else
                        {
                            txtStatus.Text += Environment.NewLine + @"Indirme işlemi tamamlandı...";
                            _taskList.Clear();
                        }
                    }
                }
            }
        }
        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            txtStatus.SelectionStart = txtStatus.Text.Length;
            txtStatus.ScrollToCaret();
        }
        private void GetThreadControl(string senderIp)
        {
            if (_taskList.Count > 0)
            {
                for (var i = 0; i < _taskList.Count; i++)
                {
                    try
                    {
                        while (_taskList[i].IsCompleted)
                        {
                            _taskList.RemoveAt(_taskList[i].Id);
                            txtStatus.Text += Environment.NewLine + senderIp + @" için tarama tamamlandı.";
                        }
                    }
                    catch (Exception)
                    {
                        //todo
                    }
                }
            }
        }
    }
}
