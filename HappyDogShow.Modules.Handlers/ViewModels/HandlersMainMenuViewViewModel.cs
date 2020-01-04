using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Handlers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers.ViewModels
{
    public class HandlersMainMenuViewViewModel : BindableViewModelBase, IHandlersMainMenuViewViewModel
    {
        public HandlersMainMenuViewViewModel(IHandlersMainMenuView view) : base(view)
        {
        }
    }
}
