using System;
using CommandLine;
using Configuration;
using Utils;

namespace Utils
{
    public class CLI
    {
        public class CliPatchOptions
        {
        }

        public class CliLaunchOptions
        {
            [Option('u', "url", Required = true, HelpText = "The URL that is passed to the game cli.")]
            public string URL {get; set;}

            [Option('s', "server", Required = false, HelpText = "Start as server")]
            public bool StartAsServer {get; set;}

            [Option('i', "ip", Required = false, Default = "127.0.0.1")]
            public string IP {get; set;}

            [Option('p', "port", Required = false, Default = "7777")]
            public string Port {get; set;}
        }

        public static void Run(string[] args)
        {
            if(args.Length <= 0)
                Exit("Arguments cannot be empty", 0x10001);

            Config.Load();
            Logging.Initialize(true);
            
            switch(args[0])
            {
                case "registry":
                    HandleRegistryCLI(args);
                    break;
                case "patch":
                    HandlePatchCLI(args, Parser.Default.ParseArguments<CliPatchOptions>(args));
                    break;
                case "launch":
                    HandleLaunchCLI(args, Parser.Default.ParseArguments<CliLaunchOptions>(args));
                    break;
                default:
                    Exit("command not recognized.", 0x10002);
                    break;
            }
        }

        public static void HandleRegistryCLI(string[] args)
        {
            if(args.Length == 1)
                Exit(Config.App.GameFolder);

            /*switch(args[1])
            {
                case "add":
                    break;
                case "remove":
                    break;
                default:
                    Exit("wrong command syntax", 0x10005);
                    break;
            }*/
            Exit("Not implemented yet");
        }

        public static void HandlePatchCLI(string[] args, ParserResult<CliPatchOptions> opts)
        {
            if(args.Length <= 2)
                Exit("patch needs at least two arguments", 0x10003);
            opts.WithParsed<CliPatchOptions>(o => {
                GameLauncher.LaunchPatcher(args[1], args[2]);
            }).WithNotParsed<CliPatchOptions>(e => {
                Exit("Error while parsing options: " + e.ToString());
            });
        }

        public static void HandleLaunchCLI(string[] args, ParserResult<CliLaunchOptions> opts)
        {
            if(args.Length <= 1)
                Exit("Missing arguments", 0x10006);

            opts.WithParsed<CliLaunchOptions>(o => {
                if(o.StartAsServer)
                    GameLauncher.LaunchServer(o.URL);
                else
                    GameLauncher.LaunchClient(o.IP, o.Port, o.URL);
            }).WithNotParsed<CliLaunchOptions>(e => {
                Exit($"Error while parsing options: " + e.ToString());
            });
        }

        private static void Exit(string message = "", int code = 0, bool waitForInput = true)
        {
            Console.WriteLine(message);
            if(waitForInput)
                Console.Read();
            Environment.Exit(code);
        }
    }
}