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
    public class BreedEntryService : IBreedEntryService
    {
        public Task<int> CreateEntityAsync(IBreedEntryEntity entity)
        {
            Task<int> t = Task<int>.Run(() =>
            {
                int newid = CreateEntity(entity);
                return newid;
            });

            return t;
        }

        private int CreateEntity(IBreedEntryEntity entity)
        {
            int newid = -1;

            using (var ctx = new HappyDogShowContext())
            {
                DogRegistration selectedDog = ctx.DogRegistrations.Where(i => i.ID == entity.Dog.Id).First();
                DogShow selectedShow = ctx.DogShows.Where(i => i.ID == entity.ShowId).First();
                List<BreedClassEntry> enteredClasses = new List<BreedClassEntry>();
                foreach (var i in entity.Classes.Where(j => j.IsSelected))
                {
                    BreedClass breedClass = ctx.BreedClasses.Where(k => k.ID == i.BreedClassID).First();

                    enteredClasses.Add(new BreedClassEntry()
                    {
                        Class = breedClass
                    }); ;
                }

                BreedEntry newEntity = new BreedEntry()
                {
                    Dog = selectedDog,
                    EnteredClasses = enteredClasses,
                    Show = selectedShow
                };

                ctx.BreedEntries.Add(newEntity);
                ctx.SaveChanges();

                newid = newEntity.ID;
            }

            return newid;
        }
    }
}
