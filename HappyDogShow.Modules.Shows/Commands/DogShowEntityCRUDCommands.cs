using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.Commands
{
    public class DogShowEntityCRUDCommands
    {
        public static CompositeCommand ShowViewToCaptureNewDogShowEntityCommand = new CompositeCommand();
        public static CompositeCommand SaveNewDogShowEntityCommand = new CompositeCommand();

    }
}
