using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IHandlerEntryEntityWithAdditionalData : IEntityWithID
    {
        string ShowName { get; set; }
        int ShowId { get; set; }
        string SexName { get; set; }
        int SexId { get; set; }
        string HandlerSurname { get; set; }
        string HandlerFirstName { get; set; }
        string HandlerDisplayName { get; }
        int HandlerId { get; set; }
        int DogId { get; set; }
        string DogName { get; set; }
        string DogRegistrationNumber { get; set; }
        string EntryNumber { get; set; }
        string EnteredClassName { get; set; }
        string DogBreed { get; set; }
        DateTime DOB { get; set; }
        string Email { get; set; }
        string Tel { get; set; }
    }
}
