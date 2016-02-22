using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmap.Commands.Attributes
{
    public class CommandArgAttribute : Attribute
    {
        public int Order { get; set; }

        public CommandArgAttribute(int order)
        {
            Order = order;
        }
    }
}
