using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Entries.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class SaveMultipleNewHandlerEntryEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureMultipleNewHandlerEntryViewViewModel, IMultipleHandlerEntry>
    {
        public SaveMultipleNewHandlerEntryEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IHandlerMultipleEntryService service)
            : base(HandlerEntryCRUDCommands.SaveMultipleNewEntityCommand, regionManager, eventAggregator, service)
        {
        }
    }
}
