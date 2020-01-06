using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Modules.Entries.Models;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class BreedEntryResultsViewViewModel : NavigateableBindableViewModelBase, IBreedEntryResultsViewViewModel
    {
        private IDogShowService _dogShowService;
        private IBreedGroupService _breedGroupService;
        private IBreedService _breedService;
        private IBreedEntryService _breedEntryService;

        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set
            {
                SetProperty(ref currentEntity, value);
            }
        }

        private List<IDogShowEntity> dogShowList;
        public List<IDogShowEntity> DogShowList
        {
            get { return dogShowList; }
            set { SetProperty(ref dogShowList, value); }
        }

        private List<IBreedGroupEntity> breedGroupList;
        public List<IBreedGroupEntity> BreedGroupList
        {
            get { return breedGroupList; }
            set { SetProperty(ref breedGroupList, value); }
        }

        private List<IBreedEntity> breedList;
        public List<IBreedEntity> BreedList
        {
            get { return breedList; }
            set { SetProperty(ref breedList, value); }
        }

        private IDogShowEntity selectedDogShow;
        public IDogShowEntity SelectedDogShow
        {
            get { return selectedDogShow; }
            set 
            { 
                SetProperty(ref selectedDogShow, value);
                SelectedBreedGroup = null;
                SelectedBreed = null;

                LoadBreedListForBreedGroupAndDogShow();
                LoadEntryListForBreedAndDogShow();
            }
        }

        private IBreedGroupEntity selectedBreedGroup;
        public IBreedGroupEntity SelectedBreedGroup
        {
            get { return selectedBreedGroup; }
            set 
            { 
                SetProperty(ref selectedBreedGroup, value);
                SelectedBreed = null;
                LoadBreedListForBreedGroupAndDogShow();
                LoadEntryListForBreedAndDogShow();
            }
        }

        private IBreedEntity selectedBreed;
        public IBreedEntity SelectedBreed
        {
            get { return selectedBreed; }
            set 
            { 
                SetProperty(ref selectedBreed, value);
                LoadEntryListForBreedAndDogShow();
            }
        }


        public BreedEntryResultsViewViewModel(IBreedEntryResultsView view, IDogShowService dogShowService, IBreedService breedService, IBreedGroupService breedGroupService, IBreedEntryService breedEntryService) 
            : base(view)
        {
            _dogShowService = dogShowService;
            _breedGroupService = breedGroupService;
            _breedService = breedService;
            _breedEntryService = breedEntryService;
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();
            BreedGroupList = await _breedGroupService.GetListAsync<BreedGroupDetail>();
            BreedList = new List<IBreedEntity>();
            CurrentEntity = new MultipleBreedEntryClassEntry();
        }

        private async void LoadBreedListForBreedGroupAndDogShow()
        {
            if (selectedDogShow == null)
                return;

            if (selectedBreedGroup == null)
                return;

            BreedList = await _breedService.GetListForGroupAndShowAsync<BreedDetail>(selectedDogShow.Id, selectedBreedGroup.Id);
            SelectedBreed = null;
        }

        private async void LoadEntryListForBreedAndDogShow()
        {
            (CurrentEntity as IMultipleBreedEntryClassEntry).BreedClassEntries.Clear();

            if (selectedDogShow == null)
                return;

            if (selectedBreedGroup == null)
                return;

            if (selectedBreed == null)
                return;

            var data = await _breedEntryService.GetBreedEntryClassEntryListAsync<BreedEntryClassEntry>(selectedDogShow.Id, selectedBreed.Id);

            data.ForEach(d => (CurrentEntity as IMultipleBreedEntryClassEntry).BreedClassEntries.Add(d));
        }

    }
}
