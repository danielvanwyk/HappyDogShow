using HappyDogShow.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Exceptions
{
    public class CouldNotSaveExistingEntityException : Exception
    {
        public ValidatableBindableBase NewEntity;
        public CouldNotSaveExistingEntityException(ValidatableBindableBase newEntity)
            : base("Could not save existing entity")
        {
            NewEntity = newEntity;
        }
    }
}
