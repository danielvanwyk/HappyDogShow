using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Infrastructure.FormNameConstants;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers.CommandExecutors
{
    public class ShowHandlerListCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowHandlerListCommandExecutor(IRegionManager regionManager)
            : base(HandlerListCommands.ShowHandlerListCommand, regionManager, HandlerFormNameConstants.Handlers.HandlersList.ViewName)
        {
        }
    }
}
