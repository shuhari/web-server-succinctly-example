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
            Console.WriteLine(exp.Message);
            Console.WriteLine(exp.StackTrace);

            context.Response.Status(500, "Internal Server Error");
        }
    }
}