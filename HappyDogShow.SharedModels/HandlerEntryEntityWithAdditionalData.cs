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
        public string HandlerName { get; set; }
        public int HandlerId { get; set; }
        public string DogName { get; set; }
        public string EntryNumber { get; set; }
        public IEnumerable<string> EnteredClasses { get; set; }
        public string EnteredClassNames { get; set; }
        public int Id { get; set; }
    }
}
