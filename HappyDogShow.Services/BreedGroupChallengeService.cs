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
    public class BreedGroupChallengeService : IBreedGroupChallengeService
    {
        public Task<List<IBreedGroupChallengeEntity>> GetListAsync<T>() where T : IBreedGroupChallengeEntity, new()
        {
            Task<List<IBreedGroupChallengeEntity>> t = Task<List<IBreedGroupChallengeEntity>>.Run(() =>
            {
                List<IBreedGroupChallengeEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedGroupChallengeEntity> GetList<T>() where T : IBreedGroupChallengeEntity, new()
        {
            BreedChallenge defaultBC = new BreedChallenge()
            {
                Abbreviation = ""
            };

            List<IBreedGroupChallengeEntity> items = new List<IBreedGroupChallengeEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.BreedGroupChallenges.Include("BreedChallenges")
                           select d;

                foreach (BreedGroupChallenge d in data)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        Abbreviation = d.Abbreviation,
                        ShowChallengeName = d.ShowChallenge != null ? d.ShowChallenge.Name : "",
                        JudginOrder = d.JudgingOrder,
                        RelatedBreedChallengeName = GetTheBreedChallengeName(d), //d.BreedChallenges.FirstOrDefault() != null ? d.BreedChallenges.First().Abbreviation : "",
                        Name = d.Name
                    });
                }
            }

            return items;
        }

        private string GetTheBreedChallengeName(BreedGroupChallenge d)
        {
            if (d.BreedChallenges == null)
                return "not specified";

            return d.BreedChallenges.First().Abbreviation;
        }
    }
}
