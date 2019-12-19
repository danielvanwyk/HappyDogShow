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

    /*
    public class ShowViewToCaptureNewEntryCommandExecutor2
    {
        private IRegionManager _regionManager;

        public DelegateCommand CommandHandler { get; set; }

        public ShowViewToCaptureNewEntryCommandExecutor2(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CommandHandler = new DelegateCommand(ExecuteCommand);
            NewEntryCommands.ShowViewToCaptureNewEntryCommand.RegisterCommand(CommandHandler);
        }

        private void ExecuteCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, FormNameConstants.Entries.NewEntry.ViewName,
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                    // put a breakpoint here and checkout what NavigationResult contains
                });
        }
    }
    */
}
