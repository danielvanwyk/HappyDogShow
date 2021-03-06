﻿using HappyDogShow.Infrastructure.CommandExecutors;
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
    public class SaveExistingHandlerEntryEntityCommandExecutor : SaveExistingEntityCommandExecutor<IEditHandlerEntryViewViewModel, IHandlerEntryEntity>
    {
        public SaveExistingHandlerEntryEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IHandlerEntryService service)
            : base(HandlerEntryCRUDCommands.SaveExistingEntityCommand, regionManager, eventAggregator, service)
        {
        }

    }
}
