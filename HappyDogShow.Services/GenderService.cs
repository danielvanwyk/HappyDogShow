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
    public class GenderService : IGenderService
    {
        public Task<List<IGenderEntity>> GetListAsync<T>() where T : IGenderEntity, new()
        {
            Task<List<IGenderEntity>> t = Task<List<IGenderEntity>>.Run(() =>
            {
                List<IGenderEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IGenderEntity> GetList<T>() where T : IGenderEntity, new()
        {
            List<IGenderEntity> items = new List<IGenderEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.Genders
                            select d;

                foreach (Gender d in data)
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
