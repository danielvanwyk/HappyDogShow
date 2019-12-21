using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class BreedEntry
    {
        public int ID { get; set; }

        public DogShow Show { get; set; }

        public DogRegistration Dog { get; set; }

        public List<BreedClassEntry> EnteredClasses { get; set; }

        public string Number { get; set; }
    }
}
