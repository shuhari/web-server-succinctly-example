using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Implement web server
    /// </summary>
    public class WebServer
    {
        private readonly Semaphore _sem;

        private readonly HttpListener _listener;

        public WebServer(int concurrentCount)
        {
            _sem = new Semaphore(concurrentCount, concurrentCount);
            _listener = new HttpListener();
        }

        public void Bind(string url)
        {
            _listener.Prefixes.Add(url);
        }

        public void Start()
        {
            _listener.Start();

            Task.Run(async () =>
            {
                while (true)
                {
                    _sem.WaitOne();
                    var context = await _listener.GetContextAsync();
                    _sem.Release();
                    HandleRequest(context);
                }
            });
        }

        private void HandleRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var urlPath = request.Url.LocalPath.TrimStart('/');
            Console.WriteLine($"url path={urlPath}");
            
            try
            {
                string filePath = Path.Combine("files", urlPath);
                byte[] data = File.ReadAllBytes(filePath);

                response.ContentType = "text/html";
                response.ContentLength64 = data.Length;
                response.ContentEncoding = Encoding.UTF8;
                response.StatusCode = 200;
                response.OutputStream.Write(data, 0, data.Length);
                response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
