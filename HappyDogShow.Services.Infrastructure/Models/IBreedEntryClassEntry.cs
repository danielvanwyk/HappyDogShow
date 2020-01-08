using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedEntryClassEntry : IEntityWithID
    {
        string ShowName { get; set; }
        int ShowId { get; set; }
        DateTime ShowDate { get; set; }
        string BreedGroupName { get; set; }
        int BreedGroupId { get; set; }
        string BreedName { get; set; }
        int BreedId { get; set; }
        string GenderName { get; set; }
        int GenderId { get; set; }
        string DogName { get; set; }
        int DogId { get; set; }
        string DogRegistrationNumber { get; set; }
        DateTime DogDOB { get; set; }
        string EntryNumber { get; set; }
        string EnteredClassName { get; set; }
        int EnteredClassMaxAgeInMonths { get; set; }
        int EnteredClassMinAgeInMonths { get; set; }
        string Result { get; set; }

        string ReportGroupingKey { get; }
        string ReportSortingKey { get; }
        int ReportingRank { get; set; }
        int ReportingRankRow { get; }
        int ReportingRankColumn { get; }
        int JudgingOrder { get; set; }
    }
}
