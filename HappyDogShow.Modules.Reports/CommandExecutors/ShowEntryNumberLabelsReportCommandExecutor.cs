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
    public class ShowEntryNumberLabelsReportCommandExecutor
    {
        private IBreedEntryService _breedEntryService;
        private IReportViewerService _reportViewerService;
        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowEntryNumberLabelsReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            DogShowReportCommands.ShowEntryNumberLabelsReportCommand.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IBreedEntryEntityWithAdditionalData> items = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>(obj.Id);
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            datasources.Add("DSBreedEntriesForShow", data);

            Dictionary<string, string> parms = new Dictionary<string, string>();
            parms.Add("parmClubName", ReportConstants.CLUB_NAME);
            parms.Add("parmDogShowName", obj.DogShowName);
            parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));


            _reportViewerService.ShowReport(@"Reports\EntryNumberLabelsForShow.rdlc", datasources, parms);
        }
    }
}
