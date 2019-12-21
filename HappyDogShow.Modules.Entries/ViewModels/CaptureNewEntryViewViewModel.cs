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



        private List<IBreedClassEntryEntityWithClassDetail> classes;
        public List<IBreedClassEntryEntityWithClassDetail> Classes
        {
            get { return classes; }
            set { SetProperty(ref classes, value); }
        }

        public CaptureNewEntryViewViewModel(ICaptureNewEntryView view, IDogShowService dogShowService) 
            : base(view)
        {
            _dogShowService = dogShowService;
        }

        public async override void Prepare()
        {
            DogShowList = await _dogShowService.GetDogShowListAsync<DogShowDetail>();

            Classes = await _dogShowService.GetListOfClassEntriesForNewBreedEntryAsync<BreedClassEntryEntityWithClassDetailForSelection>();
        }
    }
}
