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
    public class ClubService : IClubService
    {
        public Task<List<IClubEntity>> GetListAsync<T>() where T : IClubEntity, new()
        {
            Task<List<IClubEntity>> t = Task<List<IClubEntity>>.Run(() =>
            {
                List<IClubEntity> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IClubEntity> GetList<T>() where T : IClubEntity, new()
        {
            List<IClubEntity> items = new List<IClubEntity>();

            using (var ctx = new HappyDogShowContext())
            {
                var clubs = from d in ctx.Clubs
                            select d;

                foreach (Club ds in clubs)
                {
                    items.Add(new T()
                    {
                        Id = ds.ID,
                        Name = ds.Name
                    });
                }
            }

            return items;
        }

    }
}
