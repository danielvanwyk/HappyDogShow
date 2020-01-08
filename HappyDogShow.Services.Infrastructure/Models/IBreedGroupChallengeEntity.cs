using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedGroupChallengeEntity : IEntityWithID
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
        string ShowChallengeName { get; set; }
        int JudginOrder { get; set; }
        string RelatedBreedChallengeName { get; set; }
    }
}
