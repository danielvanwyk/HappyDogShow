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
    public class ShowHandlerResultsSheetReportCommandExecutor
    {
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;
        private string _mode;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowHandlerResultsSheetReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService, IBreedChallengeService breedChallengeService, string mode, CompositeCommand command)
        {
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;
            _mode = mode;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IHandlerEntryEntityWithAdditionalData> handleritems = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var handlerdata = handleritems.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            datasources.Add("DSHandlerEntriesForShow", handlerdata);

            var ds = new List<IDogShowEntity>();
            ds.Add(obj);
            datasources.Add("DSShowInfo", ds);

            var ds2 = new List<ReportExecutionProperties>();
            ds2.Add(new ReportExecutionProperties()
            {
                Mode = _mode
            });
            datasources.Add("DSExecutionProperties", ds2);


            _reportViewerService.ShowReport(@"C:\Work\Personal\HappyDogShow\HappyDogShow.Modules.Reports\Reports\HandlerResultsSheet.rdlc", datasources, null);
        }
    }
}
