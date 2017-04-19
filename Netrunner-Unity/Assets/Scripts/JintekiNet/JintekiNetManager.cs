using System;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.SocketIO;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        private SocketIO _socketIO;

        private void Awake()
        {
            _socketIO = new SocketIO(GameManager.Instance.Config.BackendURL);
            _socketIO.Connect();
        }

        public void Authenticate(string username, string password, Action onSuccess, Action<string> onFailure)
        {
            onSuccess?.Invoke();
        }
    }
}
