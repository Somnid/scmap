using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scmap.Commands.Attributes;

namespace scmap.Commands
{
    public class ConfigCommand : ICommand
    {
        [CommandArg(0)]
        public string Key { get; set; }
        [CommandArg(1)]
        public string Value { get; set; }
    }
}
