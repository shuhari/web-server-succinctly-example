using System.Collections.Generic;
using System.Reflection;

namespace WebServerExample.Models
{
    /// <summary>
    /// Route values
    /// </summary>
    public class RouteValueDictionary : Dictionary<string, object>
    {
        public RouteValueDictionary Load(object values)
        {
            if (values != null)
            {
                foreach (var prop in values.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    this[prop.Name] = prop.GetValue(values);
                }
            }

            return this;
        }
    }
}