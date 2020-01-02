using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.Infrastructure.Extensions;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Infrastructure.Models;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class CaptureNewEntryViewViewModel : NavigateableBindableViewModelBase, ICaptureNewEntryViewViewModel, INavigationAware, ICancelAwareViewViewModel
    {
        private IDogShowService _dogShowService;

        private IDogRegistration selectedDogRegistration;
        public IDogRegistration SelectedDogRegistration
        {
            get { return selectedDogRegistration; }
            set { SetProperty(ref selectedDogRegistration, value); }
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

        public string CancelNavigateToViewName { get { return FormNameConstants.Entries.EntriesList.ViewName; } }

        public CaptureNewEntryViewViewModel(ICaptureNewEntryView view, IDogShowService dogShowService) 
            : base(view)
        {
            _dogShowService = dogShowService;
        }

        public override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            SelectedDogRegistration = navigationContext.Parameters["entity"] as IDogRegistration;
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();

            CurrentEntity = new BreedEntry();
            (CurrentEntity as IBreedEntryEntity).Classes = await _dogShowService.GetListOfClassEntriesForNewBreedEntryAsync<BreedClassEntryEntityWithClassDetailForSelection>();
            (CurrentEntity as IBreedEntryEntity).Dog = SelectedDogRegistration;
            CurrentEntity.MarkEntityAsClean();
        }
    }
}
