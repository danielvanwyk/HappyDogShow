using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IGlobalContextService
    {
        string RegisteredOwnerSurname { get; set; }
        string RegisteredOwnerTitle { get; set; }
        string RegisteredOwnerInitials { get; set; }
        string RegisteredOwnerAddress { get; set; }
        string RegisteredOwnerPostalCode { get; set; }
        string RegisteredOwnerKUSANo { get; set; }
        string RegisteredOwnerTel { get; set; }
        string RegisteredOwnerCell { get; set; }
        string RegisteredOwnerFax { get; set; }
        string RegisteredOwnerEmail { get; set; }
    }
}
