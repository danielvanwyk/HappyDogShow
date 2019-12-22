using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Entries.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowViewToEditEntryCommandExecutor : NavigateToEntityEditViewCommandExecutor<IBreedEntryEntity>
    {
        public ShowViewToEditEntryCommandExecutor(IRegionManager regionManager)
            : base(BreedEntryCRUDCommands.ShowViewToEditEntityCommand, regionManager, FormNameConstants.Entries.EditEntry.ViewName)
        {
        }
    }
}
