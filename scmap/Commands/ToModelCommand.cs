using scmap.Commands.Attributes;

namespace scmap.Commands
{
    public class ToModelCommand : ICommand
    {
        [CommandArg(0)]
        public string Id { get; set; }
        [CommandArg(1)]
        public string FileName { get; set; }
    }
}
