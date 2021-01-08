using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BLRevive.Patcher
{

    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.Write("Error: Please provide valid arguments!\n\n" +
                                "Usage: Patcher.exe <GameFile> <options>\n" +
                                "Options:\n" +
                                "\t--output=\"<filepath>\": set custom output path" +
                                "\t--no-emblem-patch: disables patching of SetEmblem function\n" +
                                "\t--no-proxy: disables injection of proxy\n" +
                                "\t--aslr-only: only patch aslr (shortcut for switches above)\n");
                Environment.Exit(1);
            }

            Patcher.OriginalGameFile = (string)args[0];

            if (Patcher.OriginalGameFile.Contains("\\"))
                Patcher.GameFolder = Patcher.OriginalGameFile.Substring(0, Patcher.OriginalGameFile.IndexOf("\\Binaries\\Win32"));
            else
            {
                Patcher.GameFolder = Directory.GetCurrentDirectory();
                Patcher.OriginalGameFile = $"{Patcher.GameFolder}\\Binaries\\Win32\\{Patcher.OriginalGameFile}";
            }

            Patcher.BinariesFolder = $"{Patcher.GameFolder}\\Binaries\\Win32\\";
            Patcher.PatchedGameFile = Patcher.OriginalGameFile.Remove(Patcher.OriginalGameFile.IndexOf(".exe"), 4) + "-Patched.exe";

            List<string> opts = new List<string>(args);
            opts.RemoveAt(0);

            foreach (string arg in opts)
            {
                if (arg.IndexOf("--no-emblem-patch") == 0)
                {
                    Console.WriteLine("Disabled emblem patch!");
                    Patcher.ApplyEmblemPatch = false;
                }

                if (arg.IndexOf("--no-proxy") == 0)
                {
                    Console.WriteLine("Disabled proxy injection!");
                    Patcher.InjectProxy = false;
                }

                if(arg.IndexOf("--aslr-only") == 0)
                {
                    Console.WriteLine("Only disable ASLR!");
                    Patcher.ApplyEmblemPatch = false;
                    Patcher.InjectProxy = false;
                }

                if(arg.IndexOf("--output=") == 0)
                {
                    string outputPath = arg.Replace("--output=", "").Replace("\"", "");
                    Patcher.PatchedGameFile = outputPath;

                }
            }

            if (Patcher.PatchGameFile())
                Console.WriteLine($"Successfully patched {Patcher.OriginalGameFile} to {Patcher.PatchedGameFile}");
        }
    }
}
