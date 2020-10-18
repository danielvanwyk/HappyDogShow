using HappyDogShow.Data;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class BreedEntryService : IBreedEntryService
    {
        public Task<int> CreateEntityAsync(IBreedEntryEntity entity)
        {
            Task<int> t = Task<int>.Run(() =>
            {
                int newid = CreateEntity(entity);
                return newid;
            });

            return t;
        }

        private int CreateEntity(IBreedEntryEntity entity)
        {
            int newid = -1;

            using (var ctx = new HappyDogShowContext())
            {
                DogRegistration selectedDog = ctx.DogRegistrations.Where(i => i.ID == entity.Dog.Id).First();
                DogShow selectedShow = ctx.DogShows.Where(i => i.ID == entity.ShowId).First();
                List<BreedClassEntry> enteredClasses = new List<BreedClassEntry>();
                foreach (var i in entity.Classes.Where(j => j.IsSelected))
                {
                    BreedClass breedClass = ctx.BreedClasses.Where(k => k.ID == i.BreedClassID).First();

                    enteredClasses.Add(new BreedClassEntry()
                    {
                        Class = breedClass
                    }); ;
                }

                if (string.IsNullOrEmpty(entity.Number))
                {
                    var usednumbers = ctx.BreedEntries.Where(be => be.Show.ID == entity.ShowId).Select(be => be.Number).ToList().Distinct().ToList();

                    if (usednumbers.Count > 0)
                    {
                        int temp;
                        int max = usednumbers.Select(n => int.TryParse(n, out temp) ? temp : 0).Max();

                        if (max > 0)
                            entity.Number = (max + 1).ToString();
                    }
                    else
                        entity.Number = "";
                }

                BreedEntry newEntity = new BreedEntry()
                {
                    Dog = selectedDog,
                    EnteredClasses = enteredClasses,
                    Show = selectedShow,
                    Number = entity.Number
                };

                ctx.BreedEntries.Add(newEntity);
                ctx.SaveChanges();

                newid = newEntity.ID;
            }

            return newid;
        }

        public Task UpdateEntityAsync(IBreedEntryEntity entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IBreedEntryEntity entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                DogShow selectedShow = ctx.DogShows.Where(i => i.ID == entity.ShowId).First();

                BreedEntry foundEntity = ctx.BreedEntries.Where(d => d.ID == entity.Id).Include(b => b.EnteredClasses).First();

                if (foundEntity != null)
                {
                    if (entity.Classes != null)
                    {
                        foreach (var i in entity.Classes)
                        {
                            // existing class entry
                            if (i.ID > 0)
                            {
                                if (i.IsSelected)
                                {
                                    // nothing to do, keep it
                                }
                                else
                                {
                                    var foundEntries = ctx.BreedClassEntries.Where(ec => ec.ID == i.ID);
                                    if (foundEntries.Count() == 1)
                                    {
                                        ctx.BreedClassEntries.Remove(foundEntries.First());
                                    }
                                }
                            }
                            // potential new class entry
                            else
                            {
                                if (i.IsSelected)
                                {
                                    BreedClass breedClass = ctx.BreedClasses.Where(k => k.ID == i.BreedClassID).First();

                                    foundEntity.EnteredClasses.Add(new BreedClassEntry()
                                    {
                                        Class = breedClass
                                    });
                                }
                                else
                                {
                                    // ignore
                                }
                            }

                        }
                    }

                    foundEntity.Show = selectedShow;
                    foundEntity.Number = entity.Number;

                    ctx.SaveChanges();
                }
            }
        }

        public Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>() where T : IBreedEntryEntityWithAdditionalData, new()
        {
            Task<List<IBreedEntryEntityWithAdditionalData>> t = Task<List<IBreedEntryEntityWithAdditionalData>>.Run(() =>
            {
                List<IBreedEntryEntityWithAdditionalData> items = GetBreedEntryList<T>(-1, -1, null);
                return items;
            });

            return t;
        }

        public Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>(int dogShowId) where T : IBreedEntryEntityWithAdditionalData, new()
        {
            Task<List<IBreedEntryEntityWithAdditionalData>> t = Task<List<IBreedEntryEntityWithAdditionalData>>.Run(() =>
            {
                List<IBreedEntryEntityWithAdditionalData> items = GetBreedEntryList<T>(dogShowId, -1, null);
                return items;
            });

            return t;
        }

        public Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>(int dogShowId, string entryNumber) where T : IBreedEntryEntityWithAdditionalData, new()
        {
            Task<List<IBreedEntryEntityWithAdditionalData>> t = Task<List<IBreedEntryEntityWithAdditionalData>>.Run(() =>
            {
                List<IBreedEntryEntityWithAdditionalData> items = GetBreedEntryList<T>(dogShowId, -1, entryNumber);
                return items;
            });

            return t;
        }

        public Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>(IDogRegistration dogRegistration) where T : IBreedEntryEntityWithAdditionalData, new()
        {
            Task<List<IBreedEntryEntityWithAdditionalData>> t = Task<List<IBreedEntryEntityWithAdditionalData>>.Run(() =>
            {
                if (dogRegistration == null)
                    return new List<IBreedEntryEntityWithAdditionalData>();

                List<IBreedEntryEntityWithAdditionalData> items = GetBreedEntryList<T>(-1, dogRegistration.Id, null);
                return items;
            });

            return t;
        }

        private List<IBreedEntryEntityWithAdditionalData> GetBreedEntryList<T>(int dogShowId, int dogRegistrationId, string entryNumber) where T : IBreedEntryEntityWithAdditionalData, new()
        {
            List<IBreedEntryEntityWithAdditionalData> items = new List<IBreedEntryEntityWithAdditionalData>();

            using (var ctx = new HappyDogShowContext())
            {
                ShowBreedJudge defaultShowBreedJudge = new ShowBreedJudge()
                {
                    Breed = new Breed()
                    {
                        ID = 0
                    },
                    Judge = new Judge()
                    {
                        ID = 0,
                        Name = "n/a"
                    }
                };

                var rawdata = from d in ctx.BreedEntries
                              select d;

                if (dogShowId > 0)
                    rawdata = rawdata.Where(d => d.Show.ID == dogShowId);

                if (dogRegistrationId > 0)
                    rawdata = rawdata.Where(d => d.Dog.ID == dogRegistrationId);

                if (!string.IsNullOrEmpty(entryNumber))
                    rawdata = rawdata.Where(d => d.Number == entryNumber);

                var data = from d in rawdata
                           orderby 
                                d.Show.Name, 
                                d.Dog.Breed.BreedGroup.Name, 
                                d.Dog.Breed.Name, 
                                d.Dog.RegisteredOwnerSurname, 
                                d.Dog.RegisteredOwnerTitle,
                                d.Dog.RegisteredOwnerInitials,
                                d.Dog.Gender.Name descending, 
                                d.Dog.RegisrationNumber,
                                d.Dog.RegisteredName
                           select new T()
                           {
                               Id = d.ID,
                               ShowName = d.Show.Name,
                               ShowId = d.Show.ID,
                               BreedGroupName = d.Dog.Breed.BreedGroup.Name,
                               BreedGroupId = d.Dog.Breed.BreedGroup.ID,
                               BreedName = d.Dog.Breed.Name,
                               BreedId = d.Dog.Breed.ID,
                               GenderName = d.Dog.Gender.Name,
                               GenderId = d.Dog.Gender.ID,
                               DogName = d.Dog.RegisteredName,
                               DogId = d.Dog.ID,
                               DogRegistrationNumber = d.Dog.RegisrationNumber,
                               EntryNumber = d.Number,
                               EnteredClasses = d.EnteredClasses.Select(i => i.Class.Name),
                               RegisteredOwnerSurname = d.Dog.RegisteredOwnerSurname,
                               RegisteredOwnerInitials = d.Dog.RegisteredOwnerInitials,
                               RegisteredOwnerTitle = d.Dog.RegisteredOwnerTitle,
                               BreedGroupJudgeName = d.Show.ShowGroupJudges.Where(i => i.BreedGroup.ID == d.Dog.Breed.BreedGroup.ID).FirstOrDefault().Judge.Name,
                               BreedJudgeName = d.Show.ShowBreedJudges.Where(i => i.Breed.ID == d.Dog.Breed.ID).FirstOrDefault().Judge.Name,
                               Sire = d.Dog.Sire,
                               Dam = d.Dog.Dam,
                               Breeder = d.Dog.BredBy,
                               DOB = d.Dog.DateOfBirth,
                               IDNumber = d.Dog.ChipOrTattooNumber,
                               RegisteredOwnerEmail = d.Dog.RegisteredOwnerEmail,
                               RegisteredOwnerTel = d.Dog.RegisteredOwnerCell
                           };

                foreach (var item in data)
                {
                    item.EnteredClassNames = string.Join(",", item.EnteredClasses);
                    items.Add(item);
                }
            }

            return items;
        }

        public Task<IBreedEntryEntity> GetBreedEntryAsync<T>(int id)
            where T : IBreedEntryEntity, new()
        {
            Task<IBreedEntryEntity> t = Task<IBreedEntryEntity>.Run(() =>
            {
                IBreedEntryEntity entity = GetEntity<T>(id);
                return entity;
            });

            return t;
        }

        private IBreedEntryEntity GetEntity<T>(int id) where T : IBreedEntryEntity, new()
        {
            IBreedEntryEntity result = new T();

            using (var ctx = new HappyDogShowContext())
            {
                BreedEntry foundEntry = ctx.BreedEntries.Where(i => i.ID == id).Include(b => b.Show).First();
                if (foundEntry != null)
                {
                    result.Id = foundEntry.ID;
                    result.ShowId = foundEntry.Show.ID;
                    result.Dog = null;
                    result.Classes = null;
                    result.Number = foundEntry.Number;
                }
            }

            return result;
        }

        public Task<List<IBreedEntryClassEntry>> GetBreedEntryClassEntryListAsync<T>() where T : IBreedEntryClassEntry, new()
        {
            Task<List<IBreedEntryClassEntry>> t = Task<List<IBreedEntryClassEntry>>.Run(() =>
            {
                List<IBreedEntryClassEntry> items = GetBreedEntryClassEntryList<T>(-1, -1);
                return items;
            });

            return t;
        }

        public Task<List<IBreedEntryClassEntry>> GetBreedEntryClassEntryListAsync<T>(int dogShowId, int breedId) where T : IBreedEntryClassEntry, new()
        {
            Task<List<IBreedEntryClassEntry>> t = Task<List<IBreedEntryClassEntry>>.Run(() =>
            {
                List<IBreedEntryClassEntry> items = GetBreedEntryClassEntryList<T>(dogShowId, breedId);
                return items;
            });

            return t;
        }

        private List<IBreedEntryClassEntry> GetBreedEntryClassEntryList<T>(int dogShowId, int breedId) where T : IBreedEntryClassEntry, new()
        {
            List<IBreedEntryClassEntry> items = new List<IBreedEntryClassEntry>();

            using (var ctx = new HappyDogShowContext())
            {
                var rawData = from c in ctx.BreedClassEntries
                              where c.Entry.Show != null
                              select c;

                if (dogShowId > 0)
                {
                    rawData = rawData.Where(c => c.Entry.Show.ID == dogShowId);
                }

                if (breedId > 0)
                {
                    rawData = rawData.Where(c => c.Entry.Dog.Breed.ID == breedId);
                }

                var data = from c in rawData
                           select new T()
                           {
                               Id = c.ID,
                               ShowName = c.Entry.Show.Name,
                               ShowId = c.Entry.Show.ID,
                               ShowDate = c.Entry.Show.ShowDate,
                               BreedGroupName = c.Entry.Dog.Breed.BreedGroup.Name,
                               BreedGroupId = c.Entry.Dog.Breed.BreedGroup.ID,
                               BreedName = c.Entry.Dog.Breed.Name,
                               BreedId = c.Entry.Dog.Breed.ID,
                               GenderName = c.Entry.Dog.Gender.Name,
                               GenderId = c.Entry.Dog.Gender.ID,
                               DogName = c.Entry.Dog.RegisteredName,
                               DogId = c.Entry.Dog.ID,
                               DogRegistrationNumber = c.Entry.Dog.RegisrationNumber,
                               DogDOB = c.Entry.Dog.DateOfBirth,
                               EntryNumber = c.Entry.Number,
                               EnteredClassName = c.Class.Name,
                               EnteredClassMaxAgeInMonths = c.Class.MaxAgeInMonths,
                               EnteredClassMinAgeInMonths = c.Class.MinAgeInMonths,
                               Result = c.Result,
                               BreedGroupJudgeName = c.Entry.Show.ShowGroupJudges.Where(i => i.BreedGroup.ID == c.Entry.Dog.Breed.BreedGroup.ID).FirstOrDefault().Judge.Name,
                               BreedJudgeName = c.Entry.Show.ShowBreedJudges.Where(i => i.Breed.ID == c.Entry.Dog.Breed.ID).FirstOrDefault().Judge.Name,
                               JudgingOrder = c.Class.JudgingOrder
                           };

                data.ToList().ForEach(c => items.Add(c));
            }

            return items;
        }

        public Task DeleteEntityAsync(IEntityWithID entity)
        {
            Task t = Task<int>.Run(() =>
            {
                DeleteEntity(entity);
            });

            return t;
        }

        private void DeleteEntity(IEntityWithID entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                BreedEntry foundEntity = ctx.BreedEntries.Where(d => d.ID == entity.Id).Include(b => b.EnteredClasses).First();

                if (foundEntity != null)
                {
                    if (foundEntity.EnteredClasses != null)
                        foundEntity.EnteredClasses.Clear();
                    ctx.BreedEntries.Remove(foundEntity);
                    ctx.SaveChanges();
                }
            }
        }

        public Task UpdateEntityAsync(IMultipleBreedEntryClassEntry entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IMultipleBreedEntryClassEntry entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                foreach (IBreedEntryClassEntry classEntry in entity.BreedClassEntries)
                {
                    BreedClassEntry foundEntry = ctx.BreedClassEntries.Where(i => i.ID == classEntry.Id).First();

                    foundEntry.Result = classEntry.Result;
                }

                ctx.SaveChanges();
            }
        }
    }

}
