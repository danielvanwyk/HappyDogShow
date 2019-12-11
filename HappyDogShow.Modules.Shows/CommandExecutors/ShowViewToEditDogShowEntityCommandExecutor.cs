using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Shows.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.CommandExecutors
{
    class ShowViewToEditDogShowEntityCommandExecutor : NavigateToEntityViewCommandExecutor<IDogShowEntity>
    {
        public ShowViewToEditDogShowEntityCommandExecutor(IRegionManager regionManager)
            : base(DogShowEntityCRUDCommands.ShowViewToEditDogShowEntityCommand, regionManager, FormNameConstants.Shows.EditDogShow.ViewName)
        {
        }
    }
}
