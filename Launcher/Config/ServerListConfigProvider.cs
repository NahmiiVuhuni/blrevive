using System.Collections.Generic;

namespace Configuration
{
    public class ServerListConfigProvider : IConfigProvider
    {

        /// <summary>
        /// Contains the server connected to in the previous session.
        /// </summary>
        public Server PreviousHost { get; set; }

        /// <summary>
        /// Known Host Servers by IP or Name and port  
        /// </summary>
        public List<Server> Hosts { get; set; }

        public int MaxClientHostListSize = 50;
    }
}
