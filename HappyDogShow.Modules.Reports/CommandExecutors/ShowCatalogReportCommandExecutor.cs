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
    class ShowCatalogReportCommandExecutor
    {
        private IBreedEntryService _breedEntryService;
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;

        private DelegateCommand<IDogShowEntity> commandHandler { get; set; }

        public ShowCatalogReportCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService, IHandlerEntryService handlerEntryService)
        {
            _breedEntryService = breedEntryService;
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;

            commandHandler = new DelegateCommand<IDogShowEntity>(ExecuteCommand);
            DogShowReportCommands.ShowCatalogReportCommand.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IDogShowEntity obj)
        {
            List<IBreedEntryEntityWithAdditionalData> items = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>();
            var data = items.Where(i => i.ShowId == obj.Id).ToList();

            List<IHandlerEntryEntityWithAdditionalData> handleritems = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var handlerdata = handleritems.Where(i => i.ShowId == obj.Id).ToList();

            Dictionary<string, object> datasources = new Dictionary<string, object>();
            datasources.Add("DSBreedEntriesForShow", data);
            datasources.Add("DSHandlerEntriesForShow", handlerdata);

            var ds = new List<IDogShowEntity>();
            ds.Add(obj); 
            datasources.Add("DSShowInfo", ds);

            //Dictionary<string, string> parms = new Dictionary<string, string>();
            //parms.Add("parmClubName", "Overberg Kennel Club");
            //parms.Add("parmDogShowName", obj.DogShowName);
            //parms.Add("parmDogShowDate", obj.ShowDate.ToString("yyyy-MM-dd"));


            _reportViewerService.ShowReport(@"Reports\ShowCatalog.rdlc", datasources, null);
        }
    }
}
