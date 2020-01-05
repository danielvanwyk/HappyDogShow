using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IHandlerEntryClassEntry : IEntityWithID
    {
        string ShowName { get; set; }
        int ShowId { get; set; }
        DateTime ShowDate { get; set; }
        string SexName { get; set; }
        int SexId { get; set; }
        string HandlerName { get; set; }
        int HandlerId { get; set; }
        string DogName { get; set; }
        DateTime HadlerDOB { get; set; }
        string EntryNumber { get; set; }
        string EnteredClassName { get; set; }
        int EnteredClassMaxAgeInYears { get; set; }
        int EnteredClassMinAgeInYears { get; set; }
    }
}
