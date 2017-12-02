using System;
using System.Net;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    /// <summary>
    /// Log request
    /// </summary>
    public class HttpLog : IMiddleware
    {
        public MiddlewareResult Execute(HttpListenerContext context)
        {
            var request = context.Request;
            var path = request.Url.LocalPath;
            var clientIp = request.RemoteEndPoint.Address;
            var method = request.HttpMethod;

            Console.WriteLine("[{0:yyyy-MM-dd HH:mm:ss}] {1} {2} {3}",
                DateTime.Now, clientIp, method, path);

            return MiddlewareResult.Continue;
        }
    }
}