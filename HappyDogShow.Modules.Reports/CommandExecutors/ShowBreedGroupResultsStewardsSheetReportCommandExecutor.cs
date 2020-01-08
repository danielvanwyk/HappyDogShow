using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Reports.CommandExecutors
{
    public class ShowBreedGroupResultsStewardsSheetReportCommandExecutor : ShowBreedGroupResultsSheetReportCommandExecutor
    {
        public ShowBreedGroupResultsStewardsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService, IBreedGroupChallengeService breedGroupChallengeService) 
            : base(reportViewerService, breedEntryService, handlerEntryService, breedChallengeService, breedGroupChallengeService, "STEWARD SHEET", DogShowReportCommands.ShowBreedGroupResultsStewardsSheetReportCommand)
        {
        }
    }
}
