using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IBreedGroupChallengeService
    {
        Task<List<IBreedGroupChallengeEntity>> GetListAsync<T>() where T : IBreedGroupChallengeEntity, new();
    }
}
