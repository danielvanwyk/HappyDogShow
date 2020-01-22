using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedChallengeResult : IChallengeResult
    {
        string BreedName { get; set; }
        string BreedGroupName { get; set; }
    }
}
