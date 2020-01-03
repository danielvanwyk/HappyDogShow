using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class SaveNewDogEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureNewDogViewViewModel, IDogRegistration>
    {
        public SaveNewDogEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IDogRegistrationService service)
            : base(DogEntityCRUDCommands.SaveNewEntityCommand, regionManager, eventAggregator, service)
        {
        }

        protected override void HandleSuccessfulSave(ICaptureNewDogViewViewModel vm, int newId)
        {
            BreedEntryCRUDCommands.ShowViewToCaptureNewEntityCommand.Execute(vm.CurrentEntity);
        }

    }
}
