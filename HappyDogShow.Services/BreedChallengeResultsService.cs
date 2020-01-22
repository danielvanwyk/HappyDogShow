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
        public Task<List<IBreedChallengeResult>> GetListAsync<T>(int dogShowId, int breedId) where T : IBreedChallengeResult, new()
        {
            Task<List<IBreedChallengeResult>> t = Task<List<IBreedChallengeResult>>.Run(() =>
            {
                List<IBreedChallengeResult> items = GetList<T>(dogShowId, breedId);
                //List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        public Task<List<IBreedChallengeResult>> GetListAsync<T>(int dogShowId) where T : IBreedChallengeResult, new()
        {
            Task<List<IBreedChallengeResult>> t = Task<List<IBreedChallengeResult>>.Run(() =>
            {
                List<IBreedChallengeResult> items = GetList<T>(dogShowId, -1);
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

        private List<IBreedChallengeResult> GetList<T>(int dogShowId, int breedId) where T : IBreedChallengeResult, new()
        {
            List<IBreedChallengeResult> items = new List<IBreedChallengeResult>();

            if (breedId > 0)
            {
                CreateBlankRecordsIfThereAreNoRecordsYet(dogShowId, breedId);
            }
            else
            {
                using (var ctx = new HappyDogShowContext())
                {
                    foreach (Breed breed in ctx.Breeds)
                    {
                        CreateBlankRecordsIfThereAreNoRecordsYet(dogShowId, breed.ID);
                    }
                }
            }
                // see if there is nothing in the table
                // and then create it

                using (var ctx = new HappyDogShowContext())
            {

                var rawdata = from r in ctx.BreedChallengeResults
                              where r.DogShow.ID == dogShowId
                              select r;

                if (breedId > 0)
                    rawdata = rawdata.Where(r => r.Breed.ID == breedId);

                // get a list of all the breeds we have entries for
                // filter the 
                var enteredBreeds = (from e in ctx.BreedClassEntries
                                     where e.Entry.Show.ID == dogShowId
                                     select e.Entry.Dog.Breed.ID).Distinct().ToList();

                var actualEntries = from r in rawdata
                                    join b in enteredBreeds on
                                        r.Breed.ID equals b
                                    orderby r.BreedChallenge.JudgingOrder, r.Placing
                                    select new T
                                    {
                                        Id = r.ID,
                                        ShowId = r.DogShow.ID,
                                        ShowName = r.DogShow.Name,
                                        Challenge = r.BreedChallenge.Name,
                                        EntryNumber = r.EntryNumber,
                                        Placing = r.Placing,
                                        Print = false,
                                        JudgingOrder = r.BreedChallenge.JudgingOrder,
                                        BreedGroupName = r.Breed.BreedGroup.Name,
                                        BreedName = r.Breed.Name
                                    };

                foreach (var entry in actualEntries)
                    items.Add(entry);
            }

            return items;
        }

        private static void CreateBlankRecordsIfThereAreNoRecordsYet(int dogShowId, int breedId)
        {
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
            }
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
