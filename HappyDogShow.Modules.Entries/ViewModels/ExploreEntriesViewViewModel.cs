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
    public class ExploreEntriesViewViewModel : NavigateableBindableViewModelBase, IExploreEntriesViewViewModel
    {
        public ExploreEntriesViewViewModel(IExploreEntriesView view) 
            : base(view)
        {
        }
    }
}
