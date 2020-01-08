using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Reports.CommandExecutors
{
    class ShowHandlerResultsStewardsSheetReportCommandExecutor : ShowHandlerResultsSheetReportCommandExecutor
    {
        public ShowHandlerResultsStewardsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService)
            : base(reportViewerService, breedEntryService, handlerEntryService, breedChallengeService, "STEWARD SHEET", DogShowReportCommands.ShowHandlerResultsStewardsSheetReportCommand)
        {
        }
    }
}
