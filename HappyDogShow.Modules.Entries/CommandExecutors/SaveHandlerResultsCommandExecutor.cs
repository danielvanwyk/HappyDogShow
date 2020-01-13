using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class SaveHandlerResultsCommandExecutor : SaveExistingEntityCommandExecutor<IHandlerResultsViewViewModel, IChallengeResultCollection<IChallengeResult>>
    {
        public SaveHandlerResultsCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IHandlerChallengeResultsService service)
            : base(ResultsCommands.SaveHandlerResultsCommand, regionManager, eventAggregator, service)
        {
        }

        protected override async Task HandleSuccessfulSave(IHandlerResultsViewViewModel vm)
        {
            await NotifyUserThatSaveWentWell(vm);
        }
    }
}
