using WebServerExample.Interfaces;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class Controller : IController
    {
        public ISession Session { get; internal set; }
    }
}