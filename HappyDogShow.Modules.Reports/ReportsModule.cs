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
        private ShowBreedSplashReportCommandExecutor showBreedSplashReportCommandExecutor;
        private ShowCatalogReportCommandExecutor showCatalogReportCommandExecutor;
        private ShowBreedResultsStewardsSheetReportCommandExecutor showBreedResultsStewardsSheetReportCommandExecutor;
        private ShowBreedResultsJudgesSheetReportCommandExecutor showBreedResultsJudgesSheetReportCommandExecutor;
        private ShowBreedGroupResultsStewardsSheetReportCommandExecutor showBreedGroupResultsStewardsSheetReportCommandExecutor;
        private ShowBreedGroupResultsJudgesSheetReportCommandExecutor showBreedGroupResultsJudgesSheetReportCommandExecutor;
        public ReportsModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            showBreedBreakdownReportCommandExecutor = Container.Resolve<ShowBreedBreakdownReportCommandExecutor>();
            showEntryNumberLabelsReportCommandExecutor = Container.Resolve<ShowEntryNumberLabelsReportCommandExecutor>();
            showBreedSplashReportCommandExecutor = Container.Resolve<ShowBreedSplashReportCommandExecutor>();
            showCatalogReportCommandExecutor = Container.Resolve<ShowCatalogReportCommandExecutor>();
            showBreedResultsStewardsSheetReportCommandExecutor = Container.Resolve<ShowBreedResultsStewardsSheetReportCommandExecutor>();
            showBreedResultsJudgesSheetReportCommandExecutor = Container.Resolve<ShowBreedResultsJudgesSheetReportCommandExecutor>();
            showBreedGroupResultsStewardsSheetReportCommandExecutor = Container.Resolve<ShowBreedGroupResultsStewardsSheetReportCommandExecutor>();
            showBreedGroupResultsJudgesSheetReportCommandExecutor = Container.Resolve<ShowBreedGroupResultsJudgesSheetReportCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
        }
    }
}
