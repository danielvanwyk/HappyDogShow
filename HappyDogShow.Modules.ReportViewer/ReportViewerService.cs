using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.ReportViewer
{
    public class ReportViewerService : IReportViewerService
    {
        public void ShowReport(string reportname, Dictionary<string, object> datasources, Dictionary<string, string> parms)
        {
            ViewReport viewReport = new ViewReport();
            viewReport.reportViewer.LocalReport.ReportPath = reportname;

            if (datasources != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in datasources)
                {
                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = keyValuePair.Key; // Name of the DataSet we set in .rdlc
                    reportDataSource.Value = keyValuePair.Value;
                    viewReport.reportViewer.LocalReport.DataSources.Add(reportDataSource);
                }
            }

            if (parms != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in parms)
                {
                    viewReport.reportViewer.LocalReport.SetParameters(new ReportParameter(keyValuePair.Key, keyValuePair.Value.ToString()));
                }
            }

            viewReport.reportViewer.RefreshReport();

            viewReport.ShowDialog();
        }
    }
}
