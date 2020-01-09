using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface ICertficateDetail
    {
        string RegionName { get; set; }
        string ShowName { get; set; }
        string VenueName { get; set; }
        string DateAsString { get; set; }
        string EntryNumber { get; set; }
        string RegistrationNumber { get; set; }
        string BreedName { get; set; }
        string SexName { get; set; }
        string DogName { get; set; }
        string OwnerName { get; set; }
        string JudgeName { get; set; }
        string SecretaryName { get; set; }
    }
}
