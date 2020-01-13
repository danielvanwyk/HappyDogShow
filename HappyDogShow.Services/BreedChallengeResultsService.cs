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
                var existingData = from r in ctx.BreedChallengeResults
                                   where r.DogShow.ID == dogShowId && r.Breed.ID == breedId
                                   select r;

                if (existingData.Count() == 0)
                {
                    //DogShow selectedDogShow = ctx.DogShows.Where(d => d.ID == dogShowId).First();
                    //List<BreedChallenge> breedChallenges = ctx.BreedChallenges.OrderBy(d => d.JudgingOrder).ToList();

                    var newEntries = from ds in ctx.DogShows.Where(d => d.ID == dogShowId)
                                     from b in ctx.Breeds.Where(d => d.ID == breedId)
                                     from bc in ctx.BreedChallenges.OrderBy(d => d.JudgingOrder)
                                     select new 
                                     {
                                         DogShow = ds,
                                         Breed = b,
                                         BreedChallenge = bc
                                     };

                    foreach (var newEntry in newEntries)
                    {
                        BreedChallengeResult realEntry = new BreedChallengeResult()
                        {
                            DogShow = newEntry.DogShow,
                            Breed = newEntry.Breed,
                            BreedChallenge = newEntry.BreedChallenge,
                            Placing = "",
                            EntryNumber = ""
                        };

                        ctx.BreedChallengeResults.Add(realEntry);
                    }
                    ctx.SaveChanges();
                }
                // see if there is nothing in the table
                // and then create it

                var actualEntries = from r in ctx.BreedChallengeResults
                                    where r.DogShow.ID == dogShowId && r.Breed.ID == breedId
                                    orderby r.BreedChallenge.JudgingOrder, r.Placing
                                    select new T
                                    {
                                        Id = r.ID,
                                        ShowId = r.DogShow.ID,
                                        Challenge = r.BreedChallenge.Name,
                                        EntryNumber = r.EntryNumber,
                                        Placing = r.Placing,
                                        Print = false,
                                        JudgingOrder = r.BreedChallenge.JudgingOrder
                                    };

                foreach (var entry in actualEntries)
                    items.Add(entry);
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
                foreach (IChallengeResult result in entity.Results)
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
