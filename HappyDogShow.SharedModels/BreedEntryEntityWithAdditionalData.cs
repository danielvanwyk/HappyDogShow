using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedEntryEntityWithAdditionalData : ValidatableBindableBase, IBreedEntryEntityWithAdditionalData
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
        private string entryNumber;
        public string EntryNumber 
        { 
            get { return entryNumber; }
            set { SetProperty(ref entryNumber, value); }
        }
        public IEnumerable<string> EnteredClasses { get; set; }
        public string EnteredClassNames { get; set; }
        private string registeredOwnerSurname;
        public string RegisteredOwnerSurname 
        { 
            get { return registeredOwnerSurname; }
            set { SetProperty(ref registeredOwnerSurname, value.Trim()); }
        }
        public string RegisteredOwnerTel { get; set; }
        public string RegisteredOwnerEmail { get; set; }

        private string registeredOwnerInitials;
        public string RegisteredOwnerInitials
        {
            get { return registeredOwnerInitials; }
            set
            {
                if (value == null)
                    value = "";
                SetProperty(ref registeredOwnerInitials, value.Trim());
            }
        }
        private string registeredOwnerTitle;
        public string RegisteredOwnerTitle
        {
            get { return registeredOwnerTitle; }
            set 
            {
                if (value == null)
                    value = "";
                SetProperty(ref registeredOwnerTitle, value.Trim()); 
            }
        }
        public string RegisteredOwner
        {
            get { return string.Format("{0}, {1} {2}", registeredOwnerSurname, RegisteredOwnerTitle, RegisteredOwnerInitials); }
        }
        public string BreedGroupJudgeName { get; set; }
        public string BreedJudgeName { get; set; }
        public string ActualJudgeName
        {
            get
            {
                if (string.IsNullOrEmpty(BreedJudgeName))
                    return BreedGroupJudgeName;

                return BreedJudgeName;
            }
        }

        public string Sire { get; set; }
        public string Dam { get; set; }
        public string Breeder { get; set; }
        public DateTime DOB { get; set; }
        public string IDNumber { get; set; }

    }
}
