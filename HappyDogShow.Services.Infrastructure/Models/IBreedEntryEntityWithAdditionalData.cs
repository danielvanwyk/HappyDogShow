using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedEntryEntityWithAdditionalData : IEntityWithID
    {
        string ShowName { get; set; }
        int ShowId { get; set; }
        string BreedGroupName { get; set; }
        int BreedGroupId { get; set; }
        string BreedName { get; set; }
        int BreedId { get; set; }
        string GenderName { get; set; }
        int GenderId { get; set; }
        string DogName { get; set; }
        int DogId { get; set; }
        string DogRegistrationNumber { get; set; }
        string EntryNumber { get; set; }
        IEnumerable<string> EnteredClasses { get; set; }
        string EnteredClassNames { get; set; }
        string RegisteredOwnerSurname { get; set; }
        string RegisteredOwnerTel { get; set; }
        string RegisteredOwnerEmail { get; set; }
        string RegisteredOwnerInitials { get; set; }
        string RegisteredOwnerTitle { get; set; }
        string BreedGroupJudgeName { get; set; }
        string BreedJudgeName { get; set; }
        string Sire { get; set; }
        string Dam { get; set; }
        string Breeder { get; set; }
        DateTime DOB { get; set; }
        string IDNumber { get; set; }
    }
}
