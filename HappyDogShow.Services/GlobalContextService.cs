using HappyDogShow.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class GlobalContextService : IGlobalContextService
    {
        public string RegisteredOwnerSurname { get; set; }
        public string RegisteredOwnerTitle { get; set; }
        public string RegisteredOwnerInitials { get; set; }
        public string RegisteredOwnerAddress { get; set; }
        public string RegisteredOwnerPostalCode { get; set; }
        public string RegisteredOwnerKUSANo { get; set; }
        public string RegisteredOwnerTel { get; set; }
        public string RegisteredOwnerCell { get; set; }
        public string RegisteredOwnerFax { get; set; }
        public string RegisteredOwnerEmail { get; set; }
    }
}
