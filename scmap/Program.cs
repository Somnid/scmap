using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using scmap.CommandExecutor;
using scmap.Commands;
using scmap.Extensions;
using scmap.Helpers;

namespace scmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var allCommands = TypeHelper.GetAllTypesInheritedFromType<ICommand>().Where(x => x.IsClass);
            var allExecutors = TypeHelper.GetAllTypesInheritedFromType<IExecutor>().Where(x => x.IsClass);
            var commandMap = allCommands.ToDictionary(k => k.Name.Replace("Command", string.Empty).ToLower(), v => v);
            var executorMap = allExecutors.ToDictionary(k => k.Name.Replace("Executor", string.Empty).ToLower(), v => (IExecutor)Activator.CreateInstance(v));

            if (!ConfigHelper.CheckOrCreate("config.json"))
            {
                Console.WriteLine("Could not open or create config.json");
                return;
            }

            var commandMapper = new CommandMapper();

            if(args.Length == 0)
            {
                args = new[] { "help" };
            }

            var commandType = commandMap[args[0].ToLower()];
            var executor = executorMap[args[0].ToLower()];

            var command = commandMapper.MapCommand(commandType, args.SubArray(1));
            executor.Execute(command);
        }
    }
}
