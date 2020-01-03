using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class ShowViewToCaptureNewDogCommandExecutor : NavigateToEntityCreateViewCommandExecutor<IDogRegistration>
    {
        public ShowViewToCaptureNewDogCommandExecutor(IRegionManager regionManager)
            : base(DogEntityCRUDCommands.ShowViewToCaptureNewEntityCommand, regionManager, FormNameConstants.Dogs.NewDog.ViewName)
        {
        }
    }
}
