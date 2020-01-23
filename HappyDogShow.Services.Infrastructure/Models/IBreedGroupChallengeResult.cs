using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedGroupChallengeResult : IChallengeResult
    {
        string BreedGroupName { get; set; }
        string BreedGroupJudgeName { get; set; }
        string BreedName { get; set; }
        string RelatedInShowChallengeName { get; set; }
    }
}
