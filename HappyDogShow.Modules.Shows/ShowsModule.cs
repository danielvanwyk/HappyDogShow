using HappyDogShow.Infrastructure;
using HappyDogShow.Modules.Shows.CommandExecutors;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.ViewModels;
using HappyDogShow.Modules.Shows.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows
{
    public class ShowsModule : ModuleBase
    {
        private ShowShowListCommandExecutor _showShowListCommandExecutor;
        private ShowViewToCaptureNewDogShowCommandExecutor _showViewToCaptureNewDogShowCommandExecutor;

        public ShowsModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IShowsMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            _showShowListCommandExecutor = Container.Resolve<ShowShowListCommandExecutor>();
            _showViewToCaptureNewDogShowCommandExecutor = Container.Resolve<ShowViewToCaptureNewDogShowCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
            // main menu
            Container.RegisterType<IShowsMainMenuView, ShowsMainMenuView>();
            Container.RegisterType<IShowsMainMenuViewViewModel, ShowsMainMenuViewViewModel>();

            // the shows list
            Container.RegisterType<object, ExploreShowsViewViewModel>(FormNameConstants.Shows.ShowsList.ViewName);
            Container.RegisterType<IExploreShowsView, ExploreShowsView>();

            // the new form
            Container.RegisterType<object, CaptureNewDogShowViewViewModel>(FormNameConstants.Shows.NewDogShow.ViewName);
            Container.RegisterType<ICaptureNewDogShowView, CaptureNewDogShowView>();
        }
    }
}
