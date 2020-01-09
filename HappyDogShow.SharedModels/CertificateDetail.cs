using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class CertificateDetail : ICertficateDetail
    {
        public string RegionName { get; set; }
        public string ShowName { get; set; }
        public string VenueName { get; set; }
        public string DateAsString { get; set; }
        public string EntryNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string BreedName { get; set; }
        public string SexName { get; set; }
        public string DogName { get; set; }
        public string OwnerName { get; set; }
        public string JudgeName { get; set; }
        public string SecretaryName { get; set; }
    }
}
