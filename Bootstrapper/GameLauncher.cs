using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Bootstrapper
{
    class Config
    {
        public int ServerStartupTime;
        public int ClientStartupTime;
        public string[] Maps;
        public string[] GameModes;
    }

    class GameLauncher
    {
        static string ServerExe = "FoxGame-win32-Shipping-Server.exe";
        static string ClientExe = "FoxGame-win32-Shipping.exe";
        static string Injector = "Injector.exe";

        private static Config _Config = null;

        public static Config GetConfig()
        {
            if(_Config == null)
                _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("LauncherConfig.json"));

            return _Config;
        }

        protected static Process LaunchProcess(string FileName, string Args, string WorkDir = "")
        {
            if (WorkDir == "")
                WorkDir = Directory.GetCurrentDirectory();

            Process process = new Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.WorkingDirectory = WorkDir;
            process.StartInfo.Arguments = Args;

            process.Start();
            return process;
        }

        public static void LaunchServer(string Options)
        {
            LaunchProcess(ServerExe, "server " + Options);
        }

        public static void LaunchClient(string IP, string Options)
        {
            LaunchProcess(ClientExe, IP + Options);
        }

        public static void LaunchInjector()
        {
            LaunchProcess(Injector, ClientExe + " Proxy.dll");
        }

        public static void LaunchBotgame(string Map, string GameMode, Action LaunchFinishedAction)
        {
            string serverArgs = Map + "?Game=FoxGame.FoxGameMP_" + GameMode + "?SingleMatch?NumBots=10";
            LaunchServer(serverArgs);

            Thread.Sleep(GetConfig().ServerStartupTime);

            LaunchClient("127.0.0.1", "?Name=Player");

            Thread.Sleep(GetConfig().ClientStartupTime);

            LaunchInjector();
            LaunchFinishedAction.Invoke();
        }
    }
}
