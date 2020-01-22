using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedChallengeResultsService : IEntityUpdateService<IChallengeResultCollection<IChallengeResult>>
    {
        Task<List<IBreedChallengeResult>> GetListAsync<T>(int dogShowId, int breedId) where T : IBreedChallengeResult, new();
        Task<List<IBreedChallengeResult>> GetListAsync<T>(int dogShowId) where T : IBreedChallengeResult, new();
    }
}
