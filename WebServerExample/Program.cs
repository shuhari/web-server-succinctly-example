using System;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Middlewares;

namespace WebServerExample
{
    internal class Program
    {
        private const int concurrentCount = 20;
        private const string serverUrl = "http://localhost:9000/";
        
        public static void Main(string[] args)
        {
            var server = new WebServer(concurrentCount);
            
            RegisterMiddlewares(server);
            
            server.Bind(serverUrl);
            server.Start();
            
            Console.WriteLine($"Web server started at {serverUrl}. Press any key to exist...");
            Console.ReadKey();
        }

        static void RegisterMiddlewares(IWebServerBuilder builder)
        {
            builder.Use(new HttpLog());
            // builder.Use(new BlockIp("::1", "127.0.0.1"));
            builder.Use(new StaticFile());
            builder.Use(new Http404());

            builder.UnhandledException(new Http500());
        }
    }
}