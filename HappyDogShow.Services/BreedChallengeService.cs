using HappyDogShow.Data;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class BreedChallengeService : IBreedChallengeService
    {
        public Task<List<IBreedChallengeEntity>> GetListAsync<T>() where T : IBreedChallengeEntity, new()
        {
            Task<List<IBreedChallengeEntity>> t = Task<List<IBreedChallengeEntity>>.Run(() =>
            {
                List<IBreedChallengeEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedChallengeEntity> GetList<T>() where T : IBreedChallengeEntity, new()
        {
            List<IBreedChallengeEntity> items = new List<IBreedChallengeEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.BreedChallenges.Include("BreedGroupChallenge")
                           select d;

                foreach (BreedChallenge d in data)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        Abbreviation = d.Abbreviation,
                        BreedGroupChallengeName = d.BreedGroupChallenge != null ? d.BreedGroupChallenge.Name : "",
                        JudginOrder = d.JudgingOrder,
                        Name = d.Name
                    });
                }
            }

            return items;
        }

    }
}
