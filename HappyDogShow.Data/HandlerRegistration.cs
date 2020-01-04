using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class HandlerRegistration
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Tel { get; set; }
        public string Cell { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
