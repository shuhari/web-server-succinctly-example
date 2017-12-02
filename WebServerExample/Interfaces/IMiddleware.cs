using System.Net;
using WebServerExample.Models;

namespace WebServerExample.Interfaces
{
    /// <summary>
    /// Describe middleware behavior
    /// </summary>
    public interface IMiddleware
    {
        /// <summary>
        /// Execute middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        MiddlewareResult Execute(HttpListenerContext context);
    }
}