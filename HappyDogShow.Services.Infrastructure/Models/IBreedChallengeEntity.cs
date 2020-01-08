using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedChallengeEntity : IEntityWithID
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
        string BreedGroupChallengeName { get; set; }
        int JudginOrder { get; set; }
    }
}
