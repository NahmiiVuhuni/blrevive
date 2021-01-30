using CommandLine;

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

        public void Execute()
        {
            switch(Task)
            {
                case Action.LIST:
                    break;
                case Action.ADD:
                    break;
                case Action.REMOVE:
                    break;
            }
        }
    }
}