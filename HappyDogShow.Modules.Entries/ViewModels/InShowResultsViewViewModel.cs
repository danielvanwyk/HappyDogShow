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
    public class InShowResultsViewViewModel : NavigateableBindableViewModelBase, IInShowResultsViewViewModel, ICRUDActionAwareViewViewModel
    {
        private IDogShowService _dogShowService;
        private IShowChallengeService _inShowChallengeService;
        private IInShowChallengeResultsService _inShowChallengeResultsService;

        public InShowResultsViewViewModel(IInShowResultsView view, IDogShowService dogShowService, IInShowChallengeResultsService inShowChallengeResultsService, IShowChallengeService inShowChallengeService)
            : base(view)
        {
            _dogShowService = dogShowService;
            _inShowChallengeResultsService = inShowChallengeResultsService;
            _inShowChallengeService = inShowChallengeService;
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

        private List<IShowChallengeEntity> challengeList;
        public List<IShowChallengeEntity> ChallengeList
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
                LoadChallengeList();
                LoadResultsList();
            }
        }

        private IShowChallengeEntity selectedChallenge;
        public IShowChallengeEntity SelectedChallenge
        {
            get { return selectedChallenge; }
            set
            {
                SetProperty(ref selectedChallenge, value);
                LoadResultsList();
            }
        }

        private async void LoadChallengeList()
        {
            if (selectedDogShow == null)
                return;

            ChallengeList = new List<IShowChallengeEntity>();
            ChallengeList = await _inShowChallengeService.GetListAsync<ShowChallengeEntity>(selectedDogShow.Id);
        }

        private async void LoadResultsList()
        {
            ChallengeResults.Results.Clear();

            if (selectedDogShow == null)
                return;

            if (selectedChallenge == null)
                return;

            List<IInShowChallengeResult> challengeResults = await _inShowChallengeResultsService.GetListAsync<InShowChallengeResult>(selectedDogShow.Id, selectedChallenge.ChallengeId);

            challengeResults.ForEach(result => ChallengeResults.Results.Add(result));
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();
            ChallengeList = null; 

            ChallengeResults = new ChallengeResultCollection<IChallengeResult>();

            CurrentEntity = ChallengeResults as ValidatableBindableBase;
        }


    }
}
