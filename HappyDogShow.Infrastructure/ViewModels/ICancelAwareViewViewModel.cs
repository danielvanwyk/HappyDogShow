using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.ViewModels
{
    public interface ICancelAwareViewViewModel
    {
        string CancelNavigateToViewName { get; }
    }
}
