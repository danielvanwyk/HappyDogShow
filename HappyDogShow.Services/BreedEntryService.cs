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

                BreedEntry newEntity = new BreedEntry()
                {
                    Dog = selectedDog,
                    EnteredClasses = enteredClasses,
                    Show = selectedShow
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

                    foundEntity.Show = selectedShow;

                    ctx.SaveChanges();
                }
            }
        }

        public Task<List<IBreedEntryEntityWithAdditionalData>> GetBreedEntryListAsync<T>() where T : IBreedEntryEntityWithAdditionalData, new()
        {
            Task<List<IBreedEntryEntityWithAdditionalData>> t = Task<List<IBreedEntryEntityWithAdditionalData>>.Run(() =>
            {
                List<IBreedEntryEntityWithAdditionalData> items = GetBreedEntryList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedEntryEntityWithAdditionalData> GetBreedEntryList<T>() where T : IBreedEntryEntityWithAdditionalData, new()
        {
            List<IBreedEntryEntityWithAdditionalData> items = new List<IBreedEntryEntityWithAdditionalData>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.BreedEntries
                           orderby d.Show.Name, d.Dog.Breed.BreedGroup.Name, d.Dog.Breed.Name, d.Dog.Gender.Name, d.Dog.RegisteredName
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
                               EnteredClasses = d.EnteredClasses.Select(i => i.Class.Name)
                           };

                foreach (var item in data)
                {
                    item.EnteredClassNames = string.Join(",", item.EnteredClasses);
                    items.Add(item);
                }

                //foreach (DogShow ds in shows)
                //{
                //    items.Add(new T()
                //    {
                //        Id = ds.ID,
                //        DogShowName = ds.Name,
                //        ShowDate = ds.ShowDate
                //    });
                //}
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
                }
            }

            return result;
        }

        public Task<List<IBreedEntryClassEntry>> GetBreedEntryClassEntryListAsync<T>() where T : IBreedEntryClassEntry, new()
        {
            Task<List<IBreedEntryClassEntry>> t = Task<List<IBreedEntryClassEntry>>.Run(() =>
            {
                List<IBreedEntryClassEntry> items = GetBreedEntryClassEntryList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedEntryClassEntry> GetBreedEntryClassEntryList<T>() where T : IBreedEntryClassEntry, new()
        {
            List<IBreedEntryClassEntry> items = new List<IBreedEntryClassEntry>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from c in ctx.BreedClassEntries
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
    }

}
