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
    public class ShowViewToEditHandlerEntityCommandExecutor : NavigateToEntityEditViewCommandExecutor<IHandlerRegistration>
    {
        public ShowViewToEditHandlerEntityCommandExecutor(IRegionManager regionManager)
            : base(HandlerEntityCRUDCommands.ShowViewToEditEntityCommand, regionManager, HandlerFormNameConstants.Handlers.EditHandler.ViewName)
        {
        }
    }
}
