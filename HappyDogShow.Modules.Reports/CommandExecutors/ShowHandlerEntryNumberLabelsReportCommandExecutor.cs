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
    public class ShowHandlerEntryNumberLabelsReportCommandExecutor
    {
        private IHandlerEntryService _handlerEntryService;
        private IReportViewerService _reportViewerService;
        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowHandlerEntryNumberLabelsReportCommandExecutor(IReportViewerService reportViewerService, IHandlerEntryService handlerEntryService)
        {
            _handlerEntryService = handlerEntryService;
            _reportViewerService = reportViewerService;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            DogShowReportCommands.ShowHandlerEntryNumberLabelsReportCommand.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IHandlerEntryEntityWithAdditionalData> items = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>(obj.Id);
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            datasources.Add("DSHandlerEntriesForShow", data);

            Dictionary<string, string> parms = new Dictionary<string, string>();
            parms.Add("parmClubName", "Overberg Kennel Club");
            parms.Add("parmDogShowName", obj.DogShowName);
            parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));


            _reportViewerService.ShowReport(@"Reports\HandlerEntryNumberLabelsForShow.rdlc", datasources, parms);
        }
    }
}
