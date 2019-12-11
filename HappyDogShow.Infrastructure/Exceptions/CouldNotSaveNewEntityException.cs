using HappyDogShow.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Exceptions
{
    public class CouldNotSaveNewEntityException : Exception
    {
        public ValidatableBindableBase NewEntity;
        public CouldNotSaveNewEntityException(ValidatableBindableBase newEntity)
            : base("Could not save new entity")
        {
            NewEntity = newEntity;
        }
    }
}
