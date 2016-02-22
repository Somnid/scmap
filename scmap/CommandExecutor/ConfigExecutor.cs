using System;
using System.Collections.Generic;
using scmap.Commands;
using scmap.Extensions;
using scmap.Helpers;

namespace scmap.CommandExecutor
{
    public class ConfigExecutor : IExecutor
    {
        private readonly Dictionary<string, string> _schema = new Dictionary<string, string>
        {
            { "namespace", "string" },
            { "master-db", "string" }
        };

        public void Execute(ICommand command)
        {
            var configCommand = (ConfigCommand)command;

            if (!_schema.ContainsKey(configCommand.Key))
            {
                Console.WriteLine($"Config does not support key: {configCommand.Key}");
                return;
            }

            var config = ConfigHelper.Read();
            if (configCommand.Value != null)
            {
                config.SetProperty(configCommand.Key, configCommand.Value);
                ConfigHelper.Write(config, "config.json");
                Console.WriteLine($"SET {configCommand.Key}={configCommand.Value}");
            }
            else
            {
                Console.WriteLine(config.GetStringProperty(configCommand.Key));
            }
        }
    }
}
