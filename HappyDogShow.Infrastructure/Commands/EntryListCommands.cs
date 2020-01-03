using Microsoft.Practices.Prism.Commands;

namespace HappyDogShow.Infrastructure.Commands
{
    public class EntryListCommands
    {
        public static CompositeCommand ShowEntryListCommand = new CompositeCommand();
        public static CompositeCommand ShowEntryByClassListCommand = new CompositeCommand();
    }
}
