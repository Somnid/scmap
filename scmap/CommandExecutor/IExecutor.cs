using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using scmap.Commands;

namespace scmap.CommandExecutor
{
    public interface IExecutor
    {
        void Execute(ICommand command);
    }
}
