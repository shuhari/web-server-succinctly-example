using System.Net;
using System.Linq;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    public class BlockIp : IMiddleware
    {
        public BlockIp(params string[] forbiddens)
        {
            _forbiddens = forbiddens;
        }

        private string[] _forbiddens;

        public MiddlewareResult Execute(HttpListenerContext context)
        {
            var clientIp = context.Request.RemoteEndPoint.Address;
            if (_forbiddens.Contains(clientIp.ToString()))
            {
                context.Response.Status(403, "Forbidden");
                return MiddlewareResult.Processed;
            }
            return MiddlewareResult.Continue;
        }
    }
}