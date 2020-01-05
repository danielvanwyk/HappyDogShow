using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Infrastructure.FormNameConstants;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowHandlerEntryListCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowHandlerEntryListCommandExecutor(IRegionManager regionManager)
            : base(HandlerEntryListCommands.ShowHandlerEntryListCommand, regionManager, HandlerFormNameConstants.HandlerEntries.EntriesList.ViewName)
        {
        }
    }
}
