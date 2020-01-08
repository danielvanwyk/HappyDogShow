using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class BreedChallenge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int JudgingOrder { get; set; }
        public BreedGroupChallenge BreedGroupChallenge { get; set; }
    }
}
