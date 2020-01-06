using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Services.Infrastructure.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.CommandExecutors
{
    public class GenerateNumbersCommandExecutor : NavigateToEntityCreateViewCommandExecutor<IDogShowEntity>
    {
        public GenerateNumbersCommandExecutor(IRegionManager regionManager)
            : base(DogShowAdminCommands.GenerateNumbersCommand, regionManager, FormNameConstants.Shows.GenerateNumbers.ViewName)
        {
        }
    }
}
