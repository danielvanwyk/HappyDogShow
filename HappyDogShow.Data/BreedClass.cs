using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class BreedClass
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MinAgeInMonths { get; set; }

        public int MaxAgeInMonths { get; set; }
    }
}
