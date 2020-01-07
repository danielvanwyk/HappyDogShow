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
        }

        protected override void RegisterTypes()
        {
        }
    }
}
