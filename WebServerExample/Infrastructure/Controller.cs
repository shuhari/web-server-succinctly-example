using System.Security.Principal;
using WebServerExample.Infrastructure.Results;
using WebServerExample.Interfaces;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class Controller : IController
    {
        public HttpServerContext HttpContext { get; internal set; }

        protected ISession Session => HttpContext.Session;

        protected IPrincipal User => HttpContext.User;

        protected HttpServerRequest Request => HttpContext.Request;
        
        protected ViewResult View(string viewName, object model)
        {
            var controllerName = GetType().Name;
            if (controllerName.EndsWith("Controller"))
                controllerName = controllerName.Substring(0, controllerName.Length - 10);
            return new ViewResult(controllerName, viewName, model);
        }

        protected RedirectResult Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}