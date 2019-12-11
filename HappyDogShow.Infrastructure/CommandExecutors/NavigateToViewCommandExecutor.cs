using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.CommandExecutors
{
    public class NavigateToViewCommandExecutor
    {
        protected IRegionManager _regionManager;
        private DelegateCommand commandHandler { get; set; }
        private string viewName;

        public NavigateToViewCommandExecutor(CompositeCommand command, IRegionManager regionManager, string viewToNavigateToName)
        {
            _regionManager = regionManager;
            viewName = viewToNavigateToName;
            commandHandler = new DelegateCommand(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private void ExecuteCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, viewName,
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                    // put a breakpoint here and checkout what NavigationResult contains
                });
        }

    }
}
