using HappyDogShow.Infrastructure.Events;
using HappyDogShow.Infrastructure.Exceptions;
using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HappyDogShow.Infrastructure.CommandExecutors
{
    public abstract class DeleteExistingEntityCommandExecutor<U>
        where U : class, IEntityWithID
    {
        protected IRegionManager _regionManager;
        protected IEventAggregator _eventAggregator;
        protected IEntityDeleteService<U> _entityDeleteService;

        private DelegateCommand<U> commandHandler { get; set; }

        public DeleteExistingEntityCommandExecutor(CompositeCommand command, IRegionManager regionManager, IEventAggregator eventAggregator, IEntityDeleteService<U> entityDeleteService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _entityDeleteService = entityDeleteService;
            commandHandler = new DelegateCommand<U>(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(U entity)
        {
            try
            {
                MetroWindow metroWindow = Application.Current.MainWindow as MetroWindow;
                MessageDialogResult result = await metroWindow.ShowMessageAsync("CONFIRM", "Are you sure you want to delete this?", MessageDialogStyle.AffirmativeAndNegative);
                if (result == MessageDialogResult.Negative)
                    return;

                await PerformDelete(entity);
            }
            catch
            {
                throw new CouldNotDeleteExistingEntityException(entity);
            }

            _eventAggregator.GetEvent<EntityDeletedEvent<U>>().Publish(new EntityDeletedEventArgument(entity.Id));

            HandleSuccessfulDelete(entity);
        }

        protected virtual async Task PerformDelete(U currentEntity)
        {
            U entity = currentEntity as U;
            if (entity == null)
                throw new Exception(string.Format("Cannot save entity because it is of type {0}", currentEntity.GetType()));

            await _entityDeleteService.DeleteEntityAsync(entity);
        }

        protected virtual void HandleSuccessfulDelete(U entity)
        {

        }
    }
}
