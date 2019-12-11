using HappyDogShow.Data;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Modules.Shows.Models;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class ExploreShowsViewViewModel : NavigateableBindableViewModelBase, IExploreShowsViewViewModel
    {
        private ObservableCollection<IDogShowEntity> showList;
        public ObservableCollection<IDogShowEntity> ShowList
        {
            get { return showList; }
            set { SetProperty(ref showList, value); }
        }

        private IDogShowEntity selectedDogShow;
        public IDogShowEntity SelectedDogShow 
        {
            get { return selectedDogShow; }
            set { SetProperty(ref selectedDogShow, value); }
        }
        public ExploreShowsViewViewModel(IExploreShowsView view) : base(view)
        {
            ShowList = new ObservableCollection<IDogShowEntity>();
        }

        public override void Prepare()
        {
            ShowList.Clear();
            using (var ctx = new HappyDogShowContext())
            {
                var shows = from d in ctx.DogShows
                           select d;

                foreach (DogShow ds in shows)
                {
                    ShowList.Add(new DogShowDetail()
                    {
                        Id = ds.ID,
                        DogShowName = ds.Name,
                        ShowDate = ds.ShowDate
                    });
                }
            }
        }
    }
}
