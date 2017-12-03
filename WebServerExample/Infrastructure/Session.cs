using System.Collections.Concurrent;
using WebServerExample.Interfaces;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Session
    /// </summary>
    public class Session : ISession
    {
        public Session()
        {
            _items = new ConcurrentDictionary<string, object>();
        }
        
        private ConcurrentDictionary<string, object> _items;
        
        public object this[string name]
        {
            get { return _items.ContainsKey(name) ? _items[name] : null; }
            set { _items[name] = value; }
        }
    }
}