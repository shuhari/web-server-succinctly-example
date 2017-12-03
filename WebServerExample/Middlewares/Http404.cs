using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    /// <summary>
    /// Return 404 result
    /// </summary>
    public class Http404 : IMiddleware
    {
        public MiddlewareResult Execute(HttpServerContext context)
        {
            context.Response.Status(404, "File Not Found");
            return MiddlewareResult.Processed;
        }
    }
}