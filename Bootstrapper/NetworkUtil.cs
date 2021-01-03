using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Serilog;

namespace Bootstrapper
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
                hostIp = ipAddress.ToString();
            }
            catch (Exception exception)
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

            return Regex.IsMatch(ipString, "^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$");
        }

        /// <summary>
        /// Provides a default Host Server as the first entry in Config.Hosts list or falls back to Config.DefaultLocalHostIp
        /// </summary>
        /// <returns>First host server (defaulted as Local Host IP) in the Config Hosts List OR Default Local Host server</returns>
        public static Server GetDefaultHostServer()
        {
            List<Server> hosts = Config.Get().Hosts;
            if (hosts != null && hosts.Count > 0)
            {
                return hosts[0];
            }

            return Config.DefaultLocalHostServer;
        }

        /// <summary>
        /// Reset the Host Servers list to default entry and saves it in Config JSON 
        /// </summary>
        public static void ResetHostsList()
        {
            Config.Get().Hosts = new List<Server>() { Config.DefaultLocalHostServer };
            Config.Save();
        }

        /// <summary>
        /// Update the Host Servers list only with uniques Host IP/Server Name and saves it in Config JSON 
        /// </summary>
        /// <param name="server"></param>
        /// <returns>True - if the host list was updated, False otherwise</returns>
        public static bool UpdateHostsList(Server server)
        {
            List<Server> hosts = Config.Get().Hosts;
            if (hosts == null 
                || String.IsNullOrWhiteSpace(server.Address)
                || String.IsNullOrWhiteSpace(server.Port)
                || hosts.Exists(item => item.Address.Equals(server.Address) && item.Port.Equals(server.Port)) 
                || hosts.Count >= Config.MaxClientHostListSize)
            {
                return false;
            }

            // check if the host name is already in the list with it's equivalent IP
            string hostIp = GetHostIp(server.Address);
            if (!String.IsNullOrWhiteSpace(hostIp))
            {
                List<Server> tempHostsList = hosts;

                if (!hosts.Exists(item => item.Address.Equals(hostIp)))
                {
                    // add actual valid host representation (IP or name), as added by user 
                    tempHostsList.Add(server);
                } else if (hosts.Exists(item => item.Address.Equals(hostIp) && item.Port.Equals(server.Port)))
                {
                    // overwrite server IP representation with the DNS string representation 
                    int existingHostWithIpIndex = hosts.FindIndex(item => item.Address.Equals(hostIp) && item.Port.Equals(server.Port));
                    tempHostsList[existingHostWithIpIndex] = server;
                }

                Config.Get().Hosts = tempHostsList;
                bool isSaved = Config.Save();
                if (!isSaved)
                {
                    // restore the old list in case Config JSON save has failed
                    Config.Get().Hosts = hosts;
                }
                return isSaved;
            }

            return false;
        }

        public static bool BackupHostsList()
        {
            return HostsConfig.Save();
        } 

        public static bool RestoreHostsListFromBackup()
        {
            List<Server> backupHosts = HostsConfig.Get().Hosts;
            if (backupHosts == null || backupHosts.Count == 0)
            {
                return false;
            }

            List<Server> currentHosts = Config.Get().Hosts;
            Config.Get().Hosts = backupHosts;
            bool isSaved = Config.Save();
            if (!isSaved)
            {
                // fall back to existing hosts
                Config.Get().Hosts = currentHosts;
            }
            return isSaved;
        }

        public static bool SaveAsPreviousServer(string hostIpOrAddress, string hostPort)
        {
            Config.Get().PreviousHost = new PreviousHost() {Server = new Server() { Address = hostIpOrAddress, Port = hostPort}};
            return Config.Save();
        }
    }
}

