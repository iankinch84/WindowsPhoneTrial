using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Pararaton___Windows_Phone
{
    class CookieAwareWebClient : WebClient
    {
        [System.Security.SecuritySafeCritical]
        public CookieAwareWebClient() : base()
        {
        }

        private CookieContainer m_container = new CookieContainer();

        public CookieContainer getCookieContainer()
        {
            return m_container;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = m_container;
            }
            return request;
        }
    }
}
