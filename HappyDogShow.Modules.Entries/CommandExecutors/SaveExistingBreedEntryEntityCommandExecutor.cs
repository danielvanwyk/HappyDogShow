﻿using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class SaveExistingBreedEntryEntityCommandExecutor : SaveExistingEntityCommandExecutor<IEditEntryViewViewModel, IBreedEntryEntity>
    {
        public SaveExistingBreedEntryEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IBreedEntryService service)
            : base(BreedEntryCRUDCommands.SaveExistingEntityCommand, regionManager, eventAggregator, service)
        {
        }

    }
}
