using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebServerExample.Interfaces;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Implement web server
    /// </summary>
    public class WebServer : IWebServerBuilder
    {
        private readonly Semaphore _sem;

        private readonly HttpListener _listener;

        private readonly MiddlewarePipeline _pipeline;
        
        public WebServer(int concurrentCount)
        {
            _sem = new Semaphore(concurrentCount, concurrentCount);
            _listener = new HttpListener();
            _pipeline = new MiddlewarePipeline();
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
                    _pipeline.Execute(context);
                }
            });
        }

        public IWebServerBuilder Use(IMiddleware middleware)
        {
            _pipeline.Add(middleware);
            return this;
        }

        public IWebServerBuilder UnhandledException(IExceptionHandler handler)
        {
            _pipeline.UnhandledException(handler);
            return this;
        }
    }
}
