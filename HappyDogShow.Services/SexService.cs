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
    public class SexService : ISexService
    {
        public Task<List<ISexEntity>> GetListAsync<T>() where T : ISexEntity, new()
        {
            Task<List<ISexEntity>> t = Task<List<ISexEntity>>.Run(() =>
            {
                List<ISexEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<ISexEntity> GetList<T>() where T : ISexEntity, new()
        {
            List<ISexEntity> items = new List<ISexEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var data = from d in ctx.Sexes
                           select d;

                foreach (Sex d in data)
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
