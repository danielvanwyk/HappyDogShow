using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.WPF.Infrastructure
{
    public interface IViewViewModel
    {
        IView View { get; set; }
        bool IsBusy { get; set; }
    }
}
