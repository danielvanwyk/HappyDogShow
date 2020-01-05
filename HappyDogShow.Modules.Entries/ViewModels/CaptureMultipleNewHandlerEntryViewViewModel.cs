using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Modules.Entries.Models;
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
    public class CaptureMultipleNewHandlerEntryViewViewModel : NavigateableBindableViewModelBase, ICaptureMultipleNewHandlerEntryViewViewModel, INavigationAware, ICancelAwareViewViewModel
    {
        private IDogShowService _dogShowService;
        private IDogRegistrationService _dogRegistrationService;
        private IHandlerEntryService _handlerEntryService;

        private IHandlerRegistration selectedHandlerRegistration;
        public IHandlerRegistration SelectedHandlerRegistration
        {
            get { return selectedHandlerRegistration; }
            set { SetProperty(ref selectedHandlerRegistration, value); }
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

        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set
            {
                SetProperty(ref currentEntity, value);
            }
        }

        public string CancelNavigateToViewName { get { return FormNameConstants.Entries.EntriesList.ViewName; } }

        public CaptureMultipleNewHandlerEntryViewViewModel(ICaptureMultipleNewHandlerEntryView view, IDogShowService dogShowService, IDogRegistrationService dogRegistrationService, IHandlerEntryService handlerEntryService)
            : base(view)
        {
            _dogShowService = dogShowService;
            _dogRegistrationService = dogRegistrationService;
            _handlerEntryService = handlerEntryService;
        }

        public override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            SelectedHandlerRegistration = navigationContext.Parameters["entity"] as IHandlerRegistration;
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();

            var data = await _dogRegistrationService.GetListAsync<DogRegistrationDetail>();
            var orderedData = from d in data
                               orderby d.RegisrationNumber ascending
                               select d;
            DogRegistrations = orderedData.ToList();

            HandlerClasses = await _handlerEntryService.GetHandlerClassListAsync<HandlerClassEntity>();

            CurrentEntity = new MultipleHandlerEntry();
            foreach (IDogShowEntity dogShow in DogShowList)
            {
                HandlerEntry newEntry = new HandlerEntry();
                newEntry.DogShow = dogShow;
                newEntry.Handler = SelectedHandlerRegistration;

                (CurrentEntity as MultipleHandlerEntry).HandlerEntries.Add(newEntry);
                (CurrentEntity as MultipleHandlerEntry).NotifyEntriesChanged();
            }
        }
    }
}
