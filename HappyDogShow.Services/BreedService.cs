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
    public class BreedService : IBreedService
    {
        public Task<List<IBreedEntity>> GetListAsync<T>() where T : IBreedEntity, new()
        {
            Task<List<IBreedEntity>> t = Task<List<IBreedEntity>>.Run(() =>
            {
                List<IBreedEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedEntity> GetList<T>() where T : IBreedEntity, new()
        {
            List<IBreedEntity> items = new List<IBreedEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.Breeds
                           orderby d.Name ascending
                           select d;

                foreach (Breed d in data)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        Name = d.Name
                    });
                }
            }

            return items;
        }

        public Task<List<IBreedEntity>> GetListForGroupAndShowAsync<T>(int dogShowId, int breedGroupId) where T : IBreedEntity, new()
        {
            Task<List<IBreedEntity>> t = Task<List<IBreedEntity>>.Run(() =>
            {
                List<IBreedEntity> items = GetListForGroupAndShow<T>(dogShowId, breedGroupId);
                return items;
            });

            return t;
        }

        private List<IBreedEntity> GetListForGroupAndShow<T>(int dogShowId, int breedGroupId) where T : IBreedEntity, new()
        {
            List<IBreedEntity> items = new List<IBreedEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var rawdata = from e in ctx.BreedClassEntries
                           where e.Entry.Show.ID == dogShowId
                           && e.Entry.Dog.Breed.BreedGroup.ID == breedGroupId
                           select e.Entry.Dog.Breed;

                var data = rawdata.Distinct();

                foreach (Breed d in data)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        Name = d.Name
                    });
                }
            }

            return items;
        }
    }
}
