﻿using HappyDogShow.Infrastructure;
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
        private ShowViewToCaptureNewDogShowEntityCommandExecutor _ShowViewToCaptureNewDogShowEntityCommandExecutor;
        private ShowViewToEditDogShowEntityCommandExecutor _showViewToEditDogShowEntityCommandExecutor;
        private SaveNewDogShowEntityCommandExecutor _saveNewDogShowEntityCommandExecutor;
        private SaveExistingDogShowEntityCommandExecutor _saveExistingDogShowEntityCommandExecutor;
        private GenerateNumbersCommandExecutor generateNumbersCommandExecutor;
        private ClearNumbersCommandExecutor clearNumbersCommandExecutor;
        private GenerateHandlerNumbersCommandExecutor generateHandlerNumbersCommandExecutor;

        public ShowsModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IShowsMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            _showShowListCommandExecutor = Container.Resolve<ShowShowListCommandExecutor>();
            _ShowViewToCaptureNewDogShowEntityCommandExecutor = Container.Resolve<ShowViewToCaptureNewDogShowEntityCommandExecutor>();
            _showViewToEditDogShowEntityCommandExecutor = Container.Resolve<ShowViewToEditDogShowEntityCommandExecutor>();
            _saveNewDogShowEntityCommandExecutor = Container.Resolve<SaveNewDogShowEntityCommandExecutor>();
            _saveExistingDogShowEntityCommandExecutor = Container.Resolve<SaveExistingDogShowEntityCommandExecutor>();
            generateNumbersCommandExecutor = Container.Resolve<GenerateNumbersCommandExecutor>();
            clearNumbersCommandExecutor = Container.Resolve<ClearNumbersCommandExecutor>();
            generateHandlerNumbersCommandExecutor = Container.Resolve<GenerateHandlerNumbersCommandExecutor>();
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

            // the edit form
            Container.RegisterType<object, EditDogShowViewViewModel>(FormNameConstants.Shows.EditDogShow.ViewName);
            Container.RegisterType<IEditDogShowView, EditDogShowView>();

            // the generate and clear numbers forms
            Container.RegisterType<object, MassUpdateNumbersGenerateNumbersViewViewModel>(FormNameConstants.Shows.GenerateNumbers.ViewName);
            Container.RegisterType<object, MassUpdateNumbersRemoveNumbersViewViewModel>(FormNameConstants.Shows.RemoveNumbers.ViewName);
            Container.RegisterType<IMassUpdateNumbersView, MassUpdateNumbersView>();
            Container.RegisterType<object, MassUpdateHandlerEntryNumbersViewViewModel>(FormNameConstants.Shows.GenerateHandlerNumbers.ViewName);
            Container.RegisterType<IMassUpdateHandlerNumbersView, MassUpdateHandlerNumbersView>();
        }
    }
}
