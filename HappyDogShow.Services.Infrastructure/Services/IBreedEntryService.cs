using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedEntryService : IEntityCreateService<IBreedEntryEntity>, IEntityUpdateService<IBreedEntryEntity>
    {
        Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>() where T : IBreedEntryEntityWithAdditionalData, new();
        Task<IBreedEntryEntity> GetBreedEntryAsync<T>(int id) where T : IBreedEntryEntity, new();
    }
}
