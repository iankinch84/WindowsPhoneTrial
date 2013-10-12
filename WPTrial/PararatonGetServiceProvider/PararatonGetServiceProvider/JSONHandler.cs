using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace PararatonGetServiceProvider
{
    class JSONHandler
    {
        private string _JSONString;

        public JSONHandler()
        {
            _JSONString = "";
        }

        public JSONHandler(string jsonstring)
        {
            _JSONString = jsonstring;
        }

        public void SetJSONString(string jsonstring)
        {
            _JSONString = jsonstring;
        }

        public dynamic Deserialize(string jsonstring)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            dynamic data = jss.Deserialize<dynamic>(jsonstring);

            return data;
        }

        public dynamic Deserialize()
        {
            return this.Deserialize(_JSONString);
        }        
    }
}
