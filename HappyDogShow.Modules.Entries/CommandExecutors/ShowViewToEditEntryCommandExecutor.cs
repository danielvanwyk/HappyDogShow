using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;

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
