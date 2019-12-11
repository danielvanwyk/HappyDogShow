using HappyDogShow.Infrastructure;
using HappyDogShow.Modules.Shows.Commands;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.CommandExecutors
{
    public class ShowViewToCaptureNewDogShowEntityCommandExecutor
    {
        private IRegionManager _regionManager;

        public DelegateCommand CommandHandler { get; set; }

        public ShowViewToCaptureNewDogShowEntityCommandExecutor(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CommandHandler = new DelegateCommand(ExecuteCommand);
            DogShowEntityCRUDCommands.ShowViewToCaptureNewDogShowEntityCommand.RegisterCommand(CommandHandler);
        }

        private void ExecuteCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, FormNameConstants.Shows.NewDogShow.ViewName,
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                    // put a breakpoint here and checkout what NavigationResult contains
                });
        }
    }
}
