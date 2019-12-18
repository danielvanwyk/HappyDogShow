using HappyDogShow.Infrastructure.Events;
using HappyDogShow.Infrastructure.Exceptions;
using HappyDogShow.Infrastructure.Extensions;
using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Infrastructure.ViewModels;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.CommandExecutors
{
    public abstract class SaveExistingEntityCommandExecutor<T, U>
        where T : IEntityAwareViewViewModel
        where U : class, IEntityWithID
    {
        protected IRegionManager _regionManager;
        protected IEventAggregator _eventAggregator;
        protected IEntityUpdateService<U> _entityUpdateService;

        private DelegateCommand<T> commandHandler { get; set; }

        public SaveExistingEntityCommandExecutor(CompositeCommand command, IRegionManager regionManager, IEventAggregator eventAggregator, IEntityUpdateService<U> entityUpdateService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _entityUpdateService = entityUpdateService;
            commandHandler = new DelegateCommand<T>(ExecuteCommand);
            command.RegisterCommand(commandHandler);
        }

        private async void ExecuteCommand(T vm)
        {
            vm.CurrentEntity.ValidateProperties();

            if (vm.CurrentEntity.HasErrors)
                return;

            try
            {
                vm.MarkAsBusy();

                try
                {
                    await PerformSave(vm.CurrentEntity);
                }
                catch
                {
                    throw new CouldNotSaveExistingEntityException(vm.CurrentEntity);
                }
                finally
                {
                    vm.MarkAsNotBusy();
                }

                IEntityWithID entityWithID = vm.CurrentEntity as IEntityWithID;
                if (entityWithID != null)
                    _eventAggregator.GetEvent<EntityUpdatedEvent<U>>().Publish(new EntityUpdatedEventArgument(entityWithID.Id));

                HandleSuccessfulSave(vm);
            }
            catch (Exception ex)
            {
                vm.MarkAsNotBusy();
                HandleUnsuccessfulSave(ex);
            }
        }

        protected virtual async Task PerformSave(ValidatableBindableBase currentEntity)
        {
            U entity = currentEntity as U;
            if (entity == null)
                throw new Exception(string.Format("Cannot save entity because it is of type {0}", currentEntity.GetType()));

            await _entityUpdateService.UpdateEntityAsync(entity);
        }

        protected virtual void HandleSuccessfulSave(T vm)
        {
            INavigationAware navigationAwareVm = vm as INavigationAware;
            if (vm != null)
                _regionManager.Regions[RegionNames.ContentRegion].NavigationService.Journal.GoBack();
        }
        protected virtual void HandleUnsuccessfulSave(Exception ex)
        {
            throw ex;
        }


    }
}
