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
    public class HandlerResultsViewViewModel : NavigateableBindableViewModelBase, IHandlerResultsViewViewModel, ICRUDActionAwareViewViewModel
    {
        private IDogShowService _dogShowService;
        private IHandlerClassService _handlerClassService;
        private IHandlerChallengeResultsService _handlerChallengeResultsService;

        public HandlerResultsViewViewModel(IHandlerResultsView view, IDogShowService dogShowService, IHandlerChallengeResultsService handlerChallengeResultsService, IHandlerClassService handlerClassService)
            : base(view)
        {
            _dogShowService = dogShowService;
            _handlerChallengeResultsService = handlerChallengeResultsService;
            _handlerClassService = handlerClassService;
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

        private List<IHandlerClassEntity> classList;
        public List<IHandlerClassEntity> ClassList
        {
            get { return classList; }
            set { SetProperty(ref classList, value); }
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

        private IHandlerClassEntity selectedClass;
        public IHandlerClassEntity SelectedClass
        {
            get { return selectedClass; }
            set
            {
                SetProperty(ref selectedClass, value);
                LoadResultsList();
            }
        }

        private async void LoadClassList()
        {
            ClassList = new List<IHandlerClassEntity>();
            ClassList = await _handlerClassService.GetHandlerClassListAsync<HandlerClassEntity>();
        }

        private async void LoadResultsList()
        {
            ChallengeResults.Results.Clear();

            if (selectedDogShow == null)
                return;

            if (selectedClass == null)
                return;

            List<IChallengeResult> challengeResults = await _handlerChallengeResultsService.GetListAsync<HandlerChallengeResult>(selectedDogShow.Id, selectedClass.Id);

            challengeResults.ForEach(result => ChallengeResults.Results.Add(result));
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();
            LoadClassList();

            ChallengeResults = new ChallengeResultCollection<IChallengeResult>();

            CurrentEntity = ChallengeResults as ValidatableBindableBase;
        }


    }
}
