using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedChallengeEntity : IBreedChallengeEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string BreedGroupChallengeName { get; set; }
        public int JudginOrder { get; set; }
        public int Id { get; set; }
    }
}
