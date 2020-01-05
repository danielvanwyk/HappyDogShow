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
    public class HandlerEntryService : IHandlerEntryService
    {
        public Task<int> CreateEntityAsync(IHandlerEntryEntity entity)
        {
            Task<int> t = Task<int>.Run(() =>
            {
                int newid = CreateEntity(entity);
                return newid;
            });

            return t;
        }

        private int CreateEntity(IHandlerEntryEntity entity)
        {
            int newid = -1;

            using (var ctx = new HappyDogShowContext())
            {
                DogRegistration selectedDog = ctx.DogRegistrations.Where(i => i.ID == entity.Dog.Id).First();
                DogShow selectedShow = ctx.DogShows.Where(i => i.ID == entity.DogShow.Id).First();
                HandlerClass selectedClass = ctx.HandlerClasses.Where(i => i.ID == entity.Class.Id).First();
                HandlerRegistration selectedHander = ctx.HandlerRegistrations.Where(i => i.ID == entity.Handler.Id).First();

                HandlerEntry newEntity = new HandlerEntry()
                {
                    Dog = selectedDog,
                    Show = selectedShow,
                    EnteredClass = selectedClass,
                    Handler = selectedHander
                };

                ctx.HandlerEntries.Add(newEntity);
                ctx.SaveChanges();

                newid = newEntity.ID;
            }

            return newid;
        }

        public Task UpdateEntityAsync(IHandlerEntryEntity entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IHandlerEntryEntity entity)
        {
            throw new NotImplementedException();
            /*
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
            */
        }

        public Task<List<IHandlerEntryEntityWithAdditionalData>> GetHandlerEntryListAsync<T>() where T : IHandlerEntryEntityWithAdditionalData, new()
        {
            Task<List<IHandlerEntryEntityWithAdditionalData>> t = Task<List<IHandlerEntryEntityWithAdditionalData>>.Run(() =>
            {
                List<IHandlerEntryEntityWithAdditionalData> items = GetHandlerEntryList<T>();
                return items;
            });

            return t;
        }

        private List<IHandlerEntryEntityWithAdditionalData> GetHandlerEntryList<T>() where T : IHandlerEntryEntityWithAdditionalData, new()
        {
            List<IHandlerEntryEntityWithAdditionalData> items = new List<IHandlerEntryEntityWithAdditionalData>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.HandlerEntries
                           orderby d.Show.Name, d.Dog.Breed.BreedGroup.Name, d.Dog.Breed.Name, d.Dog.Gender.Name, d.Dog.RegisteredName
                           select new T()
                           {
                               Id = d.ID,
                               ShowName = d.Show.Name,
                               ShowId = d.Show.ID,
                               SexName = d.Handler.Sex.Name,
                               SexId = d.Handler.Sex.ID,
                               HandlerSurname = d.Handler.Surname,
                               HandlerFirstName = d.Handler.FirstName,
                               DogName = d.Dog.RegisteredName,
                               DogId = d.Dog.ID,
                               DogRegistrationNumber = d.Dog.RegisrationNumber,
                               EntryNumber = d.Number,
                               EnteredClassName = d.EnteredClass.Name
                           };

                foreach (var item in data)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public Task<IHandlerEntryEntity> GetHandlerEntryAsync<T>(int id)
            where T : IHandlerEntryEntity, new()
        {
            Task<IHandlerEntryEntity> t = Task<IHandlerEntryEntity>.Run(() =>
            {
                IHandlerEntryEntity entity = GetEntity<T>(id);
                return entity;
            });

            return t;
        }

        private IHandlerEntryEntity GetEntity<T>(int id) where T : IHandlerEntryEntity, new()
        {
            throw new NotImplementedException();
            /*
            IHandlerEntryEntity result = new T();

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
            */
        }

        public Task<List<IHandlerEntryClassEntry>> GetHandlerEntryClassEntryListAsync<T>() where T : IHandlerEntryClassEntry, new()
        {
            Task<List<IHandlerEntryClassEntry>> t = Task<List<IHandlerEntryClassEntry>>.Run(() =>
            {
                List<IHandlerEntryClassEntry> items = GetHandlerEntryClassEntryList<T>();
                return items;
            });

            return t;
        }

        private List<IHandlerEntryClassEntry> GetHandlerEntryClassEntryList<T>() where T : IHandlerEntryClassEntry, new()
        {
            throw new NotImplementedException();
            /*
            List<IHandlerEntryClassEntry> items = new List<IHandlerEntryClassEntry>();

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
            */
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
                HandlerEntry foundEntity = ctx.HandlerEntries.Where(d => d.ID == entity.Id).First();

                if (foundEntity != null)
                {
                    ctx.HandlerEntries.Remove(foundEntity);
                    ctx.SaveChanges();
                }
            }
        }

        public Task<List<IHandlerClassEntity>> GetHandlerClassListAsync<T>() where T : IHandlerClassEntity, new()
        {
            Task<List<IHandlerClassEntity>> t = Task<List<IHandlerClassEntity>>.Run(() =>
            {
                List<IHandlerClassEntity> items = GetHandlerClassList<T>();
                return items;
            });

            return t;
        }

        private List<IHandlerClassEntity> GetHandlerClassList<T>() where T : IHandlerClassEntity, new()
        {
            List<IHandlerClassEntity> items = new List<IHandlerClassEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.HandlerClasses
                           select new T()
                           {
                               Id = d.ID,
                               Description = d.Description,
                               Name = d.Name
                           };

                foreach (var item in data)
                {
                    items.Add(item);
                }
            }

            return items;
        }
    }

}
