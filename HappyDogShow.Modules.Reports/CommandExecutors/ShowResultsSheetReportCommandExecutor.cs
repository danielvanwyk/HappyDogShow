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
    public class ShowResultsSheetReportCommandExecutor
    {
        private IBreedEntryService _breedEntryService;
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowResultsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            DogShowReportCommands.ShowResultsSheetReportCommand.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IBreedEntryEntityWithAdditionalData> items = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>();
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            List<IBreedEntryClassEntry> classEntryItems = await _breedEntryService.GetBreedEntryClassEntryListAsync<BreedEntryClassEntry>();
            var classEntryData = classEntryItems.Where(i => i.ShowId == obj.Id).ToList();

            var rankeddata = classEntryData.GroupBy(d => d.ReportGroupingKey)
                .SelectMany(g => g.OrderBy(y => y.ReportSortingKey)
                                   .Select((x, i) => new { g.Key, Item = x, Rank = i+1 }));

            foreach (var i in rankeddata)
            {
                i.Item.ReportingRank = i.Rank;
            }





            List<IHandlerEntryEntityWithAdditionalData> handleritems = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var handlerdata = handleritems.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            //datasources.Add("DSBreedEntriesForShow", data);
            //datasources.Add("DSHandlerEntriesForShow", handlerdata);
            datasources.Add("DSBreedEntryClassEntriesForShow", classEntryData);

            var ds = new List<IDogShowEntity>();
            ds.Add(obj);
            datasources.Add("DSShowInfo", ds);

            //Dictionary<string, string> parms = new Dictionary<string, string>();
            //parms.Add("parmClubName", "Overberg Kennel Club");
            //parms.Add("parmDogShowName", obj.DogShowName);
            //parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));


            _reportViewerService.ShowReport(@"C:\Work\Personal\HappyDogShow\HappyDogShow.Modules.Reports\Reports\ResultsSheet.rdlc", datasources, null);
        }
    }
}
