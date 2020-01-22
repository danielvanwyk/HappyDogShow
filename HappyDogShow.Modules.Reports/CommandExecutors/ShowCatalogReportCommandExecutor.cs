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
        //private IBreedChallengeService _breedChallengeService;
        private IBreedChallengeResultsService _breedChallengeResultsService;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowCatalogReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IJudgesService judgesService, IBreedChallengeResultsService breedChallengeResultsService)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;
            _judgesService = judgesService;
            //_breedChallengeService = breedChallengeService;
            _breedChallengeResultsService = breedChallengeResultsService;

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
            officials.Add(new KeyValueCombo() { Key = "Chairman", Value = "Mr Herman Groenewald" });
            officials.Add(new KeyValueCombo() { Key = "Show Manager", Value = "Ms Nadine Snyman 083 227 9827" });
            officials.Add(new KeyValueCombo() { Key = "Secretary", Value = "Dr Annemari Groenewald" });
            officials.Add(new KeyValueCombo() { Key = "Vet on Call", Value = "To be announced" });
            officials.Add(new KeyValueCombo() { Key = "KUSA Rep", Value = "Ms Doreen Powell" });
            datasources.Add("dsOfficials", officials);

            List<KeyValueCombo> judgingOrder = new List<KeyValueCombo>();
            judgingOrder.Add(new KeyValueCombo() { Key = "In Breed", Value = "Best of Breed, Puppy, Junior, Veteran, Baby Puppy, Neuter" });
            judgingOrder.Add(new KeyValueCombo() { Key = "In Group", Value = "Best in Group, Puppy, Junior, Veteran, Baby Puppy, Neuter" });
            judgingOrder.Add(new KeyValueCombo() { Key = "In Show", Value = "Best in Show, Puppy, Junior, Veteran, Baby Puppy, Neuter" });
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

            /*
            List<IBreedChallengeEntity> breedChallenges = await _breedChallengeService.GetListAsync<BreedChallengeEntity>();
            foreach (IBreedChallengeEntity breedChallenge in breedChallenges)
            {
                foreach (var tempydatay in moreTempData)
                {
                    classEntryData.Add(new BreedEntryClassEntry()
                    {
                        ShowName = tempydatay.TempShowName,
                        BreedGroupName = tempydatay.TempBreedGroupName,
                        BreedName = tempydatay.TempBreedName,
                        GenderName = "ALL",
                        EntryNumber = "",
                        EnteredClassName = breedChallenge.Name,
                        JudgingOrder = breedChallenge.JudginOrder
                    });
                }
            }
            */
            datasources.Add("DSBreedEntryClassEntriesForShow", classEntryData);






            //Dictionary<string, string> parms = new Dictionary<string, string>();
            //parms.Add("parmClubName", "Overberg Kennel Club");
            //parms.Add("parmDogShowName", obj.DogShowName);
            //parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));


            _reportViewerService.ShowReport(@"Reports\MarkedShowCatalog.rdlc", datasources, null);
        }
    }
}
