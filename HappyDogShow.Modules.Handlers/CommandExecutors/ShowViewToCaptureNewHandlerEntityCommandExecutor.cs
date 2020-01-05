using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Infrastructure.FormNameConstants;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Handlers.CommandExecutors
{
    public class ShowViewToCaptureNewHandlerEntityCommandExecutor : NavigateToEntityCreateViewCommandExecutor<IHandlerRegistration>
    {
        public ShowViewToCaptureNewHandlerEntityCommandExecutor(IRegionManager regionManager)
            : base(HandlerEntityCRUDCommands.ShowViewToCaptureNewEntityCommand, regionManager, HandlerFormNameConstants.Handlers.NewHandler.ViewName)
        {
        }
    }
}
