using System.Security.Principal;

namespace WebServerExample.Infrastructure
{
    public class User : IPrincipal
    {
        public User(string name)
        {
            _name = name;
        }

        private readonly string _name;
        
        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity => new GenericIdentity(_name, "");
    }
}