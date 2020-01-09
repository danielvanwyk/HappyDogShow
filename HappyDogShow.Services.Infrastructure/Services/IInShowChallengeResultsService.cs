using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IInShowChallengeResultsService : IEntityUpdateService<IChallengeResultCollection<IChallengeResult>>
    {
        Task<List<IChallengeResult>> GetListAsync<T>(int dogShowId, int challengeId) where T : IChallengeResult, new();
    }
}
