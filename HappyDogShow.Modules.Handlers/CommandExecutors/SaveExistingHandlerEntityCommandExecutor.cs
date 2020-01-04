using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Handlers.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Handlers.CommandExecutors
{
    public class SaveExistingHandlerEntityCommandExecutor : SaveExistingEntityCommandExecutor<IEditHandlerViewViewModel, IHandlerRegistration>
    {
        public SaveExistingHandlerEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IHandlerRegistrationService HandlerRegistrationService)
            : base(HandlerEntityCRUDCommands.SaveExistingEntityCommand, regionManager, eventAggregator, HandlerRegistrationService)
        {
        }

    }
}
