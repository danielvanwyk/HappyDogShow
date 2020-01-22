﻿using HappyDogShow.Services.Infrastructure.Services;
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

            if (e.ReportPath.Contains("BreedGroupsEntriesAndResults"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedGroupCatalog"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedGroupEntryBreakdown"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedEntries"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntriesForShow").First());
            }

            if (e.ReportPath.Contains("BreedResults"))
            {
                e.DataSources.Add(parentReport.DataSources.Where(d => d.Name == "DSBreedEntryClassEntriesForShow").First());
            }
        }
    }
}
