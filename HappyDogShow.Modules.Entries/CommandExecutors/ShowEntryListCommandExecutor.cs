using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.Commands;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowEntryListCommandExecutor
    {
        private IRegionManager _regionManager;

        public DelegateCommand CommandHandler { get; set; }

        public ShowEntryListCommandExecutor(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CommandHandler = new DelegateCommand(ExecuteCommand);
            EntryListCommands.ShowEntryListCommand.RegisterCommand(CommandHandler);
        }

        private void ExecuteCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, FormNameConstants.Entries.EntriesList.ViewName,
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                    // put a breakpoint here and checkout what NavigationResult contains
                });
        }
    }
}
