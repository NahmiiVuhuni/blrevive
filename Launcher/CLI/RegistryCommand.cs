using CommandLine;
using Launcher.Utils;
using Serilog;
using System;
using System.IO;

namespace Launcher.CLI.Commands
{
    [Verb("reg", HelpText = "Manage game registry")]
    public class RegistryCommand
    {
        public enum Action
        {
            ADD,
            REMOVE,
            LIST
        }

        [Value(0, MetaName = "Task", HelpText = "Add, remove or list entries.", Default = Action.LIST)]
        public Action Task { get; set; }

        [Value(1, MetaName = "Target", HelpText = "Target of action. list => empty; add => game file path; remove => registry id", Required = false)]
        public string Target { get; set; }

        [Option('a', "alias", HelpText = "Alias for game client")]
        public string Alias { get; set; }

        [Option('c', "client-version", HelpText = "Version of client")]
        public int ClientVersion { get; set; }

        public void Execute()
        {
            switch(Task)
            {
                case Action.LIST:
                    ListCommand();
                    break;
                case Action.ADD:
                    AddCommand();
                    break;
                case Action.REMOVE:
                    RemoveCommand();
                    break;
            }
        }

        private void ListCommand()
        {
            foreach(var client in GameRegistry.GetClients())
                Log.Information($"{client.Alias}:\t{client.InstallPath}");
        }

        private void AddCommand()
        {
            try
            {
                GameRegistry.AddClient(c => {
                    c.Alias = Alias;
                    c.ClientVersion = ClientVersion;
                    c.InstallPath = Path.GetDirectoryName(Target).Replace(c.BinaryDir, "");
                    c.OriginalGameFile = Path.GetFileName(Target);
                });
            } 
            catch(UserInputException ex) 
            {
                Log.Error(ex.Message);
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception while adding client!");
                throw;
            }
        }

        private void RemoveCommand()
        {
            try 
            {
                GameRegistry.RemoveClient(c =>  c.Alias == Target);
            }
            catch(UserInputException ex)
            {
                Log.Error(ex.Message);
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception while removing client!");
                throw;
            }
        }
    }
}