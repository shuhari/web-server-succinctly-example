using System;
using WebServerExample.Infrastructure;

namespace WebServerExample
{
    internal class Program
    {
        private const int concurrentCount = 20;
        private const string serverUrl = "http://localhost:9000/";
        
        public static void Main(string[] args)
        {
            var server = new WebServer(concurrentCount);
            server.Bind(serverUrl);
            server.Start();
            
            Console.WriteLine($"Web server started at {serverUrl}. Press any key to exist...");
            Console.ReadKey();
        }
    }
}