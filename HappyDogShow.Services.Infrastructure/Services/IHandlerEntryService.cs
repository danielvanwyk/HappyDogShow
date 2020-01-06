using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IHandlerEntryService : IEntityCreateService<IHandlerEntryEntity>, IEntityUpdateService<IHandlerEntryEntity>, IEntityDeleteService<IEntityWithID>
    {
        Task<List<IHandlerEntryEntityWithAdditionalData>> GetHandlerEntryListAsync<T>() where T : IHandlerEntryEntityWithAdditionalData, new();
        Task<List<IHandlerEntryEntityWithAdditionalData>> GetHandlerEntryListAsync<T>(int dogShowId) where T : IHandlerEntryEntityWithAdditionalData, new();
        Task<IHandlerEntryEntity> GetHandlerEntryAsync<T>(int id) where T : IHandlerEntryEntity, new();
        Task<List<IHandlerEntryClassEntry>> GetHandlerEntryClassEntryListAsync<T>() where T : IHandlerEntryClassEntry, new();
        Task<List<IHandlerClassEntity>> GetHandlerClassListAsync<T>() where T : IHandlerClassEntity, new();
    }
}
