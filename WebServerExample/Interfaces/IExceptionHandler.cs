using System;
using System.Net;

namespace WebServerExample.Interfaces
{
    /// <summary>
    /// Handle exception
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Handle exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exp"></param>
        void HandleException(HttpListenerContext context, Exception exp);
    }
}