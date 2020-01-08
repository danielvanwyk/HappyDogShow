using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Reports.Models;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Reports.CommandExecutors
{
    public class DataForThisInShowReport
    {
        public string ShowName { get; set; }
        public string BreedGroupName { get; set; }
        public string BreedName { get; set; }
        public string ShowJudgeName { get; set; }
        public string BreedGroupChallengeAbbreviation { get; set; }
        public string ShowChallengeName { get; set; }
        public string PositionText { get; set; }
        public int EntryCount { get; set; }
        public int JudgingOrder { get; set; }

    }
    public abstract class ShowInShowResultsSheetReportCommandExecutor
    {
        private IBreedEntryService _breedEntryService;
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;
        private IBreedChallengeService _breedChallengeService;
        private IShowChallengeService _showChallengeService;
        private string _mode;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowInShowResultsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService, IShowChallengeService showChallengeService, string mode, CompositeCommand command)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;
            _breedChallengeService = breedChallengeService;
            _showChallengeService = showChallengeService;
            _mode = mode;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IBreedEntryEntityWithAdditionalData> items = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>();
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            List<IShowChallengeEntity> showChallenges = await _showChallengeService.GetListAsync<ShowChallengeEntity>();

            var listOfGroups = items.Select(i => i.BreedGroupName).Distinct();

            List<string> positions = new List<string>();
            positions.Add("1st");
            positions.Add("2nd");
            positions.Add("3rd");
            positions.Add("4th");

            //var magicdata2 = from breedEntry in data
            //                 from challenge in showChallenges
            //                 select new DataForThisInShowReport()
            //                 {
            //                     BreedName = breedEntry.BreedName,
            //                     BreedGroupName = breedEntry.BreedGroupName,
            //                     ShowJudgeName = breedEntry.BreedGroupJudgeName,
            //                     BreedGroupChallengeName = challenge.Name,
            //                     BreedChallengeAbbreviation = challenge.RelatedBreedGroupChallengeName,
            //                     EntryCount = 1
            //                 };

            var magicdata = from breedEntry in data
                            from challenge in showChallenges
                            from position in positions
                            select new DataForThisInShowReport()
                            {
                                BreedName = breedEntry.BreedName,
                                BreedGroupName = breedEntry.BreedGroupName,
                                ShowJudgeName = "O KRIEK", // breedEntry.BreedGroupJudgeName,
                                ShowChallengeName = challenge.Name,
                                BreedGroupChallengeAbbreviation = challenge.RelatedBreedGroupChallengeName,
                                EntryCount = position == "1st" ? 1 : 0,
                                PositionText = position,
                                JudgingOrder = challenge.JudginOrder
                            };

            //var moremagic = magicdata.Where(i => i.BreedName == "Great Dane" && i.BreedChallengeAbbreviation == "BOB");
            //var moremagic2 = magicdata2.Where(i => i.BreedName == "Great Dane" && i.BreedChallengeAbbreviation == "BOB");


            List<IHandlerEntryEntityWithAdditionalData> handleritems = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var handlerdata = handleritems.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            datasources.Add("dsMagic", magicdata);


            var ds = new List<IDogShowEntity>();
            ds.Add(obj);
            datasources.Add("DSShowInfo", ds);

            var ds2 = new List<ReportExecutionProperties>();
            ds2.Add(new ReportExecutionProperties()
            {
                Mode = _mode
            });
            datasources.Add("DSExecutionProperties", ds2);

            _reportViewerService.ShowReport(@"C:\Work\Personal\HappyDogShow\HappyDogShow.Modules.Reports\Reports\InShowResultsSheet.rdlc", datasources, null);
        }
    }
}
