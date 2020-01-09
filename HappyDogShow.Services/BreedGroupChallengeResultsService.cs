using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class BreedGroupChallengeResultsService : IBreedGroupChallengeResultsService
    {
        public Task<List<IChallengeResult>> GetListAsync<T>(int dogShowId, int breedGroupId, int challengeId) where T : IChallengeResult, new()
        {
            Task<List<IChallengeResult>> t = Task<List<IChallengeResult>>.Run(() =>
            {
                //List<IChallengeResult> items = GetList<T>(dogShowId, breedId);
                List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        private List<IChallengeResult> GetTempList<T>() where T : IChallengeResult, new()
        {
            List<IChallengeResult> items = new List<IChallengeResult>();

            IChallengeResult t = new T();
            t.Id = 1;
            t.Challenge = "Best in Group";
            t.Placing = "1st";
            t.EntryNumber = "";
            t.Print = true;
            items.Add(t);

            IChallengeResult t2 = new T();
            t2.Id = 2;
            t2.Challenge = "Best in Group";
            t2.Placing = "2nd";
            t2.EntryNumber = "";
            t2.Print = true;
            items.Add(t2);

            IChallengeResult t3 = new T();
            t3.Id = 3;
            t3.Challenge = "Best in Group";
            t3.Placing = "3rd";
            t3.EntryNumber = "";
            t3.Print = false;
            items.Add(t3);

            return items;

        }


        public Task UpdateEntityAsync(IChallengeResultCollection<IChallengeResult> entity)
        {
            throw new NotImplementedException();
        }
    }
}
