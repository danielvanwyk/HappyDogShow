﻿using HappyDogShow.Infrastructure;
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
        private ShowViewToCaptureNewHandlerCommandExecutor showViewToCaptureNewHandlerCommandExecutor;
        private SaveNewHandlerEntityCommandExecutor saveNewHandlerEntityCommandExecutor;
        //private ShowViewToEditHandlerEntityCommandExecutor _showViewToEditHandlerEntityCommandExecutor;
        //private SaveExistingHandlerEntityCommandExecutor _saveExistingHandlerEntityCommandExecutor;

        public HandlersModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IHandlersMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            showHandlerListCommandExecutor = Container.Resolve<ShowHandlerListCommandExecutor>();
            showViewToCaptureNewHandlerCommandExecutor = Container.Resolve<ShowViewToCaptureNewHandlerCommandExecutor>();
            saveNewHandlerEntityCommandExecutor = Container.Resolve<SaveNewHandlerEntityCommandExecutor>();
            //_showViewToEditHandlerEntityCommandExecutor = Container.Resolve<ShowViewToEditHandlerEntityCommandExecutor>();
            //_saveExistingHandlerEntityCommandExecutor = Container.Resolve<SaveExistingHandlerEntityCommandExecutor>();
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
            //Container.RegisterType<object, EditHandlerViewViewModel>(FormNameConstants.Handlers.EditHandler.ViewName);
            //Container.RegisterType<IEditHandlerView, EditHandlerView>();
        }
    }
}
