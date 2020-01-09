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
    public class EditHandlerEntryViewViewModel : NavigateableBindableViewModelBase, IEditHandlerEntryViewViewModel
    {
        private IDogShowService _dogShowService;
        private IHandlerEntryService _handlerEntryService;
        private IDogRegistrationService _dogRegistrationService;
        private IHandlerRegistrationService _handlerRegistrationService;
        private IHandlerEntryEntityWithAdditionalData data;

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

        private List<IHandlerClassEntity> handlerClassList;
        public List<IHandlerClassEntity> HandlerClasses
        {
            get { return handlerClassList; }
            set { SetProperty(ref handlerClassList, value); }
        }

        private List<IDogRegistration> dogRegistrations;
        public List<IDogRegistration> DogRegistrations
        {
            get { return dogRegistrations; }
            set { SetProperty(ref dogRegistrations, value); }
        }

        private IHandlerRegistration selectedHandlerRegistration;
        public IHandlerRegistration SelectedHandlerRegistration
        {
            get { return selectedHandlerRegistration; }
            set { SetProperty(ref selectedHandlerRegistration, value); }
        }

        public IDogRegistration SelectedDogRegistration
        {
            get { return (CurrentEntity as HandlerEntry).Dog; }
            set 
            {
                (CurrentEntity as HandlerEntry).Dog = value;
                OnPropertyChanged("SelectedDogRegistration");
            }
        }

        public IDogShowEntity SelectedDogShow
        {
            get { return (CurrentEntity as HandlerEntry).DogShow; }
            set
            {
                (CurrentEntity as HandlerEntry).DogShow = value;
                OnPropertyChanged("SelectedDogShow");
            }
        }

        public IHandlerClassEntity SelectedHandlerClass
        {
            get { return (CurrentEntity as HandlerEntry).Class; }
            set
            {
                (CurrentEntity as HandlerEntry).Class = value;
                OnPropertyChanged("SelectedHandlerClass");
            }
        }

        public EditHandlerEntryViewViewModel(IEditHandlerEntryView view, IDogShowService dogShowService, IHandlerRegistrationService handlerRegistrationService, IHandlerEntryService handlerEntryService, IDogRegistrationService dogRegistrationService)
            : base(view)
        {
            _dogShowService = dogShowService;
            _handlerEntryService = handlerEntryService;
            _dogRegistrationService = dogRegistrationService;
            _handlerRegistrationService = handlerRegistrationService;
        }

        public override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            IHandlerEntryEntityWithAdditionalData parmdata = navigationContext.Parameters["entity"] as IHandlerEntryEntityWithAdditionalData;
            if (parmdata != null)
            {
                data = parmdata;
            }
        }

        public async override void Prepare()
        {
            CurrentEntity = new HandlerEntry()
            {
                Id = data.Id,
                Handler = SelectedHandlerRegistration,
                Number = data.EntryNumber
            };

            SelectedHandlerRegistration = await _handlerRegistrationService.GetHandlerRegistrationAsync<HandlerRegistrationDetail>(data.HandlerId);

            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();

            var rawdata = await _dogRegistrationService.GetListAsync<DogRegistrationDetail>();
            var orderedData = from d in rawdata
                              orderby d.RegisrationNumber ascending
                              select d;
            DogRegistrations = orderedData.ToList();

            HandlerClasses = await _handlerEntryService.GetHandlerClassListAsync<HandlerClassEntity>();

            SelectedDogShow = DogShowList.Where(d => d.Id == data.ShowId).First();
            SelectedDogRegistration = DogRegistrations.Where(d => d.Id == data.DogId).First();
            SelectedHandlerClass = HandlerClasses.Where(d => d.Name == data.EnteredClassName).First();
        }
    }
}
