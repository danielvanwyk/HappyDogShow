using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class DogRegistrationDetail : ValidatableBindableBase, IDogRegistration
    {
        public int Id { get; set; }
        public string RegisrationNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Breed { get; set; }
        public string RegisteredName { get; set; }
        public string Qualifications { get; set; }
        public string ChipOrTattooNumber { get; set; }
        public string Sire { get; set; }
        public string Dam { get; set; }
        public string BredBy { get; set; }
        public string Colour { get; set; }
        public string RegisteredOwner { get; set; }
    }
}
