using System;
using CommandLine;
using Launcher.Utils;

namespace Launcher.CLI.Commands
{
    [Verb("launch", HelpText = "Launch game client or server")]
    public class LaunchCommand
    {
        [Value(0, MetaName = "ClientIdentifier", HelpText = "Client identifier. Either name of game file or a registry ID", Required = true)]
        public string ClientIdentifier { get; set; }

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

        public void Execute()
        {
            ClientIdentifier = App.ParseClientIdentifier(ClientIdentifier, Gamefolder);

            if(LaunchServer)
                GameLauncher.LaunchServer(URL);
            else
                GameLauncher.LaunchClient(IP, Port.ToString(), URL);
        }
    }
}