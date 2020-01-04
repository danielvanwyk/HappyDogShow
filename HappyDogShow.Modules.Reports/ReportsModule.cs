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

        public ReportsModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            showBreedBreakdownReportCommandExecutor = Container.Resolve<ShowBreedBreakdownReportCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
        }
    }
}
