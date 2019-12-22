using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IDogShowService : IEntityCreateService<IDogShowEntity>, IEntityUpdateService<IDogShowEntity>
    {
        Task<List<IDogShowEntity>> GetDogShowListAsync<T>() where T : IDogShowEntity, new();
        Task<List<IBreedClassEntryEntityWithClassDetailForSelection>> GetListOfClassEntriesForNewBreedEntryAsync<T>() where T : IBreedClassEntryEntityWithClassDetailForSelection, new();
        Task<List<IBreedClassEntryEntityWithClassDetailForSelection>> GetListOfClassEntriesForBreedEntryAsync<T>(int id) where T : IBreedClassEntryEntityWithClassDetailForSelection, new();
    }
}
