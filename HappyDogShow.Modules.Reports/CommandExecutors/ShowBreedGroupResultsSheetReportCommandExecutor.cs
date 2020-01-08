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
    public class DataForThisReport
    {
        public string ShowName { get; set; }
        public string BreedGroupName { get; set; }
        public string BreedName { get; set; }
        public string BreedGroupJudgeName { get; set; }
        public string BreedChallengeAbbreviation { get; set; }
        public string BreedGroupChallengeName { get; set; }
        public string PositionText { get; set; }
        public int EntryCount { get; set; }

    }
    public abstract class ShowBreedGroupResultsSheetReportCommandExecutor
    {
        private IBreedEntryService _breedEntryService;
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;
        private IBreedChallengeService _breedChallengeService;
        private IBreedGroupChallengeService _breedGroupChallengeService;
        private string _mode;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowBreedGroupResultsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService, IBreedGroupChallengeService breedGroupChallengeService, string mode, CompositeCommand command)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;
            _breedChallengeService = breedChallengeService;
            _breedGroupChallengeService = breedGroupChallengeService;
            _mode = mode;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IBreedEntryEntityWithAdditionalData> items = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>();
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            List<IBreedGroupChallengeEntity> breedGroupChallenges = await _breedGroupChallengeService.GetListAsync<BreedGroupChallengeEntity>();

            var listOfGroups = items.Select(i => i.BreedGroupName).Distinct();

            List<string> positions = new List<string>();
            positions.Add("1st");
            positions.Add("2nd");
            positions.Add("3rd");
            positions.Add("4th");

            //var magicdata = from breedgroup in listOfGroups
            //                 from challenge in breedGroupChallenges
            //                 from position in positions
            //                 select new DataForThisReport()
            //                 {
            //                     BreedGroupName = breedgroup,
            //                     BreedGroupChallengeName = challenge.Name,
            //                     PositionText = position
            //                 };

            var magicdata2 = from breedEntry in data
                            from challenge in breedGroupChallenges
                            select new DataForThisReport()
                            {
                                BreedName = breedEntry.BreedName,
                                BreedGroupName = breedEntry.BreedGroupName,
                                BreedGroupJudgeName = breedEntry.BreedGroupJudgeName,
                                BreedGroupChallengeName = challenge.Name,
                                BreedChallengeAbbreviation = challenge.RelatedBreedChallengeName,
                                EntryCount = 1
                            };

            var magicdata = from breedEntry in data
                            from challenge in breedGroupChallenges
                            from position in positions
                            select new DataForThisReport()
                            {
                                BreedName = breedEntry.BreedName,
                                BreedGroupName = breedEntry.BreedGroupName,
                                BreedGroupJudgeName = breedEntry.BreedGroupJudgeName,
                                BreedGroupChallengeName = challenge.Name,
                                BreedChallengeAbbreviation = challenge.RelatedBreedChallengeName,
                                EntryCount = position == "1st" ? 1 : 0,
                                PositionText = position
                            };

            var moremagic = magicdata.Where(i => i.BreedName == "Great Dane" && i.BreedChallengeAbbreviation == "BOB");
            var moremagic2 = magicdata2.Where(i => i.BreedName == "Great Dane" && i.BreedChallengeAbbreviation == "BOB");


            List< IHandlerEntryEntityWithAdditionalData > handleritems = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var handlerdata = handleritems.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            //datasources.Add("DSBreedEntriesForShow", data);
            //datasources.Add("DSHandlerEntriesForShow", handlerdata);
            //datasources.Add("DSBreedEntryClassEntriesForShow", classEntryData);
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

            //Dictionary<string, string> parms = new Dictionary<string, string>();
            //parms.Add("parmClubName", "Overberg Kennel Club");
            //parms.Add("parmDogShowName", obj.DogShowName);
            //parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));


            _reportViewerService.ShowReport(@"Reports\BreedGroupResultsSheet.rdlc", datasources, null);
        }
    }
}
