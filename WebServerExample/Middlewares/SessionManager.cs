using System;
using System.Collections.Concurrent;
using System.Net;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    /// <summary>
    /// Manage session
    /// </summary>
    public class SessionManager : IMiddleware
    {
        public SessionManager()
        {
            _sessions = new ConcurrentDictionary<string, Session>();            
        }
        
        private const string _cookieName = "__sessionid__";

        private ConcurrentDictionary<string, Session> _sessions;
        
        public MiddlewareResult Execute(HttpServerContext context)
        {
            var cookie = context.Request.Cookies[_cookieName];
            Session session = null;
            if (cookie != null)
            {
                _sessions.TryGetValue(cookie.Value, out session);
            }
            if (session == null)
            {
                session = new Session();
                var sessionId = GenerateSessionId();
                _sessions[sessionId] = session;
                cookie = new Cookie(_cookieName, sessionId);
                context.Response.SetCookie(cookie);
            }
            context.Session = session;
            return MiddlewareResult.Continue;
        }

        private string GenerateSessionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}