using System;
using System.IO;
using CommandLine;
using Configuration;
using Serilog;

namespace Utils
{
    /// <summary>
    /// CLI app entry point to provide features without GUI.
    /// </summary>
    public static class CLI
    {
        /// <summary>
        /// cli options for `patch`
        /// </summary>
        public class CliPatchOptions
        {
            [Option('i', "input", Required = true, HelpText = "Input file to patch")]
            public string Input {get; set;}

            [Option('o', "output", Required = true, HelpText = "Output filename")]
            public string Output {get; set;}

            [Option('f', "gamefolder", Required = false,  HelpText = "Path to game directory")]
            public string Gamefolder {get; set;}

            [Option('e', "no-patches", Required = false, Default = false, HelpText = "Dont apply any game patches")]
            public bool NoGamePatches {get; set;}

            [Option('p', "inject-proxy", Required = false, Default = false, HelpText = "Enable the proxy debugging tool")]
            public bool ProxyInjection {get; set;}
        }

        /// <summary>
        /// cli options for `launch`
        /// </summary>
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

        /// <summary>
        /// App entry point
        /// </summary>
        /// <param name="args">arguments passed from command line</param>
        public static void Run(string[] args)
        {
            if(args.Length <= 0)
                Exit("Arguments cannot be empty", 0x10001);

            Config.Load();
            Logging.Initialize(true);
            
            switch(args[0])
            {
                case "registry":
                    HandleRegistryCli(args);
                    break;
                case "patch":
                    HandlePatchCli(args, Parser.Default.ParseArguments<CliPatchOptions>(args));
                    break;
                case "launch":
                    HandleLaunchCli(args, Parser.Default.ParseArguments<CliLaunchOptions>(args));
                    break;
                default:
                    Exit("command not recognized.", 0x10002);
                    break;
            }
        }

        /// <summary>
        /// Add/Remove new game folders to config.
        /// </summary>
        /// <param name="args"></param>
        private static void HandleRegistryCli(string[] args)
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

        /// <summary>
        /// Patch game application.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="opts"></param>
        private static void HandlePatchCli(string[] args, ParserResult<CliPatchOptions> opts)
        {
            if(args.Length <= 2)
                Exit("patch needs at least two arguments", 0x10003);
            opts.WithParsed<CliPatchOptions>(o => {
                string inputPath = o.Input;
                string outputPath = o.Output;
                if(!String.IsNullOrEmpty(o.Gamefolder)) 
                {
                    inputPath = Path.Join(o.Gamefolder, o.Input);
                    outputPath = Path.Join(o.Gamefolder, o.Output);
                }
                Patcher.PatchGameFile(inputPath, outputPath, !o.NoGamePatches, o.ProxyInjection);
            }).WithNotParsed<CliPatchOptions>(e => {
                Exit($"Error while parsing options: {e}");
            });
        }

        /// <summary>
        /// Launch game instance.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="opts"></param>
        private static void HandleLaunchCli(string[] args, ParserResult<CliLaunchOptions> opts)
        {
            if(args.Length <= 1)
                Exit("Missing arguments", 0x10006);

            opts.WithParsed<CliLaunchOptions>(o => {
                if(o.StartAsServer)
                    GameLauncher.LaunchServer(o.URL);
                else
                    GameLauncher.LaunchClient(o.IP, o.Port, o.URL);
            }).WithNotParsed<CliLaunchOptions>(e => {
                Exit($"Error while parsing options: {e}");
            });
        }

        /// <summary>
        /// Exit the application.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <param name="waitForInput"></param>
        private static void Exit(string message = "", int code = 0, bool waitForInput = false)
        {
            if(code == 0)
                
            Console.WriteLine(message);
            if(waitForInput)
                Console.Read();
            Environment.Exit(code);
        }
    }
}