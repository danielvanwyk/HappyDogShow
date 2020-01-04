using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Handlers.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers.CommandExecutors
{
    public class SaveNewHandlerEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureNewHandlerViewViewModel, IHandlerRegistration>
    {
        public SaveNewHandlerEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IHandlerRegistrationService service)
            : base(HandlerEntityCRUDCommands.SaveNewEntityCommand, regionManager, eventAggregator, service)
        {
        }

    }
}
