using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.ViewModels;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HappyDogShow.Infrastructure.CommandExecutors
{
    public class CancelEntityCommandExecutor
    {
        private IRegionManager _regionManager;
        private DelegateCommand<IEntityAwareViewViewModel> commandHandler { get; set; }


        public CancelEntityCommandExecutor (IRegionManager regionManager)
        {
            _regionManager = regionManager;
            commandHandler = new DelegateCommand<IEntityAwareViewViewModel>(ExecuteCommand);
            NavigateableViewCommands.CancelEntityCommand.RegisterCommand(commandHandler);
        }
        public async void ExecuteCommand(IEntityAwareViewViewModel viewModel)
        {
            ValidatableBindableBase entity = viewModel.CurrentEntity;

            IDirtyAwareEntity dirtyAwareEntity = (entity as IDirtyAwareEntity);

            if (dirtyAwareEntity != null)
            {
                if (dirtyAwareEntity.IsDirty)
                {
                    MessageDialogResult dialogResult;
                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Yes, I want to cancel this action",
                        NegativeButtonText = "No, I changed my mind",
                        MaximumBodyHeight = 100,
                        ColorScheme = MetroDialogColorScheme.Accented
                    };

                    MetroWindow metroWindow = Application.Current.MainWindow as MetroWindow;
                    dialogResult = await metroWindow.ShowMessageAsync("CONFIRM ACTION", "You are about to move away without saving.  Are you sure you want to cancel the current action?",
                        MessageDialogStyle.AffirmativeAndNegative, mySettings);

                    if (dialogResult == MessageDialogResult.Affirmative)
                        NavigateBack(viewModel);
                }
                else
                    NavigateBack(viewModel);
            }
            else
                NavigateBack(viewModel);
        }

        private void NavigateBack(IEntityAwareViewViewModel vm)
        {
            INavigationAware navigationAwareVm = vm as INavigationAware;
            if (vm != null)
                _regionManager.Regions[RegionNames.ContentRegion].NavigationService.Journal.GoBack();
        }

    }
}
