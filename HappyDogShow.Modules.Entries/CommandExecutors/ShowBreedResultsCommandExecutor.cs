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
    class ShowBreedResultsCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowBreedResultsCommandExecutor(IRegionManager regionManager)
            : base(ResultsCommands.ShowBreedResultsCommand, regionManager, FormNameConstants.Results.Breed.ViewName)
        {
        }
    }
}
