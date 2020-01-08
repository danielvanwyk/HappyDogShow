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
    public class ShowChallengeService : IShowChallengeService
    {
        public Task<List<IShowChallengeEntity>> GetListAsync<T>() where T : IShowChallengeEntity, new()
        {
            Task<List<IShowChallengeEntity>> t = Task<List<IShowChallengeEntity>>.Run(() =>
            {
                List<IShowChallengeEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IShowChallengeEntity> GetList<T>() where T : IShowChallengeEntity, new()
        {
            BreedGroupChallenge defaultBGC = new BreedGroupChallenge()
            {
                Abbreviation = ""
            };

            List<IShowChallengeEntity> items = new List<IShowChallengeEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.ShowChallenges.Include("BreedGroupChallenges")
                           select d;

                foreach (ShowChallenge d in data)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        Abbreviation = d.Abbreviation,
                        JudginOrder = d.JudgingOrder,
                        RelatedBreedGroupChallengeName = GetTheBreedGroupChallengeName(d), //d.BreedChallenges.FirstOrDefault() != null ? d.BreedChallenges.First().Abbreviation : "",
                        Name = d.Name
                    });
                }
            }

            return items;
        }

        private string GetTheBreedGroupChallengeName(ShowChallenge d)
        {
            if (d.BreedGroupChallenges == null)
                return "not specified";

            return d.BreedGroupChallenges.First().Abbreviation;
        }
    }
}
