using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class BreedMultipleEntryService : IBreedMultipleEntryService
    {
        private IBreedEntryService _breedEntryService;

        public BreedMultipleEntryService(IBreedEntryService breedEntryService)
        {
            _breedEntryService = breedEntryService;
        }
        public async Task<int> CreateEntityAsync(IMultipleBreedEntry entity)
        {
            foreach (IBreedEntryEntity entry in entity.BreedEntries)
            {
                if (EntryHasClassesToSave(entry))
                    await _breedEntryService.CreateEntityAsync(entry);
            }

            return 1;
        }

        private bool EntryHasClassesToSave(IBreedEntryEntity entry)
        {
            var selectedClasses = entry.Classes.Where(i => i.IsSelected == true);

            if (selectedClasses.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
