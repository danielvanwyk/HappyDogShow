using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedGroupChallengeResultsService : IEntityUpdateService<IChallengeResultCollection<IChallengeResult>>
    {
        Task<List<IChallengeResult>> GetListAsync<T>(int dogShowId, int breedGroupId, int challengeId) where T : IChallengeResult, new();
    }
}
