using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using scmap.Commands.Attributes;

namespace scmap.Commands
{
    public class CommandMapper
    {
        public T MapCommand<T>(string[] args)
        {
            var command = Activator.CreateInstance<T>();
            var commandProps = typeof(T).GetProperties();
            foreach (var prop in commandProps)
            {
                var attributes = prop.GetCustomAttributes().Where(x => x.GetType() == typeof(CommandArgAttribute)).Cast<CommandArgAttribute>().ToList();
                foreach (var attribute in attributes)
                {
                    if(attribute.Order < args.Length)
                    {
                        prop.SetValue(command, args[attribute.Order]);
                    }
                }
            }

            return command;
        }

        public ICommand MapCommand(Type type, string[] args)
        {
            var command = Activator.CreateInstance(type);
            var commandProps = type.GetProperties();
            foreach (var prop in commandProps)
            {
                var attributes = prop.GetCustomAttributes().Where(x => x.GetType() == typeof(CommandArgAttribute)).Cast<CommandArgAttribute>().ToList();
                foreach (var attribute in attributes)
                {
                    if (attribute.Order < args.Length)
                    {
                        prop.SetValue(command, args[attribute.Order]);
                    }
                }
            }

            return (ICommand)command;
        }
    }
}
