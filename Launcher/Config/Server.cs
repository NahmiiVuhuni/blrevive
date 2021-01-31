
namespace Launcher.Configuration
{
    /// <summary>
    /// Object containing a host server representation for Config JSON and HostsConfig JSON 
    /// </summary>
    public class Server
    {
        /// <summary>
        /// IP or Name (DNS)
        /// </summary>
        public string Address { get; set; }
        public string Port { get; set; }

        /// <summary>
        /// Needed for showing all info in dropdown UI selector
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Address}:{Port}";
        }
    }
}
