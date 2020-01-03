using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    class ShowViewToEditDogEntityCommandExecutor : NavigateToEntityEditViewCommandExecutor<IDogRegistration>
    {
        public ShowViewToEditDogEntityCommandExecutor(IRegionManager regionManager)
            : base(DogEntityCRUDCommands.ShowViewToEditEntityCommand, regionManager, FormNameConstants.Dogs.EditDog.ViewName)
        {
        }
    }
}
