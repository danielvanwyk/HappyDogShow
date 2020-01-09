using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class BreedChallengeResult
    {
        public int ID { get; set; }
        public DogShow DogShow { get; set; }
        public Breed Breed { get; set; }
        public BreedChallenge BreedChallenge { get; set; }
        public string EntryNumber { get; set; }
        public string Placing { get; set; }
    }
}
