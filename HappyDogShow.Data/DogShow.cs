using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class DogShow
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ShowDate { get; set; }
        public List<ShowGroupJudge> ShowGroupJudges { get; set; }
        public List<ShowBreedJudge> ShowBreedJudges { get; set; }
    }
}
