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
    public class ShowBreedGroupResultsJudgesSheetReportCommandExecutor : ShowBreedGroupResultsSheetReportCommandExecutor
    {
        public ShowBreedGroupResultsJudgesSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService, IBreedGroupChallengeService breedGroupChallengeService) 
            : base(reportViewerService, breedEntryService, handlerEntryService, breedChallengeService, breedGroupChallengeService, "JUDGE SHEET", DogShowReportCommands.ShowBreedGroupResultsJudgesSheetReportCommand)
        {
        }
    }
}
