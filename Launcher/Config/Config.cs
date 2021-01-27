using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Configuration
{ 
    /// <summary>
    /// Provides read/write access to JSON configuration.
    /// </summary>
    public static class Config
    {
        public static AppConfigProvider App;
        public static UserConfigProvider User;
        public static GameConfigProvider Game;
        public static ServerConfigProvider Server;
        public static ServerListConfigProvider ServerList;
        public static HostsConfigProvider Hosts;
        public static DefaultConfigProvider Defaults = new DefaultConfigProvider();

        private const string LauncherConfigFileName = "LauncherConfig.json";

        public static void Load()
        {
            // get all config providers declared in this class
            var confprop = typeof(Config).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            List<FieldInfo> providers = confprop.Where(prop => prop.FieldType.IsSubclassOf(typeof(IConfigProvider))).ToList();

            // read config
            var config = JsonDocument.Parse(File.ReadAllText(LauncherConfigFileName)).RootElement;

            // initialize providers
            foreach (var providerProp in providers)
            {
                var staticProvider = providerProp.FieldType;
                var customFileProp = staticProvider.GetField("FileName", BindingFlags.Public | BindingFlags.Static);

                if ( customFileProp != null)
                {
                    var ownConfig = JsonSerializer.Deserialize(File.ReadAllText((string)customFileProp.GetValue(null)), providerProp.FieldType);
                    providerProp.SetValue(null, ownConfig);
                } else
                {
                    var json = config.GetProperty(providerProp.Name).ToString();
                    IConfigProvider provider = (IConfigProvider)JsonSerializer.Deserialize(json, providerProp.FieldType);
                    providerProp.SetValue(null, provider);
                }
            }
        }

        public static bool Save(IConfigProvider filter = null)
        {
            try
            {
                // get all config providers declared in this class
                List<PropertyInfo> providers = new List<PropertyInfo>(typeof(Config).GetProperties(BindingFlags.Public | BindingFlags.Static).Where(prop => prop.PropertyType == typeof(IConfigProvider)));

                Dictionary<PropertyInfo, string> sectionJson = new Dictionary<PropertyInfo, string>();

                if(filter != null && filter.GetType().GetProperty("FileName") != null)
                {
                    PropertyInfo provider = providers.Where(prov => prov.PropertyType == filter.GetType()).FirstOrDefault();
                    if (provider == null)
                        return false;

                    var json = JsonSerializer.Serialize(provider.GetValue(null), provider.PropertyType);
                    File.WriteAllText((string)filter.GetType().GetProperty("FileName", BindingFlags.Public | BindingFlags.Static).GetValue(null), json);
                    return true;
                }

                foreach(var providerProp in providers)
                {
                    var staticProvider = providerProp.PropertyType;
                    var customFileProp = staticProvider.GetProperty("FileName", BindingFlags.Public | BindingFlags.Static);

                    if (customFileProp != null && customFileProp.GetValue(null) != null)
                    {
                        var json = JsonSerializer.Serialize(providerProp.GetValue(null), providerProp.PropertyType);
                        File.WriteAllText((string)customFileProp.GetValue(null), json);
                    } else
                    {
                        var json = JsonSerializer.Serialize(providerProp.GetValue(null), providerProp.PropertyType);
                        sectionJson.Add(providerProp, json);
                    }
                }

                string mergedJson = "";
                foreach(var section in sectionJson)
                {
                    mergedJson += $"\t\"{section.Key.Name}\": {section.Value},\n";
                }
                mergedJson = $"{{\n{mergedJson}\n}}";
                File.WriteAllText(LauncherConfigFileName, mergedJson);
            }
            catch (JsonException ex)
            {
                // TODO: error handling
                return false;
            }
            catch (IOException ex)
            {
                // TODO: error handling
                return false;
            }

            return true;
        }
    }
}
