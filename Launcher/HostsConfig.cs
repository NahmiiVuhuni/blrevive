using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace BLRevive.Launcher
{
    /// <summary>
    /// Provides read/write access to JSON hosts backup configuration.
    /// </summary>
    public class HostsConfig
    {
        /// <summary>
        /// Known Hosts by IP or Name and port
        /// </summary>
        public List<Server> Hosts;

        private static HostsConfig _HostsConfig = null;
        public const string HostsConfigFileName = "HostsConfigBackup.json";

        /// <summary>
        /// Get the host configuration backup from JSON.
        /// </summary>
        /// <returns>Instance of this class with parsed host config backup</returns>
        public static HostsConfig Get()
        {
            try
            {
                if (File.Exists(HostsConfigFileName))
                {
                    _HostsConfig = JsonConvert.DeserializeObject<HostsConfig>(File.ReadAllText(HostsConfigFileName));
                }
                else
                {
                    MessageBox.Show($"Failed to parse {HostsConfigFileName}, there is no backup available!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse {HostsConfigFileName}!");
            }

            return _HostsConfig ?? (_HostsConfig = new HostsConfig());
        }

        /// <summary>
        /// Saves the current hosts to the dedicated hosts config backup JSON
        /// 1- deletes the old backup JSON config if already exists
        /// 2- creates new backup JSON file to store the hosts 
        /// </summary>
        /// <returns>whether saving succeeded</returns>
        public static bool Save()
        {
            try
            {
                List<Server> currentHosts = Config.Get().Hosts;
                if (currentHosts == null || currentHosts.Count == 0)
                {
                    MessageBox.Show("There are no hosts servers available to save!");
                    return false;
                }

                if (File.Exists(HostsConfigFileName))
                {
                    File.Delete(HostsConfigFileName);
                }
                File.Create(HostsConfigFileName).Close();

                _HostsConfig = new HostsConfig { Hosts = currentHosts };

                string jsonConfig = JsonConvert.SerializeObject(_HostsConfig, Formatting.Indented);
                File.WriteAllText(HostsConfigFileName, jsonConfig);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error on writing hosts config backup: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}

