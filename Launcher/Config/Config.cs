using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System;
using System.Reflection;
using System.Linq;
using System.Text.Json.Serialization;
using Launcher.Utils;

namespace Launcher.Configuration
{
    /// <summary>
    /// Provides read/write access to JSON configuration.
    /// The config is devided into sections, each IConfigProvider represents a section. 
    /// </summary>
    /// <example>
    /// This example shows how to load, read, change and save the config.
    /// <code>
    /// // load config from file (must have been called at least once before accessing config vars)
    /// Config.Load();
    /// // get config var
    /// string name = Config.User.Username;
    /// // set config var (temporary)
    /// Config.User.Username = "NewName";
    /// // save changes to file
    /// Config.Save();
    /// </code>
    /// </example>
    public class Config
    {
        #region Provider
        /// <summary>
        /// app configuration
        /// </summary>
        public static AppConfigProvider App;
        [JsonPropertyName("App")]
        public AppConfigProvider _AppShallow { get { return Config.App; } }

        /// <summary>
        /// user configuration
        /// </summary>
        public static UserConfigProvider User;
        [JsonPropertyName("User")]
        public UserConfigProvider _UserShallow { get { return Config.User; } }

        /// <summary>
        /// game configuration
        /// </summary>
        public static GameConfigProvider Game;
        [JsonPropertyName("Game")]
        public GameConfigProvider _GameShallow { get { return Config.Game; } }

        /// <summary>
        /// server configuration
        /// </summary>
        public static ServerConfigProvider Server;
        [JsonPropertyName("Server")]
        public ServerConfigProvider _ServerShallow { get { return Config.Server; } }

        /// <summary>
        /// server list configuration
        /// </summary>
        public static ServerListConfigProvider ServerList;
        [JsonPropertyName("ServerList")]
        public ServerListConfigProvider _ServerListShallow { get { return Config.ServerList; } }

        /// <summary>
        /// host list
        /// </summary>
        public static HostsConfigProvider Hosts;

        /// <summary>
        /// default configuration
        /// </summary>
        public static DefaultConfigProvider Defaults = new DefaultConfigProvider();
        #endregion

        /// <summary>
        /// Filename of configuration
        /// </summary>
        private const string LauncherConfigFileName = "LauncherConfig.json";

        /// <summary>
        /// Load configuration from file.
        /// </summary>
        public static void Load()
        {
            try 
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
            catch(JsonException ex)
            {
                throw new Exception("Config JSON is invalid!", ex);
            } catch (Exception ex) when (
                ex.GetType() == typeof(FileNotFoundException) ||
                ex.GetType() == typeof(DirectoryNotFoundException) ||
                ex.GetType() == typeof(AccessViolationException)
            )
            {
                throw new Exception("Config file is missing or not accessable!", ex);
            }
        }

        /// <summary>
        /// Save configuraiton to file.
        /// </summary>
        /// <param name="filter">section override for faster saving</param>
        public static void Save(IConfigProvider filter = null)
        {
            try
            {
                // get all config providers declared in this class
                var confprop = typeof(Config).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                List<FieldInfo> providers = confprop.Where(prop => prop.FieldType.IsSubclassOf(typeof(IConfigProvider))).ToList();

                var sectionJson = new Dictionary<FieldInfo, string>();

                if(filter != null && filter.GetType().GetProperty("FileName") != null)
                {
                    FieldInfo provider = providers.Where(prov => prov.FieldType == filter.GetType()).FirstOrDefault();
                    if (provider == null)
                        throw new Exception("No provider for such filter was found.");

                    var json = JsonSerializer.Serialize(provider.GetValue(null), provider.FieldType);
                    File.WriteAllText((string)filter.GetType().GetProperty("FileName", BindingFlags.Public | BindingFlags.Static).GetValue(null), json);
                    return;
                }

                foreach(var providerProp in providers)
                {
                    var staticProvider = providerProp.FieldType;
                    var customFileProp = staticProvider.GetProperty("FileName", BindingFlags.Public | BindingFlags.Static);

                    if (customFileProp != null && customFileProp.GetValue(null) != null)
                    {
                        var json = JsonSerializer.Serialize(providerProp.GetValue(null), providerProp.FieldType);
                        File.WriteAllText((string)customFileProp.GetValue(null), json);
                    } else
                    {
                        var json = JsonSerializer.Serialize(providerProp.GetValue(null), providerProp.FieldType);
                        sectionJson.Add(providerProp, json);
                    }
                }


                string fulljson = JsonSerializer.Serialize<Config>(new Config(), new JsonSerializerOptions() { WriteIndented = true});
                File.WriteAllText(LauncherConfigFileName, fulljson);
            }
            catch (JsonException ex)
            {
                throw new Exception("Failed saving config: JSON is invalid!", ex);
            }
            catch (Exception ex) when (
                ex.GetType() == typeof(FileNotFoundException) ||
                ex.GetType() == typeof(DirectoryNotFoundException) ||
                ex.GetType() == typeof(AccessViolationException)
            )
            {
                throw new Exception("Failed saving config: file is missing or not accessable!", ex);
            }
        }
    }
}
