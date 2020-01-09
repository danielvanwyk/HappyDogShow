using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Services;
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

            List<KeyValueCombo> officials = new List<KeyValueCombo>();
            officials.Add(new KeyValueCombo() { Key = "Chairman", Value = "Mr Herman Groenewald" });
            officials.Add(new KeyValueCombo() { Key = "Show Manager", Value = "Ms Nadine Snyman 083 227 9827" });
            officials.Add(new KeyValueCombo() { Key = "Secretary", Value = "Dr Annemari Groenewald" });
            officials.Add(new KeyValueCombo() { Key = "Vet on Call", Value = "To be announced" });
            officials.Add(new KeyValueCombo() { Key = "KUSA Rep", Value = "Ms Doreen Powell" });
            datasources.Add("dsCertificateDetail", officials);

            _reportViewerService.ShowReport(@"Reports\Certificate.rdlc", datasources, null);
        }
    }
}
