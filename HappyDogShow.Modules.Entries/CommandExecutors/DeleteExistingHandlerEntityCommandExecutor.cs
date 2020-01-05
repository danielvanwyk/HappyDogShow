using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Infrastructure.FormNameConstants;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class DeleteExistingHandlerEntityCommandExecutor : DeleteExistingEntityCommandExecutor<IEntityWithID>
    {
        public DeleteExistingHandlerEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IHandlerEntryService service)
            : base(HandlerEntryCRUDCommands.DeleteExistingEntityCommand, regionManager, eventAggregator, service)
        {
        }

        protected override void HandleSuccessfulDelete(IEntityWithID entity)
        {
            _regionManager.Regions[RegionNames.ContentRegion].NavigationService.RequestNavigate(HandlerFormNameConstants.HandlerEntries.EntriesList.ViewName);
        }

    }
}
