using Microsoft.Practices.Prism.Commands;

namespace HappyDogShow.Infrastructure.Commands
{
    public class DogShowAdminCommands
    {
        public static CompositeCommand GenerateNumbersCommand = new CompositeCommand();
        public static CompositeCommand ClearNumbersCommand = new CompositeCommand();
    }
}
