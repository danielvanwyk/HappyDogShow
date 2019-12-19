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

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class CaptureNewEntryViewViewModel : NavigateableBindableViewModelBase, ICaptureNewEntryViewViewModel, INavigationAware
    {
        private IDogShowService _dogShowService;

        private List<IDogShowEntity> dogShowList;
        public List<IDogShowEntity> DogShowList 
        { 
            get { return dogShowList; }
            set { SetProperty(ref dogShowList, value); }
        }

        private string registrationNumber;
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set 
            { 
                SetProperty(ref registrationNumber, value);
                PerformRegistrationNumberLookup();
            }
        }

        private bool isSearchingDogRegistration;
        public bool IsSearchingDogRegistration
        {
            get { return isSearchingDogRegistration; }
            set { SetProperty(ref isSearchingDogRegistration, value); }
        }

        private async void PerformRegistrationNumberLookup()
        {
            IsSearchingDogRegistration = true;
            await Task.Delay(TimeSpan.FromSeconds(3));
            IsSearchingDogRegistration = false;
        }

        public CaptureNewEntryViewViewModel(ICaptureNewEntryView view, IDogShowService dogShowService) 
            : base(view)
        {
            _dogShowService = dogShowService;
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();

        }
    }
}
