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

    }
}
