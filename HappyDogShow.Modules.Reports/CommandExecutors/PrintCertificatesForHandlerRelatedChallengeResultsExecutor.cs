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
    public class PrintCertificatesForHandlerRelatedChallengeResultsExecutor
    {
        private IReportViewerService _reportViewerService;
        private IHandlerEntryService _handlerEntryService;

        private DelegateCommand<IChallengeResultCollection<IChallengeResult>> commandHandler { get; set; }

        public PrintCertificatesForHandlerRelatedChallengeResultsExecutor(IReportViewerService reportViewerService, IHandlerEntryService handlerEntryService)
        {
            _reportViewerService = reportViewerService;
            _handlerEntryService = handlerEntryService;

            commandHandler = new DelegateCommand<IChallengeResultCollection<IChallengeResult>>(ExecuteCommand);
            PrintCommands.PrintCertificatesForHandlerRelatedChallengeResults.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IChallengeResultCollection<IChallengeResult> obj)
        {
            Dictionary<string, object> datasources = new Dictionary<string, object>();
            List<ICertficateDetail> certs = new List<ICertficateDetail>();

            List<IChallengeResult> resultstoprint = obj.Results.Where(i => i.Print && !string.IsNullOrEmpty(i.EntryNumber)).ToList();

            if (resultstoprint.Count == 0)
                return;

            foreach (IChallengeResult result in resultstoprint)
            {
                await AddDataForCertificate(certs, result);
            };

            datasources.Add("dsCertificateDetail", certs);

            _reportViewerService.ShowReport(@"Reports\HandlerCertificate.rdlc", datasources, null);
        }

        private async Task AddDataForCertificate(List<ICertficateDetail> certs, IChallengeResult result)
        {
            if (!result.Print)
                return;

            if (string.IsNullOrEmpty(result.EntryNumber))
                return;

            if (result.ShowId <= 0)
                return;

            var allentries = await _handlerEntryService.GetHandlerEntryListAsync<HandlerEntryEntityWithAdditionalData>();
            var entries = allentries.Where(e => e.ShowId == result.ShowId && e.EntryNumber == result.EntryNumber).ToList();
            if (entries.Count == 1)
            {
                IHandlerEntryEntityWithAdditionalData entryData = entries.First();
                certs.Add(new CertificateDetail()
                {
                    RegionName = "Western Cape",
                    DateAsString = "11 January 2020",
                    SecretaryName = "Dr Annemari Groenewald",
                    VenueName = "Kleinmond Primary School",
                    ClubName = "Overberg Kennel Club",
                    ShowName = entryData.ShowName,

                    DateOfBirth = entryData.DOB.ToString("yyyy-MM-dd"),
                    ChallengeName = entryData.EnteredClassName,
                    BreedName = entryData.DogBreed,
                    DogName = entryData.HandlerDisplayName,
                    EntryNumber = entryData.EntryNumber,
                    JudgeName = entryData.JudgeName,
                    OwnerName = "",
                    RegistrationNumber = entryData.DogRegistrationNumber,
                    SexName = entryData.SexName

                });
            };
        }
    }
}
