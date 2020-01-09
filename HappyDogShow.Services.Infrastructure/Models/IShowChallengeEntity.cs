using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IShowChallengeEntity : IEntityWithID
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
        int JudginOrder { get; set; }
        string RelatedBreedGroupChallengeName { get; set; }
        string ChallengeJudgeName { get; set; }
        int ChallengeId { get; set; }
    }
}
