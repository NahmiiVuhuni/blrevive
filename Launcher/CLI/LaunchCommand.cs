using System;
using System.IO;
using CommandLine;
using Launcher.Utils;

namespace Launcher.CLI.Commands
{
    [Verb("launch", HelpText = "Launch game client or server")]
    public class LaunchCommand
    {
        [Value(0, MetaName = "ClientPath", HelpText = "Path to game client. Required if -a not specified.")]
        public string ClientPath { get; set; }

        [Option('u', "url", HelpText = "Unreal URL passed to game command line", Default = "localhost?Name=Player")]
        public string URL { get; set; }

        [Option('s', "server", HelpText = "Launch client as server", Default = false)]
        public bool LaunchServer { get; set; }

        [Option('i', "ip", HelpText = "IP adress of server when launching client", Default = "127.0.0.1")]
        public string IP { get; set; }

        [Option('p', "port", HelpText = "Port of server to connect when launching client", Default = 7777)]
        public int Port { get; set; }

        [Option('g', "gamefolder", HelpText = "Path to gamefolder. Required when launching with filename")]
        public string Gamefolder { get; set; }

        [Option('a', "alias", HelpText = "Alias for game client to launch")]
        public string Alias { get; set; }

        public void Execute()
        {
            if(!String.IsNullOrWhiteSpace(Alias))
            {
                var clientInfo = GameRegistry.GetClient(c => c.Alias == Alias);
                ClientPath = clientInfo.OriginalGameFile;
                Gamefolder = Path.Join(clientInfo.InstallPath, clientInfo.BinaryDir);
            } else {
                ClientPath = App.ParseClientIdentifier(ClientPath, Gamefolder);
            }

            if(LaunchServer)
                GameInstanceManager.StartServer(cfg => cfg.CustomParams = URL);
            else
                GameInstanceManager.StartClient(cfg => {
                    cfg.IP = IP;
                    cfg.Port = Port;
                    cfg.Filename = ClientPath;
                    cfg.BinaryPath = Gamefolder;
                    cfg.CustomParams = URL;
                });
        }
    }
}