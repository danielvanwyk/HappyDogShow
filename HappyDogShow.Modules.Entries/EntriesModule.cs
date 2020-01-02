using HappyDogShow.Infrastructure;
using HappyDogShow.Modules.Entries.CommandExecutors;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Modules.Entries.ViewModels;
using HappyDogShow.Modules.Entries.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries
{
    public class EntriesModule : ModuleBase
    {
        private ShowEntryListCommandExecutor _showEntryListCommandExecutor;
        private ShowViewToCaptureNewEntryCommandExecutor _showViewToCaptureNewEntryCommandExecutor;
        private SaveNewBreedEntryEntityCommandExecutor _saveNewBreedEntryEntityCommandExecutor;
        private ShowViewToEditEntryCommandExecutor _showViewToEditEntryCommandExecutor;
        private SaveExistingBreedEntryEntityCommandExecutor _saveExistingBreedEntryEntityCommandExecutor;

        public EntriesModule(IUnityContainer container, IRegionManager regionManager)
                    : base(container, regionManager)
        {

        }

        protected override void InitializeModule()
        {
            RegisterViewWithRegionUsingViewModel<IEntriesMainMenuViewViewModel>(RegionNames.MainMenuRegion);
            _showEntryListCommandExecutor = Container.Resolve<ShowEntryListCommandExecutor>();
            _showViewToCaptureNewEntryCommandExecutor = Container.Resolve<ShowViewToCaptureNewEntryCommandExecutor>();
            _saveNewBreedEntryEntityCommandExecutor = Container.Resolve<SaveNewBreedEntryEntityCommandExecutor>();
            _showViewToEditEntryCommandExecutor = Container.Resolve<ShowViewToEditEntryCommandExecutor>();
            _saveExistingBreedEntryEntityCommandExecutor = Container.Resolve<SaveExistingBreedEntryEntityCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
            // main menu
            Container.RegisterType<IEntriesMainMenuView, EntriesMainMenuView>();
            Container.RegisterType<IEntriesMainMenuViewViewModel, EntriesMainMenuViewViewModel>();

            // the entries list
            Container.RegisterType<object, ExploreEntriesViewViewModel>(FormNameConstants.Entries.EntriesList.ViewName);
            Container.RegisterType<IExploreEntriesView, ExploreEntriesView>();

            // the new form
            Container.RegisterType<object, CaptureNewEntryViewViewModel>(FormNameConstants.Entries.NewEntry.ViewName);
            Container.RegisterType<ICaptureNewEntryView, CaptureNewEntryView>();

            // the edit form
            Container.RegisterType<object, EditEntryViewViewModel>(FormNameConstants.Entries.EditEntry.ViewName);
            Container.RegisterType<IEditEntryView, EditEntryView>();

            // the multiple new form
            Container.RegisterType<object, CaptureMultipleNewEntryViewViewModel>(FormNameConstants.Entries.MultipleNewEntry.ViewName);
            Container.RegisterType<ICaptureMultipleNewEntryView, CaptureMultipleNewEntryView>();
        }
    }
}
