using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedEntryService : IEntityCreateService<IBreedEntryEntity>, IEntityUpdateService<IBreedEntryEntity>, IEntityDeleteService<IEntityWithID>, IEntityUpdateService<IMultipleBreedEntryClassEntry>
    {
        Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>() where T : IBreedEntryEntityWithAdditionalData, new();
        Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>(int dogShowId) where T : IBreedEntryEntityWithAdditionalData, new();
        Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>(int dogShowId, string entryNumber) where T : IBreedEntryEntityWithAdditionalData, new();
        Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>(IDogRegistration dogRegistration) where T : IBreedEntryEntityWithAdditionalData, new();
        Task<IBreedEntryEntity> GetBreedEntryAsync<T>(int id) where T : IBreedEntryEntity, new();
        Task<List<IBreedEntryClassEntry>> GetBreedEntryClassEntryListAsync<T>() where T : IBreedEntryClassEntry, new();
        Task<List<IBreedEntryClassEntry>> GetBreedEntryClassEntryListAsync<T>(int dogShowId, int breedId) where T : IBreedEntryClassEntry, new();
    }
}
