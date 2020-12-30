using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// IP of the server connected to in the previous session.
        /// </summary>
        public string PreviousIP;

        /// <summary>
        /// Available Maps.
        /// </summary>
        public string[] Maps;

        /// <summary>
        /// Available Gamemodes.
        /// </summary>
        public string[] Gamemodes;
        

        private static Config _Config = null;

        /// <summary>
        /// Get the configuration from JSON.
        /// </summary>
        /// <returns>Instance of this class with parsed config.</returns>
        public static Config Get()
        {
            try
            {
                if (_Config == null)
                    _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("LauncherConfig.json"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to parse LauncherConfig.json!");
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
                File.WriteAllText("LauncherConfig.json", jsonConfig);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error writing config: {ex.Message}");
            }
            return true;
        }
    }
}
