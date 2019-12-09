using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class DisciplineGrade
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Discipline Discipline { get; set; }
    }
}
