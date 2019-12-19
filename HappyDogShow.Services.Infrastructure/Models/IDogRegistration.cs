using System;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IDogRegistration : IEntityWithID
    {
        string RegisrationNumber { get; set; }
        string Gender { get; set; }
        DateTime DateOfBirth { get; set; }
        string Breed { get; set; }
        string RegisteredName { get; set; }
        string Qualifications { get; set; }
        string ChipOrTattooNumber { get; set; }
        string Sire { get; set; }
        string Dam { get; set; }
        string BredBy { get; set; }
        string Colour { get; set; }
        string RegisteredOwner { get; set; }
    }
}
