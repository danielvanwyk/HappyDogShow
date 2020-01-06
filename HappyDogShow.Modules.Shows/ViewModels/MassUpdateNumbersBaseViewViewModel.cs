using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public abstract class MassUpdateNumbersBaseViewViewModel<T> : ListViewViewModelBase<T>, IMassUpdateNumbersViewViewModel
    {
        private string statusText;
        public string StatusText
        {
            get { return statusText; }
            set { SetProperty(ref statusText, value); }
        }

        public MassUpdateNumbersBaseViewViewModel(IMassUpdateNumbersView view)
            : base(view)
        {
        }

        public async override void Prepare()
        {
            StatusText = "Loading data ...";
            await LoadData();

            StatusText = "Generating Numbers ...";
            await GenerateNumbers();

            StatusText = "Saving ...";
            await UpdateEntries();

            StatusText = "Done ...";
            await Task.Delay(TimeSpan.FromSeconds(2));

            NavigateAway();
        }

        public abstract void NavigateAway();

        public abstract Task LoadData();

        public abstract Task GenerateNumbers();

        public abstract Task UpdateEntries();
    }
}
