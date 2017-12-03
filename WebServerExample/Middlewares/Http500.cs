using System;
using System.Net;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;

namespace WebServerExample.Middlewares
{
    public class Http500 : IExceptionHandler
    {
        public void HandleException(HttpListenerContext context, Exception exp)
        {
            while (exp != null)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
                exp = exp.InnerException;
            }

            context.Response.Status(500, "Internal Server Error");
        }
    }
}