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
        string HandlerName { get; set; }
        int HandlerId { get; set; }
        string DogName { get; set; }
        string EntryNumber { get; set; }
        IEnumerable<string> EnteredClasses { get; set; }
        string EnteredClassNames { get; set; }
    }
}
