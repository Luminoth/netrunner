﻿using System;

using EnergonSoftware.Netrunner.Core.Logging;

using WebSocketSharp;

namespace EnergonSoftware.Netrunner.Core.SocketIO
{
    // https://github.com/socketio/socket.io-protocol
    public sealed class SocketIO
    {
        private static readonly UnityEngine.Logger Logger = new UnityEngine.Logger(new CustomLogHandler());

        private readonly WebSocket _webSocket;

        private readonly Encoder _encoder = new Encoder();
        private readonly Decoder _decoder = new Decoder();

        public SocketIO(string url)
        {
            _webSocket = new WebSocket(url);
            _webSocket.OnOpen += WebSocketOpenEventHandler;
            _webSocket.OnClose += WebSocketCloseEventHandler;
            _webSocket.OnError += WebSocketErrorEventHandler;
            _webSocket.OnMessage += WebSocketMessageEventHandler;
        }

        public void Connect()
        {
            if(_webSocket.IsAlive) {
                return;
            }

            Logger.Log($"Connecting web socket at {_webSocket.Url}...");
            _webSocket.ConnectAsync();
        }

        public void Close()
        {
            if(!_webSocket.IsAlive) {
                return;
            }

            Logger.Log("Closing web socket...");
            _webSocket.CloseAsync();
        }

#region Event Handlers
        private void WebSocketOpenEventHandler(object sender, EventArgs args)
        {
Logger.LogError("web socket open!");
        }

        private void WebSocketCloseEventHandler(object sender, CloseEventArgs args)
        {
Logger.LogError($"web socket close: {args.Code}:{args.Reason} ({args.WasClean})");
        }

        private void WebSocketErrorEventHandler(object sender, ErrorEventArgs args)
        {
Logger.LogError($"web socket error: {args.Message}");
        }

        private void WebSocketMessageEventHandler(object sender, MessageEventArgs args)
        {
Logger.LogError("web socket message!");
        }
#endregion
    }
}
