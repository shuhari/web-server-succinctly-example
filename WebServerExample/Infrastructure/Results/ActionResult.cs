namespace WebServerExample.Infrastructure.Results
{
    public abstract class ActionResult
    {
        public abstract void Execute(HttpServerContext context);
    }
}