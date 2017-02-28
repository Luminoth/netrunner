using System;
using System.Text;
using System.Threading;

using UnityEngine;

namespace EnergonSoftware.Netrunner.Logging
{
    public sealed class CustomLogHandler : ILogHandler
    {
// TODO: this should take the type of the logger in order to tag the log

        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            StringBuilder newLogFormat = new StringBuilder();

            newLogFormat.Append("[");
            if(AsyncTools.IsMainThread()) {
                string contextName = (SynchronizationContext.Current as UnitySynchronizationContext)?.Name ?? "-";
                newLogFormat.Append($"{contextName}:{Time.frameCount}");
            } else {
                newLogFormat.Append($"{Thread.CurrentThread.ManagedThreadId}");
            }
            newLogFormat.Append("]");

            newLogFormat.Append(": ");
            newLogFormat.Append(format);

            Debug.logger.logHandler.LogFormat(logType, context, newLogFormat.ToString(), args);
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            Debug.logger.LogException(exception, context);
        }
    }
}
