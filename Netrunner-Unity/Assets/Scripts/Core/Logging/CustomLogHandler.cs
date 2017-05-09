using System;
using System.Text;
using System.Threading;

using UnityEngine;

namespace EnergonSoftware.Netrunner.Core.Logging
{
    public sealed class CustomLogHandler : ILogHandler
    {
// TODO: this should take the type of the logger in order to tag the log

        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            StringBuilder newLogFormat = new StringBuilder();

            newLogFormat.Append($"[{Thread.CurrentThread.ManagedThreadId}");
            if(GameManager.HasInstance && Thread.CurrentThread.ManagedThreadId == GameManager.Instance.MainThreadId) {
                newLogFormat.Append($":{Time.frameCount}");
            }
            newLogFormat.Append("]");

            newLogFormat.Append(": ");
            newLogFormat.Append(format);

            Debug.unityLogger.logHandler.LogFormat(logType, context, newLogFormat.ToString(), args);
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            Debug.unityLogger.LogException(exception, context);
        }
    }
}
