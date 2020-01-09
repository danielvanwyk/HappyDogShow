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
    public class HandlerClassService : IHandlerClassService
    {
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
