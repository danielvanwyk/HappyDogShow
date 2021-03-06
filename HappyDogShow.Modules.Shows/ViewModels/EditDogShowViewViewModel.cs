﻿using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;

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

        public EditDogShowViewViewModel(IEditDogShowView view, IDogShowService service)
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
