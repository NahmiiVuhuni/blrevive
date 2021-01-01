using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Serilog;

namespace Bootstrapper
{
    /// <summary>
    /// Provides functionality for starting Server and Client.
    /// </summary>
    class GameLauncher
    {
        /// <summary>
        /// name of untouched game file without extension
        /// </summary>
        public static string GameFile = "FoxGame-win32-Shipping";

        /// <summary>
        /// name of untouched game file with extension
        /// </summary>
        public static string GameExe = $"{GameFile}.exe";

        /// <summary>
        /// name of patched game file
        /// </summary>
        public static string PatchedGameExe = $"{GameFile}-Patched.exe";

        /// <summary>
        /// name of server copy of patched game file
        /// </summary>
        public static string ServerExe = $"{GameFile}-Patched-Server.exe";

        /// <summary>
        /// Starts a process with the given attributes.
        /// </summary>
        /// <param name="FileName">application file to execute</param>
        /// <param name="Args">cli arguments</param>
        /// <param name="ShowWindow">show the window for the process ?</param>
        /// <param name="WorkDir">workdir of process (defaults to current workdir)</param>
        /// <returns>process handle</returns>
        protected static Process LaunchProcess(string FileName, string Args, bool ShowWindow = true, string WorkDir = "")
        {
            Log.Debug("Launching process {0} \"{1}\"", FileName, Args);

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

        /// <summary>
        /// Start server process with custom options.
        /// </summary>
        /// <param name="Options">URL for server</param>
        /// <returns>server process handle</returns>
        public static Process LaunchServer(string Options)
        {
            Log.Information("Launching Server");
            Log.Debug("Options: {0}", Options);

            Process serverProcess = LaunchProcess(ServerExe, $"server {Options}");

            if (serverProcess == null)
                return null;

            Log.Information("Server succesfully started and patched!");
            return serverProcess;
        }

        /// <summary>
        /// Start server process with given attributes.
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="GameMode"></param>
        /// <param name="BotCount"></param>
        /// <param name="MaxPlayers"></param>
        /// <param name="additionalArgs"></param>
        /// <returns>server process handle</returns>
        public static Process LaunchServer(string Map, string GameMode, int BotCount, int MaxPlayers, string additionalArgs)
        {
            string args = $"{Map}?Game=FoxGame.FoxGameMP_{GameMode}?NumBots={BotCount}?MaxPlayers={MaxPlayers}{additionalArgs}";
            return LaunchServer(args);
        }

        /// <summary>
        /// Start client process with given attributes.
        /// </summary>
        /// <param name="IP">server ip to connect to</param>
        /// <param name="Options">client URL</param>
        /// <returns></returns>
        public static Process LaunchClient(string IP, string Options)
        {
            Log.Information("Launching Client");
            Log.Debug("IP: {0} | Options: {1}", IP, Options);

            Process clientProcess = LaunchProcess(PatchedGameExe, $"{IP}{Options}");

            if(clientProcess == null)
            {
                Log.Error("Failed to launch client!");
                Log.Debug("CLI: {0} {1}{2}", PatchedGameExe, IP, Options);
                return null;
            }

            Log.Information("Client successfully started and patched!");
            return clientProcess;
        }

        /// <summary>
        /// Start server & client process for a local botgame.
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="GameMode"></param>
        /// <param name="BotCount"></param>
        /// <param name="LaunchFinishedAction"></param>
        public static void LaunchBotgame(string Map, string GameMode, int BotCount, Action LaunchFinishedAction)
        {
            Log.Information("Preparing local botgame.");
            Log.Debug("Map: {0} | GameMode: {1}", Map, GameMode);
            string serverArgs = $"{Map}?Game=FoxGame.FoxGameMP_{GameMode}?SingleMatch?NumBots={BotCount}";
            string clientArgs = $"?Name={Config.Get().Username}";
            Log.Debug("Server Args: {0} | Client Args: {1}", serverArgs, clientArgs);


            if (LaunchServer(serverArgs) == null)
            {
                Log.Error("Failed to start server!");
                Environment.Exit(1);
            }

            Log.Information("Started game server.");
            Log.Debug("Waiting {0} seconds for server to start", Config.Get().ServerStartupOffset);
            Thread.Sleep(Config.Get().ServerStartupOffset);


            if (LaunchClient(NetworkUtil.GetDefaultHost(), clientArgs) == null)
            {
                Log.Error("Failed to start client!");
            }

            Log.Information("Botgame has started!");

            LaunchFinishedAction.Invoke();
        }

        /// <summary>
        /// Make sure everything is setup properly before starting GUI.
        /// </summary>
        public static void Prepare()
        {
            Log.Verbose("Preparing GameLauncher");

            if (!Patcher.IsPatched)
                Patcher.PatchFiles();
        }
    }
}
