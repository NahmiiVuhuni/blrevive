using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Launcher.Configuration
{
    /// <summary>
    /// Provides read/write access to JSON hosts backup configuration.
    /// </summary>
    public class HostsConfigProvider : IConfigProvider
    {
        public static string FileName = "HostsConfigBackup.json";

        /// <summary>
        /// Known Hosts by IP or Name and port
        /// </summary>
        public List<Server> Hosts { get; set; }

        /// <summary>
        /// last connected host
        /// </summary>
        public Server PreviousHost { get; set; }
    }
}

