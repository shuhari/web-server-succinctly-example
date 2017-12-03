using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using WebServerExample.Infrastructure;
using WebServerExample.Interfaces;
using WebServerExample.Models;

namespace WebServerExample.Middlewares
{
    public class Authentication : IMiddleware
    {
        private const string _cookieName = "_userid_";
        
        private const string _sessionKey = "_user_";
        
        public MiddlewareResult Execute(HttpServerContext context)
        {
            IPrincipal user = null;
            var cookie = context.Request.Cookies[_cookieName];
            if (cookie != null)
            {
                user = context.Session[_sessionKey] as User;
            }
            user = user ?? new AnonymousUser();
            context.User = user;

            return MiddlewareResult.Continue;
        }

        public static void Login(HttpServerContext context, string userName)
        {
            var user = new User(userName);
            context.Session[_sessionKey] = user;
            context.User = user;

            var cookie = new Cookie(_cookieName, userName);
            context.Response.SetCookie(cookie);
        }

        public static void Logout(HttpServerContext context)
        {
            context.Session.Remove(_sessionKey);
            context.User = new AnonymousUser();
            
            var cookie = new Cookie(_cookieName, "");
            cookie.Expired = true;
            context.Response.SetCookie(cookie);
        }
    }
}