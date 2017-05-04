using System;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Logging;
using EnergonSoftware.Netrunner.Core.SocketIO;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        private static readonly UnityEngine.Logger Logger = new UnityEngine.Logger(new CustomLogHandler());

        private SocketIO _socketIO;

        private async void Awake()
        {
            _socketIO = new SocketIO();

            bool connected = await _socketIO.ConnectAsync(GameManager.Instance.Config.BackendURL);
Logger.LogError($"connected: {connected}");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _socketIO.Dispose();
            _socketIO = null;
        }

        public void Authenticate(string username, string password, Action onSuccess, Action<string> onFailure)
        {
            onSuccess?.Invoke();
        }
    }
}
