namespace WebServerExample.Infrastructure.Results
{
    public class ContentResult : ActionResult
    {
        public ContentResult(string content, string mimeType = null)
        {
            _content = content ?? "";
            _mimeType = mimeType ?? "text/html";
        }

        private readonly string _content;

        private readonly string _mimeType;
        
        public override void Execute(HttpServerContext context)
        {
            context.Response.Content(_content, _mimeType);
        }
    }
}