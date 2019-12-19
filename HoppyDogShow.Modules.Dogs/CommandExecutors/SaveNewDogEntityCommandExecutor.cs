using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Modules.Dogs.Commands;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class SaveNewDogEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureNewDogViewViewModel, IDogRegistration>
    {
        public SaveNewDogEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IDogRegistrationService service)
            : base(DogEntityCRUDCommands.SaveNewEntityCommand, regionManager, eventAggregator, service)
        {
        }

    }
}
