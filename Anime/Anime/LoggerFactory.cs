using MetroLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anime
{
    public static class LoggerFactory
    {
        private static ILogManager logManager;

        public static void Inititalize(LoggingConfiguration configuration)
        {
            logManager = LogManagerFactory.CreateLogManager(configuration);
        }

        public static ILogger GetLogger(string loggerName)
        {
            if(logManager == null) {
                throw new InvalidOperationException("LogFactory must be Initialized before creating any logger");
            }

            return logManager.GetLogger(loggerName);
        }

    }
}
