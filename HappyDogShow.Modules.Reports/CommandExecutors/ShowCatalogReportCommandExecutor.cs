using HappyDogShow.Infrastructure.Commands;
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
    public class KeyValueCombo
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class GroupAndClassInformation
    {
        public string GroupOrClassName { get; set; }
        public string JudgeName { get; set; }
    }
    class ShowCatalogReportCommandExecutor
    {
        private IBreedEntryService _breedEntryService;
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;
        private IJudgesService _judgesService;
        private IBreedChallengeService _breedChallengeService;
        private IBreedChallengeResultsService _breedChallengeResultsService;
        private IBreedGroupChallengeResultsService _breedGroupChallengeResultsService;
        private IInShowChallengeResultsService _inShowChallengeResultsService;
        private IHandlerChallengeResultsService _handlerChallengeResultsService;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowCatalogReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IJudgesService judgesService, IBreedChallengeService breedChallengeService, IBreedChallengeResultsService breedChallengeResultsService, IBreedGroupChallengeResultsService breedGroupChallengeResultsService, IInShowChallengeResultsService inShowChallengeResultsService, IHandlerChallengeResultsService handlerChallengeResultsService)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;
            _judgesService = judgesService;
            _breedChallengeService = breedChallengeService;
            _breedChallengeResultsService = breedChallengeResultsService;
            _breedGroupChallengeResultsService = breedGroupChallengeResultsService;
            _inShowChallengeResultsService = inShowChallengeResultsService;
            _handlerChallengeResultsService = handlerChallengeResultsService;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            DogShowReportCommands.ShowCatalogReportCommand.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IBreedEntryEntityWithAdditionalData> items = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>();
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            List<IHandlerEntryEntityWithAdditionalData> handleritems = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var handlerdata = handleritems.Where(i => i.ShowId == obj.Id).ToList();

            List<IJudgeAssignmentInformation> judgesList = await _judgesService.GetListOfAllTheJudgesForShowAsync<JudgeAssignmentInformation>(obj.Id);

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            datasources.Add("DSBreedEntriesForShow", data);
            datasources.Add("DSHandlerEntriesForShow", handlerdata);
            datasources.Add("DSJudgesInformation", judgesList);

            List<KeyValueCombo> officials = new List<KeyValueCombo>();
            officials.Add(new KeyValueCombo() { Key = "Chairman", Value = ReportConstants.CHAIRMAN });
            officials.Add(new KeyValueCombo() { Key = "Show Manager", Value = ReportConstants.SHOWMANAGER });
            officials.Add(new KeyValueCombo() { Key = "Secretary", Value = ReportConstants.SECRETARY });
            officials.Add(new KeyValueCombo() { Key = "Vet on Call", Value = ReportConstants.VETONCALL });
            officials.Add(new KeyValueCombo() { Key = "KUSA Rep", Value = ReportConstants.KUSA_REP });
            datasources.Add("dsOfficials", officials);

            List<KeyValueCombo> judgingOrder = new List<KeyValueCombo>();
            judgingOrder.Add(new KeyValueCombo() { Key = "In Breed", Value = ReportConstants.JUDGING_ORDER_BREED });
            judgingOrder.Add(new KeyValueCombo() { Key = "In Group", Value = ReportConstants.JUDGING_ORDER_GROUP });
            judgingOrder.Add(new KeyValueCombo() { Key = "In Show", Value = ReportConstants.JUDGING_ORDER_SHOW });
            datasources.Add("dsJudgingOrder", judgingOrder);

            var ds = new List<IDogShowEntity>();
            ds.Add(obj); 
            datasources.Add("DSShowInfo", ds);







            List<IBreedEntryClassEntry> classEntryItems = await _breedEntryService.GetBreedEntryClassEntryListAsync<BreedEntryClassEntry>();
            var classEntryData = classEntryItems.Where(i => i.ShowId == obj.Id).ToList();

            var rankeddata = classEntryData.GroupBy(d => d.ReportGroupingKey)
                .SelectMany(g => g.OrderBy(y => y.ReportSortingKey)
                                   .Select((x, i) => new { g.Key, Item = x, Rank = i + 1 }));

            foreach (var i in rankeddata)
            {
                i.Item.ReportingRank = i.Rank;
            }

            var tempData = from c in classEntryData
                           select new
                           {
                               TempShowName = c.ShowName,
                               TempBreedGroupName = c.BreedGroupName,
                               TempBreedName = c.BreedName
                           };

            var moreTempData = tempData.Distinct().ToList();

            List<IBreedChallengeResult> breedchallengeresults = await _breedChallengeResultsService.GetListAsync<BreedChallengeResult>(obj.Id);
            foreach (IBreedChallengeResult challengeResult in breedchallengeresults)
            {
                classEntryData.Add(new BreedEntryClassEntry()
                {
                    ShowName = challengeResult.ShowName,
                    BreedGroupName = challengeResult.BreedGroupName,
                    BreedName = challengeResult.BreedName,
                    GenderName = "ALL",
                    EntryNumber = challengeResult.EntryNumber,
                    EnteredClassName = challengeResult.Challenge,
                    JudgingOrder = challengeResult.JudgingOrder
                });
            }
            datasources.Add("DSBreedEntryClassEntriesForShow", classEntryData);

            List<IBreedChallengeEntity> breedChallenges = await _breedChallengeService.GetListAsync<BreedChallengeEntity>();
            datasources.Add("DSBreedChallenges", breedChallenges);

            var breedGroupChallengeResults = await _breedGroupChallengeResultsService.GetListAsync<BreedGroupChallengeResult>(obj.Id);
            datasources.Add("DSBreedGroupChallengResults", breedGroupChallengeResults);

            datasources.Add("DSBreedChallengeResults", breedchallengeresults);

            var inshowChallengeResults = await _inShowChallengeResultsService.GetListAsync<InShowChallengeResult>(obj.Id);
            datasources.Add("DSInShowChallengeResuls", inshowChallengeResults);

            //Dictionary<string, string> parms = new Dictionary<string, string>();
            //parms.Add("parmClubName", "Overberg Kennel Club");
            //parms.Add("parmDogShowName", obj.DogShowName);
            //parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));

            var handlerChallengeResults = await _handlerChallengeResultsService.GetListAsync<HandlerChallengeResult>(obj.Id);
            datasources.Add("DSHandlerChallengeResults", handlerChallengeResults);

            _reportViewerService.ShowReport(@"Reports\MarkedShowCatalog.rdlc", datasources, null);
        }
    }
}
