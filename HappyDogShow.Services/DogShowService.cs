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
    public class DogShowService : IDogShowService
    {
        public Task<int> CreateEntityAsync(IDogShowEntity entity)
        {
            Task<int> t = Task<int>.Run(() =>
            {
                int newid = CreateEntity(entity);
                return newid;
            });

            return t;
        }

        private int CreateEntity(IDogShowEntity entity)
        {
            int newid = -1;

            using (var ctx = new HappyDogShowContext())
            {
                DogShow newEntity = new DogShow()
                {
                    ID = entity.Id,
                    Name = entity.DogShowName,
                    ShowDate = entity.ShowDate
                };

                ctx.DogShows.Add(newEntity);
                ctx.SaveChanges();

                newid = newEntity.ID;
            }

            return newid;
        }

        public Task UpdateEntityAsync(IDogShowEntity entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IDogShowEntity entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                DogShow foundEntity = ctx.DogShows.Where(d => d.ID == entity.Id).First();

                if (foundEntity != null)
                {
                    foundEntity.Name = entity.DogShowName;
                    foundEntity.ShowDate = entity.ShowDate;

                    ctx.SaveChanges();
                }
            }
        }

        public Task<List<IDogShowEntity>> GetDogShowListAsync<T>()
            where T : IDogShowEntity, new()
        {
            Task<List<IDogShowEntity>> t = Task<List<IDogShowEntity>>.Run(() =>
            {
                List<IDogShowEntity> items = GetDogShowList<T>();
                return items;
            });

            return t;
        }

        private List<IDogShowEntity> GetDogShowList<T>() where T : IDogShowEntity, new()
        {
            List<IDogShowEntity> items = new List<IDogShowEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var shows = from d in ctx.DogShows
                            select d;

                foreach (DogShow ds in shows)
                {
                    items.Add(new T()
                    {
                        Id = ds.ID,
                        DogShowName = ds.Name,
                        ShowDate = ds.ShowDate
                    });
                }
            }

            return items;
        }

        public Task<List<IBreedClassEntryEntityWithClassDetailForSelection>> GetListOfClassEntriesForNewBreedEntryAsync<T>() where T : IBreedClassEntryEntityWithClassDetailForSelection, new()
        {
            Task<List<IBreedClassEntryEntityWithClassDetailForSelection>> t = Task<List<IBreedClassEntryEntityWithClassDetailForSelection>>.Run(() =>
            {
                List<IBreedClassEntryEntityWithClassDetailForSelection> items = GetListOfClassEntriesForNewBreedEntry<T>();
                return items;
            });

            return t;
        }

        private List<IBreedClassEntryEntityWithClassDetailForSelection> GetListOfClassEntriesForNewBreedEntry<T>() where T : IBreedClassEntryEntityWithClassDetailForSelection, new()
        {
            List<IBreedClassEntryEntityWithClassDetailForSelection> items = new List<IBreedClassEntryEntityWithClassDetailForSelection>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.BreedClasses
                            select d;

                foreach (BreedClass i in data)
                {
                    items.Add(new T()
                    {
                        BreedClassID = i.ID,
                        BreedClassName = i.Name,
                        BreedClassDescription = i.Description,
                        MinAgeInMonths = i.MinAgeInMonths,
                        MaxAgeInMonths = i.MaxAgeInMonths
                    });
                }
            }

            return items;
        }

        public Task<List<IBreedClassEntryEntityWithClassDetailForSelection>> GetListOfClassEntriesForBreedEntryAsync<T>(int id) where T : IBreedClassEntryEntityWithClassDetailForSelection, new()
        {
            Task<List<IBreedClassEntryEntityWithClassDetailForSelection>> t = Task<List<IBreedClassEntryEntityWithClassDetailForSelection>>.Run(() =>
            {
                List<IBreedClassEntryEntityWithClassDetailForSelection> items = GetListOfClassEntriesForBreedEntry<T>(id);
                return items;
            });

            return t;
        }

        private List<IBreedClassEntryEntityWithClassDetailForSelection> GetListOfClassEntriesForBreedEntry<T>(int id) where T : IBreedClassEntryEntityWithClassDetailForSelection, new()
        {
            List<IBreedClassEntryEntityWithClassDetailForSelection> items = new List<IBreedClassEntryEntityWithClassDetailForSelection>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.BreedClasses
                           select d;

                List<BreedClassEntry> enteredClasses = ctx.BreedClassEntries.Where(i => i.Entry.ID == id).Include(b => b.Class).ToList();

                foreach (BreedClass i in data)
                {
                    T itemToAdd = new T()
                    {
                        BreedClassID = i.ID,
                        BreedClassName = i.Name,
                        BreedClassDescription = i.Description,
                        MinAgeInMonths = i.MinAgeInMonths,
                        MaxAgeInMonths = i.MaxAgeInMonths
                    };

                    List<BreedClassEntry> classEntries = enteredClasses.Where(c => c.Class.ID == itemToAdd.BreedClassID).ToList();
                    if (classEntries.Count == 1)
                    {
                        BreedClassEntry classEntry = classEntries.First();

                        itemToAdd.ID = classEntry.ID;
                        itemToAdd.IsSelected = true;
                    }

                    items.Add(itemToAdd);
                }
            }

            return items;
        }
    }
}
