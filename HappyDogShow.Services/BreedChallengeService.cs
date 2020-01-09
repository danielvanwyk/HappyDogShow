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
                var data = from d in ctx.BreedChallenges
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

        public Task UpdateEntityAsync(IChallengeResultCollection<IChallengeResult> entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IChallengeResultCollection<IChallengeResult> entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                foreach(IChallengeResult result in entity.Results)
                {
                    var foundResults = ctx.BreedChallengeResults.Where(i => i.ID == result.Id);
                    if (foundResults.Count() == 1)
                    {
                        BreedChallengeResult foundResult = foundResults.First();
                        foundResult.EntryNumber = result.EntryNumber;
                    }
                }

                ctx.SaveChanges();
            }
        }

    }
}
