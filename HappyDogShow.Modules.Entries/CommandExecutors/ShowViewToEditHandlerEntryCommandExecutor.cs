﻿using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Infrastructure.FormNameConstants;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    class ShowViewToEditHandlerEntryCommandExecutor : NavigateToEntityEditViewCommandExecutor<IHandlerEntryEntity>
    {
        public ShowViewToEditHandlerEntryCommandExecutor(IRegionManager regionManager)
            : base(HandlerEntryCRUDCommands.ShowViewToEditEntityCommand, regionManager, HandlerFormNameConstants.HandlerEntries.EditEntry.ViewName)
        {
        }
    }
}
