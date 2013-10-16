using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace Pararaton___Windows_Phone.Classes
{
    class HttpHandler_2
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        private HttpWebRequest _HttpClientRequest;
        private HttpWebResponse _HttpClientResponse;

        private const string _DefaultURL_RESTful = "http://localhost:8080/rest/";
        private const string _DefaultURL = "http://localhost:8080/";
        private string _URL;
        private string _ResponseString;
        private string _ResponseHeaderString;
        
        private Dictionary<string, string> _Parameters;
        private Dictionary<string, string> _Cookies;

        public HttpHandler_2()
        {
            _Parameters = new Dictionary<string, string>();
            _Cookies = new Dictionary<string, string>();
        }

        public HttpHandler_2(string url)
        {   
            _URL = url;
        }

        public string GetResponseDataString()
        {
            return _ResponseString;
        }

        public void AddParameter(string key, string value)
        {
            _Parameters.Add(key, value);
        }

        public void AddParameter(Dictionary<string, string> param)
        {
            _Parameters.Clear();
            _Parameters = param;
        }

        public void AddCookie(Dictionary<string, string> cookies)
        {
            _Cookies.Clear();
            _Cookies = cookies;
        }

        public void closeHttpResponse()
        {
            _HttpClientResponse.Close();
        }

        public void Request(string controller, string action,
            string method, Dictionary<string, string> parameters,
            Dictionary<string, string> cookies)
        {         
            string RequestURI = "";

            this.AddParameter(parameters);
            this.AddCookie(cookies);

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
                    _HttpClientRequest = (HttpWebRequest)WebRequest.Create(new Uri(RequestURI));
                    _HttpClientRequest.Method = "POST";
                    _HttpClientRequest.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.66 Safari/537.36";
                    _HttpClientRequest.ContentType = 
                        "application/x-www-form-urlencoded;charset=UTF-8";
                    _HttpClientRequest.CookieContainer = new CookieContainer();

                    _HttpClientRequest.BeginGetRequestStream(new AsyncCallback
                        (GetRequestStreamCallback), _HttpClientRequest);

                    //allDone.WaitOne();
                    break;

                default: //-- GET
                    param = "?";
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> KeyValue in parameters)
                        {
                            param += KeyValue.Key + "=" + KeyValue.Value + "&";
                        }
                    }

                    _HttpClientRequest = (HttpWebRequest)WebRequest.Create
                        (new Uri(RequestURI + param));

                    _HttpClientRequest.BeginGetResponse(GetResponseStreamCallback,
                        _HttpClientRequest);

                    break;
            }     
        }

        private void GetRequestStreamCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            if (_Parameters != null && _Parameters.Count > 0)
            {
                // End of Operation
                using (StreamWriter writer = new StreamWriter
                    (request.EndGetRequestStream(asyncResult)))
                {
                    foreach (KeyValuePair<string, string> keyVal in _Parameters)
                    {
                        writer.Write("{0}={1}&", keyVal.Key, keyVal.Value);
                    }

                    writer.Close();
                }
                
            }

            if (_Cookies != null && _Cookies.Count > 0)
            {
                foreach (KeyValuePair<string, string> keyVal in _Cookies)
                {
                    request.CookieContainer.Add(new Uri(_DefaultURL), new Cookie(keyVal.Key, keyVal.Value));                    
                }                
            }

            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseStreamCallback), request);
        }

        private void GetResponseStreamCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            // End the operation
            HttpWebResponse respond = (HttpWebResponse)request.EndGetResponse(asyncResult);
            _ResponseHeaderString = respond.Headers["set-cookie"];

            using (StreamReader reader = new StreamReader(respond.GetResponseStream()))
            {
                _ResponseString = reader.ReadToEnd();
                reader.Close();
            }

            char[] delimiter = { ';', '=' };
            string[] temp = _ResponseHeaderString.Split(delimiter);

            respond.Close();                
        }

        

    }
}
