using HappyDogShow.Data;
using HappyDogShow.Infrastructure.WPF;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.ViewModels
{
    public class ExploreDogsViewViewModel : ListViewViewModelBase<IDogRegistration>, IExploreDogsViewViewModel
    {
        private IDogRegistrationService _service;
        private IBreedEntryService _beedEntryService;

        public IDogRegistration SelectedDogRegistration
        {
            get { return SelectedItem; }
        }

        private string registrationNumberFilterCriteria;
        public string RegistrationNumberFilterCriteria
        {
            get { return registrationNumberFilterCriteria; }
            set 
            { 
                SetProperty(ref registrationNumberFilterCriteria, value);
            }
        }

        private ObservableCollection<IBreedEntryEntityWithAdditionalData> breedEntries;
        public ObservableCollection<IBreedEntryEntityWithAdditionalData> BreedEntries
        {
            get { return breedEntries; }
            set { SetProperty(ref breedEntries, value); }
        }

        private IBreedEntryEntityWithAdditionalData selectedBreedEntry;
        public IBreedEntryEntityWithAdditionalData SelectedBreedEntry
        {
            get { return selectedBreedEntry; }
            set { SetProperty(ref selectedBreedEntry, value); }
        }

        public ExploreDogsViewViewModel(IExploreDogsView view, IDogRegistrationService service, IBreedEntryService breedEntryService)
            : base(view)
        {
            _service = service;
            _beedEntryService = breedEntryService;

            RegistrationNumberFilterCriteria = "";
            BreedEntries = new ObservableCollection<IBreedEntryEntityWithAdditionalData>();
        }

        public async override void Prepare()
        {
            Items.Clear();

            List<IDogRegistration> items = await _service.GetListAsync<DogRegistrationDetail>();

            items.ForEach(i => Items.Add(i));
        }

        public override void OnSelectedItemChanged()
        {
            OnPropertyChanged("SelectedDogRegistration");
            LoadEntriesForDog();
        }

        private async void LoadEntriesForDog()
        {
            BreedEntries.Clear();

            if (SelectedDogRegistration == null)
                return;

            List<IBreedEntryEntityWithAdditionalData> items = await _beedEntryService.GetBreedEntryListAsync<BreedEntryEntityWithAdditionalData>(SelectedDogRegistration);

            items.ForEach(i => BreedEntries.Add(i));
        }
    }
}
