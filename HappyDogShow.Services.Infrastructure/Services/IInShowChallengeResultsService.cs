using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IInShowChallengeResultsService : IEntityUpdateService<IChallengeResultCollection<IChallengeResult>>
    {
        Task<List<IInShowChallengeResult>> GetListAsync<T>(int dogShowId, int challengeId) where T : IInShowChallengeResult, new();
        Task<List<IInShowChallengeResult>> GetListAsync<T>(int dogShowId) where T : IInShowChallengeResult, new();
    }
}
