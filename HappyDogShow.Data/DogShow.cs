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
        public Club ShowClub { get; set; }
        public string Venue { get; set; }
        public string Chairman { get; set; }
        public string ShowManager { get; set; }
        public string Secretary { get; set; }
        public string VetOnCall { get; set; }
        public string KUSARep { get; set; }
        public string SponsoredBy { get; set; }
    }
}
