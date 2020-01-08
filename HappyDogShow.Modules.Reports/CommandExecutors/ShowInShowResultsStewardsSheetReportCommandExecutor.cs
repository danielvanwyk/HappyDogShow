using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Reports.CommandExecutors
{
    class ShowInShowResultsStewardsSheetReportCommandExecutor : ShowInShowResultsSheetReportCommandExecutor
    {
        public ShowInShowResultsStewardsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService, IShowChallengeService showChallengeService)
            : base(reportViewerService, breedEntryService, handlerEntryService, breedChallengeService, showChallengeService, "STEWARD SHEET", DogShowReportCommands.ShowInShowResultsStewardsSheetReportCommand)
        {
        }
    }
}
