using System;
using ICommand = scmap.Commands.ICommand;

namespace scmap.CommandExecutor
{
    public class HelpExecutor : IExecutor
    {
        public void Execute(ICommand command)
        {
            Console.WriteLine(@"tomodel {sitecoreId} {filename}: Generates a model for the given sitecore item");
            Console.WriteLine(@"config {key} {value}: sets the config value for the provided key");
            Console.WriteLine(@"help: prints help text");
        }
    }
}
