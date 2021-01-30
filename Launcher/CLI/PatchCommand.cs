using System;
using System.IO;
using CommandLine;
using Utils;

namespace Launcher.CLI.Commands
{
    [Verb("patch", HelpText = "Patch a BL:R game file")]
    public class PatchCommand
    {
        [Value(0, MetaName = "Input", HelpText = "Identifier for input file. Either a valid filename or registry ID.", Required = true)]
        public string Input { get; set; }

        [Value(1, MetaName = "Output", HelpText = "Patched file output. If empty, using <Input>-Patched.exe", Required = false)]
        public string Output { get; set; }

        [Option('i', "inject-proxy", HelpText = "Inject proxy", Default = false)]
        public bool InjectProxy { get; set; }

        [Option('p', "patch", HelpText = "Apply game patches", Default = true)]
        public bool ApplyPatches { get; set; }

        [Option('g', "gamefolder", HelpText = "Path to game binaries when using filenames as input")]
        public string Gamefolder { get; set; }

        public void Execute()
        {
            Input = Handler.ParseClientIdentifier(Input, Gamefolder);

            // set output to <input>-Patched if not specified
            if(String.IsNullOrWhiteSpace(Output))
            {
                 var orig = Path.Join(Path.GetDirectoryName(Input), Path.GetFileNameWithoutExtension(Input));
                 Output = $"{orig}-Patched{Path.GetExtension(Input)}";
            }

            Patcher.PatchGameFile(Input, Output, ApplyPatches, InjectProxy);
        }
    }
}