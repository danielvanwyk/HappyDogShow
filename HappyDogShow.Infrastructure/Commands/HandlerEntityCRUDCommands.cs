using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Commands
{
    public class HandlerEntityCRUDCommands
    {
        public static CompositeCommand ShowViewToCaptureNewEntityCommand = new CompositeCommand();
        public static CompositeCommand ShowViewToEditEntityCommand = new CompositeCommand();

        public static CompositeCommand SaveNewEntityCommand = new CompositeCommand();
        public static CompositeCommand SaveExistingEntityCommand = new CompositeCommand();

    }
}
