using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class BreedGroupChallengeResult
    {
        public int ID { get; set; }
        public DogShow DogShow { get; set; }
        public BreedGroup BreedGroup { get; set; }
        public BreedGroupChallenge BreedGroupChallenge { get; set; }
        public string EntryNumber { get; set; }
        public string Placing { get; set; }
    }
}
