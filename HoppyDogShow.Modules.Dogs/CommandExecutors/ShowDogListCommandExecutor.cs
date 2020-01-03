using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class ShowDogListCommandExecutor : NavigateToViewCommandExecutor
    {
        public ShowDogListCommandExecutor(IRegionManager regionManager)
            : base(DogListCommands.ShowDogListCommand, regionManager, FormNameConstants.Dogs.DogsList.ViewName)
        {
        }
    }
}
