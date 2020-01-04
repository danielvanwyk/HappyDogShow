using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IHandlerRegistration : IEntityWithID
    {
        int SexId { get; set; }
        string SexName { get; set; }
        DateTime DateOfBirth { get; set; }
        string Surname { get; set; }
        string Title { get; set; }
        string FirstName { get; set; }
        string Address { get; set; }
        string PostalCode { get; set; }
        string Tel { get; set; }
        string Cell { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
    }
}
