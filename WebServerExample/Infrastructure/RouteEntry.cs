using System.Linq;
using System.Net;
using WebServerExample.Models;

namespace WebServerExample.Infrastructure
{
    public class RouteEntry
    {
        public RouteEntry(string name, string url, object defaults)
        {
            _name = name;
            _fragments = Parse(url, defaults);
        }

        private readonly string _name;

        private readonly RouteFragment[] _fragments;

        private RouteFragment[] Parse(string url, object defaults)
        {
            var defaultValues = new RouteValueDictionary().Load(defaults);
            return url.Split('/')
                .Select(x => new RouteFragment(x, defaultValues))
                .ToArray();
        }

        public RouteValueDictionary Match(HttpListenerRequest request)
        {
            var urlPath = request.Url.LocalPath.TrimStart('/');
            var urlParts = urlPath.Split('/');
            var routeValues = new RouteValueDictionary();
            for (var i = 0; i < _fragments.Length; i++)
            {
                string urlPart = (i < urlParts.Length) ? urlParts[i] : "";
                if (!_fragments[i].Match(urlPart, routeValues))
                    return null;
            }

            if (routeValues.Values.Contains(UrlParameter.Missing))
                return null;

            return routeValues;
        }
    }
}