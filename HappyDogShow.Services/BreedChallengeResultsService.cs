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
    public class BreedChallengeResultsService : IBreedChallengeResultsService
    {
        public Task<List<IChallengeResult>> GetListAsync<T>(int dogShowId, int breedId) where T : IChallengeResult, new()
        {
            Task<List<IChallengeResult>> t = Task<List<IChallengeResult>>.Run(() =>
            {
                List<IChallengeResult> items = GetList<T>(dogShowId, breedId);
                //List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        private List<IChallengeResult> GetTempList<T>() where T : IChallengeResult, new()
        {
            List<IChallengeResult> items = new List<IChallengeResult>();

            IChallengeResult t = new T();
            t.Id = 1;
            t.Challenge = "CC Dog (2 points)";
            t.Placing = "";
            t.EntryNumber = "";
            t.Print = true;
            items.Add(t);

            IChallengeResult t2 = new T();
            t2.Id = 2;
            t2.Challenge = "BOB";
            t2.Placing = "";
            t2.EntryNumber = "";
            t2.Print = true;
            items.Add(t2);

            IChallengeResult t3 = new T();
            t3.Id = 3;
            t3.Challenge = "RBOB";
            t3.Placing = "";
            t3.EntryNumber = "";
            t3.Print = false;
            items.Add(t3);

            return items;

        }

        private List<IChallengeResult> GetList<T>(int dogShowId, int breedId) where T : IChallengeResult, new()
        {
            List<IChallengeResult> items = new List<IChallengeResult>();

            using (var ctx = new HappyDogShowContext())
            {
                // see if there is nothing in the table
                // and then create it

            // return what is in the table
            }

            return items;
        }
    }
}
