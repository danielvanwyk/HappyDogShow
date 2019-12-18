using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.CommandExecutors
{
    public class NavigateToEntityEditViewCommandExecutor<T> : NavigateToEntityViewCommandExecutor<T>
    {
        public NavigateToEntityEditViewCommandExecutor(CompositeCommand command, IRegionManager regionManager, string viewToNavigateToName)
            : base(command, regionManager, viewToNavigateToName)
        {
            RequireObject = true;
        }

    }
}
