using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.ViewModels
{
    public class CaptureNewDogViewViewModel : NavigateableBindableViewModelBase, ICaptureNewDogViewViewModel
    {
        private IGenderService _genderService;
        private IBreedService _breedService;
        private IGlobalContextService _globalContextService;

        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        private List<IGenderEntity> genderList;
        public List<IGenderEntity> GenderList
        {
            get { return genderList; }
            set { SetProperty(ref genderList, value); }
        }

        private List<IBreedEntity> breedList;
        public List<IBreedEntity> BreedList
        {
            get { return breedList; }
            set { SetProperty(ref breedList, value); }
        }

        private IBreedEntity selectedBreed;
        public IBreedEntity SelectedBreed
        {
            get { return selectedBreed; }
            set 
            { 
                SetProperty(ref selectedBreed, value);
                try
                {
                    (CurrentEntity as IDogRegistration).BreedName = selectedBreed.Name;
                }
                catch { }
            }
        }

        private bool rememberRegisteredOwnerDetails;
        public bool RememberRegisteredOwnerDetails
        {
            get { return rememberRegisteredOwnerDetails; }
            set { SetProperty(ref rememberRegisteredOwnerDetails, value); }
        }

        public CaptureNewDogViewViewModel(ICaptureNewDogView view, IGenderService genderService, IBreedService breedService, IGlobalContextService globalContextService)
            : base(view)
        {
            _genderService = genderService;
            _breedService = breedService;
            _globalContextService = globalContextService;
        }

        public async override void Prepare()
        {
            CurrentEntity = new DogRegistrationDetail();

            IDogRegistration entity = CurrentEntity as IDogRegistration;
            if (entity != null)
            {
                entity.RegisteredOwnerSurname = _globalContextService.RegisteredOwnerSurname;
                entity.RegisteredOwnerTitle = _globalContextService.RegisteredOwnerTitle;
                entity.RegisteredOwnerInitials = _globalContextService.RegisteredOwnerInitials;
                entity.RegisteredOwnerAddress = _globalContextService.RegisteredOwnerAddress;
                entity.RegisteredOwnerPostalCode = _globalContextService.RegisteredOwnerPostalCode;
                entity.RegisteredOwnerKUSANo = _globalContextService.RegisteredOwnerKUSANo;
                entity.RegisteredOwnerTel = _globalContextService.RegisteredOwnerTel;
                entity.RegisteredOwnerCell = _globalContextService.RegisteredOwnerCell;
                entity.RegisteredOwnerFax = _globalContextService.RegisteredOwnerFax;
                entity.RegisteredOwnerEmail = _globalContextService.RegisteredOwnerEmail;
            }

            GenderList = await _genderService.GetListAsync<GenderDetail>();
            BreedList = await _breedService.GetListAsync<BreedDetail>();
        }
    }
}
