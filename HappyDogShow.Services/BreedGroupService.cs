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
    public class BreedGroupService : IBreedGroupService
    {
        public Task<List<IBreedGroupEntity>> GetListAsync<T>() where T : IBreedGroupEntity, new()
        {
            Task<List<IBreedGroupEntity>> t = Task<List<IBreedGroupEntity>>.Run(() =>
            {
                List<IBreedGroupEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IBreedGroupEntity> GetList<T>() where T : IBreedGroupEntity, new()
        {
            List<IBreedGroupEntity> items = new List<IBreedGroupEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.BreedGroups
                           orderby d.Name ascending
                           select d;

                foreach (BreedGroup d in data)
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
