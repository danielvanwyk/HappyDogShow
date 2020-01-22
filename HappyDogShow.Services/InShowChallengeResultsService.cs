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
    public class InShowChallengeResultsService : IInShowChallengeResultsService
    {
        public Task<List<IInShowChallengeResult>> GetListAsync<T>(int dogShowId, int challengeId) where T : IInShowChallengeResult, new()
        {
            Task<List<IInShowChallengeResult>> t = Task<List<IInShowChallengeResult>>.Run(() =>
            {
                List<IInShowChallengeResult> items = GetList<T>(dogShowId, challengeId);
                //List<IInShowChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        public Task<List<IInShowChallengeResult>> GetListAsync<T>(int dogShowId) where T : IInShowChallengeResult, new()
        {
            Task<List<IInShowChallengeResult>> t = Task<List<IInShowChallengeResult>>.Run(() =>
            {
                List<IInShowChallengeResult> items = GetList<T>(dogShowId, -1);
                //List<IInShowChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        private List<IInShowChallengeResult> GetList<T>(int dogShowId, int challengeId) where T : IInShowChallengeResult, new()
        {
            List<IInShowChallengeResult> items = new List<IInShowChallengeResult>();

            using (var ctx = new HappyDogShowContext())
            {
                if (challengeId > 0)
                {
                    var existingData = from r in ctx.InShowChallengeResults
                                       where r.DogShow.ID == dogShowId && r.ShowChallenge.ID == challengeId
                                       select r;

                    if (existingData.Count() == 0)
                    {
                        List<string> placings = new List<string>();
                        placings.Add("1st");
                        placings.Add("2nd");
                        placings.Add("3rd");
                        placings.Add("4th");

                        var newEntries = from ds in ctx.DogShows.Where(d => d.ID == dogShowId)
                                         from scc in ctx.ShowChallenges.Where(d => d.ID == challengeId)
                                         from p in placings
                                         select new
                                         {
                                             DogShow = ds,
                                             ShowChallenge = scc,
                                             Placing = p
                                         };

                        foreach (var newEntry in newEntries)
                        {
                            InShowChallengeResult realEntry = new InShowChallengeResult()
                            {
                                DogShow = newEntry.DogShow,
                                ShowChallenge = newEntry.ShowChallenge,
                                Placing = newEntry.Placing,
                                EntryNumber = ""
                            };

                            ctx.InShowChallengeResults.Add(realEntry);
                        }
                        ctx.SaveChanges();
                    }
                }

                var rawdata = from r in ctx.InShowChallengeResults
                              where r.DogShow.ID == dogShowId
                              select r;

                if (challengeId > 0)
                    rawdata = rawdata.Where(r => r.ShowChallenge.ID == challengeId);

                var judges = from j in ctx.ShowInShowChallengeJudges
                                       where j.DogShow.ID == dogShowId
                                       select j;

                var actualEntries = from r in rawdata
                                    join j in judges on 
                                        r.ShowChallenge.ID equals j.ShowChallenge.ID
                                    orderby r.Placing
                                    select new T
                                    {
                                        Id = r.ID,
                                        ShowId = r.DogShow.ID,
                                        ShowName  = r.DogShow.Name,
                                        Challenge = r.ShowChallenge.Name,
                                        EntryNumber = r.EntryNumber,
                                        Placing = r.Placing,
                                        Print = false,
                                        JudgeName = j.Judge.Name,
                                        BreedName = ""
                                    };

                foreach (var entry in actualEntries.ToList())
                {
                    if (entry.EntryNumber != "")
                    {
                        entry.BreedName = ctx.BreedEntries.Include("Dog").Include("Dog.Breed").Where(e => e.Show.ID == dogShowId && e.Number == entry.EntryNumber).First().Dog.Breed.Name;


                    }
                    items.Add(entry);
                }
            }

            return items;
        }

        private List<IInShowChallengeResult> GetTempList<T>() where T : IInShowChallengeResult, new()
        {
            List<IInShowChallengeResult> items = new List<IInShowChallengeResult>();

            IInShowChallengeResult t = new T();
            t.Id = 1;
            t.Challenge = "Best in Show";
            t.Placing = "1st";
            t.EntryNumber = "";
            t.Print = true;
            items.Add(t);

            IInShowChallengeResult t2 = new T();
            t2.Id = 2;
            t2.Challenge = "Best in Show";
            t2.Placing = "2nd";
            t2.EntryNumber = "";
            t2.Print = true;
            items.Add(t2);

            IInShowChallengeResult t3 = new T();
            t3.Id = 3;
            t3.Challenge = "Best in Show";
            t3.Placing = "3rd";
            t3.EntryNumber = "";
            t3.Print = false;
            items.Add(t3);

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
                    var foundResults = ctx.InShowChallengeResults.Where(i => i.ID == result.Id);
                    if (foundResults.Count() == 1)
                    {
                        InShowChallengeResult foundResult = foundResults.First();
                        foundResult.EntryNumber = result.EntryNumber;
                    }
                }

                ctx.SaveChanges();
            }
        }

    }
}
