using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

using EnergonSoftware.Netrunner.Core.Logging;

namespace EnergonSoftware.Netrunner.Core.SocketIO
{
    // https://github.com/socketio/socket.io-protocol
    public sealed class SocketIO : IDisposable
    {
        private static readonly UnityEngine.Logger Logger = new UnityEngine.Logger(new CustomLogHandler());

        // TODO: make this an extension
        private static bool IsSecureURI(Uri uri)
        {
            return uri.Scheme.Equals("https", StringComparison.InvariantCultureIgnoreCase)
                || uri.Scheme.Equals("wss", StringComparison.InvariantCultureIgnoreCase);
        }

        private readonly ClientWebSocket _webSocket;

        public bool IsConnected => WebSocketState.Open == (_webSocket?.State ?? WebSocketState.Closed);

        private readonly Encoder _encoder = new Encoder();
        private readonly Decoder _decoder = new Decoder();

        public SocketIO()
        {
            _webSocket = new ClientWebSocket();
        }

        ~SocketIO()
        {
            Dispose(false);
        }

#region IDisposable
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if(disposing) {
                _webSocket.Dispose();
            }
        }
#endregion

        public async Task<bool> ConnectAsync(string url)
        {
            if(IsConnected) {
                // TODO: what if it's a different URL?
                return true;
            }

            Logger.Log($"Connecting web socket at {url}...");

            Uri uri = new Uri(url);
            if(IsSecureURI(uri)) {
                ServicePointManager.ServerCertificateValidationCallback = (o, certificate, chain, errors) => true;
            }

            try {
                await _webSocket.ConnectAsync(uri, CancellationToken.None).ConfigureAwait(false);
            } catch(Exception ex) {
                Logger.LogError($"Connection exception: {ex.InnerException?.Message ?? ex.Message}");
                Logger.Log(ex.InnerException?.StackTrace ?? ex.StackTrace);
                return false;
            }

            return WebSocketState.Open == _webSocket.State;
        }
    }
}
