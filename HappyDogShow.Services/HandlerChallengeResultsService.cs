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
    public class HandlerChallengeResultsService : IHandlerChallengeResultsService
    {
        public Task<List<IChallengeResult>> GetListAsync<T>(int dogShowId, int classId) where T : IChallengeResult, new()
        {
            Task<List<IChallengeResult>> t = Task<List<IChallengeResult>>.Run(() =>
            {
                List<IChallengeResult> items = GetList<T>(dogShowId, classId);
                //List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        private List<IChallengeResult> GetList<T>(int dogShowId, int classId) where T : IChallengeResult, new()
        {
            List<IChallengeResult> items = new List<IChallengeResult>();

            using (var ctx = new HappyDogShowContext())
            {
                var existingData = from r in ctx.HandlerChallengeResults
                                   where r.DogShow.ID == dogShowId && r.HandlerClass.ID == classId
                                   select r;

                if (existingData.Count() == 0)
                {
                    List<string> placings = new List<string>();
                    placings.Add("1st");
                    placings.Add("2nd");
                    placings.Add("3rd");
                    placings.Add("4th");

                    var newEntries = from ds in ctx.DogShows.Where(d => d.ID == dogShowId)
                                     from scc in ctx.HandlerClasses
                                     from p in placings
                                     select new
                                     {
                                         DogShow = ds,
                                         HandlerClass = scc,
                                         Placing = p
                                     };

                    foreach (var newEntry in newEntries)
                    {
                        HandlerChallengeResult realEntry = new HandlerChallengeResult()
                        {
                            DogShow = newEntry.DogShow,
                            HandlerClass = newEntry.HandlerClass,
                            Placing = newEntry.Placing,
                            EntryNumber = ""
                        };

                        ctx.HandlerChallengeResults.Add(realEntry);
                    }
                    ctx.SaveChanges();
                }

                var actualEntries = from r in ctx.HandlerChallengeResults
                                    where r.DogShow.ID == dogShowId && r.HandlerClass.ID == classId
                                    orderby r.Placing
                                    select new T
                                    {
                                        Id = r.ID,
                                        ShowId = r.DogShow.ID,
                                        Challenge = r.HandlerClass.Name,
                                        EntryNumber = r.EntryNumber,
                                        Placing = r.Placing,
                                        Print = false
                                    };

                foreach (var entry in actualEntries)
                    items.Add(entry);
            }

            return items;
        }

        private List<IChallengeResult> GetTempList<T>() where T : IChallengeResult, new()
        {
            List<IChallengeResult> items = new List<IChallengeResult>();

            IChallengeResult t = new T();
            t.Id = 1;
            t.Challenge = "Junior Handler";
            t.Placing = "1st";
            t.EntryNumber = "";
            t.Print = true;
            items.Add(t);

            IChallengeResult t2 = new T();
            t2.Id = 2;
            t2.Challenge = "Junior Handler";
            t2.Placing = "2nd";
            t2.EntryNumber = "";
            t2.Print = true;
            items.Add(t2);

            IChallengeResult t3 = new T();
            t3.Id = 3;
            t3.Challenge = "Junior Handler";
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
                    var foundResults = ctx.HandlerChallengeResults.Where(i => i.ID == result.Id);
                    if (foundResults.Count() == 1)
                    {
                        HandlerChallengeResult foundResult = foundResults.First();
                        foundResult.EntryNumber = result.EntryNumber;
                    }
                }

                ctx.SaveChanges();
            }
        }

    }
}
