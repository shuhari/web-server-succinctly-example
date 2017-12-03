using System;
using System.IO;
using System.Text;
using System.Web;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    public class BodyParser : IMiddleware
    {
        public MiddlewareResult Execute(HttpServerContext context)
        {
            var request = context.Request;
            if (request.HttpMethod.Equals("POST", StringComparison.InvariantCultureIgnoreCase))
            {
                using (var reader = new StreamReader(request.InputStream, Encoding.UTF8))
                {
                    string postData = reader.ReadToEnd();
                    foreach (var kv in postData.Split('&'))
                    {
                        int index = kv.IndexOf('=');
                        if (index > 0)
                        {
                            string key = kv.Substring(0, index);
                            string value = HttpUtility.UrlDecode(kv.Substring(index + 1));
                            request.Form[key] = value;
                        }
                    }
                }
            }
            
            return MiddlewareResult.Continue;
        }
    }
}