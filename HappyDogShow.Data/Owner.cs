using System;
using System.Collections.Generic;
using System.Text;

namespace HappyDogShow.Data
{
    public class Owner
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public Title Title { get; set; }
        public string Initials { get; set; }
        public string KUSARegistrationNumber { get; set; }
        public Address Address { get; set; }
    }
}
