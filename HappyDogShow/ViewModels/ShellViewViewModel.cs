using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.WPF;
using HappyDogShow.Infrastructure.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.ViewModels
{
    public class ShellViewViewModel : BindableViewModelBase, IShellViewViewModel
    {
        public ShellViewViewModel(IShellView view)
            : base(view)
        {
        }
    }
}
