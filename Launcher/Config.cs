using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace BLRevive.Launcher
{
    /// <summary>
    /// Provides read/write access to JSON configuration.
    /// </summary>
    public class Config
    {
        
        public const string DefaultPlayerName = "Player";
        
        private const string DefaultLocalHostIP = "127.0.0.1";
        private const string DefaultLocalHostPort = "7777";
        public static Server DefaultLocalHostServer = new Server()
        {
            Address = DefaultLocalHostIP, 
            Port = DefaultLocalHostPort
        };

        public const int MaxClientHostListSize = 50;

        /// <summary>
        /// The log level to use
        /// </summary>
        public int LogLevel;

        /// <summary>
        /// Delay between server and client startup.
        /// </summary>
        public int ServerStartupOffset;

        /// <summary>
        /// Saved username
        /// </summary>
        public string Username;

        /// <summary>
        /// Contains the server connected to in the previous session.
        /// </summary>
        public PreviousHost PreviousHost;

        /// <summary>
        /// Available Maps.
        /// </summary>
        public string[] Maps;

        /// <summary>
        /// Available Gamemodes.
        /// </summary>
        public string[] Gamemodes;

        /// <summary>
        /// Available Playlists.
        /// </summary>
        public string[] Playlists;

        /// <summary>
        /// Known Host Servers by IP or Name and port  
        /// </summary>
        public List<Server> Hosts;

        /// <summary>
        /// path to blacklight installation directory
        /// </summary>
        public string GameFolder;

        private static Config _Config = null;
        private const string LauncherConfigFileName = "LauncherConfig.json";

        /// <summary>
        /// Get the configuration from JSON.
        /// </summary>
        /// <returns>Instance of this class with parsed config.</returns>
        public static Config Get()
        {
            var serializerOptions = new JsonSerializerOptions
            {
                IncludeFields = true,
            };

            try
            {
                if (_Config == null)
                    _Config = JsonSerializer.Deserialize<Config>(File.ReadAllText(LauncherConfigFileName), serializerOptions);
            }
            catch (Exception ex)
            {
                MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Error", $"Failed to parse {LauncherConfigFileName}!")
                .Show();
                //Log.Debug(ex.Message);

                Environment.Exit(1);
            }


            return _Config;
        }

        /// <summary>
        /// Save the current config to JSON.
        /// </summary>
        /// <returns>Whether saving succeeded.</returns>
        public static bool Save()
        {
            var serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                string jsonConfig = JsonSerializer.Serialize(Get(), serializerOptions);
                File.WriteAllText(LauncherConfigFileName, jsonConfig);
            } catch (Exception ex)
            {
                MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Error", $"Error writing config: {ex.Message}")
                .Show();
            }

            return true;
        }
    }
}
