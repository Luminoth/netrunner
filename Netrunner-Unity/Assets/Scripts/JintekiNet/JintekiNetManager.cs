using System;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.SocketIO;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        private readonly SocketIO _socketIO = new SocketIO();

        public void Authenticate(string username, string password, Action onSuccess, Action<string> onFailure)
        {
            onSuccess?.Invoke();
        }
    }
}
