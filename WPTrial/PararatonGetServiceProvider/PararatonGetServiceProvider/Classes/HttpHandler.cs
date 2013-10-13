using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace PararatonGetServiceProvider
{
    class HttpHandler
    {
        private WebRequest _request;
        private WebResponse _response;        

        private const string _DefaultURL_RESTful = "http://www.pararaton.com/rest/";
        private const string _DefaultURL = "http://www.pararaton.com/";
        private string _URL;

        //-- Constructor HttpHandler tanpa parameter
        public HttpHandler()
        {
            _URL = "";
        }

        //-- Constructor HttpHandler dengan parameter
        public HttpHandler(string url)
        {
            _URL = url;
        }

        //-- Mengirim Request dan mendapatkan nilai respond
        public string Request(string controller, string action, 
            string method, Dictionary<string, object> parameters, 
            Dictionary<string, string> cookies)
        {
            string result;

            if (!String.IsNullOrEmpty(controller))
            {
                controller += "/";
            }

            _request = WebRequest.Create(_DefaultURL_RESTful + controller + action);

            if (!String.IsNullOrEmpty(_URL))
            {
                _request = WebRequest.Create(_DefaultURL_RESTful + _URL + controller + action);
            }

            _request.Method = method.ToUpper();
            _request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            if (cookies != null && cookies.Count > 0)
            {
                ((HttpWebRequest)_request).CookieContainer = new CookieContainer();

                foreach (KeyValuePair<string, string> keyVal in cookies)
                {
                    ((HttpWebRequest)_request).CookieContainer.Add(new Uri(_DefaultURL),
                        new Cookie(keyVal.Key, keyVal.Value));                        
                }
            }

            if (parameters != null && parameters.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(_request.GetRequestStream()))
                {
                    foreach (KeyValuePair<string, object> KeyValue in parameters)
                    {
                        writer.Write("{0}={1}&", KeyValue.Key, KeyValue.Value.ToString());
                    }

                    writer.Close();
                }
            }            

            _response = _request.GetResponse();            

            using (StreamReader reader = new StreamReader(_response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
                reader.Close();
            }

            return result;
        }

        //-- Mengirim Request dan mendapatkan nilai respond
        public string Request(string controller, string action,
            string method, Dictionary<string, object> parameters)
        {
            return this.Request(controller, action, method, parameters, null);
        }

        //-- Mengirim Request dan mendapatkan nilai respond        
        public string Request(string url, string method, Dictionary<string, object> parameters,
            Dictionary<string, string> cookies)
        {
            _URL = url;
            return this.Request(null, null, method, parameters, cookies);
        }

        //-- Mengirim Request dan mendapatkan nilai respond        
        public string Request(string url, string method, Dictionary<string, object> parameters)
        {
            _URL = url;
            return this.Request(null, null, method, parameters, null);
        }

        //-- Mengirim Request dan mendapatkan nilai respond
        public string Request(string method, Dictionary<string, object> parameters,
            Dictionary<string, string> cookies)
        {
            return this.Request(_URL, method, parameters, cookies);
        }

        //-- Mengirim Request dan mendapatkan nilai respond
        public string Request(string method, Dictionary<string, object> parameters)
        {
            return this.Request(_URL, method, parameters, null);
        }

        //-- Mengirim Request dan mendapatkan nilai respond
        public string Request(string method)
        {
            return this.Request(method, null);
        }

        //-- Mendapatkan nilai data string dari respond yang telah ada
        public string GetResponseDataString()
        {
            if (_response != null)
            {
                string result;
                using (StreamReader reader = new StreamReader(_response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                }

                return result;
            }

            return null;
        }

        public string GetResposeHeaderDataString(string HeaderKey)
        {
            if (_response != null)
            {
                HttpWebResponse currentResponse = (HttpWebResponse)_response;

                return currentResponse.GetResponseHeader(HeaderKey);
            }

            return null;
        }
    }
}
