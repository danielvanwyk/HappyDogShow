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
    public abstract class SaveNewEntityCommandExecutor<T, U> 
        where T : IEntityAwareViewViewModel
        where U : class, IEntityWithID
    {
        protected IRegionManager _regionManager;
        protected IEventAggregator _eventAggregator;
        protected IEntityCreateService<U> _entityCreateService;

        private DelegateCommand<T> commandHandler { get; set; }

        public SaveNewEntityCommandExecutor(CompositeCommand command, IRegionManager regionManager, IEventAggregator eventAggregator, IEntityCreateService<U> entityCreateService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _entityCreateService = entityCreateService;
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

                int result = await PerformSaveAndGetIDBack(vm.CurrentEntity);

                vm.MarkAsNotBusy();

                if (result == -1)
                    throw new CouldNotSaveNewEntityException(vm.CurrentEntity);
                else
                {
                    IEntityWithID entityWithID = vm.CurrentEntity as IEntityWithID;
                    if (entityWithID != null)
                    {
                        entityWithID.Id = result;
                    }
                }

                _eventAggregator.GetEvent<NewEntityCreatedEvent<U>>().Publish(new NewEntityCreatedEventArgument(result));

                HandleSuccessfulSave(vm, result);
            }
            catch (Exception ex)
            {
                vm.MarkAsNotBusy();
                HandleUnsuccessfulSave(ex);
            }
        }

        protected virtual async Task<int> PerformSaveAndGetIDBack(ValidatableBindableBase currentEntity)
        {
            int newId = -1;

            U entity = currentEntity as U;
            if (entity == null)
                throw new Exception(string.Format("Cannot save entity because it is of type {0}", currentEntity.GetType()));

            newId = await _entityCreateService.CreateEntityAsync(entity);

            return newId;
        }

        protected virtual void HandleSuccessfulSave(T vm, int newId)
        {
            ICancelAwareViewViewModel cancelAwareViewViewModel = vm as ICancelAwareViewViewModel;
            if (cancelAwareViewViewModel != null)
            {
                _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate(cancelAwareViewViewModel.CancelNavigateToViewName);
            }
            else
            {
                INavigationAware navigationAwareVm = vm as INavigationAware;
                if (vm != null)
                    _regionManager.Regions[RegionNames.ContentRegion].NavigationService.Journal.GoBack();
            }
        }
        protected virtual void HandleUnsuccessfulSave(Exception ex)
        {
            throw ex;
        }


    }
}
