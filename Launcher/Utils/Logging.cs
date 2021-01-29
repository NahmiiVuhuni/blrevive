using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Serilog;
using Configuration;

namespace Utils
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

        /// <summary>
        /// Setup Serilog.
        /// </summary>
        /// <returns>wether setup succeeded</returns>
        public static bool Initialize(bool logToConsole = false)
        {
            LoggerConfiguration loggerConfig = new LoggerConfiguration();

            if(logToConsole)
            {
                loggerConfig.WriteTo.Console();
            }
            else if (!Directory.Exists(LogFileDirectoryAbs))
            {
                try
                {
                    Directory.CreateDirectory(LogFileDirectoryAbs);
                } catch (Exception ex)
                {
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", $"Logfile directory ({LogFileDirectoryAbs}) doesn't exist and failed to create!")
                    .Show();

                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", ex.Message)
                    .Show();

                    Environment.Exit(2121800003);
                }
                loggerConfig.WriteTo.File(LogFileName, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Error", "Failed to initialize logging system. Log file directory may not be writable.")
                .Show();

                MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Error", ex.Message)
                .Show();

                Environment.Exit(2121800004);
            }

            return true;
        }
    }
}
