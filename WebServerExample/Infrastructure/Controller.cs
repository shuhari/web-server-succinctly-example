using WebServerExample.Infrastructure.Results;
using WebServerExample.Interfaces;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class Controller : IController
    {
        public ISession Session { get; internal set; }

        protected ViewResult View(string viewName, object model)
        {
            var controllerName = GetType().Name;
            if (controllerName.EndsWith("Controller"))
                controllerName = controllerName.Substring(0, controllerName.Length - 10);
            return new ViewResult(controllerName, viewName, model);
        }
    }
}