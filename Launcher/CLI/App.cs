using System;
using System.IO;
using CommandLine;
using Serilog;
using System.Reflection;
using System.Linq;
using Launcher.Configuration;
using Launcher.Utils;

namespace Launcher.CLI
{
    /// <summary>
    /// CLI app entry point to provide features without GUI.
    /// </summary>
    public static class App
    {
        /// <summary>
        /// App entry point
        /// </summary>
        /// <param name="args">arguments passed from command line</param>
        public static void Run(string[] args)
        {
            try {
                Config.Load();
                Logging.Initialize(true);
            } catch(Exception ex) {
                Console.WriteLine($"Error while initializing application: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Environment.Exit(1);
            }

            try
            {
                if(args.Length <= 0 || String.IsNullOrWhiteSpace(args[0]))
                    throw new UserInputException("Arguments must be provided!");

                var verbs = LoadVerbs();
                var parser = new Parser(cfg => {
                    cfg.CaseInsensitiveEnumValues = true;
                    cfg.HelpWriter = Parser.Default.Settings.HelpWriter;
                    cfg.AutoHelp = true;
                    cfg.AutoVersion = true;
                    cfg.CaseSensitive = Parser.Default.Settings.CaseSensitive;
                    cfg.ParsingCulture = Parser.Default.Settings.ParsingCulture;
                });
                parser.ParseArguments(args, verbs)
                    .WithParsed(obj => obj.GetType().GetMethod("Execute").Invoke(obj, null));
            } catch(Exception ex) when (
                ex.GetType() == typeof(UserInputException) ||
                ex.InnerException.GetType() == typeof(UserInputException)
            )
            {
                string msg = ex.GetType() == typeof(UserInputException) ? ex.Message : ex.InnerException.Message;
                Log.Error(msg);
            } catch(Exception ex) {
                Log.Error(ex, "Unhandled exception while running app");
                throw;
            }
        }

        /// <summary>
        /// Parse identifier for game clients.
        /// </summary>
        /// <param name="identifier">either a filename, path or id</param>
        /// <param name="path">gamefolder param</param>
        /// <returns></returns>
        public static string ParseClientIdentifier(string identifier, string path)
        {

            int registryID;
            if(Int32.TryParse(identifier, out registryID))
            {
                // Todo: get game filepath from registry
            } 
            else if(!Path.IsPathFullyQualified(identifier))
            {
                if(String.IsNullOrWhiteSpace(path))
                    throw new UserInputException("Input file path must be absolute if no gamefolder is specified");

                identifier = Path.Join(path, identifier);
            } else if (!Path.IsPathFullyQualified(path)) {
                throw new UserInputException("Gamefolder must be absoulte path");
            }

            return identifier;
        }

        /// <summary>
        /// Load all Verbs by searching for classes with VerbAttribute.
        /// </summary>
        /// <returns>list of verbs</returns>
        private	static Type[] LoadVerbs()
        {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();		 
        }
    }
}