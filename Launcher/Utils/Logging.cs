using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Serilog;
using Launcher.Configuration;

namespace Launcher.Utils
{
    /// <summary>
    /// Logic for logging. Don't try to use this class directly, instead use the static instance of Serilog (just Log)
    /// </summary>
    class Logging
    {
        /// <summary>
        /// relative path to log directory
        /// </summary>
        static string LogDirectory = "Logs";

        /// <summary>
        /// absolute path to log directory
        /// </summary>
        static string LogFileDirectoryAbs = Path.Join(Directory.GetCurrentDirectory(), LogDirectory); 

        /// <summary>
        /// log file name
        /// </summary>
        static string LogFileName = Path.Join(LogFileDirectoryAbs, "BLReviveLauncher.log"); 

        public static bool IsInitialized = false;

        /// <summary>
        /// Setup Serilog.
        /// </summary>
        public static void Initialize(bool logToConsole = false)
        {
            LoggerConfiguration loggerConfig = new LoggerConfiguration();

            if(logToConsole)
            {
                loggerConfig.WriteTo.Console();
            }
            else if (!Directory.Exists(LogFileDirectoryAbs))
            {
                Directory.CreateDirectory(LogFileDirectoryAbs);
                loggerConfig.WriteTo.File(LogFileName, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true);
            }

            int LogLevel = Config.App == null ? 0 : Config.App.LogLevel;
            switch (Config.App.LogLevel)
            {
                // verbose
                case 0:
                    loggerConfig.MinimumLevel.Verbose();
                    break;
                case 1:
                    loggerConfig.MinimumLevel.Debug();
                    break;
                case 2:
                    loggerConfig.MinimumLevel.Warning();
                    break;
                case 3:
                    loggerConfig.MinimumLevel.Error();
                    break;
                case 4:
                    loggerConfig.MinimumLevel.Fatal();
                    break;
            }

            Log.Logger = loggerConfig.CreateLogger();

            IsInitialized = true;
        }
    }
}
