using System.IO;
using Launcher.Configuration;
using System;
using System.Diagnostics;
using Serilog;

namespace Launcher.Utils
{
    /// <summary>
    /// Manager class for game instances.
    /// </summary>
    public static class GameInstanceManager
    {
        #region Game instance options
        public abstract class GenericGameOptions
        {
            public string Filename = "FoxGame-win32-Shipping-Patched.exe";
            public string BinaryPath = Path.Join(Config.App.GameFolder, "Binaries", "Win32");
            public string CustomParams { get; set; }
        }

        /// <summary>
        /// Options for launching client.
        /// </summary>
        public class ClientStartOptions : GenericGameOptions
        {
            public string IP = "127.0.0.1";
            public int Port = 7777;
            public string Playername = "Player";
        }

        /// <summary>
        /// Options for launching server.
        /// </summary>
        public class ServerStartOptions : GenericGameOptions
        {
            public string Servername { get; set; }

            public string Map = "HeloDeck";
            public string Gamemode = "DM";
            public string Playlist = "";
            public int Port = 7777;
            public int BotCount = 0;
            public int MaxPlayers = 16;
        }
        #endregion

        /// <summary>
        /// Start client instance.
        /// </summary>
        /// <param name="options">client options</param>
        public static void StartClient(ClientStartOptions options)
        {
            if(!UserUtil.IsValidPlayerName(options.Playername))
                throw new UserInputException("Failed to start client: playername is invalid!");

            string resolvedIP = NetworkUtil.GetHostIp(options.IP);
            if(!NetworkUtil.IsValidIPv4(resolvedIP))
                throw new UserInputException("Failed to start client: ip adress is invalid!");

            string parms = $"?Name=\"{options.Playername}\"";
            string URL = $"{resolvedIP}:{options.Port}{parms}?{options.CustomParams}";

            StartGame(options.Filename, URL, options.BinaryPath);
        }

        /// <summary>
        /// Start client instance.
        /// </summary>
        /// <param name="ConfigureOptions">configuration lambda</param>
        public static void StartClient(Action<ClientStartOptions> ConfigureOptions)
        {
            ClientStartOptions opts = new ClientStartOptions();
            ConfigureOptions(opts);
            StartClient(opts);
        }

        /// <summary>
        /// Start server instance.
        /// </summary>
        /// <param name="options">server options</param>
        public static void StartServer(ServerStartOptions options)
        {
            string url = $"server?Map={options.Map}?Name=\"{options.Servername}\"?Game=FoxGame.FoxGameMP_{options.Gamemode}?Port={options.Port}" +
                $"?BotCount={options.BotCount}?MaxPlayers={options.MaxPlayers}?Playlist={options.Playlist}";
            StartGame(options.Filename, url, options.BinaryPath);
        }

        /// <summary>
        /// Start server instance.
        /// </summary>
        /// <param name="ConfigureOptions">configuration lambda</param>
        public static void StartServer(Action<ServerStartOptions> ConfigureOptions)
        {
            ServerStartOptions opts = new ServerStartOptions();
            ConfigureOptions(opts);
            StartServer(opts);
        }

        /// <summary>
        /// Start a game instance with given parameters.
        /// </summary>
        /// <param name="filename">BLR app</param>
        /// <param name="args">parameters</param>
        /// <param name="workdir">path to BLR</param>
        private static void StartGame(string filename, string args, string workdir)
        {
            if(!Directory.Exists(workdir))
                throw new UserInputException("Starting game failed: directory does not exist!");
            
            if(!File.Exists(Path.Join(workdir, filename)))
                throw new UserInputException("Starting game failed: file does not exist!");
            
            ProcessStartInfo si = new ProcessStartInfo() {
                WorkingDirectory = workdir,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            #if LINUX
            si.FileName = "wine";
            si.Arguments = $"\"{filename}\" {args}";
            #else
            si.FileName = filename;
            si.Arguments = args;
            #endif

            try 
            {
                Log.Debug($"Starting game ({Path.Join(workdir, filename)} {args})");
                Process gameProcess = new Process();
                gameProcess.StartInfo = si;
                gameProcess.Start();
            } catch(Exception ex) {
                throw new UserInputException("Failed to launch game process.", ex);
            }
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