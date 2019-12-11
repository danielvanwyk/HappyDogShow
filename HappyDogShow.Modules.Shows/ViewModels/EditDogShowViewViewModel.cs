using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class EditDogShowViewViewModel : NavigateableBindableViewModelBase, IEditDogShowViewViewModel
    {
        private ValidatableBindableBase currentEntity;
        public ValidatableBindableBase CurrentEntity
        {
            get { return currentEntity; }
            set { SetProperty(ref currentEntity, value); }
        }

        public EditDogShowViewViewModel(ICaptureNewDogShowView view)
            : base(view)
        {
        }

        public override void Prepare()
        {
            CurrentEntity = new DogShowDetail();
            (CurrentEntity as DogShowDetail).DogShowName = "boo";
        }
    }
}
