using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries.CommandExecutors
{
    public class ShowBreedEntryResultsCaptureViewCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowBreedEntryResultsCaptureViewCommandExecutor(IRegionManager regionManager)
            : base(BreedEntryResultsCommands.ShowBreedEntryResultsCaptureViewCommand, regionManager, FormNameConstants.BreedEntryResults.CaptureResults.ViewName)
        {
        }
    }
}
