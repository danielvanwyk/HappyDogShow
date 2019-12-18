using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class EditDogShowViewViewModel : NavigateableBindableViewModelBase, IEditDogShowViewViewModel
    {
        private IDogShowService _service;

        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        public EditDogShowViewViewModel(ICaptureNewDogShowView view, IDogShowService service)
            : base(view)
        {
            _service = service;
        }

        public override void GetValuesFromNavigationParameters(NavigationContext navigationContext)
        {
            CurrentEntity = navigationContext.Parameters["entity"] as ValidatableBindableBase;
        }

        public override void Prepare()
        {
            CurrentEntity.MarkEntityAsClean();
        }
    }
}
