using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.Commands
{
    public class BreedEntryCRUDCommands
    {
        public static CompositeCommand ShowViewToCaptureNewEntityCommand = new CompositeCommand();
        public static CompositeCommand ShowViewToEditEntityCommand = new CompositeCommand();

        public static CompositeCommand SaveNewEntityCommand = new CompositeCommand();
        public static CompositeCommand SaveExistingEntityCommand = new CompositeCommand();

        public static CompositeCommand SaveMultipleNewEntityCommand = new CompositeCommand();
    }
}
