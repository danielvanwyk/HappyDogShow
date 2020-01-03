using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using Microsoft.Practices.Prism.Regions;

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
