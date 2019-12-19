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
    public class DogRegistrationService : IDogRegistrationService
    {
        public Task<int> CreateEntityAsync(IDogRegistration entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(IDogRegistration entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<IDogRegistration>> GetListAsync<T>() where T : IDogRegistration, new()
        {
            Task<List<IDogRegistration>> t = Task<List<IDogRegistration>>.Run(() =>
            {
                List<IDogRegistration> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IDogRegistration> GetList<T>() where T : IDogRegistration, new()
        {
            List<IDogRegistration> items = new List<IDogRegistration>();

            using (var ctx = new HappyDogShowContext())
            {
                var dogs = from d in ctx.DogRegistrations
                            select d;

                foreach (DogRegistration d in dogs)
                {
                    items.Add(new T()
                    {
                        Id = d.ID,
                        RegisrationNumber = d.RegisrationNumber,
                        Gender = "TO DO", //d.Gender,
                        DateOfBirth = d.DateOfBirth,
                        Breed = "TO DO", //d.Breed,
                        RegisteredName = d.RegisteredName,
                        Qualifications = d.Qualifications,
                        ChipOrTattooNumber = d.ChipOrTattooNumber,
                        Sire = d.Sire,
                        Dam = d.Dam,
                        BredBy = d.BredBy,
                        Colour = d.Colour,
                        RegisteredOwner = "TO DO" //d.RegisteredOwner
                    });
                }
            }

            return items;
        }

    }
}
