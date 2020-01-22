using HappyDogShow.Services.Infrastructure.Models;
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

            viewReport.reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

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
                    try
                    {
                        viewReport.reportViewer.LocalReport.SetParameters(new ReportParameter(keyValuePair.Key, keyValuePair.Value.ToString()));
                    }
                    catch 
                    { 
                        // do nothing 
                    }
                }
            }

            viewReport.reportViewer.RefreshReport();

            viewReport.ShowDialog();
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            LocalReport parentReport = sender as LocalReport;

            if (e.ReportPath.Contains("CatalogCoverPage"))
            {
                ReportDataSource ds = parentReport.DataSources.Where(d => d.Name == "DSShowInfo").First();
                e.DataSources.Add(ds);
            }

            if (e.ReportPath.Contains("ShowDetailsPage"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSShowInfo").First());
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "dsOfficials").First());
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSJudgesInformation").First());
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "dsJudgingOrder").First());
            }

            if (e.ReportPath.Contains("ShowEntryBreakdown"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSHandlerEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedGroupsEntryBreakdown"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedsCatalog"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedGroupCatalog"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedGroupEntryBreakdown"))
            {
                string breedGroupName = e.Parameters["parmBreedGroupName"].Values[0];

                var originaldata = parentReport.DataSources["DSBreedEntriesForShow"].Value;
                List<IBreedEntryEntityWithAdditionalData> data = originaldata as List<IBreedEntryEntityWithAdditionalData>;
                List<IBreedEntryEntityWithAdditionalData> newdata = data.Where(b => b.BreedGroupName == breedGroupName).ToList();

                e.DataSources.Add(new ReportDataSource("DSBreedEntriesForShow", newdata));
            }

            if (e.ReportPath.Contains("BreedEntries"))
            {
                string breedName = e.Parameters["parmBreedName"].Values[0];

                var originaldata = parentReport.DataSources["DSBreedEntriesForShow"].Value;
                List<IBreedEntryEntityWithAdditionalData> data = originaldata as List<IBreedEntryEntityWithAdditionalData>;
                List<IBreedEntryEntityWithAdditionalData> newdata = data.Where(b => b.BreedName == breedName).ToList();

                e.DataSources.Add(new ReportDataSource("DSBreedEntriesForShow", newdata));
            }

            if (e.ReportPath.Contains("BreedResults"))
            {
                string breedName = e.Parameters["parmBreedName"].Values[0];

                var originaldata = parentReport.DataSources["DSBreedEntryClassEntriesForShow"].Value;
                List<IBreedEntryClassEntry> data = originaldata as List<IBreedEntryClassEntry>;
                List<IBreedEntryClassEntry> newdata = data.Where(b => b.BreedName == breedName).ToList();

                e.DataSources.Add(new ReportDataSource("DSBreedEntryClassEntriesForShow", newdata));
            }

            if (e.ReportPath.Contains("BreedGroupResults"))
            {
                string breedGroupName = e.Parameters["parmBreedGroupName"].Values[0];

                e.DataSources.Add(new ReportDataSource("DSBreedGroupChallengResults", parentReport.DataSources["DSBreedGroupChallengResults"].Value));
            }

            if (e.ReportPath.Contains("BreedGroupBreedChallengeResults"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedChallengeResults").First());
            }

            if (e.ReportPath.Contains("InShowResults"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSInShowChallengeResuls").First());
            }
        }
    }
}
