using UnityEngine;

namespace EnergonSoftware.Netrunner.Core.Logging
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this Logger logger, string message)
        {
            logger.Log(LogType.Log, message);
        }

        public static void LogWarning(this Logger logger, string message)
        {
            logger.Log(LogType.Warning, message);
        }

        public static void LogError(this Logger logger, string message)
        {
            logger.Log(LogType.Error, message);
        }
    }
}
