using System.Security.Principal;

namespace WebServerExample.Infrastructure
{
    public class AnonymousUser : IPrincipal
    {
        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity => new AnonymousIdentity();
    }

    class AnonymousIdentity : IIdentity
    {
        public string Name => "Anonymouse";

        public string AuthenticationType => "";

        public bool IsAuthenticated => false;
    }
}