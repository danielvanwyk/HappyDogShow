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
        private DelegateCommand<object> commandHandler { get; set; }

        public PrintCertificatesCommandExecutor(IReportViewerService reportViewerService)
        {
            _reportViewerService = reportViewerService;

            commandHandler = new DelegateCommand<object>(ExecuteCommand);
            PrintCommands.PrintCertificatesCommand.RegisterCommand(commandHandler);
        }

        private void ExecuteCommand(object obj)
        {
            Dictionary<string, object> datasources = new Dictionary<string, object>();
            List<ICertficateDetail> certs = new List<ICertficateDetail>();

            certs.Add(new CertificateDetail()
            {
                RegionName = "Western Cape",
                DateAsString = "11 January 2020",
                SecretaryName = "Some poor person doing lots of work",
                VenueName = "venue name",

                ShowName = "show name",

                BreedName = "Breed Name goes here",
                DogName = "My Silly Dog Name That Takes up a loooooooooooot of space",
                EntryNumber = "111",
                JudgeName = "Mr Fancy Pants Judge (USA)",
                OwnerName = "A very proud owner, title inits, and some more",
                RegistrationNumber = "ZA123456789012345",
                SexName = "Bitch"

            });
            certs.Add(new CertificateDetail()
            {
                RegionName = "Western Cape",
                DateAsString = "11 January 2020",
                SecretaryName = "Some poor person doing lots of work",
                VenueName = "venue name",

                ShowName = "show name",

                BreedName = "Another Breed Name goes here",
                DogName = "YOUR Silly Dog Name That Takes up a loooooooooooot of space",
                EntryNumber = "222",
                JudgeName = "Mrs Fancy Pants Judge (USA)",
                OwnerName = "A very proud owner, title inits, and some more",
                RegistrationNumber = "ZA123456789012345",
                SexName = "Dog"

            });
            datasources.Add("dsCertificateDetail", certs);

            _reportViewerService.ShowReport(@"Reports\Certificate.rdlc", datasources, null);
        }
    }
}
