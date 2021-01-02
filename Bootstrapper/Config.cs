using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace Bootstrapper
{
    /// <summary>
    /// Provides read/write access to JSON configuration.
    /// </summary>
    public class Config
    {
        
        public const string DefaultPlayerName = "Player";
        public const string DefaultLocalHostIp = "127.0.0.1";
        public const decimal DefaultLocalHostPort = 7777;
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
        /// Address of the server connected to in the previous session.
        /// </summary>
        public string PreviousServerAddress;
        /// <summary
        /// Port of the server connect to in the previous session.
        /// </summary>
        public decimal PreviousServerPort;

        /// <summary>
        /// Available Maps.
        /// </summary>
        public string[] Maps;

        /// <summary>
        /// Available Gamemodes.
        /// </summary>
        public string[] Gamemodes;

        /// <summary>
        /// Known Hosts by IP or Name 
        /// </summary>
        public string[] Hosts;

        private static Config _Config = null;
        private const string LauncherConfigFileName = "LauncherConfig.json";

        /// <summary>
        /// Get the configuration from JSON.
        /// </summary>
        /// <returns>Instance of this class with parsed config.</returns>
        public static Config Get()
        {
            try
            {
                if (_Config == null)
                    _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(LauncherConfigFileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse {LauncherConfigFileName}!");
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
            try
            {
                string jsonConfig = JsonConvert.SerializeObject(Get(), Formatting.Indented);
                File.WriteAllText(LauncherConfigFileName, jsonConfig);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error writing config: {ex.Message}");
            }

            return true;
        }
    }
}
