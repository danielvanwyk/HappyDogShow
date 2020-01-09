using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowBreedGroupResultsCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowBreedGroupResultsCommandExecutor(IRegionManager regionManager)
            : base(ResultsCommands.ShowBreedGroupResultsCommand, regionManager, FormNameConstants.Results.BreedGroup.ViewName)
        {
        }
    }
}
