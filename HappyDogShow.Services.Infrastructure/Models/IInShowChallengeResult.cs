using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IInShowChallengeResult : IChallengeResult
    {
        string JudgeName { get; set; }
        string BreedName { get; set; }
    }
}
