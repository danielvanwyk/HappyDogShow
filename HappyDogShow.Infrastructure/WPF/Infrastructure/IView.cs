using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.WPF.Infrastructure
{
    public interface IView
    {
        IViewViewModel ViewModel { get; set; }
    }
}
