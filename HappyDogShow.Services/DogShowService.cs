﻿using HappyDogShow.Data;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
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
    }
}
