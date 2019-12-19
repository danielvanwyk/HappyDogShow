using HappyDogShow.Infrastructure;
using HappyDogShow.Modules.Dogs.CommandExecutors;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Modules.Dogs.ViewModels;
using HappyDogShow.Modules.Dogs.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs
{
    public class DogsModule : ModuleBase
    {
        private ShowDogListCommandExecutor _showDogListCommandExecutor;
        private ShowViewToCaptureNewDogCommandExecutor _showViewToCaptureNewDogCommandExecutor;
        //private ShowViewToEditDogShowEntityCommandExecutor _showViewToEditDogShowEntityCommandExecutor;
        private SaveNewDogEntityCommandExecutor _saveNewDogEntityCommandExecutor;
        //private SaveExistingDogShowEntityCommandExecutor _saveExistingDogShowEntityCommandExecutor;

        public DogsModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IDogsMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            //RegisterViewWithRegionUsingViewModel<IExploreDogsViewViewModel>(RegionNames.ContentRegion);
            _showDogListCommandExecutor = Container.Resolve<ShowDogListCommandExecutor>();
            _showViewToCaptureNewDogCommandExecutor = Container.Resolve<ShowViewToCaptureNewDogCommandExecutor>();
            //_showViewToEditDogShowEntityCommandExecutor = Container.Resolve<ShowViewToEditDogShowEntityCommandExecutor>();
            _saveNewDogEntityCommandExecutor = Container.Resolve<SaveNewDogEntityCommandExecutor>();
            //_saveExistingDogShowEntityCommandExecutor = Container.Resolve<SaveExistingDogShowEntityCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
            // main menu
            Container.RegisterType<IDogsMainMenuView, DogsMainMenuView>();
            Container.RegisterType<IDogsMainMenuViewViewModel, DogsMainMenuViewViewModel>();

            // the dogs list
            Container.RegisterType<object, ExploreDogsViewViewModel>(FormNameConstants.Dogs.DogsList.ViewName);
            Container.RegisterType<IExploreDogsView, ExploreDogsView>();

            // the new form
            Container.RegisterType<object, CaptureNewDogViewViewModel>(FormNameConstants.Dogs.NewDog.ViewName);
            Container.RegisterType<ICaptureNewDogView, CaptureNewDogView>();
        }
    }
}
