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
    public class HandlerRegistrationService : IHandlerRegistrationService
    {
        public Task<int> CreateEntityAsync(IHandlerRegistration entity)
        {
            Task<int> t = Task<int>.Run(() =>
            {
                int newid = CreateEntity(entity);
                return newid;
            });

            return t;
        }

        private int CreateEntity(IHandlerRegistration entity)
        {
            int newid = -1;

            using (var ctx = new HappyDogShowContext())
            {
                Sex entitySex = ctx.Sexes.Where(g => g.ID == entity.SexId).First();

                HandlerRegistration newEntity = new HandlerRegistration()
                {
                    Sex = entitySex,
                    DateOfBirth = entity.DateOfBirth,
                    Surname = entity.Surname,
                    Title = entity.Title,
                    FirstName = entity.FirstName,
                    Address = entity.Address,
                    PostalCode = entity.PostalCode,
                    Tel = entity.Tel,
                    Cell = entity.Cell,
                    Fax = entity.Fax,
                    Email = entity.Email
                };

                ctx.HandlerRegistrations.Add(newEntity);
                ctx.SaveChanges();

                newid = newEntity.ID;
            }

            return newid;
        }

        public Task UpdateEntityAsync(IHandlerRegistration entity)
        {
            Task t = Task<int>.Run(() =>
            {
                UpdateEntity(entity);
            });

            return t;
        }

        private void UpdateEntity(IHandlerRegistration entity)
        {
            using (var ctx = new HappyDogShowContext())
            {
                HandlerRegistration foundEntity = ctx.HandlerRegistrations.Where(d => d.ID == entity.Id).First();

                if (foundEntity != null)
                {
                    Sex entitySex = ctx.Sexes.Where(g => g.ID == entity.SexId).First();

                    foundEntity.Sex = entitySex;
                    foundEntity.DateOfBirth = entity.DateOfBirth;
                    foundEntity.Surname = entity.Surname;
                    foundEntity.Title = entity.Title;
                    foundEntity.FirstName = entity.FirstName;
                    foundEntity.Address = entity.Address;
                    foundEntity.PostalCode = entity.PostalCode;
                    foundEntity.Tel = entity.Tel;
                    foundEntity.Cell = entity.Cell;
                    foundEntity.Fax = entity.Fax;
                    foundEntity.Email = entity.Email;

                    ctx.SaveChanges();
                }
            }
        }

        public Task<List<IHandlerRegistration>> GetListAsync<T>() where T : IHandlerRegistration, new()
        {
            Task<List<IHandlerRegistration>> t = Task<List<IHandlerRegistration>>.Run(() =>
            {
                List<IHandlerRegistration> items = GetList<T>();
                return items;
            });

            return t;
        }

        private List<IHandlerRegistration> GetList<T>() where T : IHandlerRegistration, new()
        {
            List<IHandlerRegistration> items = new List<IHandlerRegistration>();

            using (var ctx = new HappyDogShowContext())
            {
                var Handlers = from d in ctx.HandlerRegistrations
                           select new T()
                           {
                               Id = d.ID,
                               SexId = d.Sex.ID,
                               SexName = d.Sex.Name,
                               DateOfBirth = d.DateOfBirth,
                               Surname = d.Surname,
                               Title = d.Title,
                               FirstName = d.FirstName,
                               Address = d.Address,
                               PostalCode = d.PostalCode,
                               Tel = d.Tel,
                               Cell = d.Cell,
                               Fax = d.Fax,
                               Email = d.Email
                           };

                foreach (var d in Handlers)
                {
                    items.Add(d);
                }
            }

            return items;
        }

        public Task<IHandlerRegistration> GetHandlerRegistrationAsync<T>(int id) where T : IHandlerRegistration, new()
        {
            Task<IHandlerRegistration> t = Task<IHandlerRegistration>.Run(() =>
            {
                IHandlerRegistration item = GetItem<T>(id);
                return item;
            });

            return t;
        }

        private IHandlerRegistration GetItem<T>(int id) where T : IHandlerRegistration, new()
        {
            throw new NotImplementedException();
/*
            IHandlerRegistration item = null;

            using (var ctx = new HappyHandlerShowContext())
            {
                var foundHandler = ctx.HandlerRegistrations.Where(d => d.ID == id).Include(b => b.Gender).Include(b => b.Breed).First();

                if (foundHandler != null)
                    item = new T()
                    {
                        Id = foundHandler.ID,
                        RegisrationNumber = foundHandler.RegisrationNumber,
                        GenderId = foundHandler.Gender.ID,
                        GenderName = foundHandler.Gender.Name,
                        DateOfBirth = foundHandler.DateOfBirth,
                        BreedId = foundHandler.Breed.ID,
                        BreedName = foundHandler.Breed.Name,
                        RegisteredName = foundHandler.RegisteredName,
                        Qualifications = foundHandler.Qualifications,
                        ChipOrTattooNumber = foundHandler.ChipOrTattooNumber,
                        Sire = foundHandler.Sire,
                        Dam = foundHandler.Dam,
                        BredBy = foundHandler.BredBy,
                        Colour = foundHandler.Colour,
                        RegisteredOwnerSurname = foundHandler.RegisteredOwnerSurname,
                        RegisteredOwnerTitle = foundHandler.RegisteredOwnerTitle,
                        RegisteredOwnerInitials = foundHandler.RegisteredOwnerInitials,
                        RegisteredOwnerAddress = foundHandler.RegisteredOwnerAddress,
                        RegisteredOwnerPostalCode = foundHandler.RegisteredOwnerPostalCode,
                        RegisteredOwnerKUSANo = foundHandler.RegisteredOwnerKUSANo,
                        RegisteredOwnerTel = foundHandler.RegisteredOwnerTel,
                        RegisteredOwnerCell = foundHandler.RegisteredOwnerCell,
                        RegisteredOwnerFax = foundHandler.RegisteredOwnerFax,
                        RegisteredOwnerEmail = foundHandler.RegisteredOwnerEmail
                    };
            }

            return item;
            */
        }

    }
}
