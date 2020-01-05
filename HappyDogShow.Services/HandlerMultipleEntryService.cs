using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class HandlerMultipleEntryService : IHandlerMultipleEntryService
    {
        private IHandlerEntryService _handlerEntryService;

        public HandlerMultipleEntryService(IHandlerEntryService handlerEntryService)
        {
            _handlerEntryService = handlerEntryService;
        }
        public async Task<int> CreateEntityAsync(IMultipleHandlerEntry entity)
        {
            foreach (IHandlerEntryEntity entry in entity.HandlerEntries)
            {
                if (EntryHasDataToSave(entry))
                    await _handlerEntryService.CreateEntityAsync(entry);
            }

            return 1;
        }

        private bool EntryHasDataToSave(IHandlerEntryEntity entry)
        {
            if (entry.Class == null)
                return false;

            if (entry.Dog == null)
                return false;

            return true;
        }
    }
}
