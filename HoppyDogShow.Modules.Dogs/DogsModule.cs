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

        public DogsModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IDogsMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            //RegisterViewWithRegionUsingViewModel<IExploreDogsViewViewModel>(RegionNames.ContentRegion);
            _showDogListCommandExecutor = Container.Resolve<ShowDogListCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
            // main menu
            Container.RegisterType<IDogsMainMenuView, DogsMainMenuView>();
            Container.RegisterType<IDogsMainMenuViewViewModel, DogsMainMenuViewViewModel>();

            // the dogs list
            Container.RegisterType<object, ExploreDogsViewViewModel>(FormNameConstants.Dogs.DogsList.ViewName);
            Container.RegisterType<IExploreDogsView, ExploreDogsView>();

            Container.RegisterType<ShowDogListCommandExecutor, ShowDogListCommandExecutor>();
        }
    }
}
