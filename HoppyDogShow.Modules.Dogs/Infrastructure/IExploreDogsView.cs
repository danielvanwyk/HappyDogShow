using HappyDogShow.Infrastructure.WPF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.Infrastructure
{
    public interface IExploreDogsView : IView
    {
        void PerformFiltering();
    }
}
