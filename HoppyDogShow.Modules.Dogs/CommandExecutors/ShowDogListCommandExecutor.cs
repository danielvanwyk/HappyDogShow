using HappyDogShow.Infrastructure;
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
    public class ShowDogListCommandExecutor
    {
        private IRegionManager _regionManager;

        public DelegateCommand CommandHandler { get; set; }

        public ShowDogListCommandExecutor(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CommandHandler = new DelegateCommand(ExecuteCommand);
            DogListCommands.ShowDogListCommand.RegisterCommand(CommandHandler);
        }

        private void ExecuteCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, FormNameConstants.Dogs.DogsList.ViewName,
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                    // put a breakpoint here and checkout what NavigationResult contains
                });
        }
    }
}
