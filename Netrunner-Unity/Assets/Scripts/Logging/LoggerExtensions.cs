using UnityEngine;

namespace EnergonSoftware.Netrunner.Logging
{
    public static class LoggerExtensions
    {
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
