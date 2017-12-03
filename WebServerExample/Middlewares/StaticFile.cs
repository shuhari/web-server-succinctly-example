using System.IO;
using System.Text;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    public class StaticFile : IMiddleware
    {
        public MiddlewareResult Execute(HttpServerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var urlPath = request.Url.LocalPath.TrimStart('/');
            string filePath = Path.Combine("files", urlPath);
            if (File.Exists(filePath))
            {
                byte[] data = File.ReadAllBytes(filePath);
                response.ContentType = "text/html";
                response.ContentLength64 = data.Length;
                response.ContentEncoding = Encoding.UTF8;
                response.StatusCode = 200;
                response.OutputStream.Write(data, 0, data.Length);
                response.OutputStream.Close();
                return MiddlewareResult.Processed;
            }

            return MiddlewareResult.Continue;
        }
    }
}