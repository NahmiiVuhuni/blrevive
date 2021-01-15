using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

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
            var serializerOptions = new JsonSerializerOptions
            {
                IncludeFields = true,
            };

            try
            {
                if (File.Exists(HostsConfigFileName))
                {
                    _HostsConfig = JsonSerializer.Deserialize<HostsConfig>(File.ReadAllText(HostsConfigFileName), serializerOptions);
                }
                else
                {
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", $"Failed to parse {HostsConfigFileName}, there is no backup available!")
                    .Show();
                }
            }
            catch
            {
                MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Error", $"Failed to parse {HostsConfigFileName}!")
                .Show();
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
            var serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                List<Server> currentHosts = Config.Get().Hosts;
                if (currentHosts == null || currentHosts.Count == 0)
                {
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "There are no hosts servers available to save!")
                    .Show();

                    return false;
                }

                if (File.Exists(HostsConfigFileName))
                {
                    File.Delete(HostsConfigFileName);
                }
                File.Create(HostsConfigFileName).Close();

                _HostsConfig = new HostsConfig { Hosts = currentHosts };

                string jsonConfig = JsonSerializer.Serialize(_HostsConfig, serializerOptions);
                File.WriteAllText(HostsConfigFileName, jsonConfig);
            } catch (Exception ex)
            {                    
                MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Error", $"Error on writing hosts config backup: {ex.Message}")
                .Show();

                return false;
            }

            return true;
        }
    }
}

