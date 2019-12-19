using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.SharedModels;

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
