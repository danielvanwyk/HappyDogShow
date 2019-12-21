using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedClassEntryEntityWithClassDetail
    {
        int ID { get; set; }
        int BreedClassID { get; set; }
        string BreedClassName { get; set; }
        string BreedClassDescription { get; set; }
        int MinAgeInMonths { get; set; }
        int MaxAgeInMonths { get; set; }
    }
}
