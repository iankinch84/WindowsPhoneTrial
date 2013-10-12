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

        private const string _DefaultURL = "http://www.pararaton.com/rest/";
        private string _URL;

        public HttpHandler()
        {
            _URL = "";
        }

        public HttpHandler(string url)
        {
            _URL = url;
        }

        public string Request(string controller, string action, 
            string method, Dictionary<string, object> parameters)
        {
            string result;

            if (!String.IsNullOrEmpty(controller))
            {
                controller += "/";
            }

            _request = WebRequest.Create(_DefaultURL + controller + action);

            if (!String.IsNullOrEmpty(_URL))
            {
                _request = WebRequest.Create(_URL + controller + action);
            }

            _request.Method = method.ToUpper();
            _request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            if (parameters != null)
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

        public string Request(string url, string method, Dictionary<string, object> parameters)
        {
            return this.Request(url, null, method, parameters);
        }
    }
}
