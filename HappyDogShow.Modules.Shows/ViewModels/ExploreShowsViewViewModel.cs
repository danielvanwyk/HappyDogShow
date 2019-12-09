using HappyDogShow.Data;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class ExploreShowsViewViewModel : BindableViewModelBase, IExploreShowsViewViewModel, INavigationAware
    {
        private List<DogShow> showList;
        public List<DogShow> ShowList
        {
            get { return showList; }
            set { SetProperty(ref showList, value); }
        }
        public ExploreShowsViewViewModel(IExploreShowsView view) : base(view)
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
                var shows = from d in ctx.DogShows
                           select d;

                ShowList = shows.ToList();
            }
        }
    }
}
