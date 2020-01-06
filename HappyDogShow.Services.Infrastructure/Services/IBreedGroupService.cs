using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedGroupService
    {
        Task<List<IBreedGroupEntity>> GetListAsync<T>() where T : IBreedGroupEntity, new();
    }
}
