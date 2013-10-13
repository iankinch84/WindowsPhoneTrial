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
        

        private const string _DefaultURL_RESTful = "http://www.pararaton.com/rest/";
        private const string _DefaultURL = "http://www.pararaton.com/";
        private string _URL;

        public HttpHandler()
        {
            HttpClient = new WebClient();
        }

        public HttpHandler(string url)
        {
            HttpClient = new WebClient();
            _URL = url;
        }

        public string Request(string controller, string action,
            string method, Dictionary<string, object> parameters,
            Dictionary<string, string> cookies)
        {
            string result = null;
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

            switch (method.ToUpper())
            {
                case "POST":
                    string param = "";
                    foreach (KeyValuePair<string, object> keyVal in parameters)
                    {
                        param += String.Format("{0}={1}&", keyVal.Key, keyVal.Value);
                    }

                    HttpClient.UploadStringAsync(new Uri(RequestURI), param);
                    
                    HttpClient.UploadStringCompleted += 
                        new UploadStringCompletedEventHandler(UploadStringCompleteHandler);
                    break;

                default: //-- GET
                    string QueryString = "?";

                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> KeyValue in parameters)
                        {
                            QueryString += KeyValue.Key + "=" + KeyValue.Value + "&";
                        }
                    }

                    RequestURI = RequestURI + QueryString;

                    break;
            }

            


            return result;
        }

        public void UploadStringCompleteHandler(object sender, UploadStringCompletedEventArgs e)
        {
            string temp = e.Result;
        }
    }
}
