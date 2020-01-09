using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedChallengeService : IEntityUpdateService<IChallengeResultCollection<IChallengeResult>>
    {
        Task<List<IBreedChallengeEntity>> GetListAsync<T>() where T : IBreedChallengeEntity, new();
    }
}
