using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IHandlerRegistrationService : IEntityCreateService<IHandlerRegistration>, IEntityUpdateService<IHandlerRegistration>
    {
        Task<List<IHandlerRegistration>> GetListAsync<T>() where T : IHandlerRegistration, new();
        Task<IHandlerRegistration> GetHandlerRegistrationAsync<T>(int id) where T : IHandlerRegistration, new();
    }
}
