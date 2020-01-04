using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Handlers.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers.ViewModels
{
    public class EditHandlerViewViewModel : NavigateableBindableViewModelBase, IEditHandlerViewViewModel
    {
        private ISexService _sexService;

        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        private List<ISexEntity> sexList;
        public List<ISexEntity> SexList
        {
            get { return sexList; }
            set { SetProperty(ref sexList, value); }
        }

        public EditHandlerViewViewModel(IEditHandlerView view, ISexService sexService, IBreedService breedService)
            : base(view)
        {
            _sexService = sexService;
        }

        public async override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            SexList = await _sexService.GetListAsync<SexDetail>();

            CurrentEntity = navigationContext.Parameters["entity"] as ValidatableBindableBase;

            CurrentEntity.MarkEntityAsClean();
        }
    }
}
