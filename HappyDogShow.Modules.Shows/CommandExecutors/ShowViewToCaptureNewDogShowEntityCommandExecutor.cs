using HappyDogShow.Infrastructure;
using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Shows.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.CommandExecutors
{
    public class ShowViewToCaptureNewDogShowEntityCommandExecutor : NavigateToEntityViewCommandExecutor<IDogShowEntity>
    {
        public ShowViewToCaptureNewDogShowEntityCommandExecutor(IRegionManager regionManager)
            : base (DogShowEntityCRUDCommands.ShowViewToCaptureNewDogShowEntityCommand, regionManager, FormNameConstants.Shows.NewDogShow.ViewName)
        {
        }
    }
}
