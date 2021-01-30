using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using Launcher.Configuration;
using Serilog;

namespace Launcher.Utils
{
    public static class GameRegistry
    {
        public class ClientInfo
        {
            public string Alias { get; set; }

            public int ClientVersion { get; set; }

            public string InstallPath { get; set; }
            public string BinaryDir = Path.Join("Binaries", "Win32");

            public string OriginalGameFile = "FoxGame-win32-Shipping.exe";
            public string PatchedGameFile = "FoxGame-win32-Shipping-Patched.exe";

            public bool Validate(bool checkForPatched = false)
            {
                if(!Directory.Exists(InstallPath))
                    return false; //throw new UserInputException($"Install path ({InstallPath})does not exist!");
                
                if(!Directory.Exists(Path.Join(InstallPath, BinaryDir)))
                    return false; //throw new UserInputException("Binary directory does not exist!");
                
                if(!File.Exists(Path.Join(InstallPath, BinaryDir, OriginalGameFile)))
                    return false; //throw new UserInputException("Game file does not exist!");
                
                if(checkForPatched && !File.Exists(Path.Join(InstallPath, BinaryDir, PatchedGameFile)))
                    return false; //throw new UserInputException("Patched game file does not exist");

                return true;
            }
        }

        public class InstanceInfo
        {
            public string Alias { get; set; }
            public int InstanceProcessID { get; set; }
            public ClientInfo Client { get; set; }

            public bool Validate()
            {
                try {
                    Process instance = Process.GetProcessById(InstanceProcessID);
                } catch(Exception) {
                    return false; //throw new UserInputException("Process does not exist anymore");
                }

                return true;
            }
        }

        private static List<ClientInfo> clients = new List<ClientInfo>();
        private static List<InstanceInfo> instances = new List<InstanceInfo>();

        public static void Initialize()
        {
            Load();
        }

        public static void Load()
        {
            var tempClients = Config.Registry.Clients;
            clients = tempClients.Where(c => c.Validate()).ToList();

            // log client errors
            if(tempClients.Count() != clients.Count())
                tempClients.ForEach(c => { if(!c.Validate()) Log.Error($"Failed to load client from registry"); });
            
            var tempInstances = Config.Registry.Instances;
            instances = tempInstances.Where(i => i.Validate()).ToList();

            // log instance errors
            if(tempInstances.Count() != instances.Count())
                tempInstances.ForEach(i => { if(!i.Validate()) Log.Error($"Failed to load instance {i.InstanceProcessID}"); });
        }

        public static void Save()
        {
            Config.Registry.Clients = clients;
            Config.Registry.Instances = instances;
            Config.Save(Config.Registry);
        }

        public static void AddClient(ClientInfo client)
        {
            clients.Add(client);
            Save();
            Log.Debug("Client added to registry");
        }

        public static void AddClient(Action<ClientInfo> ConfigureInfo)
        {
            ClientInfo info = new ClientInfo();
            ConfigureInfo(info);
            AddClient(info);
        }

        public static IEnumerable<ClientInfo> GetClients(Func<ClientInfo, bool> Filter = null)
        {
            if(Filter == null)
                return clients;
            return clients.Where(Filter);
        }

        public static ClientInfo GetClient(Func<ClientInfo, bool> Filter)
        {
            var matches = GetClients(Filter);
            if(matches.Count() != 1)
                throw new UserInputException($"A client with the specified filter is not registered!");
            
            return matches.First();
        }

        public static void RemoveClient(Func<ClientInfo, bool> Filter)
        {
            var client = GetClient(Filter);
            clients.Remove(client);
            Save();
            Log.Debug("Removed client from registry");
        }

        public static IEnumerable<InstanceInfo> GetInstances(Func<InstanceInfo, bool> Filter = null)
        {
            if(Filter == null)
                return instances;
            
            return instances.Where(Filter);
        }

        public static InstanceInfo GetInstance(Func<InstanceInfo, bool> Filter)
        {
            var matches = GetInstances(Filter);
            if(matches.Count() != 1)
                throw new UserInputException("Failed to find single instance.");
            
            return matches.First();
        }

        public static void AddInstance(InstanceInfo info)
        {
            if(GetInstances(i => i.Alias == info.Alias || i.Client.InstallPath == info.Client.InstallPath).Count() > 0)
                throw new UserInputException("Instance with alias or game path already registered.");
            
            instances.Add(info);
            Save();
        }

        public static void AddInstance(Action<InstanceInfo> ConfigureInfo)
        {
            InstanceInfo info = new InstanceInfo();
            ConfigureInfo(info);
            AddInstance(info);
        }

        public static void RemoveInstance(Func<InstanceInfo, bool> Filter)
        {
            var instance = GetInstance(Filter);
            instances.Remove(instance);
            Save();
        }
    }
}