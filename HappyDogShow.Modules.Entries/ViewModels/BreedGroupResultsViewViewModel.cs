using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using System.Collections.Generic;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class BreedGroupResultsViewViewModel : NavigateableBindableViewModelBase, IBreedGroupResultsViewViewModel, ICRUDActionAwareViewViewModel
    {
        private IDogShowService _dogShowService;
        private IBreedGroupService _breedGroupService;
        private IBreedService _breedService;
        private IBreedGroupChallengeService _breedGroupChallengeService;
        private IBreedGroupChallengeResultsService _breedGroupChallengeResultsService;

        public BreedGroupResultsViewViewModel(IBreedGroupResultsView view, IDogShowService dogShowService, IBreedService breedService, IBreedGroupService breedGroupService, IBreedGroupChallengeResultsService breedGroupChallengeResultsService, IBreedGroupChallengeService breedGroupChallengeService)
            : base(view)
        {
            _dogShowService = dogShowService;
            _breedGroupService = breedGroupService;
            _breedService = breedService;
            _breedGroupChallengeResultsService = breedGroupChallengeResultsService;
            _breedGroupChallengeService = breedGroupChallengeService;
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

        private List<IBreedGroupChallengeEntity> challengeList;
        public List<IBreedGroupChallengeEntity> ChallengeList
        {
            get { return challengeList; }
            set { SetProperty(ref challengeList, value); }
        }

        private IDogShowEntity selectedDogShow;
        public IDogShowEntity SelectedDogShow
        {
            get { return selectedDogShow; }
            set
            {
                SetProperty(ref selectedDogShow, value);
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
                LoadResultsList();
            }
        }

        private IBreedGroupChallengeEntity selectedChallenge;
        public IBreedGroupChallengeEntity SelectedChallenge
        {
            get { return selectedChallenge; }
            set
            {
                SetProperty(ref selectedChallenge, value);
                LoadResultsList();
            }
        }

        private async void LoadResultsList()
        {
            ChallengeResults.Results.Clear();

            if (selectedDogShow == null)
                return;

            if (selectedBreedGroup == null)
                return;

            if (selectedChallenge == null)
                return;

            List<IChallengeResult> challengeResults = await _breedGroupChallengeResultsService.GetListAsync<BreedGroupChallengeResult>(selectedDogShow.Id, selectedBreedGroup.Id, selectedChallenge.Id);

            challengeResults.ForEach(result => ChallengeResults.Results.Add(result));
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();
            BreedGroupList = await _breedGroupService.GetListAsync<BreedGroupDetail>();
            ChallengeList = await _breedGroupChallengeService.GetListAsync<BreedGroupChallengeEntity>();

            ChallengeResults = new ChallengeResultCollection<IChallengeResult>();

            CurrentEntity = ChallengeResults as ValidatableBindableBase;
        }


    }
}
