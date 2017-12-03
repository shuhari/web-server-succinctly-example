namespace WebServerExample.Infrastructure.Results
{
    public class RedirectResult : ActionResult
    {
        public RedirectResult(string url)
        {
            _url = url;
        }

        private readonly string _url;
        
        public override void Execute(HttpServerContext context)
        {
            context.Response.StatusCode = 301;
            context.Response.AddHeader("Location", _url);
            context.Response.OutputStream.Close();
        }
    }
}