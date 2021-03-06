﻿using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class SaveMultipleNewBreedEntryEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureMultipleNewEntryViewViewModel, IMultipleBreedEntry>
    {
        public SaveMultipleNewBreedEntryEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IBreedMultipleEntryService service)
            : base(BreedEntryCRUDCommands.SaveMultipleNewEntityCommand, regionManager, eventAggregator, service)
        {
        }

        protected override void HandleSuccessfulSave(ICaptureMultipleNewEntryViewViewModel vm, int newId)
        {
            _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("DogsList");
        }

    }
}
