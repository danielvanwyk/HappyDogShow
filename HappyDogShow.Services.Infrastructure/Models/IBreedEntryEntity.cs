using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IBreedEntryEntity : IEntityWithID
    {
        int ShowId { get; set; }
        List<IBreedClassEntryEntityWithClassDetailForSelection> Classes { get; set; }
        IDogRegistration Dog { get; set; }
        IDogShowEntity DogShow { get; set; }
        string Number { get; set; }
    }
}
