using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Configuration
{
    public class GameConfigProvider : IConfigProvider
    {
        /// <summary>
        /// Available Maps.
        /// </summary>
        public string[] Maps { get; set; }

        /// <summary>
        /// Available Gamemodes.
        /// </summary>
        public string[] Gamemodes { get; set; }

        /// <summary>
        /// Available Playlists.
        /// </summary>
        public string[] Playlists { get; set; }

        /// <summary>
        /// Custom cli prefix when running on linux.
        /// </summary>
        public string LinuxExecPrefix { get; set; }
    }
}
