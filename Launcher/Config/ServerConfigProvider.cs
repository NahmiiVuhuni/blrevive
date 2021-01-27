using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class ServerConfigProvider : IConfigProvider
    {
        /// <summary>
        /// Delay between server and client startup.
        /// </summary>
        public int ServerStartupOffset { get; set; }
    }
}
