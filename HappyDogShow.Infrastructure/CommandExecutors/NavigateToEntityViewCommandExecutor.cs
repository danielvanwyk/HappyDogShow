using HappyDogShow.Services.Infrastructure.Models;
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
    public class NavigateToEntityViewCommandExecutor<T>
        //where T:IEntityWithID
    {
        protected IRegionManager _regionManager;
        private DelegateCommand<T> commandHandler { get; set; }
        private string viewName;

        public NavigateToEntityViewCommandExecutor(CompositeCommand command, IRegionManager regionManager, string viewToNavigateToName)
        {
            _regionManager = regionManager;
            viewName = viewToNavigateToName;
            commandHandler = new DelegateCommand<T>(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(T obj)
        {
            if (obj == null)
            {
                MetroWindow metroWindow = Application.Current.MainWindow as MetroWindow;
                await metroWindow.ShowMessageAsync("NO SELECTION MADE", "Please select an item first");
                return;
            }

            _regionManager.RequestNavigate(RegionNames.ContentRegion, viewName,
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                    // put a breakpoint here and checkout what NavigationResult contains
                });
        }
    }
}
