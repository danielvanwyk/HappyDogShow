using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Dogs.Commands;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class ShowDogListCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowDogListCommandExecutor(IRegionManager regionManager)
            : base(DogListCommands.ShowDogListCommand, regionManager, FormNameConstants.Dogs.DogsList.ViewName)
        {
        }
    }
}
