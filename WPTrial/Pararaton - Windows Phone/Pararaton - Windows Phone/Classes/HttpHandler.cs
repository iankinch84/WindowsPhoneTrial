using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;


namespace Pararaton___Windows_Phone
{
    class HttpHandler
    {
        WebClient HttpClient;
        CookieAwareWebClient testClient;

        private const string _DefaultURL_RESTful = "http://www.pararaton.com/rest/";
        private const string _DefaultURL = "http://www.pararaton.com/";
        private string _URL;
        private string _ResponseString;

        public HttpHandler()
        {
            HttpClient = new WebClient();
            HttpClient.Encoding = Encoding.UTF8;

            testClient = new CookieAwareWebClient();
        }

        public HttpHandler(string url)
        {
            HttpClient = new WebClient();
            HttpClient.Encoding = Encoding.UTF8;

            testClient = new CookieAwareWebClient();
            
            _URL = url;
        }

        public void Request(string controller, string action,
            string method, Dictionary<string, string> parameters,
            Dictionary<string, string> cookies)
        {         
            string RequestURI = "";

            if (!String.IsNullOrEmpty(controller))
            {
                controller += "/";
            }

            RequestURI = _DefaultURL_RESTful + controller + action;

            if (!String.IsNullOrEmpty(_URL))
            {
                RequestURI = _DefaultURL_RESTful + _URL + controller + action;
            }

            string param = "";
            switch (method.ToUpper())
            {
                case "POST":
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> keyVal in parameters)
                        {
                            param += String.Format("{0}={1}&", keyVal.Key, keyVal.Value);
                        }
                    }

                    testClient.Headers["Content-type"] = 
                        "application/x-www-form-urlencoded;charset=UTF-8";

                    testClient.UploadStringCompleted +=
                        new UploadStringCompletedEventHandler(UploadStringCompleteHandler);

                    testClient.UploadStringAsync(new Uri(RequestURI), method.ToUpper(), param);

                    break;

                default: //-- GET
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> KeyValue in parameters)
                        {
                            param += KeyValue.Key + "=" + KeyValue.Value + "&";
                        }
                    }

                    HttpClient.DownloadStringCompleted +=
                        new DownloadStringCompletedEventHandler(DownloadStringCompleteHandler);

                    HttpClient.DownloadStringAsync(new Uri(RequestURI + "?" + param));

                    break;
            }     
        }

        public string GetResponseDataString()
        {
            return _ResponseString;
        }

        public void DownloadStringCompleteHandler(object sender, DownloadStringCompletedEventArgs e)
        {
            _ResponseString = e.Result;
            
            _ResponseString = _ResponseString.Replace("\n", "");
        }

        public void UploadStringCompleteHandler(object sender, UploadStringCompletedEventArgs e)
        {
            WebHeaderCollection header = (WebHeaderCollection)((WebClient)sender).ResponseHeaders;

            CookieAwareWebClient temp = (CookieAwareWebClient)sender;
            CookieContainer cookies = temp.getCookieContainer();

            foreach (Cookie xcookie in cookies.GetCookies(new Uri("http://www.pararaton.com/")))
            {
                string t = String.Format("{0}={1}", xcookie.Name, xcookie.Value);
            }

            _ResponseString = e.Result;
            _ResponseString = _ResponseString.Replace("\n", "");
        }
        
    }
}
