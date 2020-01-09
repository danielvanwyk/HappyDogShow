using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    class ShowInShowResultsCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowInShowResultsCommandExecutor(IRegionManager regionManager)
            : base(ResultsCommands.ShowInShowResultsCommand, regionManager, FormNameConstants.Results.InShow.ViewName)
        {
        }
    }
}
