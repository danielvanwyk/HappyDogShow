using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Exceptions
{
    class CouldNotDeleteExistingEntityException : Exception
    {
        public IEntityWithID Entity;
        public CouldNotDeleteExistingEntityException(IEntityWithID entity)
            : base("Could not delete existing entity")
        {
            Entity = entity;
        }
    }
}
