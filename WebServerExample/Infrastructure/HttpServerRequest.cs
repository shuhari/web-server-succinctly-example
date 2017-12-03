using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace WebServerExample.Infrastructure
{
    public class HttpServerRequest
    {
        public HttpServerRequest(HttpListenerRequest request)
        {
            _innerRequest = request;
            Form = new NameValueCollection();
        }

        private readonly HttpListenerRequest _innerRequest;

        public CookieCollection Cookies => _innerRequest.Cookies;

        public Uri Url => _innerRequest.Url;

        public string HttpMethod => _innerRequest.HttpMethod;

        public IPEndPoint RemoteEndPoint => _innerRequest.RemoteEndPoint;

        public Stream InputStream => _innerRequest.InputStream;
        
        public NameValueCollection Form { get; private set; }
    }
}