using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Shows.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.ViewModels
{
    public class ShowsMainMenuViewViewModel : BindableViewModelBase, IShowsMainMenuViewViewModel
    {
        public ShowsMainMenuViewViewModel(IShowsMainMenuView view) : base(view)
        {
        }
    }
}
