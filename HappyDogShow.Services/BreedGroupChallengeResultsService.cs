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
        public Task<List<IBreedGroupChallengeResult>> GetListAsync<T>(int dogShowId, int breedGroupId, int challengeId) where T : IBreedGroupChallengeResult, new()
        {
            Task<List<IBreedGroupChallengeResult>> t = Task<List<IBreedGroupChallengeResult>>.Run(() =>
            {
                List<IBreedGroupChallengeResult> items = GetList<T>(dogShowId, breedGroupId, challengeId);
                //List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        public Task<List<IBreedGroupChallengeResult>> GetListAsync<T>(int dogShowId) where T : IBreedGroupChallengeResult, new()
        {
            Task<List<IBreedGroupChallengeResult>> t = Task<List<IBreedGroupChallengeResult>>.Run(() =>
            {
                List<IBreedGroupChallengeResult> items = GetList<T>(dogShowId, -1, -1);
                //List<IChallengeResult> items = GetTempList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedGroupChallengeResult> GetList<T>(int dogShowId, int breedGroupId, int challengeId) where T : IBreedGroupChallengeResult, new()
        {
            List<IBreedGroupChallengeResult> items = new List<IBreedGroupChallengeResult>();

            PopulateBreedGroupChallengeResultsTableForDogShow(dogShowId);

            using (var ctx = new HappyDogShowContext())
            {
                var rawdata = from r in ctx.BreedGroupChallengeResults
                              where r.DogShow.ID == dogShowId
                              select r;

                if (breedGroupId > 0)
                    rawdata = rawdata.Where(i => i.BreedGroup.ID == breedGroupId);

                if (challengeId > 0)
                    rawdata = rawdata.Where(i => i.BreedGroupChallenge.ID == challengeId);

                var breedGroupJudges = from j in ctx.ShowGroupJudges
                                       where j.DogShow.ID == dogShowId
                                       select j;

                var actualEntries = from r in rawdata
                                    join j in breedGroupJudges on
                                        r.BreedGroup.ID equals j.BreedGroup.ID
                                    orderby r.Placing
                                    select new T
                                    {
                                        Id = r.ID,
                                        ShowId = r.DogShow.ID,
                                        ShowName = r.DogShow.Name,
                                        Challenge = r.BreedGroupChallenge.Name,
                                        EntryNumber = r.EntryNumber,
                                        Placing = r.Placing,
                                        Print = false,
                                        BreedGroupName = r.BreedGroup.Name,
                                        BreedGroupJudgeName = j.Judge.Name,
                                        JudgingOrder = r.BreedGroupChallenge.JudgingOrder
                                    };

                foreach (var entry in actualEntries.ToList())
                {
                    if (entry.EntryNumber != "")
                    {
                        entry.BreedName = ctx.BreedEntries.Include("Dog").Include("Dog.Breed").Where(e => e.Show.ID == dogShowId && e.Number == entry.EntryNumber).First().Dog.Breed.Name;
                    }

                    var relatedInShowChallenges = from bgc in ctx.BreedGroupChallenges.Include("ShowChallenge")
                                                      where bgc.Name == entry.Challenge
                                                      select bgc.ShowChallenge;

                    var relatedData = relatedInShowChallenges.ToList();

                    if (relatedData.Count == 1)
                    {
                        var challenge = relatedData.First();
                        if (challenge != null)
                            entry.RelatedInShowChallengeName = challenge.Name;
                    }

                    items.Add(entry);
                }
            }

            return items;
        }

        private static void PopulateBreedGroupChallengeResultsTableForDogShow(int dogShowId)
        {
            using (var ctx = new HappyDogShowContext())
            {
                List<string> placings = new List<string>();
                placings.Add("1st");
                placings.Add("2nd");
                placings.Add("3rd");
                placings.Add("4th");

                var whatwemusthaveeventually = from bc in ctx.BreedGroupChallenges
                                               from bg in ctx.BreedGroups
                                               from s in ctx.DogShows.Where(i => i.ID == dogShowId)
                                               from p in placings
                                               select new
                                               {
                                                   BreedGroupChallenge = bc,
                                                   BreedGroup = bg,
                                                   Show = s,
                                                   Placing = p
                                               };

                var whatwehavenow = from res in ctx.BreedGroupChallengeResults
                                    where res.DogShow.ID == dogShowId
                                    select res;

                BreedGroupChallengeResult defaultValue = new BreedGroupChallengeResult();

                var whatwehavewithwhatwemusthave = from i in whatwemusthaveeventually
                                                   join res in whatwehavenow on
                                                   new
                                                   {
                                                       breedgroupid = i.BreedGroup.ID,
                                                       breedgroupchallengeid = i.BreedGroupChallenge.ID,
                                                       dogshowid = i.Show.ID,
                                                       placing = i.Placing
                                                   } equals
                                                   new
                                                   {
                                                       breedgroupid = res.BreedGroup.ID,
                                                       breedgroupchallengeid = res.BreedGroupChallenge.ID,
                                                       dogshowid = res.DogShow.ID,
                                                       placing = res.Placing
                                                   }
                                                   into gj
                                                   from joinedresult in gj.DefaultIfEmpty()
                                                   select new
                                                   {
                                                       breedgroupid = i.BreedGroup.ID,
                                                       breedgroup = i.BreedGroup,
                                                       breedgroupchallengeid = i.BreedGroupChallenge.ID,
                                                       breedgroupchallenge = i.BreedGroupChallenge,
                                                       dogshowid = i.Show.ID,
                                                       dogshow = i.Show,
                                                       placing = i.Placing,
                                                       existingdata = joinedresult
                                                   };

                var yes = whatwehavewithwhatwemusthave.ToList();

                var whatwemustcreate = yes.Where(i => i.existingdata == null);

                foreach (var tocreate in whatwemustcreate)
                {
                    BreedGroupChallengeResult realEntry = new BreedGroupChallengeResult()
                    {
                        DogShow = tocreate.dogshow,
                        BreedGroup = tocreate.breedgroup,
                        BreedGroupChallenge = tocreate.breedgroupchallenge,
                        Placing = tocreate.placing,
                        EntryNumber = ""
                    };

                    ctx.BreedGroupChallengeResults.Add(realEntry);
                }
                ctx.SaveChanges();


            }
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
