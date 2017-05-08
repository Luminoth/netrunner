using System;
using System.Threading.Tasks;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Logging;
using EnergonSoftware.Netrunner.Core.SocketIO;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        private static readonly UnityEngine.Logger Logger = new UnityEngine.Logger(new CustomLogHandler());

        public sealed class ConnectionFailedEventArgs : EventArgs
        {
            public string Reason { get; set; }

            public ConnectionFailedEventArgs()
            {
            }

            public ConnectionFailedEventArgs(SocketIO.ConnectionFailedEventArgs args)
            {
                Reason = args.Reason;
            }
        }

#region Events
        public event EventHandler<ConnectionFailedEventArgs> ConnectionFailedEvent;
#endregion

        private SocketIO _socketIO = new SocketIO();

        private void Awake()
        {
            _socketIO.ConnectionFailedEvent += ConnectionFailedEventHandler;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _socketIO.Dispose();
            _socketIO = null;
        }

        public async Task Authenticate(string username, string password, Action onSuccess, Action<string> onFailure)
        {
            await _socketIO.ConnectAsync(GameManager.Instance.Config.BackendURL);

            GameManager.Instance.RunOnMainThread(() =>
            {
                if(_socketIO.IsConnected) {
                    onSuccess?.Invoke();
                } else {
                    onFailure?.Invoke("Connection failed!");
                }
            });
        }

#region Event Handlers
        private void ConnectionFailedEventHandler(object sender, SocketIO.ConnectionFailedEventArgs args)
        {
            ConnectionFailedEvent?.Invoke(this, new ConnectionFailedEventArgs(args));
        }
#endregion
    }
}
