using HappyDogShow.Infrastructure.Models;
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
    public class BreedResultsViewViewModel : NavigateableBindableViewModelBase, IBreedResultsViewViewModel
    {
        private IDogShowService _dogShowService;
        private IBreedGroupService _breedGroupService;
        private IBreedService _breedService;

        public BreedResultsViewViewModel(IBreedResultsView view, IDogShowService dogShowService, IBreedService breedService, IBreedGroupService breedGroupService) 
            : base(view)
        {
            _dogShowService = dogShowService;
            _breedGroupService = breedGroupService;
            _breedService = breedService;
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
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();
            BreedGroupList = await _breedGroupService.GetListAsync<BreedGroupDetail>();
            BreedList = new List<IBreedEntity>();

            IChallengeResultCollection<IChallengeResult> temp = new ChallengeResultCollection<IChallengeResult>();
            ChallengeResults = temp;

            IChallengeResult t = new BreedChallengeResult();
            t.Challenge = "CC Dog (2 points)";
            t.Placing = "";
            t.EntryNumber = "";
            t.Print = true;
            temp.Results.Add(t);

            IChallengeResult t2 = new BreedChallengeResult();
            t2.Challenge = "BOB";
            t2.Placing = "";
            t2.EntryNumber = "";
            t2.Print = true;
            temp.Results.Add(t2);

            IChallengeResult t3 = new BreedChallengeResult();
            t3.Challenge = "RBOB";
            t3.Placing = "";
            t3.EntryNumber = "";
            t3.Print = false;
            temp.Results.Add(t3);

            CurrentEntity = temp as ValidatableBindableBase;
        }


    }
}
