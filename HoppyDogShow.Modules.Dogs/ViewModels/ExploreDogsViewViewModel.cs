using HappyDogShow.Data;
using HappyDogShow.Infrastructure.WPF;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Dogs.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.ViewModels
{
    public class ExploreDogsViewViewModel : BindableViewModelBase, IExploreDogsViewViewModel, INavigationAware
    {
        private List<DogRegistration> dogList;
        public List<DogRegistration> DogList
        {
            get { return dogList; }
            set { SetProperty(ref dogList, value); }
        }
        public ExploreDogsViewViewModel(IExploreDogsView view) : base(view)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            using (var ctx = new HappyDogShowContext())
            {
                var dogs = from d in ctx.DogRegistrations
                           select d;

                DogList = dogs.ToList();
            }
        }
    }
}
