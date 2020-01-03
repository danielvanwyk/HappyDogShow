using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Entries.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowEntryByClassListCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowEntryByClassListCommandExecutor(IRegionManager regionManager)
            : base(EntryListCommands.ShowEntryByClassListCommand, regionManager, FormNameConstants.Entries.EntriesByClassList.ViewName)
        {
        }
    }
}
