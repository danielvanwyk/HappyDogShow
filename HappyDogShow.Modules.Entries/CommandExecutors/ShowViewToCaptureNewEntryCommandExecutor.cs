using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowViewToCaptureNewEntryCommandExecutor : NavigateToEntityCreateViewCommandExecutor<IBreedEntryEntity>
    {
        public ShowViewToCaptureNewEntryCommandExecutor(IRegionManager regionManager)
            : base(BreedEntryCRUDCommands.ShowViewToCaptureNewEntityCommand, regionManager, FormNameConstants.Entries.MultipleNewEntry.ViewName)
        {
            RequireObject = true;
        }
    }
}
