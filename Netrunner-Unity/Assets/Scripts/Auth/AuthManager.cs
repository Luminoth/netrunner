using EnergonSoftware.Netrunner.Core;

namespace EnergonSoftware.Netrunner
{
    public sealed class AuthManager : SingletonBehavior<AuthManager>
    {
        public bool IsAuthenticated => false;
    }
}
