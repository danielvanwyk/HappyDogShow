using HappyDogShow.Infrastructure.CommandExecutors;
using HappyDogShow.Infrastructure.Commands;
using HappyDogShow.Modules.Dogs.Infrastructure;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace HappyDogShow.Modules.Dogs.CommandExecutors
{
    public class SaveNewDogEntityCommandExecutor : SaveNewEntityCommandExecutor<ICaptureNewDogViewViewModel, IDogRegistration>
    {
        private IGlobalContextService _globalContextService;
        public SaveNewDogEntityCommandExecutor(IRegionManager regionManager, IEventAggregator eventAggregator, IDogRegistrationService service, IGlobalContextService globalContextService)
            : base(DogEntityCRUDCommands.SaveNewEntityCommand, regionManager, eventAggregator, service)
        {
            _globalContextService = globalContextService;
        }

        protected override void HandleSuccessfulSave(ICaptureNewDogViewViewModel vm, int newId)
        {
            if (vm.RememberRegisteredOwnerDetails)
            {
                IDogRegistration entity = vm.CurrentEntity as IDogRegistration;
                if (entity != null)
                {
                    _globalContextService.RegisteredOwnerSurname = entity.RegisteredOwnerSurname;
                    _globalContextService.RegisteredOwnerTitle = entity.RegisteredOwnerTitle;
                    _globalContextService.RegisteredOwnerInitials = entity.RegisteredOwnerInitials;
                    _globalContextService.RegisteredOwnerAddress = entity.RegisteredOwnerAddress;
                    _globalContextService.RegisteredOwnerPostalCode = entity.RegisteredOwnerPostalCode;
                    _globalContextService.RegisteredOwnerKUSANo = entity.RegisteredOwnerKUSANo;
                    _globalContextService.RegisteredOwnerTel = entity.RegisteredOwnerTel;
                    _globalContextService.RegisteredOwnerCell = entity.RegisteredOwnerCell;
                    _globalContextService.RegisteredOwnerFax = entity.RegisteredOwnerFax;
                    _globalContextService.RegisteredOwnerEmail = entity.RegisteredOwnerEmail;
                }
            }
            else
            {
                _globalContextService.RegisteredOwnerSurname = "";
                _globalContextService.RegisteredOwnerTitle = "";
                _globalContextService.RegisteredOwnerInitials = "";
                _globalContextService.RegisteredOwnerAddress = "";
                _globalContextService.RegisteredOwnerPostalCode = "";
                _globalContextService.RegisteredOwnerKUSANo = "";
                _globalContextService.RegisteredOwnerTel = "";
                _globalContextService.RegisteredOwnerCell = "";
                _globalContextService.RegisteredOwnerFax = "";
                _globalContextService.RegisteredOwnerEmail = "";
            }

            BreedEntryCRUDCommands.ShowViewToCaptureNewEntityCommand.Execute(vm.CurrentEntity);
        }

    }
}
