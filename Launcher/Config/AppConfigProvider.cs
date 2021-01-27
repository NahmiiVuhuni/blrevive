using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Configuration
{
    public class AppConfigProvider : IConfigProvider
    {
        /// <summary>
        /// The log level to use
        /// </summary>
        public int LogLevel { get; set; }

        /// <summary>
        /// path to blacklight installation directory
        /// </summary>
        public string GameFolder { get; set; }
    }
}
