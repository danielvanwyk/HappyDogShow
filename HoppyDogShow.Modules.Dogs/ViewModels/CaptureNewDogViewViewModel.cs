using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.ViewModels
{
    public class CaptureNewDogViewViewModel : NavigateableBindableViewModelBase, ICaptureNewDogViewViewModel
    {
        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        public CaptureNewDogViewViewModel(ICaptureNewDogView view)
            : base(view)
        {
        }

        public override void Prepare()
        {
            CurrentEntity = new DogRegistrationDetail();
        }
    }
}
