using HappyDogShow.Infrastructure;
using System;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using HappyDogShow.Modules.Reports.CommandExecutors;

namespace HappyDogShow.Modules.Reports
{
    public class ReportsModule : ModuleBase
    {
        private ShowBreedBreakdownReportCommandExecutor showBreedBreakdownReportCommandExecutor;
        private ShowEntryNumberLabelsReportCommandExecutor showEntryNumberLabelsReportCommandExecutor;
        private ShowRegisteredOwnerLabelsReportCommandExecutor showRegisteredOwnerLabelsReportCommandExecutor;
        private ShowBreedSplashReportCommandExecutor showBreedSplashReportCommandExecutor;
        private ShowCatalogReportCommandExecutor showCatalogReportCommandExecutor;

        private ShowBreedResultsStewardsSheetReportCommandExecutor showBreedResultsStewardsSheetReportCommandExecutor;
        private ShowBreedResultsJudgesSheetReportCommandExecutor showBreedResultsJudgesSheetReportCommandExecutor;
        
        private ShowBreedGroupResultsStewardsSheetReportCommandExecutor showBreedGroupResultsStewardsSheetReportCommandExecutor;
        private ShowBreedGroupResultsJudgesSheetReportCommandExecutor showBreedGroupResultsJudgesSheetReportCommandExecutor;

        private ShowInShowResultsStewardsSheetReportCommandExecutor showInShowResultsStewardsSheetReportCommandExecutor;
        private ShowInShowResultsJudgesSheetReportCommandExecutor showInShowResultsJudgesSheetReportCommandExecutor;

        private ShowHandlerResultsStewardsSheetReportCommandExecutor showHandlerResultsStewardsSheetReportCommandExecutor;
        private ShowHandlerResultsJudgesSheetReportCommandExecutor showHandlerResultsJudgesSheetReportCommandExecutor;

        private PrintCertificatesCommandExecutor printCertificatesCommandExecutor;
        private PrintCertificatesForHandlerRelatedChallengeResultsExecutor printCertificatesForHandlerRelatedChallengeResultsExecutor;

        public ReportsModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            showBreedBreakdownReportCommandExecutor = Container.Resolve<ShowBreedBreakdownReportCommandExecutor>();
            showEntryNumberLabelsReportCommandExecutor = Container.Resolve<ShowEntryNumberLabelsReportCommandExecutor>();
            showRegisteredOwnerLabelsReportCommandExecutor = Container.Resolve<ShowRegisteredOwnerLabelsReportCommandExecutor>();
            showBreedSplashReportCommandExecutor = Container.Resolve<ShowBreedSplashReportCommandExecutor>();
            showCatalogReportCommandExecutor = Container.Resolve<ShowCatalogReportCommandExecutor>();

            showBreedResultsStewardsSheetReportCommandExecutor = Container.Resolve<ShowBreedResultsStewardsSheetReportCommandExecutor>();
            showBreedResultsJudgesSheetReportCommandExecutor = Container.Resolve<ShowBreedResultsJudgesSheetReportCommandExecutor>();

            showBreedGroupResultsStewardsSheetReportCommandExecutor = Container.Resolve<ShowBreedGroupResultsStewardsSheetReportCommandExecutor>();
            showBreedGroupResultsJudgesSheetReportCommandExecutor = Container.Resolve<ShowBreedGroupResultsJudgesSheetReportCommandExecutor>();

            showInShowResultsStewardsSheetReportCommandExecutor = Container.Resolve<ShowInShowResultsStewardsSheetReportCommandExecutor>();
            showInShowResultsJudgesSheetReportCommandExecutor = Container.Resolve<ShowInShowResultsJudgesSheetReportCommandExecutor>();

            showHandlerResultsStewardsSheetReportCommandExecutor = Container.Resolve<ShowHandlerResultsStewardsSheetReportCommandExecutor>();
            showHandlerResultsJudgesSheetReportCommandExecutor = Container.Resolve<ShowHandlerResultsJudgesSheetReportCommandExecutor>();

            printCertificatesCommandExecutor = Container.Resolve<PrintCertificatesCommandExecutor>();
            printCertificatesForHandlerRelatedChallengeResultsExecutor = Container.Resolve<PrintCertificatesForHandlerRelatedChallengeResultsExecutor>();
        }

        protected override void RegisterTypes()
        {
        }
    }
}
