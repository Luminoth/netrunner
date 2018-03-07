using System;

using BestHTTP.SocketIO;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Logging;
using EnergonSoftware.Netrunner.Core.Util;

using UnityEngine;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        private static readonly Logger Logger = new Logger(new CustomLogHandler());

        private SocketManager _socketManager;

#region Unity Lifecycle
        protected override void OnDestroy()
        {
            _socketManager?.Close();

            base.OnDestroy();
        }
#endregion

        public void Connect(string username, string password, bool saveLogin)
        {
            if(saveLogin) {
                PlayerPrefs.SetString("authUsername", username);
                // TODO: password
            } else {
                PlayerPrefs.DeleteKey("authUsername");
                // TODO: password
            }
            PlayerPrefsExtensions.SetBool("authSaveLogin", saveLogin);

            _socketManager?.Close();

            SocketOptions options = new SocketOptions
            {
                AutoConnect = false
            };
            _socketManager = new SocketManager(new Uri(GameManager.Instance.Config.BackendURL), options);

            _socketManager.Socket.On("login", OnLogin);
            _socketManager.Socket.On(SocketIOEventTypes.Error, OnError);

            _socketManager.Open();
        }

#region Event Handlers
        private void OnLogin(Socket socket, Packet packet, params object[] args)
        {
            Logger.Log("Connection success!");
        }

        private void OnError(Socket socket, Packet packet, params object[] args)
        {
            Logger.Log($"Connection Error: {args[0]}");
        }
#endregion
    }
}
