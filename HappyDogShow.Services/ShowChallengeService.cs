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
        public Task<List<IShowChallengeEntity>> GetListAsync<T>(int dogShowId) where T : IShowChallengeEntity, new()
        {
            Task<List<IShowChallengeEntity>> t = Task<List<IShowChallengeEntity>>.Run(() =>
            {
                List<IShowChallengeEntity> items = GetList<T>(dogShowId);
                return items;
            });

            return t;
        }

        private List<IShowChallengeEntity> GetList<T>(int dogShowId) where T : IShowChallengeEntity, new()
        {
            BreedGroupChallenge defaultBGC = new BreedGroupChallenge()
            {
                Abbreviation = ""
            };

            List<IShowChallengeEntity> items = new List<IShowChallengeEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from sisj in ctx.ShowInShowChallengeJudges.Include("Judge").Include("ShowChallenge").Include("DogShow").Include("ShowChallenge.BreedGroupChallenges")
                           where sisj.DogShow.ID == dogShowId
                           select sisj;

                foreach (ShowInShowChallengeJudge d in data)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        Abbreviation = d.ShowChallenge.Abbreviation,
                        JudginOrder = d.ShowChallenge.JudgingOrder,
                        RelatedBreedGroupChallengeName = GetTheBreedGroupChallengeName(d.ShowChallenge), //d.BreedChallenges.FirstOrDefault() != null ? d.BreedChallenges.First().Abbreviation : "",
                        Name = d.ShowChallenge.Name,
                        ChallengeJudgeName = d.Judge.Name
                    });
                }
            }

            return items;
        }

        private string GetTheBreedGroupChallengeName(ShowChallenge d)
        {
            if (d == null)
                return "n/a";

            if (d.BreedGroupChallenges == null)
                return "not specified";

            return d.BreedGroupChallenges.First().Abbreviation;
        }
    }
}
