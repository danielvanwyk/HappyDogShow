using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;

namespace HappyDogShow.SharedModels
{
    public class HandlerEntryEntityWithAdditionalData : ValidatableBindableBase, IHandlerEntryEntityWithAdditionalData
    {
        public string ShowName { get; set; }
        public int ShowId { get; set; }
        public string SexName { get; set; }
        public int SexId { get; set; }
        public string HandlerSurname { get; set; }
        public string HandlerFirstName { get; set; }
        public string HandlerDisplayName 
        { 
            get { return string.Format("{0}, {1}", HandlerSurname, HandlerFirstName); }
        }
        public int HandlerId { get; set; }
        public int DogId { get; set; }
        public string DogName { get; set; }
        public string DogRegistrationNumber { get; set; }
        private string entryNumber;
        public string EntryNumber
        {
            get 
            {
                if (entryNumber == null)
                    return "";
                else
                    return entryNumber; 
            }
            set 
            { 
                if (value == null)
                    SetProperty(ref entryNumber, ""); 
                else
                    SetProperty(ref entryNumber, value);
            }
        }
        public string EnteredClassName { get; set; }
        public int Id { get; set; }
    }
}
