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

        public CaptureNewDogViewViewModel(ICaptureNewDogView view, IGenderService genderService, IBreedService breedService)
            : base(view)
        {
            _genderService = genderService;
            _breedService = breedService;
        }

        public async override void Prepare()
        {
            CurrentEntity = new DogRegistrationDetail();

            GenderList = await _genderService.GetListAsync<GenderDetail>();
            BreedList = await _breedService.GetListAsync<BreedDetail>();
        }
    }
}
