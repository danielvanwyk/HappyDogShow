using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Dogs.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    class ShowViewToEditDogEntityCommandExecutor : NavigateToEntityEditViewCommandExecutor<IDogRegistration>
    {
        public ShowViewToEditDogEntityCommandExecutor(IRegionManager regionManager)
            : base(DogEntityCRUDCommands.ShowViewToEditEntityCommand, regionManager, FormNameConstants.Dogs.EditDog.ViewName)
        {
        }
    }
}
