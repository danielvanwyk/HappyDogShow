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
    public class CaptureMultipleNewEntryViewViewModel : NavigateableBindableViewModelBase, ICaptureMultipleNewEntryViewViewModel, INavigationAware, ICancelAwareViewViewModel
    {
        private IDogShowService _dogShowService;

        private IDogRegistration selectedDogRegistration;
        public IDogRegistration SelectedDogRegistration
        {
            get { return selectedDogRegistration; }
            set { SetProperty(ref selectedDogRegistration, value); }
        }

        private List<IDogShowEntity> dogShowList;

        public List<IDogShowEntity> DogShowList
        {
            get { return dogShowList; }
            set { SetProperty(ref dogShowList, value); }
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

        public CaptureMultipleNewEntryViewViewModel(ICaptureMultipleNewEntryView view, IDogShowService dogShowService)
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

            CurrentEntity = new MultipleBreedEntry();
            foreach (IDogShowEntity dogShow in DogShowList)
            {
                BreedEntry newEntry = new BreedEntry();
                newEntry.ShowId = dogShow.Id;
                newEntry.DogShow = dogShow;
                newEntry.Dog = SelectedDogRegistration;

                newEntry.Classes = await _dogShowService.GetListOfClassEntriesForNewBreedEntryAsync<BreedClassEntryEntityWithClassDetailForSelection>();

                newEntry.Classes.ForEach(c =>
                {
                    (c as BreedClassEntryEntityWithClassDetailForSelection).IsOutOfAgeRange = DetermineIfDogAgeIsOutOfRangeBasedOnClassMinAndMaxDates(newEntry.DogAgeInMonthsAtTimeOfShow, c.MinAgeInMonths, c.MaxAgeInMonths);
                });

                (CurrentEntity as MultipleBreedEntry).BreedEntries.Add(newEntry);
                (CurrentEntity as MultipleBreedEntry).NotifyEntriesChanged();
            }
        }

        public static bool DetermineIfDogAgeIsOutOfRangeBasedOnClassMinAndMaxDates(int dogAgeInMonthsAtTimeOfShow, int minAgeInMonths, int maxAgeInMonths)
        {
            bool result = false;

            if ((minAgeInMonths == 0) && (maxAgeInMonths == 0))
                result = false;
            else
            {
                if ((dogAgeInMonthsAtTimeOfShow >= minAgeInMonths) && (dogAgeInMonthsAtTimeOfShow <= maxAgeInMonths))
                    result = false;
                else
                    result = true;
            }

            return result;
        }
    }
}
