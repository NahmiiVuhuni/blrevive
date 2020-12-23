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
    class Config
    {
        public string[] Maps;
        public string[] GameModes;
    }

    class GameLauncher
    {
        static string GameFile = "FoxGame-win32-Shipping";
        static string GameExe = $"{GameFile}.exe";
        static string ServerExe = $"{GameFile}-Server.exe";
        static string Injector = "Injector.exe";

        private static Config _Config = null;

        public static Config GetConfig()
        {
            if(_Config == null)
                _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("LauncherConfig.json"));

            return _Config;
        }

        protected static Process LaunchProcess(string FileName, string Args, bool ShowWindow = true, string WorkDir = "")
        {
            if (WorkDir == "")
                WorkDir = Directory.GetCurrentDirectory();

            Process process = new Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.WorkingDirectory = WorkDir;
            process.StartInfo.Arguments = Args;
            process.StartInfo.CreateNoWindow = !ShowWindow;

            process.Start();
            return process;
        }

        public static Process LaunchServer(string Options)
        {
            Log.Debug("Launching Server with options: " + Options);
            Process serverProcess = LaunchProcess(ServerExe, $"server {Options}");
            if (!WaitForClientStartupComplete(serverProcess, "POP"))
                return null;
            LaunchInjector(serverProcess);
            return serverProcess;
        }

        public static Process LaunchServer(string Map, string GameMode, int BotCount, string additionalArgs)
        {
            string args = $"{Map}?Game=FoxGame.FoxGameMP_{GameMode}?NumBots={BotCount}{additionalArgs}";
            return LaunchServer(args);
        }

        public static Process LaunchClient(string IP, string Options)
        {
            Log.Debug("Launching Client with: IP={0}; Options={1}", IP, Options);
            Process clientProcess = LaunchProcess(GameExe, $"{IP}{Options}");
            if (!WaitForClientStartupComplete(clientProcess, "Blacklight: Retribution"))
                return null;
            Thread.Sleep(2000);
            LaunchInjector(clientProcess);
            return clientProcess;
        }

        public static Process LaunchInjector(Process target)
        {
            Log.Debug("Launching Injector for {0}", target.ProcessName);
            return LaunchProcess(Injector, $"{target.Id} Proxy.dll", false);
        }

        public static void LaunchBotgame(string Map, string GameMode, Action LaunchFinishedAction)
        {
            string serverArgs = $"{Map}?Game=FoxGame.FoxGameMP_{GameMode}?SingleMatch?NumBots=10";

            LaunchServer(serverArgs);
            LaunchClient("127.0.0.1", "?Name=Player");

            LaunchFinishedAction.Invoke();
        }

        private static bool WaitForClientStartupComplete(Process process, string title, int durationTimeout = 20000)
        {
            int duration = 0;

            while (true)
            {
                duration += 100;
                process.Refresh();

                if(process.HasExited)
                {
                    Log.Error("Process has exited unexpected!");
                    return false;
                }
                if(duration == durationTimeout)
                {
                    Log.Error("Timeout exceeded while waiting for client startup");
                    return false;
                }
                if (process.MainWindowTitle.Contains(title))
                {
                    Log.Debug("Took {0}ms to startup!", duration);
                    return true;
                }

                Log.Verbose("({0}ms) MainWindowTitle: {1} | ModuleCount {2}", duration, process.MainWindowTitle, process.Modules.Count);
                Thread.Sleep(100);
            }
        }


        public static void Prepare()
        {
            string currDir = Directory.GetCurrentDirectory();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File($"{currDir}\\..\\..\\FoxGame\\Logs\\BLReviveLauncher.log",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();

            Log.Information("Preparing GameLauncher..");

            if (!File.Exists(GameExe))
            {
                MessageBox.Show("FoxGame-win32-Shipping.exe is missing! Make sure you extracted all files in the correct directory!");
                Log.Fatal("FoxGame-win32-Shipping.exe is missing!");
                Environment.Exit(1);
            }

            if(!File.Exists(ServerExe))
            {
                File.Copy(GameExe, ServerExe);
            }

        }
    }
}
