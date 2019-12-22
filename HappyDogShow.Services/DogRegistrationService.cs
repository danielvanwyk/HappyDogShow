using HappyDogShow.Data;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class DogRegistrationService : IDogRegistrationService
    {
        public Task<int> CreateEntityAsync(IDogRegistration entity)
        {
            Task<int> t = Task<int>.Run(() =>
            {
                int newid = CreateEntity(entity);
                return newid;
            });

            return t;
        }

        private int CreateEntity(IDogRegistration entity)
        {
            int newid = -1;

            using (var ctx = new HappyDogShowContext())
            {
                Gender entityGender = ctx.Genders.Where(g => g.ID == entity.GenderId).First();
                Breed entityBreed = ctx.Breeds.Where(g => g.ID == entity.BreedId).First();

                DogRegistration newEntity = new DogRegistration()
                {
                    RegisrationNumber = entity.RegisrationNumber,
                    Gender = entityGender,
                    DateOfBirth = entity.DateOfBirth,
                    Breed = entityBreed,
                    RegisteredName = entity.RegisteredName,
                    Qualifications = entity.Qualifications,
                    ChipOrTattooNumber = entity.ChipOrTattooNumber,
                    Sire = entity.Sire,
                    Dam = entity.Dam,
                    BredBy = entity.BredBy,
                    Colour = entity.Colour,
                    RegisteredOwnerSurname = entity.RegisteredOwnerSurname,
                    RegisteredOwnerTitle = entity.RegisteredOwnerTitle,
                    RegisteredOwnerInitials = entity.RegisteredOwnerInitials,
                    RegisteredOwnerAddress = entity.RegisteredOwnerAddress,
                    RegisteredOwnerPostalCode = entity.RegisteredOwnerPostalCode,
                    RegisteredOwnerKUSANo = entity.RegisteredOwnerKUSANo,
                    RegisteredOwnerTel = entity.RegisteredOwnerTel,
                    RegisteredOwnerCell = entity.RegisteredOwnerCell,
                    RegisteredOwnerFax = entity.RegisteredOwnerFax,
                    RegisteredOwnerEmail = entity.RegisteredOwnerEmail
                };

                ctx.DogRegistrations.Add(newEntity);
                ctx.SaveChanges();

                newid = newEntity.ID;
            }

            return newid;
        }

        public Task UpdateEntityAsync(IDogRegistration entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IDogRegistration entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                DogRegistration foundEntity = ctx.DogRegistrations.Where(d => d.ID == entity.Id).First();

                if (foundEntity != null)
                {
                    Gender entityGender = ctx.Genders.Where(g => g.ID == entity.GenderId).First();
                    Breed entityBreed = ctx.Breeds.Where(g => g.ID == entity.BreedId).First();

                    foundEntity.RegisrationNumber = entity.RegisrationNumber;
                    foundEntity.Gender = entityGender;
                    foundEntity.DateOfBirth = entity.DateOfBirth;
                    foundEntity.Breed = entityBreed;
                    foundEntity.RegisteredName = entity.RegisteredName;
                    foundEntity.Qualifications = entity.Qualifications;
                    foundEntity.ChipOrTattooNumber = entity.ChipOrTattooNumber;
                    foundEntity.Sire = entity.Sire;
                    foundEntity.Dam = entity.Dam;
                    foundEntity.BredBy = entity.BredBy;
                    foundEntity.Colour = entity.Colour;
                    foundEntity.RegisteredOwnerSurname = entity.RegisteredOwnerSurname;
                    foundEntity.RegisteredOwnerTitle = entity.RegisteredOwnerTitle;
                    foundEntity.RegisteredOwnerInitials = entity.RegisteredOwnerInitials;
                    foundEntity.RegisteredOwnerAddress = entity.RegisteredOwnerAddress;
                    foundEntity.RegisteredOwnerPostalCode = entity.RegisteredOwnerPostalCode;
                    foundEntity.RegisteredOwnerKUSANo = entity.RegisteredOwnerKUSANo;
                    foundEntity.RegisteredOwnerTel = entity.RegisteredOwnerTel;
                    foundEntity.RegisteredOwnerCell = entity.RegisteredOwnerCell;
                    foundEntity.RegisteredOwnerFax = entity.RegisteredOwnerFax;
                    foundEntity.RegisteredOwnerEmail = entity.RegisteredOwnerEmail;

                    ctx.SaveChanges();
                }
            }
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
                           select new T()
                           {
                               Id = d.ID,
                               RegisrationNumber = d.RegisrationNumber,
                               GenderId = d.Gender.ID,
                               GenderName = d.Gender.Name,
                               DateOfBirth = d.DateOfBirth,
                               BreedId = d.Breed.ID,
                               BreedName = d.Breed.Name,
                               RegisteredName = d.RegisteredName,
                               Qualifications = d.Qualifications,
                               ChipOrTattooNumber = d.ChipOrTattooNumber,
                               Sire = d.Sire,
                               Dam = d.Dam,
                               BredBy = d.BredBy,
                               Colour = d.Colour,
                               RegisteredOwnerSurname = d.RegisteredOwnerSurname,
                               RegisteredOwnerTitle = d.RegisteredOwnerTitle,
                               RegisteredOwnerInitials = d.RegisteredOwnerInitials,
                               RegisteredOwnerAddress = d.RegisteredOwnerAddress,
                               RegisteredOwnerPostalCode = d.RegisteredOwnerPostalCode,
                               RegisteredOwnerKUSANo = d.RegisteredOwnerKUSANo,
                               RegisteredOwnerTel = d.RegisteredOwnerTel,
                               RegisteredOwnerCell = d.RegisteredOwnerCell,
                               RegisteredOwnerFax = d.RegisteredOwnerFax,
                               RegisteredOwnerEmail = d.RegisteredOwnerEmail
                           };

                foreach(var d in dogs)
                {
                    items.Add(d);
                }
            }

            return items;
        }

        public Task<IDogRegistration> GetDogRegistrationAsync<T>(int id) where T : IDogRegistration, new()
        {
            Task<IDogRegistration> t = Task<IDogRegistration>.Run(() =>
            {
                IDogRegistration item = GetItem<T>(id);
                return item;
            });

            return t;
        }

        private IDogRegistration GetItem<T>(int id) where T : IDogRegistration, new()
        {
            IDogRegistration item = null;

            using (var ctx = new HappyDogShowContext())
            {
                var founddog = ctx.DogRegistrations.Where(d => d.ID == id).Include(b => b.Gender).Include(b => b.Breed).First();

                if (founddog != null)
                    item = new T()
                    {
                        Id = founddog.ID,
                        RegisrationNumber = founddog.RegisrationNumber,
                        GenderId = founddog.Gender.ID,
                        GenderName = founddog.Gender.Name,
                        DateOfBirth = founddog.DateOfBirth,
                        BreedId = founddog.Breed.ID,
                        BreedName = founddog.Breed.Name,
                        RegisteredName = founddog.RegisteredName,
                        Qualifications = founddog.Qualifications,
                        ChipOrTattooNumber = founddog.ChipOrTattooNumber,
                        Sire = founddog.Sire,
                        Dam = founddog.Dam,
                        BredBy = founddog.BredBy,
                        Colour = founddog.Colour,
                        RegisteredOwnerSurname = founddog.RegisteredOwnerSurname,
                        RegisteredOwnerTitle = founddog.RegisteredOwnerTitle,
                        RegisteredOwnerInitials = founddog.RegisteredOwnerInitials,
                        RegisteredOwnerAddress = founddog.RegisteredOwnerAddress,
                        RegisteredOwnerPostalCode = founddog.RegisteredOwnerPostalCode,
                        RegisteredOwnerKUSANo = founddog.RegisteredOwnerKUSANo,
                        RegisteredOwnerTel = founddog.RegisteredOwnerTel,
                        RegisteredOwnerCell = founddog.RegisteredOwnerCell,
                        RegisteredOwnerFax = founddog.RegisteredOwnerFax,
                        RegisteredOwnerEmail = founddog.RegisteredOwnerEmail
                    };
            }

            return item;
        }

    }
}
