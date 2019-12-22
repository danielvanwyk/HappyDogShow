using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class EditEntryViewViewModel : NavigateableBindableViewModelBase, IEditEntryViewViewModel
    {
        private IDogShowService _dogShowService;
        private IBreedEntryService _breedEntryService;
        private IDogRegistrationService _dogRegistrationService;
        private IBreedEntryEntityWithAdditionalData data;

        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        private List<IDogShowEntity> dogShowList;

        public List<IDogShowEntity> DogShowList
        {
            get { return dogShowList; }
            set { SetProperty(ref dogShowList, value); }
        }

        private IDogRegistration selectedDogRegistration;
        public IDogRegistration SelectedDogRegistration
        {
            get { return selectedDogRegistration; }
            set { SetProperty(ref selectedDogRegistration, value); }
        }


        public EditEntryViewViewModel(IEditEntryView view, IDogShowService dogShowService, IBreedEntryService breedEntryService, IDogRegistrationService dogRegistrationService)
            : base(view)
        {
            _dogShowService = dogShowService;
            _breedEntryService = breedEntryService;
            _dogRegistrationService = dogRegistrationService;
        }

        public override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            IBreedEntryEntityWithAdditionalData parmdata = navigationContext.Parameters["entity"] as IBreedEntryEntityWithAdditionalData;
            if (parmdata != null)
            {
                data = parmdata;
            }
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();

            SelectedDogRegistration = await _dogRegistrationService.GetDogRegistrationAsync<DogRegistrationDetail>(data.DogId);

            IBreedEntryEntity entry = await _breedEntryService.GetBreedEntryAsync<BreedEntry>(data.Id);

            entry.Classes = await _dogShowService.GetListOfClassEntriesForBreedEntryAsync<BreedClassEntryEntityWithClassDetailForSelection>(data.Id);

            entry.Dog = SelectedDogRegistration;
            CurrentEntity = (entry as BreedEntry);
            CurrentEntity.MarkEntityAsClean();
        }
    }
}
