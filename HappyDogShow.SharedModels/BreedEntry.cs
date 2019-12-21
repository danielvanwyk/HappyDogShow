using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedEntry : ValidatableBindableBase, IBreedEntryEntity
    {
        public int Id { get; set; }

        private int showId;
        public int ShowId
        {
            get { return showId; }
            set { SetProperty(ref showId, value); }
        }

        private List<IBreedClassEntryEntityWithClassDetailForSelection> classes;
        public List<IBreedClassEntryEntityWithClassDetailForSelection> Classes
        {
            get { return classes; }
            set { SetProperty(ref classes, value); }
        }

        private IDogRegistration dog;
        public IDogRegistration Dog
        {
            get { return dog; }
            set { SetProperty(ref dog, value); }
        }
    }
}
