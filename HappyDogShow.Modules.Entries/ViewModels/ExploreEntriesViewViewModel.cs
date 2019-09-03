using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Entries.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.ViewModels
{
    public class ExploreEntriesViewViewModel : BindableViewModelBase, IExploreEntriesViewViewModel, INavigationAware
    {
        //private List<DogRegistration> dogList;
        //public List<DogRegistration> DogList
        //{
        //    get { return dogList; }
        //    set { SetProperty(ref dogList, value); }
        //}
        public ExploreEntriesViewViewModel(IExploreEntriesView view) : base(view)
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
            //using (var ctx = new HappyDogShowContext())
            //{
            //    var dogs = from d in ctx.DogRegistrations
            //               select d;

            //    DogList = dogs.ToList();
            //}
        }
    }
}
