using System;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IDogRegistration : IEntityWithID
    {
        string RegisrationNumber { get; set; }
        int GenderId { get; set; }
        string GenderName { get; set; }
        DateTime DateOfBirth { get; set; }
        int BreedId { get; set; }
        string BreedName { get; set; }
        string RegisteredName { get; set; }
        string Qualifications { get; set; }
        string ChipOrTattooNumber { get; set; }
        string Sire { get; set; }
        string Dam { get; set; }
        string BredBy { get; set; }
        string Colour { get; set; }
        string RegisteredOwnerSurname { get; set; }
        string RegisteredOwnerTitle { get; set; }
        string RegisteredOwnerInitials { get; set; }
        string RegisteredOwnerAddress { get; set; }
        string RegisteredOwnerPostalCode { get; set; }
        string RegisteredOwnerKUSANo { get; set; }
        string RegisteredOwnerTel { get; set; }
        string RegisteredOwnerCell { get; set; }
        string RegisteredOwnerFax { get; set; }
        string RegisteredOwnerEmail { get; set; }
    }
}
