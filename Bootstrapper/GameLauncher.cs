using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Serilog;

namespace Bootstrapper
{

    enum InjectorExitCodes
    {
        EXIT_MEMORY_WRITE_FAILED        = 1000,
        EXIT_MEMORY_ALLOCATION_FAILED	= 1001,
        EXIT_REMOTE_THREAD_FAILED		= 1002,
        EXIT_CREATE_LOG_FAILED			= 1003,
        EXIT_ARGS_MISSING				= 1004,
        EXIT_DLL_NOT_FOUND				= 1005,
        EXIT_PROCESS_NOT_FOUND			= 1006
    }


    class Config
    {
        public int LogLevel;
        public int ClientStartupOffset;
        public int ServerStartupOffset;
        public string[] Maps;
        public string[] GameModes;
    }

    class GameLauncher
    {
        static string GameFile = "FoxGame-win32-Shipping";
        static string GameExe = $"{GameFile}.exe";
        static string ServerExe = $"{GameFile}-Server.exe";
        static string Injector = "Injector.exe";
        static string LogDirectory = "\\..\\..\\FoxGame\\Logs\\";
        static string LogFileDirectoryAbs = $"{Directory.GetCurrentDirectory()}{LogDirectory}";
        static string LogFileName = $"{LogFileDirectoryAbs}BLReviveLauncher.log";
        static string[] ConfigFiles = { "LauncherConfig.json", "BLRevive.json" };
        static string LauncherConfigFile = $"{Directory.GetCurrentDirectory()}\\LauncherConfig.json";

        private static Config _Config = null;

        public static Config GetConfig()
        {
            try
            {
                if (_Config == null)
                    _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("LauncherConfig.json"));
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to parse LauncherConfig.json!");
                //Log.Debug(ex.Message);
                Environment.Exit(1);
            }
            

            return _Config;
        }

        protected static Process LaunchProcess(string FileName, string Args, bool ShowWindow = true, string WorkDir = "")
        {
            Log.Debug("Launchung process {0} \"{1}\"", FileName, Args);

            try
            {
                if (WorkDir == "")
                    WorkDir = Directory.GetCurrentDirectory();

                Process process = new Process();
                process.StartInfo.FileName = FileName;
                process.StartInfo.WorkingDirectory = WorkDir;
                process.StartInfo.Arguments = Args;
                process.StartInfo.CreateNoWindow = !ShowWindow;
                process.StartInfo.UseShellExecute = false;

                process.Start();

                if (process == null || process.StartTime == null)
                {
                    Log.Error("Failed to launch process!");
                    Log.Debug("CLI: {0} {1} | WD: {2}", FileName, Args, WorkDir);
                    return null;
                }

                return process;
            } catch(Exception ex)
            {
                Log.Error("Exception on creating process!");
                Log.Debug("CLI: {0} {1} | WD: {2}", FileName, Args, WorkDir);
                Log.Debug(ex.Message);
                return null;
            }
        }

        public static Process LaunchServer(string Options)
        {
            Log.Information("Launching Server");
            Log.Debug("Options: {0}", Options);

            Process serverProcess = LaunchProcess(ServerExe, $"server {Options}");

            if (serverProcess == null)
                return null;

            if (!WaitForClientStartupComplete(serverProcess, "POP"))
            {
                Log.Error("Server didn't startup in time!");

                if (!serverProcess.HasExited)
                    serverProcess.Kill();

                Log.Debug("Timeout: {0} | PID: {1} | ExitCode: {2}", 20000, serverProcess.Id, serverProcess.ExitCode);

                return null;
            }

            Thread.Sleep(GetConfig().ServerStartupOffset);

            if(LaunchInjector(serverProcess) == null)
            {
                Log.Error("Starting the Injector failed!");

                if (!serverProcess.HasExited)
                    serverProcess.Kill();

                return null;
            }

            Log.Information("Server succesfully started and patched!");
            return serverProcess;
        }

        public static Process LaunchServer(string Map, string GameMode, int BotCount, string additionalArgs)
        {
            string args = $"{Map}?Game=FoxGame.FoxGameMP_{GameMode}?NumBots={BotCount}{additionalArgs}";
            return LaunchServer(args);
        }

        public static Process LaunchClient(string IP, string Options)
        {
            Log.Information("Launching Client");
            Log.Debug("IP: {0} | Options: {1}", IP, Options);

            Process clientProcess = LaunchProcess(GameExe, $"{IP}{Options}");

            if(clientProcess == null)
            {
                Log.Error("Failed to launch client!");
                Log.Debug("CLI: {0} {1}{2}", GameExe, IP, Options);
                return null;
            }

            if (!WaitForClientStartupComplete(clientProcess, "Blacklight: Retribution"))
            {
                Log.Error("Client didn't startup in time!");

                if (!clientProcess.HasExited)
                    clientProcess.Kill();

                Log.Debug("Timeout: {0} | PID: {1} | ExitCode: {2}", 20000, clientProcess.Id, clientProcess.ExitCode);


                return null;
            }

            Thread.Sleep(GetConfig().ClientStartupOffset);

            if(LaunchInjector(clientProcess) == null)
            {
                Log.Error("Failed to launch Injector!");
                return null;
            }

            Log.Information("Client sucessfully started and patched!");
            return clientProcess;
        }

        public static Process LaunchInjector(Process target, bool bKillTargetOnError = true)
        {
            Log.Information("Launching Injector.");
            Log.Verbose("Process: {0} | PID: {1}", target.ProcessName, target.Id);

            try
            {
                Process injectorProcess = LaunchProcess(Injector, $"{target.Id} Proxy.dll", false);
                if (injectorProcess == null)
                {
                    Log.Error("Failed to launch the injector.");
                    if (!target.HasExited && bKillTargetOnError)
                    {
                        Log.Verbose("Killing target process {0} ({1}))", target.ProcessName, target.Id);
                        target.Kill();
                    }
                }

                injectorProcess.WaitForExit();

                if (injectorProcess.ExitCode != 0)
                {
                    Log.Error("Injection failed. See Injector.log. ExitCode: {0}", injectorProcess.ExitCode);
                }

                Log.Information("Injection succeeded.");

                return injectorProcess;
            } catch (Exception ex)
            {
                Log.Error("Failed to setup Injector.");
                Log.Debug(ex.Message);
                return null;
            }
        }

        public static void LaunchBotgame(string Map, string GameMode, Action LaunchFinishedAction)
        {
            Log.Information("Preparing local botgame.");
            Log.Debug("Map: {0} | GameMode: {1}", Map, GameMode);
            string serverArgs = $"{Map}?Game=FoxGame.FoxGameMP_{GameMode}?SingleMatch?NumBots=10";
            string clientArgs = "?Name=Player";
            Log.Debug("Server Args: {0} | Client Args: {1}", serverArgs, clientArgs);

            if (LaunchServer(serverArgs) != null && LaunchClient("127.0.0.1", clientArgs) != null)
                Log.Information("Botgame has started!");
            else
                Log.Error("Failed to launch local botgame!");

            LaunchFinishedAction.Invoke();
        }

        private static bool WaitForClientStartupComplete(Process process, string title, int durationTimeout = 20000)
        {
            Log.Information("Start waiting for UE engine to initialize.");
            Log.Debug("Proces: {0} | PID: {1} | Timeout: {2}", process.ProcessName, process.Id, durationTimeout);


            try
            {
                int duration = 0;
                while (true)
                {
                    process.Refresh();

                    if (process.HasExited)
                    {
                        Log.Error("Process has exited unexpected!");
                        return false;
                    }

                    if (duration >= durationTimeout)
                    {
                        Log.Error("Timeout exceeded while waiting for client startup");
                        return false;
                    }

                    if(process.Modules.Count >= 100)
                    {
                        Log.Information("Unreal Engine is initialized");
                        Log.Debug("Took {0}ms to startup!", duration);
                        return true;
                    }

                    Log.Verbose("({0}ms) MainWindowTitle: {1} | ModuleCount {2}", duration, process.MainWindowTitle, process.Modules.Count);

                    duration += 100;
                    Thread.Sleep(100);
                }
            } catch(Exception ex) 
            {
                Log.Error("Exception occured when waiting for UE to initialize!");
                Log.Debug(ex.Message);
                return false;
            }
        }

        protected static bool CheckLogDirectory()
        {
            if(!Directory.Exists(LogFileDirectoryAbs))
            {
                MessageBox.Show($"Logfile directory ({LogFileDirectoryAbs}) doesn't exist!");
                Environment.Exit(1);
            }

            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(LogFileDirectoryAbs);
            } catch(Exception ex)
            {
                MessageBox.Show($"Logfile directory is not writable!");
                Environment.Exit(1);
            }

            return true;
        }

        protected static bool CheckConfigs()
        {
            foreach(string configFile in ConfigFiles)
            {
                if (!File.Exists($"{Directory.GetCurrentDirectory()}\\{configFile}"))
                {
                    MessageBox.Show($"Config file {configFile} not found in {Directory.GetCurrentDirectory()}!");
                    Environment.Exit(1);
                }
            }

            return true;
        }

        public static bool InitializeLogger()
        {
            try
            {
                LoggerConfiguration loggerConfig = new LoggerConfiguration();
                loggerConfig.WriteTo.File(LogFileName, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true);

                switch(GetConfig().LogLevel)
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
            } catch(Exception ex)
            {
                MessageBox.Show("Failed to initialize logging system!");
                Environment.Exit(1);
            }


            return true;
        }

        protected static bool CheckGameFiles()
        {
            try
            { 
                if (!File.Exists(GameExe))
                {
                    MessageBox.Show("FoxGame-win32-Shipping.exe is missing! Make sure you extracted all files in the correct directory!");
                    Log.Fatal("FoxGame-win32-Shipping.exe is missing!");
                    Environment.Exit(1);
                }

                if (!File.Exists(ServerExe))
                {
                    File.Copy(GameExe, ServerExe);
                }

                return true;
            } catch (Exception ex)
            {
                Log.Fatal("Error while cheking game files!");
                Log.Debug(ex.Message);
                return false;
            }
        }

        public static void Prepare()
        {
            if (!CheckConfigs())
                Environment.Exit(1);

            GetConfig();

            if (!CheckLogDirectory())
                Environment.Exit(1);

            if (!InitializeLogger())
                Environment.Exit(1);

            InitializeLogger();
            Log.Information("Starting GameLauncher");

            if (!CheckGameFiles())
                Environment.Exit(0);
        }
    }
}
