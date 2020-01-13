using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class SaveBreedGroupResultsCommandExecutor : SaveExistingEntityCommandExecutor<IBreedGroupResultsViewViewModel, IChallengeResultCollection<IChallengeResult>>
    {
        public SaveBreedGroupResultsCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IBreedGroupChallengeResultsService service)
            : base(ResultsCommands.SaveBreedGroupResultsCommand, regionManager, eventAggregator, service)
        {
        }

        protected override async Task HandleSuccessfulSave(IBreedGroupResultsViewViewModel vm)
        {
            await NotifyUserThatSaveWentWell(vm);
        }
    }
}
