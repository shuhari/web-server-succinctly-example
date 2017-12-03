using System;
using System.Collections.Generic;
using System.Net;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Manage middlewares
    /// </summary>
    internal class MiddlewarePipeline
    {
        public MiddlewarePipeline()
        {
            _middlewares = new List<IMiddleware>();
        }

        private readonly List<IMiddleware> _middlewares;

        private IExceptionHandler _exeptionHandler;

        internal void Add(IMiddleware middleware)
        {
            _middlewares.Add(middleware);
        }

        internal void UnhandledException(IExceptionHandler handler)
        {
            _exeptionHandler = handler;
        }

        internal void Execute(HttpListenerContext context)
        {
            var serverContext = new HttpServerContext(context);
            
            try
            {
                foreach (var middleware in _middlewares)
                {
                    var result = middleware.Execute(serverContext);
                    if (result == MiddlewareResult.Processed)
                    {
                        break;
                    }
                    else if (result == MiddlewareResult.Continue)
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                if (_exeptionHandler != null)
                    _exeptionHandler.HandleException(context, ex);
                else
                    throw;
            }
        }
    }
}