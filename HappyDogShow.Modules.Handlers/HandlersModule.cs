using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.FormNameConstants;
using HappyDogShow.Modules.Handlers.CommandExecutors;
using HappyDogShow.Modules.Handlers.Infrastructure;
using HappyDogShow.Modules.Handlers.ViewModels;
using HappyDogShow.Modules.Handlers.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers
{
    public class HandlersModule : ModuleBase
    {
        private ShowHandlerListCommandExecutor showHandlerListCommandExecutor;
        private ShowViewToCaptureNewHandlerEntityCommandExecutor showViewToCaptureNewHandlerCommandExecutor;
        private SaveNewHandlerEntityCommandExecutor saveNewHandlerEntityCommandExecutor;
        private ShowViewToEditHandlerEntityCommandExecutor showViewToEditHandlerEntityCommandExecutor;
        private SaveExistingHandlerEntityCommandExecutor saveExistingHandlerEntityCommandExecutor;

        public HandlersModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IHandlersMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            showHandlerListCommandExecutor = Container.Resolve<ShowHandlerListCommandExecutor>();
            showViewToCaptureNewHandlerCommandExecutor = Container.Resolve<ShowViewToCaptureNewHandlerEntityCommandExecutor>();
            saveNewHandlerEntityCommandExecutor = Container.Resolve<SaveNewHandlerEntityCommandExecutor>();
            showViewToEditHandlerEntityCommandExecutor = Container.Resolve<ShowViewToEditHandlerEntityCommandExecutor>();
            saveExistingHandlerEntityCommandExecutor = Container.Resolve<SaveExistingHandlerEntityCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
            // main menu
            Container.RegisterType<IHandlersMainMenuView, HandlersMainMenuView>();
            Container.RegisterType<IHandlersMainMenuViewViewModel, HandlersMainMenuViewViewModel>();

            // the Handlers list
            Container.RegisterType<object, ExploreHandlersViewViewModel>(HandlerFormNameConstants.Handlers.HandlersList.ViewName);
            Container.RegisterType<IExploreHandlersView, ExploreHandlersView>();

            // the new form
            Container.RegisterType<object, CaptureNewHandlerViewViewModel>(HandlerFormNameConstants.Handlers.NewHandler.ViewName);
            Container.RegisterType<ICaptureNewHandlerView, CaptureNewHandlerView>();

            // the edit form
            Container.RegisterType<object, EditHandlerViewViewModel>(HandlerFormNameConstants.Handlers.EditHandler.ViewName);
            Container.RegisterType<IEditHandlerView, EditHandlerView>();
        }
    }
}
