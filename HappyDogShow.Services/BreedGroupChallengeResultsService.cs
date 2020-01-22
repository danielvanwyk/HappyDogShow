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
    public class BreedGroupChallengeResultsService : IBreedGroupChallengeResultsService
    {
        public Task<List<IChallengeResult>> GetListAsync<T>(int dogShowId, int breedGroupId, int challengeId) where T : IChallengeResult, new()
        {
            Task<List<IChallengeResult>> t = Task<List<IChallengeResult>>.Run(() =>
            {
                List<IChallengeResult> items = GetList<T>(dogShowId, breedGroupId, challengeId);
                //List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        private List<IChallengeResult> GetList<T>(int dogShowId, int breedGroupId, int challengeId) where T : IChallengeResult, new()
        {
            List<IChallengeResult> items = new List<IChallengeResult>();

            using (var ctx = new HappyDogShowContext())
            {
                var existingData = from r in ctx.BreedGroupChallengeResults
                                   where r.DogShow.ID == dogShowId && r.BreedGroup.ID == breedGroupId && r.BreedGroupChallenge.ID == challengeId
                                   select r;

                if (existingData.Count() == 0)
                {
                    List<string> placings = new List<string>();
                    placings.Add("1st");
                    placings.Add("2nd");
                    placings.Add("3rd");
                    placings.Add("4th");

                    var newEntries = from ds in ctx.DogShows.Where(d => d.ID == dogShowId)
                                     from bg in ctx.BreedGroups.Where(d => d.ID == breedGroupId)
                                     from bgc in ctx.BreedGroupChallenges.Where(d => d.ID == challengeId)
                                     from p in placings
                                     select new
                                     {
                                         DogShow = ds,
                                         BreedGroup = bg,
                                         BreedGroupChallenge = bgc,
                                         Placing = p
                                     };

                    foreach (var newEntry in newEntries)
                    {
                        BreedGroupChallengeResult realEntry = new BreedGroupChallengeResult()
                        {
                            DogShow = newEntry.DogShow,
                            BreedGroup = newEntry.BreedGroup,
                            BreedGroupChallenge = newEntry.BreedGroupChallenge,
                            Placing = newEntry.Placing,
                            EntryNumber = ""
                        };

                        ctx.BreedGroupChallengeResults.Add(realEntry);
                    }
                    ctx.SaveChanges();
                }

                var actualEntries = from r in ctx.BreedGroupChallengeResults
                                    where r.DogShow.ID == dogShowId && r.BreedGroup.ID == breedGroupId && r.BreedGroupChallenge.ID == challengeId
                                    orderby r.Placing
                                    select new T
                                    {
                                        Id = r.ID,
                                        ShowId = r.DogShow.ID,
                                        ShowName = r.DogShow.Name,
                                        Challenge = r.BreedGroupChallenge.Name,
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
                    var foundResults = ctx.BreedGroupChallengeResults.Where(i => i.ID == result.Id);
                    if (foundResults.Count() == 1)
                    {
                        BreedGroupChallengeResult foundResult = foundResults.First();
                        foundResult.EntryNumber = result.EntryNumber;
                    }
                }

                ctx.SaveChanges();
            }
        }

    }
}
