using System;

using BestHTTP.WebSocket;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Logging;
using EnergonSoftware.Netrunner.Core.Util;

using JetBrains.Annotations;

using UnityEngine;

namespace EnergonSoftware.Netrunner.JintekiNet
{
    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        private static readonly Logger Logger = new Logger(new CustomLogHandler());

        [CanBeNull]
        private WebSocket _ws;

#region Unity Lifecycle
        protected override void OnDestroy()
        {
            Disconnect();

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

            Disconnect();

            _ws = new WebSocket(new Uri(GameManager.Instance.Config.BackendURL));

            _ws.OnOpen += SocketOpenEventHandler;
            _ws.OnMessage += SocketMessageEventHandler;
            _ws.OnClosed += SocketClosedEventHandler;
            _ws.OnError += SocketErrorEventHandler;

            Logger.Log($"Connecting to {GameManager.Instance.Config.BackendURL}...");
            _ws.Open();
        }

        public void Disconnect()
        {
            if(null == _ws) {
                return;
            }

            Logger.Log("Closing connection");

            _ws.Close();
            _ws = null;
        }

#region Event Handlers
        private void SocketOpenEventHandler(WebSocket ws)
        {
            Logger.Log("Connection opened!");
        }

        private void SocketMessageEventHandler(WebSocket ws, string message)
        {
            Logger.Log($"Socket message: {message}");
        }

        private void SocketClosedEventHandler(WebSocket ws, ushort code, string message)
        {
            Logger.Log($"Socket closed: {code}: {message}");
        }

        private void SocketErrorEventHandler(WebSocket ws, Exception ex)
        {
            string error = null != ws.InternalRequest.Response
                ? $"[{ws.InternalRequest.Response.StatusCode}] {ws.InternalRequest.Response.Message}"
                : string.Empty;
            Logger.Log($"Connection Error: {ex?.Message ?? error}");
        }
#endregion
    }
}
