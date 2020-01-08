using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class ShowInShowChallengeJudge
    {
        public int ID { get; set; }
        public DogShow DogShow { get; set; }
        public ShowChallenge ShowChallenge { get; set; }
        public Judge Judge { get; set; }
    }
}
