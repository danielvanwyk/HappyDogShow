using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedEntryEntityWithAdditionalData : IBreedEntryEntityWithAdditionalData
    {
        public int Id { get; set; }
        public string ShowName { get; set; }
        public int ShowId { get; set; }
        public string BreedGroupName { get; set; }
        public int BreedGroupId { get; set; }
        public string BreedName { get; set; }
        public int BreedId { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public string DogName { get; set; }
        public int DogId { get; set; }
        public string DogRegistrationNumber { get; set; }
        public string EntryNumber { get; set; }
        public IEnumerable<string> EnteredClasses { get; set; }
        public string EnteredClassNames { get; set; }
    }
}
