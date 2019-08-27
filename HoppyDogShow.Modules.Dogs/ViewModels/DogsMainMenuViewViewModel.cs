using HappyDogShow.Infrastructure.WPF;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using HappyDogShow.Modules.Dogs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.ViewModels
{
    public class DogsMainMenuViewViewModel : BindableViewModelBase, IDogsMainMenuViewViewModel
    {
        public DogsMainMenuViewViewModel(IDogsMainMenuView view) : base(view)
        {
        }
    }
}
