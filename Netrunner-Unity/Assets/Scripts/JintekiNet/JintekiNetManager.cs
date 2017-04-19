using System;

using EnergonSoftware.Netrunner.Core;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        public void Authenticate(string username, string password, Action onSuccess, Action<string> onFailure)
        {
            onSuccess?.Invoke();
        }
    }
}
