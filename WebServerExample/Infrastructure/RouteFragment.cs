using System.Text.RegularExpressions;
using WebServerExample.Models;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    internal class RouteFragment
    {
        public RouteFragment(string part, RouteValueDictionary defaultValues)
        {
            _part = part;
            _parameters = new RouteValueDictionary();

            var re = new Regex("{([a-zA-Z0-9_]+)}");
            foreach (Match match in re.Matches(part))
            {
                string paramName = match.Groups[1].Value;
                if (defaultValues.ContainsKey(paramName))
                    _parameters[paramName] = defaultValues[paramName];
                else
                    _parameters[paramName] = UrlParameter.Missing;
            }
        }

        private readonly RouteValueDictionary _parameters;

        private readonly string _part;

        public RouteValueDictionary Parameters => _parameters;

        public bool Match(string urlPart, RouteValueDictionary routeValues)
        {
            string pattern = _part;
            foreach (var kv in _parameters)
            {
                string origin = "{" + kv.Key + "}";
                string replaceWith = string.Format("(?<{0}>[a-zA-Z0-9_]+)", kv.Key);
                if (kv.Value != UrlParameter.Missing)
                    replaceWith += "?";
                pattern = pattern.Replace(origin, replaceWith);
            }
            var re = new Regex(pattern);
            var match = re.Match(urlPart);
            if (!match.Success)
                return false;
            foreach (var kv in _parameters)
            {
                string matchValue = match.Groups[kv.Key].Value;
                if (string.IsNullOrWhiteSpace(matchValue))
                    routeValues[kv.Key] = kv.Value;
                else
                    routeValues[kv.Key] = matchValue;
            }

            return true;
        }
    }
}