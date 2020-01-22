using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Infrastructure.WPF.Infrastructure;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
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
    public class BreedResultsViewViewModel : NavigateableBindableViewModelBase, IBreedResultsViewViewModel, ICRUDActionAwareViewViewModel
    {
        private IDogShowService _dogShowService;
        private IBreedGroupService _breedGroupService;
        private IBreedService _breedService;
        private IBreedChallengeResultsService _breedChallengeResultsService;

        public BreedResultsViewViewModel(IBreedResultsView view, IDogShowService dogShowService, IBreedService breedService, IBreedGroupService breedGroupService, IBreedChallengeResultsService breedChallengeResultsService) 
            : base(view)
        {
            _dogShowService = dogShowService;
            _breedGroupService = breedGroupService;
            _breedService = breedService;
            _breedChallengeResultsService = breedChallengeResultsService;
        }

        private string cRUDActionMessage;
        public string CRUDActionMessage 
        {
            get { return cRUDActionMessage; }
            set { SetProperty(ref cRUDActionMessage, value); }
        }


        private IChallengeResultCollection<IChallengeResult> challengeResults;
        public IChallengeResultCollection<IChallengeResult> ChallengeResults
        {
            get { return challengeResults; }
            set { SetProperty(ref challengeResults, value); }
        }

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
                LoadResultsList();
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
                LoadResultsList();
            }
        }

        private IBreedEntity selectedBreed;
        public IBreedEntity SelectedBreed
        {
            get { return selectedBreed; }
            set
            {
                SetProperty(ref selectedBreed, value);
                LoadResultsList();
            }
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

        private async void LoadResultsList()
        {
            ChallengeResults.Results.Clear();

            if (selectedDogShow == null)
                return;

            if (selectedBreed == null)
                return;

            List<IBreedChallengeResult> challengeResults = await _breedChallengeResultsService.GetListAsync<BreedChallengeResult>(selectedDogShow.Id, selectedBreed.Id);

            challengeResults.ForEach(result => ChallengeResults.Results.Add(result));
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();
            BreedGroupList = await _breedGroupService.GetListAsync<BreedGroupDetail>();
            BreedList = new List<IBreedEntity>();

            ChallengeResults = new ChallengeResultCollection<IChallengeResult>();

            CurrentEntity = ChallengeResults as ValidatableBindableBase;
        }


    }
}
