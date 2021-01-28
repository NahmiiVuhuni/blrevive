using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Serilog;
using System.IO.Ports;
using System.Collections.Generic;
using Configuration;
using Utils;

namespace Utils
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

        public static string BinaryFolder = Path.Join(Config.App.GameFolder, "Binaries", "Win32");

        /// <summary>
        /// Starts a process with the given attributes.
        /// </summary>
        /// <param name="FileName">application file to execute</param>
        /// <param name="Args">cli arguments</param>
        /// <param name="ShowWindow">show the window for the process ?</param>
        /// <param name="WorkDir">workdir of process (defaults to current workdir)</param>
        /// <returns>process handle</returns>
        protected static Process LaunchProcess(string FileName, string Args, bool ShowWindow = true, string WorkDir = "", bool IsNative = true)
        {
            Log.Debug("Launching process {0} \"{1}\"", FileName, Args);

            try
            {
                if (WorkDir == "")
                    WorkDir = Directory.GetCurrentDirectory();

                Process process = new Process();
#if LINUX
                process.StartInfo.FileName = "wine";
                process.StartInfo.Arguments =  $"\"{FileName}\" {Args}";
#elif WINDOWS
                process.StartInfo.FileName = FileName;
                process.StartInfo.Arguments = Args;
#endif
                process.StartInfo.WorkingDirectory = WorkDir;
                process.StartInfo.CreateNoWindow = !ShowWindow;
                process.StartInfo.UseShellExecute = false;

                process.Start();

                if (process.HasExited)
                {
                    Log.Error("Failed to launch process!");
                    Log.Debug("CLI: {0} {1} | WD: {2}", process.StartInfo.FileName, process.StartInfo.Arguments, WorkDir);
                    return null;
                }

                return process;
            }
            catch(Exception ex)
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
            
            string args = $"server {Options}";
            Process serverProcess = LaunchProcess(PatchedGameExe, args, true, BinaryFolder);

            if (serverProcess == null)
                return null;

            Log.Information("Server succesfully started and patched!");
            return serverProcess;
        }

        /// <summary>
        /// Start server process with given attributes.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Map"></param>
        /// <param name="Gamemode"></param>
        /// <param name="Port"></param>
        /// <param name="BotCount"></param>
        /// <param name="MaxPlayers"></param>
        /// <param name="additionalArgs"></param>
        /// <returns>server process handle</returns>
        public static Process LaunchServer(string Map, string Gamemode, string Name, int Port, int BotCount, int MaxPlayers, string Playlist, string additionalArgs)
        {
            const string quote = "\"";
            string args = $"{Map}?Game=FoxGame.FoxGameMP_{Gamemode}?ServerName={quote}{Name}{quote}?Port={Port}?NumBots={BotCount}?MaxPlayers={MaxPlayers}?Playlist={Playlist}{additionalArgs}";
            return LaunchServer(args);
        }

        /// <summary>
        /// Start client process with given attributes.
        /// </summary>
        /// <param name="IP">Server IP to connect to.</param>
        /// <param name="Port">Port of the server.</param>
        /// <param name="Options">Client URL.</param>
        /// <returns></returns>
        public static Process LaunchClient(string IP, string Port, string Options)
        {
            Log.Information("Launching Client");
            Log.Debug("IP: {0} | Options: {1}", IP, Port, Options);

            string args = $"{IP}:{Port}{Options}";

            Process clientProcess = LaunchProcess(PatchedGameExe, args,true, BinaryFolder);

            if(clientProcess == null)
            {
                Log.Error("Failed to launch client!");
                Log.Debug("CLI: {0} {1}{2}", PatchedGameExe, IP, Port, Options);
                return null;
            }

            Log.Information("Client successfully started!");
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
            string clientArgs = $"?Name={Config.User.Username}";
            Log.Debug("Server Args: {0} | Client Args: {1}", serverArgs, clientArgs);


            if (LaunchServer(serverArgs) == null)
            {
                Log.Error("Failed to start server!");
                Environment.Exit(2121800002);
            }

            Log.Information("Started game server.");
            Thread.Sleep(2000);


            if (LaunchClient(NetworkUtil.GetDefaultHostServer().Address, $"{Config.Defaults.LocalHostServer.Port}", clientArgs) == null)
            {
                Log.Error("Failed to start client!");
            }

            Log.Information("Botgame has started!");

            LaunchFinishedAction.Invoke();
        }

        public static bool LaunchPatcher(string GameInputFile, string GameOutputFile, bool AslrOnly = false, bool NoEmblemPatch = false, bool NoProxyInjection = false)
        {
            Log.Information("Starting patcher.");
            Log.Debug("GameFile: {0} | AslrOnly: {1} | NoEmblemPatch: {2} | NoProxyInjection: {3}", GameInputFile, AslrOnly, NoEmblemPatch, NoProxyInjection);

            string args = $"\"{GameInputFile}\" --output=\"{GameOutputFile}\"";
            if (AslrOnly)
                args += " --aslr-only";
            if (NoEmblemPatch)
                args += " --no-emblem-patch";
            if (NoProxyInjection)
                args += " --no-proxy";

            Log.Debug("Args: {0}", args);

            Process patcherProcess = null;
            
#if WINDOWS
            patcherProcess = LaunchProcess("Patcher.exe", args, false, "", false);
#elif LINUX
            patcherProcess = LaunchProcess("Patcher", args, false, "", false);
#endif
            if(patcherProcess != null)
            {
                string patcherProcessOutput = "";
                patcherProcess.OutputDataReceived += (object sender, DataReceivedEventArgs e) => { patcherProcessOutput += e.Data; };

                patcherProcess.WaitForExit();
                if(patcherProcess.ExitCode != 0)
                {
                    Log.Error("Patcher failed!");
                    Log.Debug(patcherProcessOutput);
                    return false;
                }
            }
            else
            {
                return false;
            }

            Log.Information("Patching was succesfull!");
            return true;
        }

        public static string GetDefaultGamePath()
        {
            Func<string, bool> isGameFolder = (string path) => { return Directory.Exists(path) && IsValidGameDirectory(path); };

            string BinarySubDir = Path.Join("Binaries", "Win32");

            if (Directory.GetCurrentDirectory().IndexOf(BinarySubDir) != -1)
                return Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf(BinarySubDir));

            string DefaultSteamGamePath = Path.Join("Program Files (x86)", "Steam", "steamapps", "common", "blacklightretribution");
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach(DriveInfo drive in drives)
            {
                try {
                    if(!drive.IsReady)
                        continue;
                    if (isGameFolder(Path.Join(drive.Name, DefaultSteamGamePath)))
                        return Path.Join(drive.Name, DefaultSteamGamePath);
                } catch {
                    continue;
                }
            }

            return "";
        }

        public static bool IsValidGameDirectory(string path)
        {
            return Directory.Exists(Path.Join(path, "Binaries", "Win32")) ?
                    Directory.Exists(Path.Join(path, "FoxGame", "Logs")) ? true : false : false;
        }
    }
}
