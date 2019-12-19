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
        public string RegisteredOwnerSurname { get; set; }
        public string RegisteredOwnerTitle { get; set; }
        public string RegisteredOwnerInitials { get; set; }
        public string RegisteredOwnerAddress { get; set; }
        public string RegisteredOwnerPostalCode { get; set; }
        public string RegisteredOwnerKUSANo { get; set; }
        public string RegisteredOwnerTel { get; set; }
        public string RegisteredOwnerCell { get; set; }
        public string RegisteredOwnerFax { get; set; }
        public string RegisteredOwnerEmail { get; set; }
    }
}
