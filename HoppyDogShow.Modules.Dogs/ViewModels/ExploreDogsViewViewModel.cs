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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.ViewModels
{
    public class ExploreDogsViewViewModel : ListViewViewModelBase<IDogRegistration>, IExploreDogsViewViewModel
    {
        private IDogRegistrationService _service;

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

        public ExploreDogsViewViewModel(IExploreDogsView view, IDogRegistrationService service)
            : base(view)
        {
            _service = service;
            RegistrationNumberFilterCriteria = "";
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
        }
    }
}
