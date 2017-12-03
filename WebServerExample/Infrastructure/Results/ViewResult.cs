using System.IO;
using Microsoft.AspNetCore.Razor;
using RazorEngine;

namespace WebServerExample.Infrastructure.Results
{
    public class ViewResult : ActionResult
    {
        public ViewResult(string controllerName, string viewName,
            object model)
        {
            _viewLocation = FindViewLocation(controllerName, viewName);
            _model = model;
        }

        private string _viewLocation;

        private object _model;

        private string FindViewLocation(string controllerName, string viewName)
        {
            var baseDir = Path.GetDirectoryName(GetType().Assembly.Location);
            string filePath = Path.Combine(baseDir, "Views", controllerName, viewName + ".cshtml");
            return filePath;
        }
        
        public override void Execute(HttpServerContext context)
        {
            var tpl = File.ReadAllText(_viewLocation, System.Text.Encoding.UTF8);
            var result = Razor.Parse(tpl, _model);
            context.Response.Content(result, "text/html");
        }
    }
}