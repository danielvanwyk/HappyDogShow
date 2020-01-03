using Microsoft.Practices.Prism.Commands;

namespace HappyDogShow.Infrastructure.Commands
{
    public class DogEntityCRUDCommands
    {
        public static CompositeCommand ShowViewToCaptureNewEntityCommand = new CompositeCommand();
        public static CompositeCommand ShowViewToEditEntityCommand = new CompositeCommand();

        public static CompositeCommand SaveNewEntityCommand = new CompositeCommand();
        public static CompositeCommand SaveExistingEntityCommand = new CompositeCommand();

    }
}
