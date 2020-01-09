using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.FormNameConstants;
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
        private SaveMultipleNewBreedEntryEntityCommandExecutor _saveMultipleNewBreedEntryEntityCommandExecutor;
        private ShowEntryByClassListCommandExecutor _showEntryByClassListCommandExecutor;
        private DeleteExistingBreedEntityCommandExecutor deleteExistingBreedEntityCommandExecutor;

        private ShowHandlerEntryListCommandExecutor showHandlerEntryListCommandExecutor;
        private ShowViewToCaptureNewHandlerEntryCommandExecutor showViewToCaptureNewHandlerEntryCommandExecutor;
        private SaveMultipleNewHandlerEntryEntityCommandExecutor saveMultipleNewHandlerEntryEntityCommandExecutor;
        private DeleteExistingHandlerEntityCommandExecutor deleteExistingHandlerEntityCommandExecutor;
        private ShowViewToEditHandlerEntryCommandExecutor showViewToEditHandlerEntryCommandExecutor;
        private SaveExistingHandlerEntryEntityCommandExecutor saveExistingHandlerEntryEntityCommandExecutor;

        private ShowBreedEntryResultsCaptureViewCommandExecutor showBreedEntryResultsCaptureViewCommandExecutor;
        private SaveBreedEntryClassEntryListCommandExecutor saveBreedEntryClassEntryListCommandExecutor;

        private ShowBreedResultsCommandExecutor showBreedResultsCommandExecutor;
        private SaveBreedResultsCommandExecutor saveBreedResultsCommandExecutor;

        private ShowBreedGroupResultsCommandExecutor showBreedGroupResultsCommandExecutor;
        private SaveBreedGroupResultsCommandExecutor saveBreedGroupResultsCommandExecutor;

        private ShowInShowResultsCommandExecutor showInShowResultsCommandExecutor;
        private SaveInShowResultsCommandExecutor saveInShowResultsCommandExecutor;

        private ShowHandlerResultsCommandExecutor showHandlerResultsCommandExecutor;
        private SaveHandlerResultsCommandExecutor saveHandlerResultsCommandExecutor;

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
            _saveMultipleNewBreedEntryEntityCommandExecutor = Container.Resolve<SaveMultipleNewBreedEntryEntityCommandExecutor>();
            _showEntryByClassListCommandExecutor = Container.Resolve<ShowEntryByClassListCommandExecutor>();
            deleteExistingBreedEntityCommandExecutor = Container.Resolve<DeleteExistingBreedEntityCommandExecutor>();

            showHandlerEntryListCommandExecutor = Container.Resolve<ShowHandlerEntryListCommandExecutor>();
            showViewToCaptureNewHandlerEntryCommandExecutor = Container.Resolve<ShowViewToCaptureNewHandlerEntryCommandExecutor>();
            saveMultipleNewHandlerEntryEntityCommandExecutor = Container.Resolve<SaveMultipleNewHandlerEntryEntityCommandExecutor>();
            deleteExistingHandlerEntityCommandExecutor = Container.Resolve<DeleteExistingHandlerEntityCommandExecutor>();
            showViewToEditHandlerEntryCommandExecutor = Container.Resolve<ShowViewToEditHandlerEntryCommandExecutor>();
            saveExistingHandlerEntryEntityCommandExecutor = Container.Resolve<SaveExistingHandlerEntryEntityCommandExecutor>();

            showBreedEntryResultsCaptureViewCommandExecutor = Container.Resolve<ShowBreedEntryResultsCaptureViewCommandExecutor>();
            saveBreedEntryClassEntryListCommandExecutor = Container.Resolve<SaveBreedEntryClassEntryListCommandExecutor>();

            showBreedResultsCommandExecutor = Container.Resolve<ShowBreedResultsCommandExecutor>();
            saveBreedResultsCommandExecutor = Container.Resolve<SaveBreedResultsCommandExecutor>();

            showBreedGroupResultsCommandExecutor = Container.Resolve<ShowBreedGroupResultsCommandExecutor>();
            saveBreedGroupResultsCommandExecutor = Container.Resolve<SaveBreedGroupResultsCommandExecutor>();

            showInShowResultsCommandExecutor = Container.Resolve<ShowInShowResultsCommandExecutor>();
            saveInShowResultsCommandExecutor = Container.Resolve<SaveInShowResultsCommandExecutor>();

            showHandlerResultsCommandExecutor = Container.Resolve<ShowHandlerResultsCommandExecutor>();
            saveHandlerResultsCommandExecutor = Container.Resolve<SaveHandlerResultsCommandExecutor>();
        }

        protected override void RegisterTypes()
        {
            // main menu
            Container.RegisterType<IEntriesMainMenuView, EntriesMainMenuView>();
            Container.RegisterType<IEntriesMainMenuViewViewModel, EntriesMainMenuViewViewModel>();

            RegisterBreedEntryForms();

            RegisterHandlerEntryForms();

            RegisterResultsForms();
        }

        private void RegisterBreedEntryForms()
        {
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

            // the entries by class list
            Container.RegisterType<object, ExploreEntriesByClassViewViewModel>(FormNameConstants.Entries.EntriesByClassList.ViewName);
            Container.RegisterType<IExploreEntriesByClassView, ExploreEntriesByClassView>();
        }

        private void RegisterHandlerEntryForms()
        {
            // the entries list
            Container.RegisterType<object, ExploreHandlerEntriesViewViewModel>(HandlerFormNameConstants.HandlerEntries.EntriesList.ViewName);
            Container.RegisterType<IExploreHandlerEntriesView, ExploreHandlerEntriesView>();

            // the edit form
            Container.RegisterType<object, EditHandlerEntryViewViewModel>(HandlerFormNameConstants.HandlerEntries.EditEntry.ViewName);
            Container.RegisterType<IEditHandlerEntryView, EditHandlerEntryView>();

            // the multiple new form
            Container.RegisterType<object, CaptureMultipleNewHandlerEntryViewViewModel>(HandlerFormNameConstants.HandlerEntries.MultipleNewEntry.ViewName);
            Container.RegisterType<ICaptureMultipleNewHandlerEntryView, CaptureMultipleNewHandlerEntryView>();
        }

        private void RegisterResultsForms()
        {
            // the results form
            Container.RegisterType<object, BreedEntryResultsViewViewModel>(FormNameConstants.BreedEntryResults.CaptureResults.ViewName);
            Container.RegisterType<IBreedEntryResultsView, BreedEntryResultsView>();

            // the breed results form
            Container.RegisterType<object, BreedResultsViewViewModel>(FormNameConstants.Results.Breed.ViewName);
            Container.RegisterType<IBreedResultsView, BreedResultsView>();

            // the breedgroup results form
            Container.RegisterType<object, BreedGroupResultsViewViewModel>(FormNameConstants.Results.BreedGroup.ViewName);
            Container.RegisterType<IBreedGroupResultsView, BreedGroupResultsView>();

            // the in show results form
            Container.RegisterType<object, InShowResultsViewViewModel>(FormNameConstants.Results.InShow.ViewName);
            Container.RegisterType<IInShowResultsView, InShowResultsView>();

            // the handler results form
            Container.RegisterType<object, HandlerResultsViewViewModel>(FormNameConstants.Results.Handler.ViewName);
            Container.RegisterType<IHandlerResultsView, HandlerResultsView>();
        }

    }
}
