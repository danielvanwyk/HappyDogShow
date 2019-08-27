using HappyDogShow.Infrastructure.WPF.Infrastructure;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.WPF.ViewModels
{
    public class BindableViewModelBase : BindableBase, IViewViewModel, IBusyAwareViewModel
    {
        public Infrastructure.IView View { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public BindableViewModelBase(Infrastructure.IView view)
        {
            View = view;
            View.ViewModel = this;
        }

    }
}
