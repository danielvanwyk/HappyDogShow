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

            PopulateBreedChallengeResultsTableForDogShow(dogShowId);

            using (var ctx = new HappyDogShowContext())
            {
                var rawdata = from r in ctx.BreedChallengeResults
                              where r.DogShow.ID == dogShowId
                              select r;

                if (breedId > 0)
                    rawdata = rawdata.Where(r => r.Breed.ID == breedId);

                var actualEntries = from r in rawdata
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

                foreach (var entry in actualEntries.ToList())
                {
                    var relatedBreedGroupChallenges = from bc in ctx.BreedChallenges.Include("BreedGroupChallenge")
                                                      where bc.Name == entry.Challenge
                                                      select bc.BreedGroupChallenge;

                    var relatedData = relatedBreedGroupChallenges.ToList();

                    if (relatedData.Count == 1)
                    {
                        var challenge = relatedData.First();
                        if (challenge != null)
                            entry.RelatedBreedGroupChallengeName = challenge.Name;
                    }

                    items.Add(entry);
                }
            }

            return items;
        }

        private void PopulateBreedChallengeResultsTableForDogShow(int dogShowId)
        {
            using (var ctx = new HappyDogShowContext())
            {
                var breedsthathaveentries = from e in ctx.BreedEntries
                                            where e.Show.ID == dogShowId
                                            select e.Dog.Breed;

                breedsthathaveentries = breedsthathaveentries.Distinct();

                var whatwemusthaveeventually = from bc in ctx.BreedChallenges
                                               from b in breedsthathaveentries
                                               from s in ctx.DogShows.Where(i => i.ID == dogShowId)
                                               select new
                                               {
                                                   BreedChallenge = bc,
                                                   Breed = b,
                                                   Show = s
                                               };

                var whatwehavenow = from res in ctx.BreedChallengeResults
                                    where res.DogShow.ID == dogShowId
                                    select res;

                var whatwehavewithwhatwemusthave = from i in whatwemusthaveeventually
                                                   join res in whatwehavenow on
                                                   new
                                                   {
                                                       breedid = i.Breed.ID,
                                                       breedchallengeid = i.BreedChallenge.ID,
                                                       dogshowid = i.Show.ID
                                                   } equals
                                                   new
                                                   {
                                                       breedid = res.Breed.ID,
                                                       breedchallengeid = res.BreedChallenge.ID,
                                                       dogshowid = res.DogShow.ID
                                                   }
                                                   into gj
                                                   from joinedresult in gj.DefaultIfEmpty()
                                                   select new
                                                   {
                                                       breedid = i.Breed.ID,
                                                       breed = i.Breed,
                                                       breedchallengeid = i.BreedChallenge.ID,
                                                       breedchallenge = i.BreedChallenge,
                                                       dogshowid = i.Show.ID,
                                                       dogshow = i.Show,
                                                       existingdata = joinedresult
                                                   };

                var yes = whatwehavewithwhatwemusthave.ToList();

                var whatwemustcreate = yes.Where(i => i.existingdata == null);

                foreach (var tocreate in whatwemustcreate)
                {
                    BreedChallengeResult realEntry = new BreedChallengeResult()
                    {
                        DogShow = tocreate.dogshow,
                        Breed = tocreate.breed,
                        BreedChallenge = tocreate.breedchallenge,
                        EntryNumber = ""
                    };

                    ctx.BreedChallengeResults.Add(realEntry);
                }
                ctx.SaveChanges();


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
