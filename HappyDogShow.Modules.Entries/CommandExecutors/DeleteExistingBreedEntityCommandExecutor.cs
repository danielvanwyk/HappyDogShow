using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
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
    public class DeleteExistingBreedEntityCommandExecutor : DeleteExistingEntityCommandExecutor<IEntityWithID>
    {
        public DeleteExistingBreedEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IBreedEntryService service)
            : base(BreedEntryCRUDCommands.DeleteExistingEntityCommand, regionManager, eventAggregator, service)
        {
        }

        protected override void HandleSuccessfulDelete(IEntityWithID entity)
        {
            _regionManager.Regions[RegionNames.ContentRegion].NavigationService.RequestNavigate(FormNameConstants.Entries.EntriesList.ViewName);
        }

    }
}
