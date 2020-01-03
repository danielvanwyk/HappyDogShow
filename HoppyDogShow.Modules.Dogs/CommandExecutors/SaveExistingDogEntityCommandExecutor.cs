using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class SaveExistingDogEntityCommandExecutor : SaveExistingEntityCommandExecutor<IEditDogViewViewModel, IDogRegistration>
    {
        public SaveExistingDogEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IDogRegistrationService dogRegistrationService)
            : base(DogEntityCRUDCommands.SaveExistingEntityCommand, regionManager, eventAggregator, dogRegistrationService)
        {
        }

    }
}
