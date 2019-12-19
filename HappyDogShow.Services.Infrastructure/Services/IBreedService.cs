using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedService
    {
        Task<List<IBreedEntity>> GetListAsync<T>() where T : IBreedEntity, new();
    }
}
