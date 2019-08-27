using System;
using System.Collections.Generic;
using System.Text;

namespace HappyDogShow.Data
{
    public class DogRegistration
    {
        public int ID { get; set; }
        public string RegisrationNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Breed Breed { get; set; }
        public string RegisteredName { get; set; }
        public string Qualifications { get; set; }
        public string ChipOrTattooNumber { get; set; }
        public string Sire { get; set; }
        public string Dam { get; set; }
        public string BredBy { get; set; }
        public string Colour { get; set; }
        public Owner RegisteredOwner { get; set; }
    }
}
