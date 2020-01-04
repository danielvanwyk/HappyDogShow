using System.Collections.Generic;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IReportViewerService
    {
        void ShowReport(string reportname, Dictionary<string, object> datasources, Dictionary<string, string> parms);
    }
}
