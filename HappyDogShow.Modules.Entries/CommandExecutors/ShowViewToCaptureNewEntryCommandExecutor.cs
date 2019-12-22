using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Entries.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowViewToCaptureNewEntryCommandExecutor : NavigateToEntityCreateViewCommandExecutor<IBreedEntryEntity>
    {
        public ShowViewToCaptureNewEntryCommandExecutor(IRegionManager regionManager)
            : base(BreedEntryCRUDCommands.ShowViewToCaptureNewEntityCommand, regionManager, FormNameConstants.Entries.NewEntry.ViewName)
        {
        }
    }
}
