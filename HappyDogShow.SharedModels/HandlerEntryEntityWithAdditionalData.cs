using HappyDogShow.Services.Infrastructure.Models;
using System.Collections.Generic;

namespace HappyDogShow.SharedModels
{
    public class HandlerEntryEntityWithAdditionalData : IHandlerEntryEntityWithAdditionalData
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
        public string EntryNumber { get; set; }
        public IEnumerable<string> EnteredClasses { get; set; }
        public string EnteredClassName { get; set; }
        public int Id { get; set; }
    }
}
