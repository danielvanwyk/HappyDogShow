using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class CaptureNewDogShowViewViewModel : NavigateableBindableViewModelBase, ICaptureNewDogShowViewViewModel
    {
        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        public CaptureNewDogShowViewViewModel(ICaptureNewDogShowView view) 
            : base(view)
        {
        }

        public override void Prepare()
        {
            CurrentEntity = new DogShowDetail();
        }
    }
}
