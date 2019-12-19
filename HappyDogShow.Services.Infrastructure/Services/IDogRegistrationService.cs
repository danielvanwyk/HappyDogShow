using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IDogRegistrationService : IEntityCreateService<IDogRegistration>, IEntityUpdateService<IDogRegistration>
    {
        Task<List<IDogRegistration>> GetListAsync<T>() where T : IDogRegistration, new();
    }
}
