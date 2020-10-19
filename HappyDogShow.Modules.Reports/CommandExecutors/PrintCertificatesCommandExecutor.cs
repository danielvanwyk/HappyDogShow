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
    public class PrintCertificatesCommandExecutor
    {
        private IReportViewerService _reportViewerService;
        private IBreedEntryService _breedEntryService;

        private DelegateCommand<IChallengeResultCollection<IChallengeResult>> commandHandler { get; set; }

        public PrintCertificatesCommandExecutor(IReportViewerService reportViewerService, IBreedEntryService breedEntryService)
        {
            _reportViewerService = reportViewerService;
            _breedEntryService = breedEntryService;

            commandHandler = new DelegateCommand<IChallengeResultCollection<IChallengeResult>>(ExecuteCommand);
            PrintCommands.PrintCertificatesForDogRelatedChallengeResults.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(IChallengeResultCollection<IChallengeResult> obj)
        {
            Dictionary<string, object> datasources = new Dictionary<string, object>();
            List<ICertficateDetail> certs = new List<ICertficateDetail>();

            List<IChallengeResult> resultstoprint = obj.Results.Where(i => i.Print && !string.IsNullOrEmpty(i.EntryNumber)).OrderBy(c => c.JudgingOrder).ToList();

            if (resultstoprint.Count == 0)
                return;

            foreach (IChallengeResult result in resultstoprint)
            {
                await AddDataForCertificate(certs, result);
            };

            datasources.Add("dsCertificateDetail", certs);

            _reportViewerService.ShowReport(@"Reports\Certificate.rdlc", datasources, null);
        }

        private async Task AddDataForCertificate(List<ICertficateDetail> certs, IChallengeResult result)
        {
            if (!result.Print)
                return;

            if (string.IsNullOrEmpty(result.EntryNumber))
                return;

            if (result.ShowId <= 0)
                return;

            var entries = await _breedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>(result.ShowId, result.EntryNumber);
            if (entries.Count == 1)
            {
                IBreedEntryEntityWithAdditionalData entryData = entries.First();
                certs.Add(new CertificateDetail()
                {
                    RegionName = ReportConstants.REGION_NAME,
                    DateAsString = ReportConstants.SHOWDATE_AS_STRING,
                    SecretaryName = ReportConstants.SECRETARY,
                    VenueName = ReportConstants.VENUE_NAME,
                    ClubName = ReportConstants.CLUB_NAME,
                    ShowName = entryData.ShowName,

                    DateOfBirth = entryData.DOB.ToString("yyyy-MM-dd"),
                    ChallengeName = result.Challenge,
                    BreedName = entryData.BreedName,
                    DogName = entryData.DogName,
                    EntryNumber = entryData.EntryNumber,
                    JudgeName = entryData.ActualJudgeName,
                    OwnerName = entryData.RegisteredOwner,
                    RegistrationNumber = entryData.DogRegistrationNumber,
                    SexName = entryData.GenderName

                });
            };
        }
    }
}
