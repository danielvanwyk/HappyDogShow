using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class SaveInShowResultsCommandExecutor : SaveExistingEntityCommandExecutor<IInShowResultsViewViewModel, IChallengeResultCollection<IChallengeResult>>
    {
        public SaveInShowResultsCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IInShowChallengeResultsService service)
            : base(ResultsCommands.SaveInShowResultsCommand, regionManager, eventAggregator, service)
        {
        }

    }
}
