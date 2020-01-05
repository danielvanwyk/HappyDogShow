using HappyDogShow.Infrastructure.CommandExecutors;
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
    public class ShowViewToCaptureNewHandlerEntryCommandExecutor : NavigateToEntityCreateViewCommandExecutor<IHandlerEntryEntity>
    {
        public ShowViewToCaptureNewHandlerEntryCommandExecutor(IRegionManager regionManager)
            : base(HandlerEntryCRUDCommands.ShowViewToCaptureNewEntityCommand, regionManager, HandlerFormNameConstants.HandlerEntries.MultipleNewEntry.ViewName)
        {
            RequireObject = true;
        }
    }
}
