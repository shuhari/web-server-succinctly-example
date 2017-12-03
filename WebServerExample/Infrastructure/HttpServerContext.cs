using System.Net;
using System.Security.Principal;
using WebServerExample.Interfaces;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Extend HttpListenerContext to add session support
    /// </summary>
    public class HttpServerContext
    {
        public HttpServerContext(HttpListenerContext context)
        {
            _innerContext = context;
            Request = new HttpServerRequest(context.Request);
        }

        private readonly HttpListenerContext _innerContext;

        public HttpServerRequest Request { get; private set; }
        
        public HttpListenerResponse Response => _innerContext.Response;

        public IPrincipal User { get; internal set; }
        
        public ISession Session { get; internal set; }
    }
}