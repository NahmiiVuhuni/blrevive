using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Serilog;
using Launcher.Configuration;

namespace Launcher.Utils
{
    /// <summary>
    /// Provides common network util functions
    /// </summary>
    class NetworkUtil
    {
        /// <summary>
        /// Resolves the host IP based on host name or address
        /// </summary>
        /// <param name="hostNameOrAddress"></param>
        /// <returns>hostNameOrAddress if already a valid IPv4 or the IP based on host name</returns>
        public static string GetHostIp(string hostNameOrAddress)
        {
            if (IsValidIPv4(hostNameOrAddress))
            {
                return hostNameOrAddress;
            }

            string hostIp = null;
            try
            {
                IPAddress ipAddress = Dns.GetHostAddresses(hostNameOrAddress).First();
                hostIp = ipAddress.MapToIPv4().ToString();
            }
            catch
            {
                Log.Error("Could not resolve host name: {0}", hostNameOrAddress);
            }

            return hostIp;
        }

        /// <summary>
        /// Validates an IPv4 Address Template
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public static bool IsValidIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            return Regex.IsMatch(ipString, $"^(?:[0-9]{1,3}{Path.DirectorySeparatorChar}.){3}[0-9]{1,3}$");
        }

        /// <summary>
        /// Provides a default Host Server as the first entry in Config.Hosts list or falls back to Config.DefaultLocalHostIp
        /// </summary>
        /// <returns>First host server (defaulted as Local Host IP) in the Config Hosts List OR Default Local Host server</returns>
        public static Server GetDefaultHostServer()
        {
            List<Server> hosts = Config.ServerList.Hosts;
            if (hosts != null && hosts.Count > 0)
            {
                return hosts[0];
            }

            return Config.Defaults.LocalHostServer;
        }

        /// <summary>
        /// Reset the Host Servers list to default entry and saves it in Config JSON 
        /// </summary>
        public static void ResetHostsList()
        {
            Config.ServerList.Hosts = new List<Server>() { Config.Defaults.LocalHostServer };
            Config.Save();
        }

        /// <summary>
        /// Update the Host Servers list only with uniques Host IP/Server Name and saves it in Config JSON 
        /// </summary>
        /// <param name="server"></param>
        public static void UpdateHostsList(Server server)
        {
            List<Server> hosts = Config.ServerList.Hosts;
            if (hosts == null 
                || String.IsNullOrWhiteSpace(server.Address)
                || String.IsNullOrWhiteSpace(server.Port)
                || hosts.Exists(item => item.Address.Equals(server.Address) && item.Port.Equals(server.Port)) 
                || hosts.Count >= Config.ServerList.MaxClientHostListSize)
            {
                throw new ArgumentException("Server contains invalid values!");
            }

            // check if the host name is already in the list with it's equivalent IP
            string hostIp = GetHostIp(server.Address);
            if (!String.IsNullOrWhiteSpace(hostIp))
            {
                List<Server> tempHostsList = hosts;

                // check pairs of DNS:Port or IP:Port
                if (!hosts.Exists(item => ((GetHostIp(item.Address).Equals(hostIp) && item.Port.Equals(server.Port)) 
                                                        || (item.Address.Equals(server.Address) && item.Port.Equals(server.Port)))))
                {
                    // add actual valid host representation (IP or name), as added by user with port
                    tempHostsList.Add(server);
                } else if (!NetworkUtil.IsValidIPv4(server.Address) 
                           && hosts.Exists(item => GetHostIp(item.Address).Equals(hostIp) && item.Port.Equals(server.Port)))
                {
                    // overwrite server IP representation with the DNS string representation 
                    int existingHostWithIpIndex = hosts.FindIndex(item => GetHostIp(item.Address).Equals(hostIp) && item.Port.Equals(server.Port));
                    tempHostsList[existingHostWithIpIndex] = server;
                }

                Config.ServerList.Hosts = tempHostsList;
                Config.Save();
            }
        }

        public static void BackupHostsList()
        {
            Config.Save(Config.Hosts);
        } 

        public static void RestoreHostsListFromBackup()
        {
            List<Server> backupHosts = Config.Hosts.Hosts;
            if (backupHosts == null || backupHosts.Count == 0)
            {
                throw new FormatException("No backup specified");
            }

            List<Server> currentHosts = Config.Hosts.Hosts;
            Config.Hosts.Hosts = backupHosts;
            Config.Save(Config.Hosts);
        }

        public static void SaveAsPreviousServer(string hostIpOrAddress, string hostPort)
        {
            Config.Hosts.PreviousHost = new Server() { Address = hostIpOrAddress, Port = hostPort};
            Config.Save();
        }
    }
}

