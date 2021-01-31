using Launcher.Utils;
using System.Collections.Generic;

namespace Launcher.Configuration
{
    public class GameRegistryProvider : IConfigProvider
    {
        public static string FileName = "GameRegistry.json";

        public List<GameRegistry.ClientInfo> Clients { get; set; }

        public List<GameRegistry.InstanceInfo> Instances { get; set; }
    }
}