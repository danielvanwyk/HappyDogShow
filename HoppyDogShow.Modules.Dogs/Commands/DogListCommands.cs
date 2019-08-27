using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.Commands
{
    public class DogListCommands
    {
        public static CompositeCommand ShowDogListCommand = new CompositeCommand();
    }
}
