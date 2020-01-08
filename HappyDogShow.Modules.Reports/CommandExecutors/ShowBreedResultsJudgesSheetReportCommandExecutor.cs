using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Reports.CommandExecutors
{
    public class ShowBreedResultsJudgesSheetReportCommandExecutor : ShowResultsSheetReportCommandExecutor
    {
        public ShowBreedResultsJudgesSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService)
            : base(reportViewerService, breedEntryService, handlerEntryService, breedChallengeService, "JUDGE SHEET", DogShowReportCommands.ShowBreedResultsJudgesSheetReportCommand)
        {
        }
    }
}
