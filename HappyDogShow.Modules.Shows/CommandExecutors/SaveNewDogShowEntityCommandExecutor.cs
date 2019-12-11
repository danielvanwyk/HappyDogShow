﻿using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Modules.Shows.Commands;
using HappyDogShow.Modules.Shows.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.CommandExecutors
{
    public class SaveNewDogShowEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureNewDogShowViewViewModel, IDogShowEntity>
    {
        public SaveNewDogShowEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IDogShowService dogShowService)
            : base (DogShowEntityCRUDCommands.SaveNewDogShowEntityCommand, regionManager, eventAggregator, dogShowService)
        {
        }

    }
}
