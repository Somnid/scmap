using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scmap.Commands;

namespace scmap.CommandExecutor
{
    public class ToModelExecutor : IExecutor
    {
        public void Execute(ICommand command)
        {
            var toModelCommand = (ToModelCommand)command;
            var repo = new SitecoreRepo();
            var modelBuilder = new SitecoreModelBuilder();

            var item = repo.GetItemById(toModelCommand.Id);
            var fields = repo.GetFieldsForItemById(toModelCommand.Id);
            var csModel = modelBuilder.BuildModel(item, fields);
            Console.Write(csModel);

            using (var file = File.OpenWrite(toModelCommand.FileName ?? "model.cs"))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.Write(csModel);
                }
            }
        }
    }
}
