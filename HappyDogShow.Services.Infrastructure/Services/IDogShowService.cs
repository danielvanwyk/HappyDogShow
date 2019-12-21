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
        Task<List<IBreedClassEntryEntityWithClassDetail>> GetListOfClassEntriesForNewBreedEntryAsync<T>() where T : IBreedClassEntryEntityWithClassDetail, new();
    }
}
